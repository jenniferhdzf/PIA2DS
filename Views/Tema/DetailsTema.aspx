<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MvcPlantilla.Models.Tema>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Detalles de el Tema</title>
</head>
<body>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">IdTema</div>
        <div class="display-field"><%: Model.IdTema %></div>
        
        <div class="display-label">Nombre</div>
        <div class="display-field"><%: Model.Nombre %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Editar", "EditTema", new { id=Model.IdTema }) %> |
        <%: Html.ActionLink("Regresar a la lista", "TEMAS_1") %>
    </p>

</body>
</html>

