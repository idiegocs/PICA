﻿Imports System.Collections.Generic

Imports System.Web.UI.WebControls

Imports Microsoft.AspNet.Membership.OpenAuth

Public Class Manage
    Inherits System.Web.UI.Page

    Private successMessageTextValue As String
    Protected Property SuccessMessageText As String
        Get
            Return successMessageTextValue
        End Get
        Private Set(value As String)
            successMessageTextValue = value
        End Set
    End Property

    Private canRemoveExternalLoginsValue As Boolean
    Protected Property CanRemoveExternalLogins As Boolean
        Get
            Return canRemoveExternalLoginsValue
        End Get
        Set(value As Boolean)
            canRemoveExternalLoginsValue = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Determinar las secciones que se van a presentar
            Dim hasLocalPassword = OpenAuth.HasLocalPassword(User.Identity.Name)
            setPassword.Visible = Not hasLocalPassword
            changePassword.Visible = hasLocalPassword

            CanRemoveExternalLogins = hasLocalPassword

            ' Presentar mensaje de operación correcta
            Dim message = Request.QueryString("m")
            If Not message Is Nothing Then
                ' Seccionar la cadena de consulta desde la acción
                Form.Action = ResolveUrl("~/Account/Manage.aspx")

                Select Case message
                    Case "ChangePwdSuccess"
                        SuccessMessageText = "Su contraseña se ha cambiado."
                    Case "SetPwdSuccess"
                        SuccessMessageText = "Su contraseña se ha establecido."
                    Case "RemoveLoginSuccess"
                        SuccessMessageText = "El inicio de sesión externo se ha quitado."
                    Case Else
                        SuccessMessageText = String.Empty
                End Select

                successMessage.Visible = Not String.IsNullOrEmpty(SuccessMessageText)
            End If
        End If

        
        ' Vincular con datos la lista de las cuentas externas
        Dim accounts As IEnumerable(Of OpenAuthAccountData) = OpenAuth.GetAccountsForUser(User.Identity.Name)
        CanRemoveExternalLogins = CanRemoveExternalLogins Or accounts.Count() > 1
        externalLoginsList.DataSource = accounts
        externalLoginsList.DataBind()
        
    End Sub

    Protected Sub setPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If IsValid Then
            Dim result As SetPasswordResult = OpenAuth.AddLocalPassword(User.Identity.Name, password.Text)
            If result.IsSuccessful Then
                Response.Redirect("~/Account/Manage.aspx?m=SetPwdSuccess")
            Else
                
                newPasswordMessage.Text = result.ErrorMessage
                
            End If
        End If
    End Sub

    
    Protected Sub externalLoginsList_ItemDeleting(ByVal sender As Object, ByVal e As ListViewDeleteEventArgs)
        Dim providerName As String = DirectCast(e.Keys("ProviderName"), String)
        Dim providerUserId As String = DirectCast(e.Keys("ProviderUserId"), String)
        Dim m As String = If(OpenAuth.DeleteAccount(User.Identity.Name, providerName, providerUserId), "?m=RemoveLoginSuccess", String.Empty)
        Response.Redirect("~/Account/Manage.aspx" & m)
    End Sub

    Protected Function Item(Of T As Class)() As T
        Return TryCast(GetDataItem(), T)
    End Function
    

    Protected Shared Function ConvertToDisplayDateTime(ByVal utcDateTime As Nullable(Of DateTime)) As String
        ' Puede cambiar este método para convertir la hora y fecha UTC con el formato y el desfase
        ' deseados. En este caso, se convertirá a la zona horaria del servidor y se asignará el formato
        ' de cadena de hora larga y fecha corta mediante la cultura de subproceso actual.
        Return If(utcDateTime.HasValue, utcDateTime.Value.ToLocalTime().ToString("G"), "[nunca]")
    End Function
End Class