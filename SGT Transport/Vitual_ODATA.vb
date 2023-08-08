Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Text

Namespace ODataVirtualizationDemo.Model
	Public Class Order
		Implements INotifyPropertyChanged, IEditableObject

#Region "Fields"
		Private _orderId, _employeeId, _shipVia As Integer
		Private _customerId, _shipName, _shipAddress, _shipCity, _shipRegion, _shipPostalCode, _shipCountry As String
		Private _orderDate, _requiredDate, _shippedDate As DateTimeOffset
		Private _freight As Decimal
#End Region

#Region "Properties"

		Public Property OrderID() As Integer
			Get
				Return _orderId
			End Get
			Set(ByVal value As Integer)
				If _orderId <> value Then
					_orderId = value
					OnPropertyChanged()
				End If
			End Set
		End Property

		Public Property CustomerID() As String
			Get
				Return _customerId
			End Get
			Set(ByVal value As String)
				If _customerId <> value Then
					_customerId = value
					OnPropertyChanged()
				End If
			End Set
		End Property

		Public Property EmployeeID() As Integer
			Get
				Return _employeeId
			End Get
			Set(ByVal value As Integer)
				If _employeeId <> value Then
					_employeeId = value
					OnPropertyChanged()
				End If
			End Set
		End Property

		Public Property OrderDate() As DateTimeOffset
			Get
				Return _orderDate
			End Get
			Set(ByVal value As DateTimeOffset)
				If _orderDate <> value Then
					_orderDate = value
					OnPropertyChanged()
				End If
			End Set
		End Property

		Public Property RequiredDate() As DateTimeOffset
			Get
				Return _requiredDate
			End Get
			Set(ByVal value As DateTimeOffset)
				If _requiredDate <> value Then
					_requiredDate = value
					OnPropertyChanged()
				End If
			End Set
		End Property

		Public Property ShippedDate() As DateTimeOffset
			Get
				Return _shippedDate
			End Get
			Set(ByVal value As DateTimeOffset)
				If _shippedDate <> value Then
					_shippedDate = value
					OnPropertyChanged()
				End If
			End Set
		End Property

		Public Property ShipVia() As Integer
			Get
				Return _shipVia
			End Get
			Set(ByVal value As Integer)
				If _shipVia <> value Then
					_shipVia = value
					OnPropertyChanged()
				End If
			End Set
		End Property

		Public Property Freight() As Decimal
			Get
				Return _freight
			End Get
			Set(ByVal value As Decimal)
				If _freight <> value Then
					_freight = value
					OnPropertyChanged()
				End If
			End Set
		End Property

		Public Property ShipName() As String
			Get
				Return _shipName
			End Get
			Set(ByVal value As String)
				If _shipName <> value Then
					_shipName = value
					OnPropertyChanged()
				End If
			End Set
		End Property

		Public Property ShipAddress() As String
			Get
				Return _shipAddress
			End Get
			Set(ByVal value As String)
				If _shipAddress <> value Then
					_shipAddress = value
					OnPropertyChanged()
				End If
			End Set
		End Property

		Public Property ShipCity() As String
			Get
				Return _shipCity
			End Get
			Set(ByVal value As String)
				If _shipCity <> value Then
					_shipCity = value
					OnPropertyChanged()
				End If
			End Set
		End Property

		Public Property ShipRegion() As String
			Get
				Return _shipRegion
			End Get
			Set(ByVal value As String)
				If _shipRegion <> value Then
					_shipRegion = value
					OnPropertyChanged()
				End If
			End Set
		End Property

		Public Property ShipPostalCode() As String
			Get
				Return _shipPostalCode
			End Get
			Set(ByVal value As String)
				If _shipPostalCode <> value Then
					_shipPostalCode = value
					OnPropertyChanged()
				End If
			End Set
		End Property

		Public Property ShipCountry() As String
			Get
				Return _shipCountry
			End Get
			Set(ByVal value As String)
				If _shipCountry <> value Then
					_shipCountry = value
					OnPropertyChanged()
				End If
			End Set
		End Property

#End Region

#Region "INotifyPropertyChanged Members"

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		Private Sub OnPropertyChanged(<CallerMemberName> Optional ByVal propertyName As String = "")
			OnPropertyChanged(New PropertyChangedEventArgs(propertyName))
		End Sub

		Protected Sub OnPropertyChanged(ByVal e As PropertyChangedEventArgs)
			RaiseEvent PropertyChanged(Me, e)
		End Sub

#End Region

#Region "IEditableObject Members"

		Private _clone As Order

		Public Sub BeginEdit() Implements IEditableObject.BeginEdit
			_clone = DirectCast(MemberwiseClone(), Order)
		End Sub

		Public Sub CancelEdit() Implements IEditableObject.CancelEdit
			If _clone IsNot Nothing Then
				For Each p In Me.GetType().GetRuntimeProperties()
					If p.CanRead AndAlso p.CanWrite Then
						p.SetValue(Me, p.GetValue(_clone, Nothing), Nothing)
					End If
				Next p
			End If
		End Sub

		Public Sub EndEdit() Implements IEditableObject.EndEdit
			_clone = Nothing
		End Sub
#End Region
	End Class
End Namespace
