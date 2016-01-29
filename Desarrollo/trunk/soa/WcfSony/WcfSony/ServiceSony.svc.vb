﻿' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
' NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.vb en el Explorador de soluciones e inicie la depuración.
Public Class ServiceSony
    Implements IService1

    Public Sub New()
    End Sub

    Sub fullfillShipment(ByVal envio As Order) Implements IService1.fullfillOrder
        Dim Query As String = ""
        Dim banco As String = ""
        Dim DATASET As DataSet = New DataSet
        Dim script As New StringBuilder
        Dim obConnection As ConnectDB = New ConnectDB

        'Dim objStreamWriter As New StreamWriter("D:\Product.xml")
        'Dim plista As New List(Of bankResult)
        'Dim objReader As SqlDataReader



        Try
            script.AppendLine("exec insertORDER_SP  '" & envio.partner & "','" & _
                                                               envio.supplier & "','" & _
                                                               envio.orderId & "','" & _
                                                               envio.addresseeName & "','" & _
                                                               envio.addresseeLastName & "','" & _
                                                               envio.country & "','" & _
                                                               envio.city & "','" & _
                                                               envio.street & "','" & _
                                                               envio.state & "','" & _
                                                               envio.zipcode & "'")
            obConnection.SetQuery(script.ToString)
            DATASET = obConnection.ExecuteQuery
        Catch ex As Exception


        End Try


        For Each item In envio.items
            '--insertITEMS_sp           
            Try
                script.AppendLine("exec insertITEMS_sp '" & item.itemID & "','" & _
                                                       item.prodID & "','" & _
                                                       item.productName & "','" & _
                                                       item.partNumber & "','" & _
                                                       item.price & "','" & _
                                                       item.quantity & "','" & _
                                                       envio.orderId & "'")
                obConnection.SetQuery(script.ToString)
                DATASET = obConnection.ExecuteQuery
            Catch ex As Exception

            End Try
        Next

    End Sub

    Function checkShipmentStatus(ByVal order As String) As String Implements IService1.checkOrderStatus
        Dim Query As String = ""
        Dim banco As String = ""
        Dim DATASET As DataSet = New DataSet
        Dim script As New StringBuilder
        Dim obConnection As ConnectDB = New ConnectDB
        Dim status As String = ""
        Try
            script.AppendLine("select top 1 SHIPSTATE from [ORDER] where SHIPORDERID=" & order)
            obConnection.SetQuery(script.ToString)
            DATASET = obConnection.ExecuteQuery
        Catch ex As Exception

        End Try
        For Each row As DataRow In DATASET.Tables(0).Rows
            status = row("SHIPSTATE")
        Next
        Return status
    End Function

End Class
