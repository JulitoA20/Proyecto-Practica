Imports ConsultorioAD
Partial Class frm_Index
    Inherits System.Web.UI.Page

#Region "Limpiar"
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Limpiar()
        End If
    End Sub
#End Region

#Region "Combo"
    Private Sub comboTipo()
        Dim ods As New Data.DataSet
        Dim oConsultorio As New C_Consultorio
        ods = oConsultorio.ComboTipo

        ddlTipo.DataSource = ods.Tables(0)
        ddlTipo.DataTextField = ods.Tables(0).Columns(1).ToString
        ddlTipo.DataValueField = ods.Tables(0).Columns(0).ToString
        ddlTipo.DataBind()
    End Sub
#End Region

#Region "Limpiar"
    Private Sub Limpiar()
        ddlTipo.SelectedIndex = 1
        comboTipo()
        CargarGrilla()
    End Sub
#End Region

#Region "Agregar"
    Protected Sub cmdAgregar_Click(sender As Object, e As System.EventArgs) Handles cmdAgregar.Click
        Dim oMusica As New C_Consultorio

        If txtConsulta.Text <> Nothing And txtDias.Text <> Nothing And ddlTipo.Text <> Nothing And txtEdad.Text <> Nothing And txtEmail.Text <> Nothing Then
            oMusica.Agregar(txtConsulta.Text, txtDias.Text, ddlTipo.Text, txtEdad.Text, txtEmail.Text)
            MsgBox("Consulta cargada correctamente", vbInformation, "Cargar")
            Limpiar()
        Else
            MsgBox("Completar datos si desea continuar", vbInformation, "Cargar")
        End If
    End Sub
#End Region

#Region "Grilla/BuscarTodos"
    Private Sub CargarGrilla()
        Dim ods As New Data.DataSet
        Dim oConsulta As New C_Consultorio

        ods = oConsulta.BuscarTodos
        grlGrilla.DataSource = ods.Tables(0)
        grlGrilla.DataBind()
    End Sub
#End Region

#Region "Buscar"
    Protected Sub cmdConsultar_Click(sender As Object, e As System.EventArgs) Handles cmdBuscar.Click
        Dim ods As New Data.DataSet
        Dim oConsultorio As New C_Consultorio

        If txtId.Text <> Nothing Then
            ods = oConsultorio.BuscarPorId(txtId.Text)

            If ods.Tables(0).Rows.Count > 0 Then
                txtConsulta.Text = (ods.Tables(0).Rows(0).Item("Consulta"))
                txtDias.Text = (ods.Tables(0).Rows(0).Item("Dias_caso"))
                ddlTipo.Text = (ods.Tables(0).Rows(0).Item("Id_Tipo_Caso"))
                txtEdad.Text = (ods.Tables(0).Rows(0).Item("Edad_Caso"))
                txtEmail.Text = (ods.Tables(0).Rows(0).Item("Email"))
            End If
        Else
            MsgBox("Este ID es inexistente, corrobore lo cargado", vbInformation, "Cargar")
        End If
    End Sub
#End Region

#Region "Modificar"
    Protected Sub cmdModificar_Click(sender As Object, e As System.EventArgs) Handles cmdModificar.Click
        Dim oConsulta As New C_Consultorio

        If txtId.Text <> Nothing And txtConsulta.Text <> Nothing And txtDias.Text <> Nothing And ddlTipo.Text <> Nothing And txtEdad.Text <> Nothing And txtEmail.Text <> Nothing Then
            oConsulta.Modificar(txtId.Text, txtConsulta.Text, txtDias.Text, ddlTipo.Text, txtEdad.Text, txtEmail.Text)
            MsgBox("Consulta modificada con éxito", vbInformation, "Modificar")
            Limpiar()
        Else
            MsgBox("Completar datos para modificar, por favor", vbInformation, "Modificar")
        End If
    End Sub
#End Region

#Region "Eliminar"
    Protected Sub cmdEliminar_Click(sender As Object, e As System.EventArgs) Handles cmdEliminar.Click
        Dim oConsulta As New C_Consultorio

        If txtId.Text <> Nothing Then
            oConsulta.Eliminar(txtId.Text)
            MsgBox("Consulta Eliminada", vbInformation, "Eliminar")
            Limpiar()
        Else
            MsgBox("Ingresar dato para Eliminar", vbInformation, "Eliminar")
        End If
    End Sub
#End Region

End Class
