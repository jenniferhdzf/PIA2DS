<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcPlantilla.Models.Curso_Tema_Video>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CTVideo_list</title>
</head>
<body>
    <table>
        <tr>
            <th></th>
            
            <th>
                IdCT
            </th>
            <th>
                IdVideo
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "EditCursoTemaVideo", new {  id=item.IdCTV }) %> |
                <%: Html.ActionLink("Detalles", "DetailsCursoTemaVideo", new {  id=item.IdCTV })%> |
                <%: Html.ActionLink("Eliminar", "DeleteCursoTemaVideo", new {  id=item.IdCTV })%>
            </td>
            
            <td>
                <%: item.IdCT %>
            </td>
            <td>
                <%: item.IdVideo %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Crear Nuevo", "CreateCursoTemaVideo") %>
    </p>

</body>
</html>

