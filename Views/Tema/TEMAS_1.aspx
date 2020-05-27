<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcPlantilla.Models.Tema>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TEMAS_1</title>
</head>
<body>
    <table>
        <tr>
            
            </th>
            <th>
                Nombre
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "EditTema", new { id = item.IdTema })%> |
                <%: Html.ActionLink("Detalles", "DetailsTema", new {id= item.IdTema })%> |
                <%: Html.ActionLink("Eliminar", "DeleteTema", new { id=item.IdTema })%>
            </td>
            
            <td>
                <%: item.Nombre %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Crear Nuevo", "CreateTema") %>
    </p>

    <p>
        <a href="/Menu/Index">Regresar al Menu</a>
    </p>

</body>
</html>

