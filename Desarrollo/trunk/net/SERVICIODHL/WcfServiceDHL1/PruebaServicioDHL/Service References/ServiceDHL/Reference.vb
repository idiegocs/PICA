﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.34209
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Runtime.Serialization

Namespace ServiceDHL
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0"),  _
     System.Runtime.Serialization.DataContractAttribute(Name:="Shipment", [Namespace]:="http://schemas.datacontract.org/2004/07/WcfServiceDHL1"),  _
     System.SerializableAttribute()>  _
    Partial Public Class Shipment
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
        
        <System.NonSerializedAttribute()>  _
        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private addresseeLastNameField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private addresseeNameField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private cityField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private countryField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private orderIdField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private partnerField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private stateField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private streetField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private supplierField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private zipcodeField As String
        
        <Global.System.ComponentModel.BrowsableAttribute(false)>  _
        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set
                Me.extensionDataField = value
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property addresseeLastName() As String
            Get
                Return Me.addresseeLastNameField
            End Get
            Set
                If (Object.ReferenceEquals(Me.addresseeLastNameField, value) <> true) Then
                    Me.addresseeLastNameField = value
                    Me.RaisePropertyChanged("addresseeLastName")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property addresseeName() As String
            Get
                Return Me.addresseeNameField
            End Get
            Set
                If (Object.ReferenceEquals(Me.addresseeNameField, value) <> true) Then
                    Me.addresseeNameField = value
                    Me.RaisePropertyChanged("addresseeName")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property city() As String
            Get
                Return Me.cityField
            End Get
            Set
                If (Object.ReferenceEquals(Me.cityField, value) <> true) Then
                    Me.cityField = value
                    Me.RaisePropertyChanged("city")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property country() As String
            Get
                Return Me.countryField
            End Get
            Set
                If (Object.ReferenceEquals(Me.countryField, value) <> true) Then
                    Me.countryField = value
                    Me.RaisePropertyChanged("country")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property orderId() As String
            Get
                Return Me.orderIdField
            End Get
            Set
                If (Object.ReferenceEquals(Me.orderIdField, value) <> true) Then
                    Me.orderIdField = value
                    Me.RaisePropertyChanged("orderId")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property partner() As String
            Get
                Return Me.partnerField
            End Get
            Set
                If (Object.ReferenceEquals(Me.partnerField, value) <> true) Then
                    Me.partnerField = value
                    Me.RaisePropertyChanged("partner")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property state() As String
            Get
                Return Me.stateField
            End Get
            Set
                If (Object.ReferenceEquals(Me.stateField, value) <> true) Then
                    Me.stateField = value
                    Me.RaisePropertyChanged("state")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property street() As String
            Get
                Return Me.streetField
            End Get
            Set
                If (Object.ReferenceEquals(Me.streetField, value) <> true) Then
                    Me.streetField = value
                    Me.RaisePropertyChanged("street")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property supplier() As String
            Get
                Return Me.supplierField
            End Get
            Set
                If (Object.ReferenceEquals(Me.supplierField, value) <> true) Then
                    Me.supplierField = value
                    Me.RaisePropertyChanged("supplier")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property zipcode() As String
            Get
                Return Me.zipcodeField
            End Get
            Set
                If (Object.ReferenceEquals(Me.zipcodeField, value) <> true) Then
                    Me.zipcodeField = value
                    Me.RaisePropertyChanged("zipcode")
                End If
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="ServiceDHL.IService1")>  _
    Public Interface IService1
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IService1/devuelveValor", ReplyAction:="http://tempuri.org/IService1/devuelveValorResponse")>  _
        Function devuelveValor(ByVal a As String) As String
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IService1/fullfillShipment", ReplyAction:="http://tempuri.org/IService1/fullfillShipmentResponse")>  _
        Sub fullfillShipment(ByVal envio As ServiceDHL.Shipment)
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface IService1Channel
        Inherits ServiceDHL.IService1, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class Service1Client
        Inherits System.ServiceModel.ClientBase(Of ServiceDHL.IService1)
        Implements ServiceDHL.IService1
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function devuelveValor(ByVal a As String) As String Implements ServiceDHL.IService1.devuelveValor
            Return MyBase.Channel.devuelveValor(a)
        End Function
        
        Public Sub fullfillShipment(ByVal envio As ServiceDHL.Shipment) Implements ServiceDHL.IService1.fullfillShipment
            MyBase.Channel.fullfillShipment(envio)
        End Sub
    End Class
End Namespace
