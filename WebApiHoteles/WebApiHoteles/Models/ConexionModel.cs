using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WebApiHoteles.Models
{
    public class ConexionModel
    {
        public MySqlConnection GetConnection()
        {
            //string server = "localhost";
            //string database = "upc_hotel";
            //string user = "root";
            //string password = "";
            //string port = "3306";
            //string sslM = "none";

            string server = "localhost";
            string database = "app66744_hoteles";
            string user = "app66_app66744";
            string password = "lX52b_d1";
            string port = "3306";
            string sslM = "none";

            string connString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);
            MySqlConnection cn = new MySqlConnection(connString);
            return cn;
        }
    }
}
