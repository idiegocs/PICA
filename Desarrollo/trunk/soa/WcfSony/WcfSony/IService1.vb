' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Web
Imports System.Text
Imports System.Data

<ServiceContract()>
Public Interface IService1

    <OperationContract()>
    Sub fullfillOrder(ByVal envio As Order)

    <OperationContract()>
    Function checkOrderStatus(ByVal order As String) As String

    ' TODO: agregue aquí sus operaciones de servicio

End Interface

' Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.

'<DataContract()>
'Public Class CompositeType

<DataContract()>
Partial Public Class Order

    Private partnerField As String

    Private supplierField As String

    Private orderIdField As String

    Private addresseeNameField As String

    Private addresseeLastNameField As String

    Private countryField As String

    Private cityField As String

    Private streetField As String

    Private stateField As String

    Private zipcodeField As String

    Private itemsField As List(Of Item)

    <DataMember()>
    Public Property partner() As String
        Get
            Return Me.partnerField
        End Get
        Set(value As String)
            Me.partnerField = value
        End Set
    End Property

    <DataMember()>
    Public Property supplier() As String
        Get
            Return Me.supplierField
        End Get
        Set(value As String)
            Me.supplierField = value
        End Set
    End Property

    <DataMember()>
    Public Property orderId() As String
        Get
            Return Me.orderIdField
        End Get
        Set(value As String)
            Me.orderIdField = value
        End Set
    End Property

    <DataMember()>
    Public Property addresseeName() As String
        Get
            Return Me.addresseeNameField
        End Get
        Set(value As String)
            Me.addresseeNameField = value
        End Set
    End Property

    <DataMember()>
    Public Property addresseeLastName() As String
        Get
            Return Me.addresseeLastNameField
        End Get
        Set(value As String)
            Me.addresseeLastNameField = value
        End Set
    End Property

    <DataMember()>
    Public Property country() As String
        Get
            Return Me.countryField
        End Get
        Set(value As String)
            Me.countryField = value
        End Set
    End Property

    <DataMember()>
    Public Property city() As String
        Get
            Return Me.cityField
        End Get
        Set(value As String)
            Me.cityField = value
        End Set
    End Property

    <DataMember()>
    Public Property street() As String
        Get
            Return Me.streetField
        End Get
        Set(value As String)
            Me.streetField = value
        End Set
    End Property

    <DataMember()>
    Public Property state() As String
        Get
            Return Me.stateField
        End Get
        Set(value As String)
            Me.stateField = value
        End Set
    End Property

    <DataMember()>
    Public Property zipcode() As String
        Get
            Return Me.zipcodeField
        End Get
        Set(value As String)
            Me.zipcodeField = value
        End Set
    End Property

    <DataMember()>
    Public Property items() As List(Of Item)
        Get
            items = itemsField
        End Get
        Set(ByVal Value As List(Of Item))
            itemsField = Value
        End Set
    End Property
End Class

<DataContract()>
Partial Public Class Item

    Private itemIDField As String

    Private prodIDField As String

    Private productNameField As String

    Private partNumberField As String

    Private priceField As Integer

    Private quantityField As Integer

    <DataMember()>
    Public Property itemID() As String
        Get
            Return Me.itemIDField
        End Get
        Set(value As String)
            Me.itemIDField = value
        End Set
    End Property

    <DataMember()>
    Public Property prodID() As String
        Get
            Return Me.prodIDField
        End Get
        Set(value As String)
            Me.prodIDField = value
        End Set
    End Property

    <DataMember()>
    Public Property productName() As String
        Get
            Return Me.productNameField
        End Get
        Set(value As String)
            Me.productNameField = value
        End Set
    End Property

    <DataMember()>
    Public Property partNumber() As String
        Get
            Return Me.partNumberField
        End Get
        Set(value As String)
            Me.partNumberField = value
        End Set
    End Property

    <DataMember()>
    Public Property price() As Integer
        Get
            Return Me.priceField
        End Get
        Set(value As Integer)
            Me.priceField = value
        End Set
    End Property

    <DataMember()>
    Public Property quantity() As Integer
        Get
            Return Me.quantityField
        End Get
        Set(value As Integer)
            Me.quantityField = value
        End Set
    End Property
End Class


'End Class
