<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcPlantilla.Models.Empleado>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Empleado_list</title>
</head>
<body>
    <table>
        <tr>
            <th></th>
            
            <th>
                Nombre
            </th>
            >
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "EditEmpleado", new { id=item.IdEmpleado }) %> |
                <%: Html.ActionLink("Detalles", "DetailsEmpleado", new { id = item.IdEmpleado })%> |
                <%: Html.ActionLink("Eliminar", "DeleteEmpleado", new { id = item.IdEmpleado })%>
            </td>
            
            <td>
                <%: item.Nombre %>
            </td>
            
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Crear Empleado", "CreateEmpleado") %>
    </p>

    <p>
        <a href="/Menu/Index">Regresar al Menu</a>
    </p>

</body>
</html>

