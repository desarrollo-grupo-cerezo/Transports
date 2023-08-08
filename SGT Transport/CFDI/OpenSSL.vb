Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Permissions
Imports System.Diagnostics
Imports System.ComponentModel

Public Class Win32
    <DllImport("crypt32.dll", SetLastError:=True)>
    Public Shared Function CertCreateSelfSignCertificate(ByVal hProv As IntPtr, ByRef pSubjectIssuerBlob As CERT_NAME_BLOB, ByVal dwFlagsm As UInteger, ByRef pKeyProvInfo As CRYPT_KEY_PROV_INFO, ByVal pSignatureAlgorithm As IntPtr, ByVal pStartTime As IntPtr, ByVal pEndTime As IntPtr, ByVal other As IntPtr) As IntPtr
    End Function
    <DllImport("crypt32.dll", SetLastError:=True)>
    Public Shared Function CertStrToName(ByVal dwCertEncodingType As UInteger, ByVal pszX500 As String, ByVal dwStrType As UInteger, ByVal pvReserved As IntPtr,
        <[In], Out> ByVal pbEncoded As Byte(), ByRef pcbEncoded As UInteger, ByVal other As IntPtr) As Boolean
    End Function
    <DllImport("crypt32.dll", SetLastError:=True)>
    Public Shared Function CertFreeCertificateContext(ByVal hCertStore As IntPtr) As Boolean
    End Function
End Class

<StructLayout(LayoutKind.Sequential)>
Public Structure CRYPT_KEY_PROV_INFO
    <MarshalAs(UnmanagedType.LPWStr)>
    Public pwszContainerName As String
    <MarshalAs(UnmanagedType.LPWStr)>
    Public pwszProvName As String
    Public dwProvType As UInteger
    Public dwFlags As UInteger
    Public cProvParam As UInteger
    Public rgProvParam As IntPtr
    Public dwKeySpec As UInteger
End Structure

<StructLayout(LayoutKind.Sequential)>
Public Structure CERT_NAME_BLOB
    Public cbData As Integer
    Public pbData As IntPtr
End Structure

Public Class Opensslkey
    Const pemprivheader As String = "-----BEGIN RSA PRIVATE KEY-----"
    Const pemprivfooter As String = "-----END RSA PRIVATE KEY-----"
    Const pempubheader As String = "-----BEGIN PUBLIC KEY-----"
    Const pempubfooter As String = "-----END PUBLIC KEY-----"
    Const pemp8header As String = "-----BEGIN PRIVATE KEY-----"
    Const pemp8footer As String = "-----END PRIVATE KEY-----"
    Const pemp8encheader As String = "-----BEGIN ENCRYPTED PRIVATE KEY-----"
    Const pemp8encfooter As String = "-----END ENCRYPTED PRIVATE KEY-----"
    Shared verbose As Boolean = False

    Public Shared Sub ProcessRSA(ByVal rsa As RSACryptoServiceProvider)
        If verbose Then ShowRSAProps(rsa)
        Console.Write(vbLf & vbLf & "Export RSA private key to PKCS #12 file?  (Y or N) ")
        Dim resp As String = Console.ReadLine().ToUpper()
        If resp = "Y" OrElse resp = "YES" Then RSAtoPKCS12(rsa)
    End Sub

    Public Shared Sub RSAtoPKCS12(ByVal rsa As RSACryptoServiceProvider)
        Dim keyInfo As CspKeyContainerInfo = rsa.CspKeyContainerInfo
        Dim keycontainer As String = keyInfo.KeyContainerName
        Dim keyspec As UInteger = CUInt(keyInfo.KeyNumber)
        Dim provider As String = keyInfo.ProviderName
        Dim cspflags As UInteger = 0
        Dim fname As String = keycontainer & ".p12"
        Dim pkcs12 As Byte() = GetPkcs12(rsa, keycontainer, provider, keyspec, cspflags)
        If (pkcs12 IsNot Nothing) AndAlso verbose Then ShowBytes(vbLf & "pkcs #12", pkcs12)

        If pkcs12 IsNot Nothing Then
            PutFileBytes(fname, pkcs12, pkcs12.Length)
            Console.WriteLine(vbLf & "Wrote pkc #12 file '{0}'" & vbLf, fname)
        Else
            Console.WriteLine(vbLf & "Problem getting pkcs#12")
        End If
    End Sub

    Public Shared Function DecodePkcs8PrivateKey(ByVal instr As String) As Byte()
        Const pemp8header As String = "-----BEGIN PRIVATE KEY-----"
        Const pemp8footer As String = "-----END PRIVATE KEY-----"
        Dim pemstr As String = instr.Trim()
        Dim binkey As Byte()
        If Not pemstr.StartsWith(pemp8header) OrElse Not pemstr.EndsWith(pemp8footer) Then Return Nothing
        Dim sb As StringBuilder = New StringBuilder(pemstr)
        sb.Replace(pemp8header, "")
        sb.Replace(pemp8footer, "")
        Dim pubstr As String = sb.ToString().Trim()

        Try
            binkey = Convert.FromBase64String(pubstr)
        Catch __unusedFormatException1__ As System.FormatException
            Return Nothing
        End Try

        Return binkey
    End Function

    Public Shared Function DecodePrivateKeyInfo(ByVal pkcs8 As Byte()) As RSACryptoServiceProvider
        Dim SeqOID As Byte() = {&H30, &HD, &H6, &H9, &H2A, &H86, &H48, &H86, &HF7, &HD, &H1, &H1, &H1, &H5, &H0}
        Dim seq As Byte() = New Byte(14) {}
        Dim mem As MemoryStream = New MemoryStream(pkcs8)
        Dim lenstream As Integer = CInt(mem.Length)
        Dim binr As BinaryReader = New BinaryReader(mem)
        Dim bt As Byte = 0
        Dim twobytes As UShort = 0

        Try
            twobytes = binr.ReadUInt16()

            If twobytes = &H8130 Then
                binr.ReadByte()
            ElseIf twobytes = &H8230 Then
                binr.ReadInt16()
            Else
                Return Nothing
            End If

            bt = binr.ReadByte()
            If bt <> &H2 Then Return Nothing
            twobytes = binr.ReadUInt16()
            If twobytes <> &H1 Then Return Nothing
            seq = binr.ReadBytes(15)
            If Not CompareBytearrays(seq, SeqOID) Then Return Nothing
            bt = binr.ReadByte()
            If bt <> &H4 Then Return Nothing
            bt = binr.ReadByte()

            If bt = &H81 Then
                binr.ReadByte()
            ElseIf bt = &H82 Then
                binr.ReadUInt16()
            End If

            Dim rsaprivkey As Byte() = binr.ReadBytes(CInt((lenstream - mem.Position)))
            Dim rsacsp As RSACryptoServiceProvider = DecodeRSAPrivateKey(rsaprivkey)
            Return rsacsp
        Catch __unusedException1__ As Exception
            Return Nothing
        Finally
            binr.Close()
        End Try
    End Function

    Public Shared Function DecodePkcs8EncPrivateKey(ByVal instr As String) As Byte()
        Const pemp8encheader As String = "-----BEGIN ENCRYPTED PRIVATE KEY-----"
        Const pemp8encfooter As String = "-----END ENCRYPTED PRIVATE KEY-----"
        Dim pemstr As String = instr.Trim()
        Dim binkey As Byte()
        If Not pemstr.StartsWith(pemp8encheader) OrElse Not pemstr.EndsWith(pemp8encfooter) Then Return Nothing
        Dim sb As StringBuilder = New StringBuilder(pemstr)
        sb.Replace(pemp8encheader, "")
        sb.Replace(pemp8encfooter, "")
        Dim pubstr As String = sb.ToString().Trim()

        Try
            binkey = Convert.FromBase64String(pubstr)
        Catch __unusedFormatException1__ As System.FormatException
            Return Nothing
        End Try

        Return binkey
    End Function

    Public Shared Function DecodeEncryptedPrivateKeyInfo(ByVal encpkcs8 As Byte(), ByVal secpswd As SecureString) As RSACryptoServiceProvider
        Dim OIDpkcs5PBES2 As Byte() = {&H6, &H9, &H2A, &H86, &H48, &H86, &HF7, &HD, &H1, &H5, &HD}
        Dim OIDpkcs5PBKDF2 As Byte() = {&H6, &H9, &H2A, &H86, &H48, &H86, &HF7, &HD, &H1, &H5, &HC}
        Dim OIDdesEDE3CBC As Byte() = {&H6, &H8, &H2A, &H86, &H48, &H86, &HF7, &HD, &H3, &H7}
        Dim seqdes As Byte() = New Byte(9) {}
        Dim seq As Byte() = New Byte(10) {}
        Dim salt As Byte()
        Dim IV As Byte()
        Dim encryptedpkcs8 As Byte()
        Dim pkcs8 As Byte()
        Dim saltsize, ivsize, encblobsize As Integer
        Dim iterations As Integer
        Dim mem As MemoryStream = New MemoryStream(encpkcs8)
        Dim lenstream As Integer = CInt(mem.Length)
        Dim binr As BinaryReader = New BinaryReader(mem)
        Dim bt As Byte = 0
        Dim twobytes As UShort = 0

        Try
            twobytes = binr.ReadUInt16()

            If twobytes = &H8130 Then
                binr.ReadByte()
            ElseIf twobytes = &H8230 Then
                binr.ReadInt16()
            Else
                Return Nothing
            End If

            twobytes = binr.ReadUInt16()

            If twobytes = &H8130 Then
                binr.ReadByte()
            ElseIf twobytes = &H8230 Then
                binr.ReadInt16()
            End If

            seq = binr.ReadBytes(11)
            If Not CompareBytearrays(seq, OIDpkcs5PBES2) Then Return Nothing
            twobytes = binr.ReadUInt16()

            If twobytes = &H8130 Then
                binr.ReadByte()
            ElseIf twobytes = &H8230 Then
                binr.ReadInt16()
            End If

            twobytes = binr.ReadUInt16()

            If twobytes = &H8130 Then
                binr.ReadByte()
            ElseIf twobytes = &H8230 Then
                binr.ReadInt16()
            End If

            seq = binr.ReadBytes(11)
            If Not CompareBytearrays(seq, OIDpkcs5PBKDF2) Then Return Nothing
            twobytes = binr.ReadUInt16()

            If twobytes = &H8130 Then
                binr.ReadByte()
            ElseIf twobytes = &H8230 Then
                binr.ReadInt16()
            End If

            bt = binr.ReadByte()
            If bt <> &H4 Then Return Nothing
            saltsize = binr.ReadByte()
            salt = binr.ReadBytes(saltsize)
            If verbose Then ShowBytes("Salt for pbkd", salt)
            bt = binr.ReadByte()
            If bt <> &H2 Then Return Nothing
            Dim itbytes As Integer = binr.ReadByte()

            If itbytes = 1 Then
                iterations = binr.ReadByte()
            ElseIf itbytes = 2 Then
                iterations = 256 * binr.ReadByte() + binr.ReadByte()
            Else
                Return Nothing
            End If

            If verbose Then Console.WriteLine("PBKD2 iterations {0}", iterations)
            twobytes = binr.ReadUInt16()

            If twobytes = &H8130 Then
                binr.ReadByte()
            ElseIf twobytes = &H8230 Then
                binr.ReadInt16()
            End If

            seqdes = binr.ReadBytes(10)
            If Not CompareBytearrays(seqdes, OIDdesEDE3CBC) Then Return Nothing
            bt = binr.ReadByte()
            If bt <> &H4 Then Return Nothing
            ivsize = binr.ReadByte()
            IV = binr.ReadBytes(ivsize)
            If verbose Then ShowBytes("IV for des-EDE3-CBC", IV)
            bt = binr.ReadByte()
            If bt <> &H4 Then Return Nothing
            bt = binr.ReadByte()

            If bt = &H81 Then
                encblobsize = binr.ReadByte()
            ElseIf bt = &H82 Then
                encblobsize = 256 * binr.ReadByte() + binr.ReadByte()
            Else
                encblobsize = bt
            End If

            encryptedpkcs8 = binr.ReadBytes(encblobsize)
            pkcs8 = DecryptPBDK2(encryptedpkcs8, salt, IV, secpswd, iterations)
            If pkcs8 Is Nothing Then Return Nothing
            Dim rsa As RSACryptoServiceProvider = DecodePrivateKeyInfo(pkcs8)
            Return rsa
        Catch __unusedException1__ As Exception
            Return Nothing
        Finally
            binr.Close()
        End Try
    End Function

    Public Shared Function DecryptPBDK2(ByVal edata As Byte(), ByVal salt As Byte(), ByVal IV As Byte(), ByVal secpswd As SecureString, ByVal iterations As Integer) As Byte()
        Dim decrypt As CryptoStream = Nothing
        Dim unmanagedPswd As IntPtr = IntPtr.Zero
        Dim psbytes As Byte() = New Byte(secpswd.Length - 1) {}
        unmanagedPswd = Marshal.SecureStringToGlobalAllocAnsi(secpswd)
        Marshal.Copy(unmanagedPswd, psbytes, 0, psbytes.Length)
        Marshal.ZeroFreeGlobalAllocAnsi(unmanagedPswd)

        Try
            Dim kd As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(psbytes, salt, iterations)
            Dim decAlg As TripleDES = TripleDES.Create()
            decAlg.Key = kd.GetBytes(24)
            decAlg.IV = IV
            Dim memstr As MemoryStream = New MemoryStream()
            decrypt = New CryptoStream(memstr, decAlg.CreateDecryptor(), CryptoStreamMode.Write)
            decrypt.Write(edata, 0, edata.Length)
            decrypt.Flush()
            decrypt.Close()
            Dim cleartext As Byte() = memstr.ToArray()
            Return cleartext
        Catch e As Exception
            Console.WriteLine("Problem decrypting: {0}", e.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function DecodeOpenSSLPublicKey(ByVal instr As String) As Byte()
        Const pempubheader As String = "-----BEGIN PUBLIC KEY-----"
        Const pempubfooter As String = "-----END PUBLIC KEY-----"
        Dim pemstr As String = instr.Trim()
        Dim binkey As Byte()
        If Not pemstr.StartsWith(pempubheader) OrElse Not pemstr.EndsWith(pempubfooter) Then Return Nothing
        Dim sb As StringBuilder = New StringBuilder(pemstr)
        sb.Replace(pempubheader, "")
        sb.Replace(pempubfooter, "")
        Dim pubstr As String = sb.ToString().Trim()

        Try
            binkey = Convert.FromBase64String(pubstr)
        Catch __unusedFormatException1__ As System.FormatException
            Return Nothing
        End Try

        Return binkey
    End Function

    Public Shared Function DecodeX509PublicKey(ByVal x509key As Byte()) As RSACryptoServiceProvider
        Dim SeqOID As Byte() = {&H30, &HD, &H6, &H9, &H2A, &H86, &H48, &H86, &HF7, &HD, &H1, &H1, &H1, &H5, &H0}
        Dim seq As Byte() = New Byte(14) {}
        Dim mem As MemoryStream = New MemoryStream(x509key)
        Dim binr As BinaryReader = New BinaryReader(mem)
        Dim bt As Byte = 0
        Dim twobytes As UShort = 0

        Try
            twobytes = binr.ReadUInt16()

            If twobytes = &H8130 Then
                binr.ReadByte()
            ElseIf twobytes = &H8230 Then
                binr.ReadInt16()
            Else
                Return Nothing
            End If

            seq = binr.ReadBytes(15)
            If Not CompareBytearrays(seq, SeqOID) Then Return Nothing
            twobytes = binr.ReadUInt16()

            If twobytes = &H8103 Then
                binr.ReadByte()
            ElseIf twobytes = &H8203 Then
                binr.ReadInt16()
            Else
                Return Nothing
            End If

            bt = binr.ReadByte()
            If bt <> &H0 Then Return Nothing
            twobytes = binr.ReadUInt16()

            If twobytes = &H8130 Then
                binr.ReadByte()
            ElseIf twobytes = &H8230 Then
                binr.ReadInt16()
            Else
                Return Nothing
            End If

            twobytes = binr.ReadUInt16()
            Dim lowbyte As Byte = &H0
            Dim highbyte As Byte = &H0

            If twobytes = &H8102 Then
                lowbyte = binr.ReadByte()
            ElseIf twobytes = &H8202 Then
                highbyte = binr.ReadByte()
                lowbyte = binr.ReadByte()
            Else
                Return Nothing
            End If

            Dim modint As Byte() = {lowbyte, highbyte, &H0, &H0}
            Dim modsize As Integer = BitConverter.ToInt32(modint, 0)
            Dim firstbyte As Byte = binr.ReadByte()
            binr.BaseStream.Seek(-1, SeekOrigin.Current)

            If firstbyte = &H0 Then
                binr.ReadByte()
                modsize -= 1
            End If

            Dim modulus As Byte() = binr.ReadBytes(modsize)
            If binr.ReadByte() <> &H2 Then Return Nothing
            Dim expbytes As Integer = CInt(binr.ReadByte())
            Dim exponent As Byte() = binr.ReadBytes(expbytes)
            ShowBytes(vbLf & "Exponent", exponent)
            ShowBytes(vbLf & "Modulus", modulus)
            Dim RSA As RSACryptoServiceProvider = New RSACryptoServiceProvider()
            Dim RSAKeyInfo As RSAParameters = New RSAParameters()
            RSAKeyInfo.Modulus = modulus
            RSAKeyInfo.Exponent = exponent
            RSA.ImportParameters(RSAKeyInfo)
            Return RSA
        Catch __unusedException1__ As Exception
            Return Nothing
        Finally
            binr.Close()
        End Try
    End Function

    Public Shared Function DecodeRSAPrivateKey(ByVal privkey As Byte()) As RSACryptoServiceProvider
        Dim MODULUS, E, D, P, Q, DP, DQ, IQ As Byte()
        Dim mem As MemoryStream = New MemoryStream(privkey)
        Dim binr As BinaryReader = New BinaryReader(mem)
        Dim bt As Byte = 0
        Dim twobytes As UShort = 0
        Dim elems As Integer = 0

        Try
            twobytes = binr.ReadUInt16()

            If twobytes = &H8130 Then
                binr.ReadByte()
            ElseIf twobytes = &H8230 Then
                binr.ReadInt16()
            Else
                Return Nothing
            End If

            twobytes = binr.ReadUInt16()
            If twobytes <> &H102 Then Return Nothing
            bt = binr.ReadByte()
            If bt <> &H0 Then Return Nothing
            elems = GetIntegerSize(binr)
            MODULUS = binr.ReadBytes(elems)
            elems = GetIntegerSize(binr)
            E = binr.ReadBytes(elems)
            elems = GetIntegerSize(binr)
            D = binr.ReadBytes(elems)
            elems = GetIntegerSize(binr)
            P = binr.ReadBytes(elems)
            elems = GetIntegerSize(binr)
            Q = binr.ReadBytes(elems)
            elems = GetIntegerSize(binr)
            DP = binr.ReadBytes(elems)
            elems = GetIntegerSize(binr)
            DQ = binr.ReadBytes(elems)
            elems = GetIntegerSize(binr)
            IQ = binr.ReadBytes(elems)
            Console.WriteLine("showing components ..")

            If verbose Then
                ShowBytes(vbLf & "Modulus", MODULUS)
                ShowBytes(vbLf & "Exponent", E)
                ShowBytes(vbLf & "D", D)
                ShowBytes(vbLf & "P", P)
                ShowBytes(vbLf & "Q", Q)
                ShowBytes(vbLf & "DP", DP)
                ShowBytes(vbLf & "DQ", DQ)
                ShowBytes(vbLf & "IQ", IQ)
            End If

            Dim RSA As RSACryptoServiceProvider = New RSACryptoServiceProvider()
            Dim RSAparams As RSAParameters = New RSAParameters()
            RSAparams.Modulus = MODULUS
            RSAparams.Exponent = E
            RSAparams.D = D
            RSAparams.P = P
            RSAparams.Q = Q
            RSAparams.DP = DP
            RSAparams.DQ = DQ
            RSAparams.InverseQ = IQ
            RSA.ImportParameters(RSAparams)
            Return RSA
        Catch ex As Exception
            Return Nothing
        Finally
            binr.Close()
        End Try
    End Function

    Private Shared Function GetIntegerSize(ByVal binr As BinaryReader) As Integer
        Dim bt As Byte = 0
        Dim lowbyte As Byte = &H0
        Dim highbyte As Byte = &H0
        Dim count As Integer = 0
        bt = binr.ReadByte()
        If bt <> &H2 Then Return 0
        bt = binr.ReadByte()

        If bt = &H81 Then
            count = binr.ReadByte()
        ElseIf bt = &H82 Then
            highbyte = binr.ReadByte()
            lowbyte = binr.ReadByte()
            Dim modint As Byte() = {lowbyte, highbyte, &H0, &H0}
            count = BitConverter.ToInt32(modint, 0)
        Else
            count = bt
        End If

        While binr.ReadByte() = &H0
            count -= 1
        End While

        binr.BaseStream.Seek(-1, SeekOrigin.Current)
        Return count
    End Function

    Public Shared Function DecodeOpenSSLPrivateKey(ByVal instr As String) As Byte()
        Const pemprivheader As String = "-----BEGIN RSA PRIVATE KEY-----"
        Const pemprivfooter As String = "-----END RSA PRIVATE KEY-----"
        Dim pemstr As String = instr.Trim()
        Dim binkey As Byte()
        If Not pemstr.StartsWith(pemprivheader) OrElse Not pemstr.EndsWith(pemprivfooter) Then Return Nothing
        Dim sb As StringBuilder = New StringBuilder(pemstr)
        sb.Replace(pemprivheader, "")
        sb.Replace(pemprivfooter, "")
        Dim pvkstr As String = sb.ToString().Trim()

        Try
            binkey = Convert.FromBase64String(pvkstr)
            Return binkey
        Catch __unusedFormatException1__ As System.FormatException
        End Try

        Dim str As StringReader = New StringReader(pvkstr)
        If Not str.ReadLine().StartsWith("Proc-Type: 4,ENCRYPTED") Then Return Nothing
        Dim saltline As String = str.ReadLine()
        If Not saltline.StartsWith("DEK-Info: DES-EDE3-CBC,") Then Return Nothing
        Dim saltstr As String = saltline.Substring(saltline.IndexOf(",") + 1).Trim()
        Dim salt As Byte() = New Byte(saltstr.Length / 2 - 1) {}

        For i As Integer = 0 To salt.Length - 1
            salt(i) = Convert.ToByte(saltstr.Substring(i * 2, 2), 16)
        Next

        If Not (str.ReadLine() = "") Then Return Nothing
        Dim encryptedstr As String = str.ReadToEnd()

        Try
            binkey = Convert.FromBase64String(encryptedstr)
        Catch __unusedFormatException1__ As System.FormatException
            Return Nothing
        End Try

        Dim despswd As SecureString = GetSecPswd("Enter password to derive 3DES key==>")
        Dim deskey As Byte() = GetOpenSSL3deskey(salt, despswd, 1, 2)
        If deskey Is Nothing Then Return Nothing
        Dim rsakey As Byte() = DecryptKey(binkey, deskey, salt)

        If rsakey IsNot Nothing Then
            Return rsakey
        Else
            Console.WriteLine("Failed to decrypt RSA private key; probably wrong password.")
            Return Nothing
        End If
    End Function

    Public Shared Function DecryptKey(ByVal cipherData As Byte(), ByVal desKey As Byte(), ByVal IV As Byte()) As Byte()
        Dim memst As MemoryStream = New MemoryStream()
        Dim alg As TripleDES = TripleDES.Create()
        alg.Key = desKey
        alg.IV = IV

        Try
            Dim cs As CryptoStream = New CryptoStream(memst, alg.CreateDecryptor(), CryptoStreamMode.Write)
            cs.Write(cipherData, 0, cipherData.Length)
            cs.Close()
        Catch exc As Exception
            Console.WriteLine(exc.Message)
            Return Nothing
        End Try

        Dim decryptedData As Byte() = memst.ToArray()
        Return decryptedData
    End Function

    Private Shared Function GetOpenSSL3deskey(ByVal salt As Byte(), ByVal secpswd As SecureString, ByVal count As Integer, ByVal miter As Integer) As Byte()
        Dim unmanagedPswd As IntPtr = IntPtr.Zero
        Dim HASHLENGTH As Integer = 16
        Dim keymaterial As Byte() = New Byte(HASHLENGTH * miter - 1) {}
        Dim psbytes As Byte() = New Byte(secpswd.Length - 1) {}
        unmanagedPswd = Marshal.SecureStringToGlobalAllocAnsi(secpswd)
        Marshal.Copy(unmanagedPswd, psbytes, 0, psbytes.Length)
        Marshal.ZeroFreeGlobalAllocAnsi(unmanagedPswd)
        Dim data00 As Byte() = New Byte(psbytes.Length + salt.Length - 1) {}
        Array.Copy(psbytes, data00, psbytes.Length)
        Array.Copy(salt, 0, data00, psbytes.Length, salt.Length)
        Dim md5 As MD5 = New MD5CryptoServiceProvider()
        Dim result As Byte() = Nothing
        Dim hashtarget As Byte() = New Byte(HASHLENGTH + data00.Length - 1) {}

        For j As Integer = 0 To miter - 1

            If j = 0 Then
                result = data00
            Else
                Array.Copy(result, hashtarget, result.Length)
                Array.Copy(data00, 0, hashtarget, result.Length, data00.Length)
                result = hashtarget
            End If

            For i As Integer = 0 To count - 1
                result = md5.ComputeHash(result)
            Next

            Array.Copy(result, 0, keymaterial, j * HASHLENGTH, result.Length)
        Next

        Dim deskey As Byte() = New Byte(23) {}
        Array.Copy(keymaterial, deskey, deskey.Length)
        Array.Clear(psbytes, 0, psbytes.Length)
        Array.Clear(data00, 0, data00.Length)
        Array.Clear(result, 0, result.Length)
        Array.Clear(hashtarget, 0, hashtarget.Length)
        Array.Clear(keymaterial, 0, keymaterial.Length)
        Return deskey
    End Function

    Private Shared Function GetPkcs12(ByVal rsa As RSA, ByVal keycontainer As String, ByVal cspprovider As String, ByVal KEYSPEC As UInteger, ByVal cspflags As UInteger) As Byte()
        Dim pfxblob As Byte() = Nothing
        Dim hCertCntxt As IntPtr = IntPtr.Zero
        Dim DN As String = "CN=Opensslkey Unsigned Certificate"
        hCertCntxt = CreateUnsignedCertCntxt(keycontainer, cspprovider, KEYSPEC, cspflags, DN)

        If hCertCntxt = IntPtr.Zero Then
            Console.WriteLine("Couldn't create an unsigned-cert" & vbLf)
            Return Nothing
        End If

        Try
            Dim cert As X509Certificate = New X509Certificate(hCertCntxt)
            X509Certificate2UI.DisplayCertificate(New X509Certificate2(cert))
            Dim pswd As SecureString = GetSecPswd("Set PFX Password ==>")
            pfxblob = cert.Export(X509ContentType.Pkcs12, pswd)
        Catch exc As Exception
            Console.WriteLine("BAD RESULT" & exc.Message)
            pfxblob = Nothing
        End Try

        rsa.Clear()
        If hCertCntxt <> IntPtr.Zero Then Win32.CertFreeCertificateContext(hCertCntxt)
        Return pfxblob
    End Function

    Private Shared Function CreateUnsignedCertCntxt(ByVal keycontainer As String, ByVal provider As String, ByVal KEYSPEC As UInteger, ByVal cspflags As UInteger, ByVal DN As String) As IntPtr
        Const AT_KEYEXCHANGE As UInteger = &H1
        Const AT_SIGNATURE As UInteger = &H2
        Const CRYPT_MACHINE_KEYSET As UInteger = &H20
        Const PROV_RSA_FULL As UInteger = &H1
        Const MS_DEF_PROV As String = "Microsoft Base Cryptographic Provider v1.0"
        Const MS_STRONG_PROV As String = "Microsoft Strong Cryptographic Provider"
        Const MS_ENHANCED_PROV As String = "Microsoft Enhanced Cryptographic Provider v1.0"
        Const CERT_CREATE_SELFSIGN_NO_SIGN As UInteger = 1
        Const X509_ASN_ENCODING As UInteger = &H1
        Const CERT_X500_NAME_STR As UInteger = 3
        Dim hCertCntxt As IntPtr = IntPtr.Zero
        Dim encodedName As Byte() = Nothing
        Dim cbName As UInteger = 0
        If provider <> MS_DEF_PROV AndAlso provider <> MS_STRONG_PROV AndAlso provider <> MS_ENHANCED_PROV Then Return IntPtr.Zero
        If keycontainer = "" Then Return IntPtr.Zero
        If KEYSPEC <> AT_SIGNATURE AndAlso KEYSPEC <> AT_KEYEXCHANGE Then Return IntPtr.Zero
        If cspflags <> 0 AndAlso cspflags <> CRYPT_MACHINE_KEYSET Then Return IntPtr.Zero
        If DN = "" Then Return IntPtr.Zero

        If Win32.CertStrToName(X509_ASN_ENCODING, DN, CERT_X500_NAME_STR, IntPtr.Zero, Nothing, cbName, IntPtr.Zero) Then
            encodedName = New Byte(cbName - 1) {}
            Win32.CertStrToName(X509_ASN_ENCODING, DN, CERT_X500_NAME_STR, IntPtr.Zero, encodedName, cbName, IntPtr.Zero)
        End If

        Dim subjectblob As CERT_NAME_BLOB = New CERT_NAME_BLOB()
        subjectblob.pbData = Marshal.AllocHGlobal(encodedName.Length)
        Marshal.Copy(encodedName, 0, subjectblob.pbData, encodedName.Length)
        subjectblob.cbData = encodedName.Length
        Dim pInfo As CRYPT_KEY_PROV_INFO = New CRYPT_KEY_PROV_INFO()
        pInfo.pwszContainerName = keycontainer
        pInfo.pwszProvName = provider
        pInfo.dwProvType = PROV_RSA_FULL
        pInfo.dwFlags = cspflags
        pInfo.cProvParam = 0
        pInfo.rgProvParam = IntPtr.Zero
        pInfo.dwKeySpec = KEYSPEC
        hCertCntxt = Win32.CertCreateSelfSignCertificate(IntPtr.Zero, subjectblob, CERT_CREATE_SELFSIGN_NO_SIGN, pInfo, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero)
        If hCertCntxt = IntPtr.Zero Then showWin32Error(Marshal.GetLastWin32Error())
        Marshal.FreeHGlobal(subjectblob.pbData)
        Return hCertCntxt
    End Function

    Private Shared Function GetSecPswd(ByVal prompt As String) As SecureString
        Dim password As SecureString = New SecureString()
        Console.ForegroundColor = ConsoleColor.Gray
        Console.Write(prompt)
        Console.ForegroundColor = ConsoleColor.Magenta

        While True
            Dim cki As ConsoleKeyInfo = Console.ReadKey(True)

            If cki.Key = ConsoleKey.Enter Then
                Console.ForegroundColor = ConsoleColor.Gray
                Console.WriteLine()
                Return password
            ElseIf cki.Key = ConsoleKey.Backspace Then

                If password.Length > 0 Then
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop)
                    Console.Write(" ")
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop)
                    password.RemoveAt(password.Length - 1)
                End If
            ElseIf cki.Key = ConsoleKey.Escape Then
                Console.ForegroundColor = ConsoleColor.Gray
                Console.WriteLine()
                Return password
            ElseIf Char.IsLetterOrDigit(cki.KeyChar) OrElse Char.IsSymbol(cki.KeyChar) Then

                If password.Length < 20 Then
                    password.AppendChar(cki.KeyChar)
                    Console.Write("*")
                Else
                    Console.Beep()
                End If
            Else
                Console.Beep()
            End If
        End While
    End Function

    Private Shared Function CompareBytearrays(ByVal a As Byte(), ByVal b As Byte()) As Boolean
        If a.Length <> b.Length Then Return False
        Dim i As Integer = 0

        For Each c As Byte In a
            If c <> b(i) Then Return False
            i += 1
        Next

        Return True
    End Function

    Private Shared Sub ShowRSAProps(ByVal rsa As RSACryptoServiceProvider)
        Console.WriteLine("RSA CSP key information:")
        Dim keyInfo As CspKeyContainerInfo = rsa.CspKeyContainerInfo
        Console.WriteLine("Accessible property: " & keyInfo.Accessible)
        Console.WriteLine("Exportable property: " & keyInfo.Exportable)
        Console.WriteLine("HardwareDevice property: " & keyInfo.HardwareDevice)
        Console.WriteLine("KeyContainerName property: " & keyInfo.KeyContainerName)
        Console.WriteLine("KeyNumber property: " & keyInfo.KeyNumber.ToString())
        Console.WriteLine("MachineKeyStore property: " & keyInfo.MachineKeyStore)
        Console.WriteLine("Protected property: " & keyInfo.[Protected])
        Console.WriteLine("ProviderName property: " & keyInfo.ProviderName)
        Console.WriteLine("ProviderType property: " & keyInfo.ProviderType)
        Console.WriteLine("RandomlyGenerated property: " & keyInfo.RandomlyGenerated)
        Console.WriteLine("Removable property: " & keyInfo.Removable)
        Console.WriteLine("UniqueKeyContainerName property: " & keyInfo.UniqueKeyContainerName)
    End Sub

    Private Shared Sub ShowBytes(ByVal info As String, ByVal data As Byte())
        Console.WriteLine("{0}  [{1} bytes]", info, data.Length)

        For i As Integer = 1 To data.Length
            Console.Write("{0:X2}  ", data(i - 1))
            If i Mod 16 = 0 Then Console.WriteLine()
        Next

        Console.WriteLine(vbLf & vbLf)
    End Sub

    Private Shared Function GetFileBytes(ByVal filename As String) As Byte()
        If Not File.Exists(filename) Then Return Nothing
        Dim stream As Stream = New FileStream(filename, FileMode.Open)
        Dim datalen As Integer = CInt(stream.Length)
        Dim filebytes As Byte() = New Byte(datalen - 1) {}
        stream.Seek(0, SeekOrigin.Begin)
        stream.Read(filebytes, 0, datalen)
        stream.Close()
        Return filebytes
    End Function

    Private Shared Sub PutFileBytes(ByVal outfile As String, ByVal data As Byte(), ByVal bytes As Integer)
        Dim fs As FileStream = Nothing

        If bytes > data.Length Then
            Console.WriteLine("Too many bytes")
            Return
        End If

        Try
            fs = New FileStream(outfile, FileMode.Create)
            fs.Write(data, 0, bytes)
        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally
            fs.Close()
        End Try
    End Sub

    Private Shared Sub showWin32Error(ByVal errorcode As Integer)
        Dim myEx As Win32Exception = New Win32Exception(errorcode)
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("Error code:" & vbTab & " 0x{0:X}", myEx.ErrorCode)
        Console.WriteLine("Error message:" & vbTab & " {0}" & vbLf, myEx.Message)
        Console.ForegroundColor = ConsoleColor.Gray
    End Sub
End Class
