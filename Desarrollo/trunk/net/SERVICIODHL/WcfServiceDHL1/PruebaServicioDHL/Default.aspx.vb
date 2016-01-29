Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim Query As String = ""
        Dim banco As String = ""
        Dim DATASET As DataSet = New DataSet
        Dim script As New StringBuilder
        Dim obConnection As ConnectDB = New ConnectDB
        If Not IsPostBack Then
            script.AppendLine("select IDDEPT,NOMBREDEP from   DEPARTAMENTOS")
            obConnection.SetQuery(script.ToString)
            DATASET = obConnection.ExecuteQuery
            ddlDepartamento.DataSource = DATASET.Tables(0)
            ddlDepartamento.DataBind()
        End If
    End Sub

    Protected Sub ddlDepartamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDepartamento.SelectedIndexChanged
        Dim Query As String = ""
        Dim banco As String = ""
        Dim DATASET As DataSet = New DataSet
        Dim script As New StringBuilder
        Dim obConnection As ConnectDB = New ConnectDB

        script.AppendLine("select IDMUN,NOMBREMUN from   MUNICIPIOS where  IDDEPT =" & ddlDepartamento.SelectedValue)
        obConnection.SetQuery(script.ToString)
        DATASET = obConnection.ExecuteQuery
        ddlMunicipio.DataSource = DATASET.Tables(0)
        ddlMunicipio.DataBind()

    End Sub
End Class