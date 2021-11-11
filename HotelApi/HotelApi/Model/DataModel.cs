using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Objetos;
using MySql.Data.MySqlClient;

namespace HotelApi.Model
{
    public class DataModel
    {
        ConexionModel Cnx = new ConexionModel();

        public List<Habitacion> GetHabitaciones(string inicio,string fin,int personas)
        {
            List<Habitacion> lista = new List<Habitacion>();
            var cn = Cnx.GetConnection();
            cn.Open();
            string query = @"select hb.ROOM_ID as 'Id',tp.TYPE_NAME as 'Titulo',hb.ROOM_INFO1 as 'Descripcion' 
                                from tbl_habitacion hb inner join tbl_tipo_habitacion tp on tp.TYPE_ID=hb.ROOM_TYPE 
                                WHERE hb.START_AVAILABILITY ='"+ inicio + "' and hb.END_AVAILABILITY='" + fin + "' and tp.NUMBER_PEOPLE="+personas;

            MySqlCommand cmd = new MySqlCommand(query,cn);
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
                try { result.Caracteristicas = new[] { "Acceso a WIFI Gratis", "Estacionamiento Gratis", "Cuenta con TV 40 pulgadas" }; } catch (Exception) { result.Caracteristicas = new[] { "Ninguino"}; }
                try { result.Inicio = dr.GetString(8); } catch (Exception) { result.Inicio = ""; }
                try { result.Fin = dr.GetString(9); } catch (Exception) { result.Fin = ""; }
            }
            cn.Close();
            return result;
        }




    }
}
