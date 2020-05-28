<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MvcPlantilla.Models.Curso_Tema>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DeleteCursoTema</title>
</head>
<body>
    <h3>Seguro que quieres eliminar esto?</h3>
    <fieldset>
        <legend>DATOS</legend>
        
        <div class="display-label">IdCT</div>
        <div class="display-field"><%: Model.IdCT %></div>
        
        <div class="display-label">IdCurso</div>
        <div class="display-field"><%: Model.IdCurso %></div>
        
        <div class="display-label">IdTema</div>
        <div class="display-field"><%: Model.IdTema %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="ELIMINAR" /> |
		    <%: Html.ActionLink("Regresar a la lista", "CT_list") %>
        </p>
    <% } %>

</body>
</html>

