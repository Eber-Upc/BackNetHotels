using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Objetos;
using MySql.Data.MySqlClient;

namespace WebApiHoteles.Models
{
    public class DataModel
    {
        ConexionModel Cnx = new ConexionModel();
        public List<Habitacion> GetHabitaciones(int personas)
        {
            List<Habitacion> lista = new List<Habitacion>();
            var cn = Cnx.GetConnection();
            cn.Open();
            string query = @"select hb.ROOM_ID as 'Id',tp.TYPE_NAME as 'Titulo',hb.ROOM_INFO1 as 'Descripcion' 
                                from tbl_habitacion hb inner join tbl_tipo_habitacion tp on tp.TYPE_ID=hb.ROOM_TYPE 
                                WHERE tp.NUMBER_PEOPLE=" + personas;

            MySqlCommand cmd = new MySqlCommand(query, cn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Habitacion itm = new Habitacion();
                try { itm.Id = dr.GetInt32(0); } catch (Exception) { itm.Id = 0; }
                try { itm.Titulo = dr.GetString(1); } catch (Exception) { itm.Titulo = ""; }
                try { itm.Descripcion = dr.GetString(2); } catch (Exception) { itm.Descripcion = ""; }
                try { itm.Img = "https://media-cdn.tripadvisor.com/media/photo-s/0e/a2/c2/31/habitacion-hotel-beatriz.jpg"; } catch (Exception) { itm.Img = ""; }
                lista.Add(itm);
            }
            cn.Close();
            return lista;
        }

        public List<Habitacion> GetHabitacionesFiltradas(List<Habitacion> Hab, string inicio)
        {
            List<Habitacion> lista = new List<Habitacion>();
            int ext = 0;
            foreach (var dato in Hab)
            {
                ext = this.BuscaDisponibilidadHab(dato.Id, inicio);
                if (ext == 0)
                {
                    Habitacion h = new Habitacion();
                    try { h.Id = dato.Id; } catch (Exception) { h.Id = 0; }
                    try { h.Titulo = dato.Titulo; } catch (Exception) { h.Titulo = ""; }
                    try { h.Descripcion = dato.Descripcion; } catch (Exception) { h.Descripcion = ""; }
                    try { h.Img = dato.Img; } catch (Exception) { h.Img = ""; }
                    lista.Add(h);
                }
            }
            return lista;
        }


        public int BuscaDisponibilidadHab(int id, string inicio)
        {
            int rsl = 0;
            List<int> lista = new List<int>();
            var cn = Cnx.GetConnection();
            cn.Open();
            string query = @"SELECT rs.DETAIL_ID FROM tbl_reserva rs WHERE '" + inicio + @"' BETWEEN rs.ENTRY_DATE AND rs.DEPARTURE_DATE AND rs.ROOM_ID=" + id;
            MySqlCommand cmd = new MySqlCommand(query, cn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int itm = 0;
                try { itm = dr.GetInt32(0); } catch (Exception) { itm = 0; }
                lista.Add(itm);
            }
            cn.Close();
            try { rsl = lista.Count(); } catch (Exception) { rsl = 0; }
            return rsl;
        }




        public Habitacion GetHabitacion(int idt)
        {
            Habitacion result = new Habitacion();
            var cn = Cnx.GetConnection();
            cn.Open();
            string query = @"select 
                            hb.ROOM_ID as 'Id',
                            tp.TYPE_NAME as 'Titulo',
                            hb.ROOM_INFO1 as 'Descripcion',
                            hb.ROOM_INFO2 as 'Descripcion2',
                            hb.ROOM_INFO3 as 'Descripcion3',
                            hb.ROOM_PRICE as 'Costo',
                            tp.SERVICE_PRICE as 'Servicio',
                            tp.NUMBER_PEOPLE as 'Personas',
                            hb.START_AVAILABILITY as 'Inicio',
                            hb.END_AVAILABILITY as 'Fin'
                            from tbl_habitacion hb inner join tbl_tipo_habitacion tp on tp.TYPE_ID=hb.ROOM_TYPE WHERE hb.ROOM_ID=" + idt;

            MySqlCommand cmd = new MySqlCommand(query, cn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                try { result.Id = dr.GetInt32(0); } catch (Exception) { result.Id = 0; }
                try { result.Titulo = dr.GetString(1); } catch (Exception) { result.Titulo = ""; }
                try { result.Descripcion = dr.GetString(2); } catch (Exception) { result.Descripcion = ""; }
                try { result.Descripcion_b = dr.GetString(3); } catch (Exception) { result.Descripcion_b = ""; }
                try { result.Descripcion_c = dr.GetString(4); } catch (Exception) { result.Descripcion_c = ""; }
                try { result.Costo = dr.GetDecimal(5); } catch (Exception) { result.Costo = 0; }
                try { result.Servicio = dr.GetDecimal(6); } catch (Exception) { result.Costo = 0; }
                try { result.Personas = dr.GetInt32(7); } catch (Exception) { result.Personas = 0; }
                try { result.Img = "https://media-cdn.tripadvisor.com/media/photo-s/0e/a2/c2/31/habitacion-hotel-beatriz.jpg"; } catch (Exception) { result.Img = ""; }
                try { result.Img2 = "https://media-cdn.tripadvisor.com/media/photo-s/0e/a2/c2/31/habitacion-hotel-beatriz.jpg"; } catch (Exception) { result.Img = ""; }
                try { result.Img3 = "https://media-cdn.tripadvisor.com/media/photo-s/0e/a2/c2/31/habitacion-hotel-beatriz.jpg"; } catch (Exception) { result.Img = ""; }
                try { result.Img4 = "https://media-cdn.tripadvisor.com/media/photo-s/0e/a2/c2/31/habitacion-hotel-beatriz.jpg"; } catch (Exception) { result.Img = ""; }
                try { result.Img5 = "https://media-cdn.tripadvisor.com/media/photo-s/0e/a2/c2/31/habitacion-hotel-beatriz.jpg"; } catch (Exception) { result.Img = ""; }
                try { result.Caracteristicas = new[] { "Acceso a WIFI Gratis", "Estacionamiento Gratis", "Cuenta con TV 40 pulgadas" }; } catch (Exception) { result.Caracteristicas = new[] { "Ninguino" }; }
                try { result.Inicio = dr.GetString(8); } catch (Exception) { result.Inicio = ""; }
                try { result.Fin = dr.GetString(9); } catch (Exception) { result.Fin = ""; }
            }
            cn.Close();
            return result;
        }

        public string SetUsuario(Usuario data)
        {
            try
            {
                var cn = Cnx.GetConnection();
                cn.Open();
                string query = @"insert into tbl_user 
                            (USER_NAME,USER_PASSWORD,USER_NAMES,USER_APEPAT,USER_APEMAT,USER_TPODOC,USER_NUMDOC,USER_DIRECCION,USER_DISTRITO,USER_PROVINCIA,USER_TELEF,USER_MAIL,ROL_TYPE)
                            VALUES
                            (@userName,@userPass,@nombres,@apePat,@apeMat,@tipoDoc,@numDoc,@direccion,@distrito,@provincia,@telef,@mail,@tipo)";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@userName", data.UserName);
                cmd.Parameters.AddWithValue("@userPass", data.UserPass);
                cmd.Parameters.AddWithValue("@nombres", data.Nombre);
                cmd.Parameters.AddWithValue("@apePat", data.Apellido_Mat);
                cmd.Parameters.AddWithValue("@apeMat", data.Apellido_Pat);
                cmd.Parameters.AddWithValue("@tipoDoc", data.TipoDocument);
                cmd.Parameters.AddWithValue("@numDoc", data.NumDocument);
                cmd.Parameters.AddWithValue("@direccion", data.Direccion);
                cmd.Parameters.AddWithValue("@distrito", data.Distrito);
                cmd.Parameters.AddWithValue("@provincia", data.Provincia);
                cmd.Parameters.AddWithValue("@telef", data.Telefono);
                cmd.Parameters.AddWithValue("@mail", data.Mail);
                cmd.Parameters.AddWithValue("@tipo", 2);

                cmd.ExecuteNonQuery();
                cn.Close();
                return "Done";
            }
            catch (Exception e)
            {
                return "Error:" + e.ToString();
            }

        }

        public Usuario GetSesionUser(Usuario data)
        {
            try
            {
                List<Usuario> lista = new List<Usuario>();
                var cn = Cnx.GetConnection();
                cn.Open();
                string query = @"select
                                USER_ID as 'Id',
                                USER_NAMES as 'Nombre'
                             from tbl_user
                             where USER_NAME=@user AND  USER_PASSWORD=@pass
                            ";

                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@user", data.UserName);
                cmd.Parameters.AddWithValue("@pass", data.UserPass);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Console.WriteLine(dr.GetInt32(0) + "/" + dr.GetString(1));
                    Usuario rs = new Usuario();
                    try { rs.Id = dr.GetInt32(0); } catch (Exception) { rs.Id = 0; }
                    try { rs.Nombre = dr.GetString(1); } catch (Exception) { rs.Nombre = ""; }
                    lista.Add(rs);
                }
                cn.Close();

                return lista.Single();
            }
            catch (Exception)
            {
                return null;
            }

        }
        public string SetTokenUser(int Id, string Token)
        {
            try
            {
                var cn = Cnx.GetConnection();
                cn.Open();
                string query = @"update tbl_user set USER_TOKEN=@tkn where USER_ID=@idt ";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@tkn", Token);
                cmd.Parameters.AddWithValue("@idt", Id);
                cmd.ExecuteNonQuery();
                cn.Close();
                return "Done";
            }
            catch (Exception e)
            {
                return "Error:" + e.ToString();
            }

        }

        public string SetReserva(Reserva data)
        {
            try
            {
                var cn = Cnx.GetConnection();
                cn.Open();
                string query = @"insert into tbl_reserva 
                            (TOTAL_PRICE,ENTRY_DATE,DEPARTURE_DATE,DETAIL_COMMENT,HUESPEDES,ADMIN_ID ,CLIENT_ID ,ROOM_ID ,USER_ID )
                            VALUES
                            (@total,@entrada,@salida,@coment,@huepedes,@admin,@cliente,@room,@user)";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@total", data.Monto);
                cmd.Parameters.AddWithValue("@entrada", data.Inicio);
                cmd.Parameters.AddWithValue("@salida", data.Fin);
                cmd.Parameters.AddWithValue("@coment", "Ninguno");
                cmd.Parameters.AddWithValue("@admin", 1);
                cmd.Parameters.AddWithValue("@cliente", 1);
                cmd.Parameters.AddWithValue("@user", data.Usuario);
                cmd.Parameters.AddWithValue("@room", data.Room);
                cmd.Parameters.AddWithValue("@huepedes", data.Huespedes);
                //cmd.Parameters.AddWithValue("@date", data.Hoy);
                cmd.ExecuteNonQuery();
                cn.Close();
                return "Done";
            }
            catch (Exception e)
            {
                return "Error:" + e.ToString();
            }

        }

        public string VerifyToken(int user, string token)
        {
            try
            {
                List<Usuario> lista = new List<Usuario>();
                var cn = Cnx.GetConnection();
                cn.Open();
                string query = @"SELECT us.USER_ID FROM tbl_user us 
                                WHERE us.USER_ID=@id AND us.USER_TOKEN=@tk 
                            ";

                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", user);
                cmd.Parameters.AddWithValue("@tk", token);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Usuario rs = new Usuario();
                    try { rs.Id = dr.GetInt32(0); } catch (Exception) { rs.Id = 0; }
                    lista.Add(rs);
                }
                cn.Close();

                if (lista.Count() > 0)
                {
                    return "True";
                }
                else
                {
                    return "False";
                }

            }
            catch (Exception)
            {
                return "False";
            }
        }

        public string GestionPagos(Reserva data)
        {
            return "TRUE";
        }

        public Usuario GetMailUser(int Idt)
        {
            try
            {
                List<Usuario> lista = new List<Usuario>();
                var cn = Cnx.GetConnection();
                cn.Open();
                string query = @"SELECT us.USER_ID , us.USER_MAIL,us.USER_NAME,us.USER_APEPAT FROM tbl_user us WHERE us.USER_ID=@idt";
                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@idt", Idt);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Console.WriteLine(dr.GetInt32(0) + "/" + dr.GetString(1));
                    Usuario rs = new Usuario();
                    try { rs.Id = dr.GetInt32(0); } catch (Exception) { rs.Id = 0; }
                    try { rs.Mail = dr.GetString(1); } catch (Exception) { rs.Mail = ""; }
                    try { rs.Nombre = dr.GetString(2); } catch (Exception) { rs.Mail = ""; }
                    try { rs.Apellido_Pat = dr.GetString(3); } catch (Exception) { rs.Mail = ""; }
                    lista.Add(rs);
                }
                cn.Close();

                return lista.Single();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<Reporte> GetReporteReserva(int idt)
        {
            List<Reporte> result = new List<Reporte>();
            var cn = Cnx.GetConnection();
            cn.Open();
            string query = @"SELECT tp.TYPE_NAME,hb.ROOM_INFO1,rs.ENTRY_DATE,rs.DEPARTURE_DATE,rs.HUESPEDES,rs.TOTAL_PRICE 
                            FROM tbl_reserva rs 
                            INNER JOIN tbl_habitacion hb ON hb.ROOM_ID=rs.ROOM_ID 
                            INNER JOIN tbl_tipo_habitacion tp on tp.TYPE_ID=hb.ROOM_TYPE 
                            WHERE USER_ID=" + idt;

            MySqlCommand cmd = new MySqlCommand(query, cn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Reporte rp = new Reporte();
                try { rp.Habitacion = dr.GetString(0); } catch (Exception) { rp.Habitacion = ""; }
                try { rp.Descripcion = dr.GetString(1); } catch (Exception) { rp.Descripcion = ""; }
                try { rp.Entrada = dr.GetString(2); } catch (Exception) { rp.Entrada = ""; }
                try { rp.Salida = dr.GetString(3); } catch (Exception) { rp.Salida = ""; }
                try { rp.Huespedes = dr.GetInt32(4); } catch (Exception) { rp.Huespedes = 0; }
                try { rp.Total = dr.GetDecimal(5); } catch (Exception) { rp.Total = 0; }
                result.Add(rp);
            }
            cn.Close();
            return result;
        }

    }
}
