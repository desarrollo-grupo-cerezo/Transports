Imports System.Data.SqlServerCe
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1SuperTooltip

Public Class RibbonForm3
    Private Sub RibbonForm3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'C1SuperLabel1.Text = "<table>" + "<tr>" + "<td><img src='newToolStripButton.Image'>" + "<td>This  is the second cell in the top row" +
        '"<tr>" + "<td><img src='openToolStripButton.Image'>" + "<td>This  is the second cell in the bottom row." + "</table>"

        BindGrid(Fg)
        CreateTree(Fg)
        CreateSubTotal(Fg)

    End Sub

    Public Sub BindGrid(ByVal grid As C1FlexGrid)
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Name", GetType(String))
        dt.Columns.Add("Course", GetType(String))
        dt.Columns.Add("Score", GetType(Integer))
        dt.Columns.Add("Attendance", GetType(Integer))
        dt.Columns.Add("Country", GetType(String))
        dt.Rows.Add(1, "Helen Bennett", "ComputerScience", 79, 84, "Spain")
        dt.Rows.Add(2, "Ana Trujillo", "Biology", 78, 87, "Mexico")
        dt.Rows.Add(3, "Antonio Moreno", "Aeronautics", 71, 70, "Spain")
        dt.Rows.Add(4, "Paolo Accorti", "Biology", 74, 63, "Spain")
        dt.Rows.Add(5, "Elizabeth Brown", "ComputerScience", 80, 93, "Mexico")
        dt.Rows.Add(6, "Jaime Yorres", "Biology", 61, 48, "Spain")
        dt.Rows.Add(7, "Yvonne Moncada", "Aeronautics", 85, 78, "Mexico")
        dt.Rows.Add(8, "Martine Rancé", "Aeronautics", 67, 81, "Spain")
        dt.Rows.Add(9, "Sergio Gutiérrezy", "ComputerScience", 62, 58, "Mexico")
        dt.Rows.Add(10, "Thomas Hardy", "Aeronautics", 94, 92, "Mexico")
        dt.Rows.Add(11, "Patricio Simpson", "Aeronautics", 46, 52, "Spain")
        dt.Rows.Add(12, "Maria Anders", "ComputerScience", 85, 73, "Spain")
        grid.DataSource = dt
        grid.AutoSizeCols()
        TryCast(grid.DataSource, DataTable).DefaultView.Sort = "Course"

    End Sub

    Public Sub CreateTree(ByVal grid As C1FlexGrid)
        grid.Tree.Column = 1
        grid.Tree.Style = TreeStyleFlags.SimpleLeaf
        grid.Tree.Show(1)
        grid.AutoSizeCols()
    End Sub

    Public Sub CreateSubTotal(ByVal grid As C1FlexGrid)
        grid.Subtotal(AggregateEnum.Clear)
        grid.Subtotal(AggregateEnum.Average, 1, 3, 3, 4, "Average for {0}")
        grid.AutoSizeCols()
    End Sub

    Private Sub BarDiseñador_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs)

    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs)

        '
        'Encerramos la conexion en un Bloque using para asegurarse de destruir todos los objetos utilizados dentro
        'ademas de cerrar la conexion despues de ejectuar la consulta
        '
        Using cnx As New SqlCeConnection("Data Source=|DataDirectory|\TRANSPORTGC.sdf")
            'Creamos una variable que contendra la consulta a ejecutar
            '
            Dim SqlAction As String = "SELECT * FROM INVE"
            '
            'Creamos un comeando del tipo SqlCeCommand y le pasamos la variable que contiene
            'la consulta y la conexion
            '
            Using cmd As New SqlCeCommand(SqlAction, cnx)
                '
                'Creamos un objeto DataAdapter este objeto se encarga de abrir la conexion a la Bd
                '
                Dim da As New SqlCeDataAdapter(cmd)
                '
                'Creamos un objeto DataTable que contendra los daos recuperados por el DataAdapter
                '
                Dim dt As New DataTable()

                '
                'Llenamos el objeto DataTable con los datos recuperados por el DataAdapter
                '
                da.Fill(dt)
                '
                'Establecemos el DataSource del Control DataGridView
                '
                Fg.DataSource = dt

            End Using
        End Using
    End Sub
End Class
