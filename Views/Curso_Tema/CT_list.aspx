<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcPlantilla.Models.Curso_Tema>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CT_list</title>
</head>
<body>
    <table>
        <tr>
            <th></th>
            
            <th>
                IdCurso
            </th>
            <th>
                IdTema
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "EditCursoTema", new { id = item.IdCT })%> |
                <%: Html.ActionLink("Detalles", "DetailsCursoTema", new { id = item.IdCT })%> |
                <%: Html.ActionLink("Eliminar", "DeleteCursoTema", new { id=item.IdCT })%>
            </td>
            
            <td>
                <%: item.IdCurso %>
            </td>
            <td>
                <%: item.IdTema %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Crear Nuevo", "CreateCursoTema") %>
    </p>
    <p>
        <a href="/Menu/Index">Regresar al Menu</a>
    </p>

     <body style="background-color:#FAD7A0  ">
</body>
    <br />  

<img src="https://i.pinimg.com/originals/f0/55/87/f05587fb963a9c55419d2fd5723d1263.gif" alt="Empresarios">


</body>
</html>

