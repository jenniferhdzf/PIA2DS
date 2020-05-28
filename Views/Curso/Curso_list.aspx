<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcPlantilla.Models.Curso>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Curso_list</title>
</head>
<body>
    <table>
        <tr>
            <th></th>
            
            <th>
                Descripcion
            </th>
            
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "EditCurso", new { id=item.IdCurso}) %> |
                <%: Html.ActionLink("Detalles", "DetailsCurso", new {  id=item.IdCurso })%> |
                <%: Html.ActionLink("Eliminar", "DeleteCurso", new {  id=item.IdCurso })%>
            </td>
            
            <td>
                <%: item.Descripcion %>
            </td>
            
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Crear nuevo Curso", "CreateCurso")%>
    </p>
    <p>
        <a href="/Menu/Index">Regresar al Menu</a>
    </p>
</body>
</html>

