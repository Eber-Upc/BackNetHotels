using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace WebApiHoteles.Controllers
{
    public class Helper
    {
        public string GetDateChangeFormat(string date)
        {
            string[] parte = null;
            parte = date.Trim().Split("/");
            return (parte[2].Trim() + "-" + parte[1].Trim() + "-" + parte[0].Trim());
        }

        public string GetDateChangeFormatCal(string date)
        {
            string[] parte = null;
            parte = date.Trim().Split("/");
            return (parte[2].Trim() + "-" + parte[1].Trim() + "-" + parte[0].Trim());
        }

        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }


        public static string GetToken()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var Charsarr = new char[18];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            return resultString;
        }

        public string EnviarCorreo(string para, string contenido)
        {
            string Rsl = "";
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(new MailAddress(para));
                msg.From = new MailAddress("Hoteles");
                msg.Subject = "Confirmación - Recibo de Reserva";
                msg.Body = contenido;
                msg.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("u202010780@upc.edu.pe", "leD12@bc3");
                client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
                client.Host = "smtp.office365.com"; // smtp.office365.com
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Send(msg);
                Rsl = "Done";
            }
            catch (Exception)
            {
                Rsl = "Error";
            }

            return Rsl;
        }

        public string CreateVireRecibo(Reserva rs, string nombre, string apellido)
        {
            return @"
            <table width='100%' border='0' style='font-family: Arial, sans-serif;'>
            <tr style='background-color:#34495e;color:#fff'>
                <td height='40px' width='60%' style='font-weight:bold;padding: 10px;'>HOTELES SERVICE</td>
                <td height='40px' width='40%' style='padding: 10px;'>Fecha: " + rs.Hoy + @"</td>
            </tr>
            <tr style='background-color: #bdc3c7;'>
                <td colspan='2' style='padding: 10px;'>
                    <label style='font-size: 25px;'>" + nombre + @" " + apellido + @". ¡Gracias elegirnos!</label> <br/>
                    Se realizo con exito tu resera de habitacion, a continuación de detallamos tu pedido de reserva.</td>
            </tr>
            </table>
            <table width='100%' border='0' style='font-family: Arial, sans-serif;'>
                <tr>
                    <td width='40%' style='border: 1px solid black;height: 30px;padding: 5px;'>Item</td>
                    <td width='20%' style='border: 1px solid black;height: 30px;padding: 5px;'>Servicio</td>
                    <td width='20%' style='border: 1px solid black;height: 30px;padding: 5px;'>Costo Habitacion</td>
                    <td width='20%' style='border: 1px solid black;height: 30px;padding: 5px;'>Total</td>
                </tr>
                <tr>
                    <td style='background-color:#bdc3c7'>" + rs.Habitacion + @"</td>
                    <td style='background-color:#bdc3c7'>S/." + rs.Servicio + @"</td>
                    <td style='background-color:#bdc3c7'>S/." + rs.Unitario + @" x " + rs.Dias + @" días</td>
                    <td style='background-color:#bdc3c7'>S/." + rs.Monto + @"</td>
                </tr>
            </table>
            ";
        }

        public string ListaClientes(List<Cliente> data)
        {
            int i = 1;
            string dtll = "";
            foreach(var dato in data)
            {
                dtll = dtll + @"
                <tr>
                  <th>"+i+ @"</th>
                  <td>" + dato.Nombre + @"</td>
                  <td>" + dato.ApellidoP + @"</td>
                  <td>" + dato.ApellidoM + @"</td>
                  <td>" + dato.Documento + @"</td>
                  <td>" + dato.Mail + @"</td>
                  <td>" + dato.Celular + @"</td>
                </tr>
                ";
            }

            return @"
            <table class='table'>
              <thead>
                <tr>
                  <th scope='col'>#</th>
                  <th scope='col'>Nombre</th>
                  <th scope='col'>Apellido Paterno</th>
                  <th scope='col'>Apellido Materno</th>
                 <th scope='col'>Documento</th>
                 <th scope='col'>Email</th>
                 <th scope='col'>Celular</th>
                </tr>
              </thead>
              <tbody>
                "+ dtll + @"
              </tbody>
            </table>
            ";
        }

    }
}
