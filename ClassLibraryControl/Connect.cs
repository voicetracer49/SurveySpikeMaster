using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration; //go read abou it :-)
using System.Data;

namespace ClassLibraryControl
{
    public class Connect
    {

        public static SqlConnection GetConnection()
        {
            var connectionString = @"data source = .\sqlexpress; integrated security = true; database = ExamDB";
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }

        public static bool Access // for at gemme en variabel, der holder true/false for email og password
        {
            get;
            set;
        }

        public static SqlCommand checkLogin( string parameterEmail, string parameterPass) // Sql conn benyttes for at hente pass og email fra db
        {
            SqlConnection conn = GetConnection();
            string queryString = "StoPresChreckLogin"; // navn på StoPres
            SqlCommand command = new SqlCommand(queryString, conn); // SqlCommand tager som parameter en quiry(en udførende commando=Stored precedier) og en connection.
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterEmailFraDB = new SqlParameter();
            SqlParameter parameterPassFraDB = new SqlParameter(); // parametre som skal holde data fra DB(kommer fra stoPres)
            parameterEmailFraDB.ParameterName = "StoPresEmail"; 
            parameterPassFraDB.ParameterName = "StoPresPass"; // Parametrene fra db

            parameterEmailFraDB.SqlDbType = SqlDbType.VarChar;
            parameterPassFraDB.SqlDbType = SqlDbType.VarChar; // stoPres skal kende datatype
            parameterEmailFraDB.Direction = ParameterDirection.Input;
            parameterPassFraDB.Direction = ParameterDirection.Input;// stoPres skal vide hvilken vej (fra pro til DB)
          

        }
    }
}
