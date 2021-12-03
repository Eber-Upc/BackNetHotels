#pragma checksum "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fb77758608c01f55581c368b0aefe7dc0d33828"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Gestion_CheckIng), @"mvc.1.0.view", @"/Views/Gestion/CheckIng.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\_ViewImports.cshtml"
using WebApiHoteles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\_ViewImports.cshtml"
using WebApiHoteles.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fb77758608c01f55581c368b0aefe7dc0d33828", @"/Views/Gestion/CheckIng.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e896a9fc2471f0cd3d6e7b671b9fd105ce182729", @"/Views/_ViewImports.cshtml")]
    public class Views_Gestion_CheckIng : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
  
    int i = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div>
    <div>
        <label style=""font-size:44px;font-weight:bold"">Cheking.</label><br />
        <label style=""font-size:18px;margin-top:-15px"">Seleccione una reserva para realizar el ingreso.</label>
    </div>
    <div class=""row"">
        <table class=""table"">
            <thead>
                <tr>
                    <th scope=""col"">#</th>
                    <th scope=""col"">Usuario</th>
                    <th scope=""col"">Habitacion</th>
                    <th scope=""col"">Numero Hab.</th>
                    <th scope=""col"">Entrada</th>
                    <th scope=""col"">Salida</th>
                    <th scope=""col"">Huespedes</th>
                    <th scope=""col"">Fecha Reserva</th>
                    <th scope=""col"">Total</th>
                    <th scope=""col"">Estado</th>
                    <th scope=""col"">Agregar</th>
                    <th scope=""col"">Lista</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 28 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
                 foreach (var dato in ViewBag.ListaReservas)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 31 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 32 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
                       Write(dato.Nombres);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 32 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
                                      Write(dato.Apellidos);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 33 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
                       Write(dato.Habitacion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 34 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
                       Write(dato.Room);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 35 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
                       Write(dato.Inicio);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 36 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
                       Write(dato.Fin);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                        <td>");
#nullable restore
#line 37 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
                       Write(dato.Huespedes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 38 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
                       Write(dato.FechaReserva);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>S/.");
#nullable restore
#line 39 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
                          Write(dato.Monto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 40 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
                       Write(dato.Estado);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td><i class=\"fas fa-user-plus\" style=\"font-size: 20px; color: #3498db\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1702, "\"", 1734, 3);
            WriteAttributeValue("", 1712, "OpenRegistro(", 1712, 13, true);
#nullable restore
#line 41 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
WriteAttributeValue("", 1725, dato.Id, 1725, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1733, ")", 1733, 1, true);
            EndWriteAttribute();
            WriteLiteral("></i></td>\r\n                        <td><i class=\"fas fa-users\" style=\"font-size: 20px; color: #3498db\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1838, "\"", 1873, 3);
            WriteAttributeValue("", 1848, "OpenListaClient(", 1848, 16, true);
#nullable restore
#line 42 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
WriteAttributeValue("", 1864, dato.Id, 1864, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1872, ")", 1872, 1, true);
            EndWriteAttribute();
            WriteLiteral("></i></td>\r\n                    </tr>\r\n");
#nullable restore
#line 44 "D:\UPC\Proyectos\Fuentes\Api\WebApiHoteles\WebApiHoteles\Views\Gestion\CheckIng.cshtml"
                    i++;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </tbody>
        </table>

    </div>
</div>



<!-- Modal -->
<div class=""modal fade"" id=""ModelInsertPersona"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Ingresar Persona</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <input id=""idtRs"" style=""display:none"" />
                <label for=""exampleInputEmail1"" class=""form-label"">Nombre</label>
                <input type=""text"" class=""form-control"" id=""nombre"">
                <label for=""exampleInputEmail1"" class=""form-label"">Apellido Paterno</label>
                <input type=""text"" class=""form-control"" id=""apellidoP"">
                <label for=""exampleInputEmail1"" class=""form-label"">Ap");
            WriteLiteral(@"ellido Materno</label>
                <input type=""text"" class=""form-control"" id=""apellidoM"">
                <label for=""exampleInputEmail1"" class=""form-label"">Correo electronico</label>
                <input type=""email"" class=""form-control"" id=""correo"">

                <label for=""exampleInputEmail1"" class=""form-label"">Número documento</label>
                <input type=""text"" class=""form-control"" id=""numDoc"">
                <label for=""exampleInputEmail1"" class=""form-label"">Número Celular</label>
                <input type=""text"" class=""form-control"" id=""celnum"">
                <div style=""min-height:30px""></div>
                <a class=""btn btn-primary"" href=""#"" role=""button"" onclick=""InsertPersona()"">Registrar Persona</a>
            </div>

        </div>
    </div>
</div>


<!-- Modal -->
<div class=""modal fade"" id=""ModelListaPersona"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-cont");
            WriteLiteral(@"ent"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Lista de Personas</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"" id=""listCli"">
               
            </div>

        </div>
    </div>
</div>

<script>
    function OpenRegistro(idt) {
        $(""#ModelInsertPersona"").modal(""show"");
        document.getElementById(""idtRs"").value = idt;
    }
    function InsertPersona() {
        let idt = parseInt(document.getElementById(""idtRs"").value);
        let nombre = document.getElementById(""nombre"").value;
        let apellidoP = document.getElementById(""apellidoP"").value;
        let äpellidoM = document.getElementById(""apellidoM"").value;
        let Mail = document.getElementById(""correo"").value;
        let NumDoc = document.getElementById(""numDoc"").value;
        let Celular = document.getElementById(""celn");
            WriteLiteral(@"um"").value;

        var params = {
            Reserva: idt,
            Nombre: nombre,
            ApellidoP: apellidoP,
            ApellidoM: äpellidoM,
            Mail: Mail,
            Documento: NumDoc,
            Celular: Celular,
            Reserva: idt
        };
        var xmlhttp = new XMLHttpRequest();
        var theUrl = ""/api/SetClienteReserva"";
        xmlhttp.open(""POST"", theUrl);
        xmlhttp.setRequestHeader(""Content-Type"", ""application/json;charset=UTF-8"");
        xmlhttp.send(JSON.stringify(params));
        xmlhttp.responseType = 'json';
        xmlhttp.onload = function () {
            if (xmlhttp.status != 200) {
                console.log(""Error"")
            } else {
                let rs = xmlhttp.response;
                console.log(xmlhttp.response);
                console.log(rs[""value""]);
                if (rs[""value""] == ""Done"") {
                    clearForm();
                }

            }
        };



    }


    fun");
            WriteLiteral(@"ction clearForm() {
        document.getElementById(""nombre"").value = """";
        document.getElementById(""apellidoP"").value = """";
        document.getElementById(""apellidoM"").value = """";
        document.getElementById(""correo"").value = """";
        document.getElementById(""numDoc"").value = """";
        document.getElementById(""celnum"").value = """";
    }

    function OpenListaClient(idt) {
        $(""#ModelListaPersona"").modal(""show"");
        var params = {
            Reserva: idt
        };
        var xmlhttp = new XMLHttpRequest();
        var theUrl = ""/api/GetClienteReserva"";
        xmlhttp.open(""POST"", theUrl);
        xmlhttp.setRequestHeader(""Content-Type"", ""application/json;charset=UTF-8"");
        xmlhttp.send(JSON.stringify(params));
        xmlhttp.responseType = 'json';
        xmlhttp.onload = function () {
            if (xmlhttp.status != 200) {
                console.log(""Error"")
            } else {
                
                let dto = xmlhttp.response;
  ");
            WriteLiteral("              console.log(xmlhttp.response[0]);\r\n                document.getElementById(\"listCli\").innerHTML = dto[\"value\"];\r\n\r\n            }\r\n        };\r\n    }\r\n</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
