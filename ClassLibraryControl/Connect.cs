using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration; //go read abou it :-)
using System.Data;

namespace ClassLibraryControl
{           // taget fra Marcus - FinalThesis/ ConnectClass.cs
    public class Connect
    {

        public static SqlConnection GetConnection()
        {
            var connectionString = @"data source = .\sqlexpress; integrated security = true; database = Survey";
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }

        public static bool Access // for at gemme en variabel, der holder true/false for email og password 
        { //parameter der senere gir adgang
            get;  //properties der sætter variablen Access (vistnok som i en classe?)
            set;
        }

         public static string AccessAloud  //string der vil indeholde Email(tilLabelPåSiden) fra db 
             //                            if( (email findes i db) && (det er den samme der er skrevet i wbformen));
         {
         get;
         set;
         }


         public static int AccessProfileId  // til oprettelse af ForeignKey i SurvayTabel!
         {
             get;
             set;
         }


         public static string TextBoxWriteQuestionParam  // til at gemme spørgsmålet, som indsættes i questionTabel!
         {
             get;
             set;
         }

         //DENNE Metode Henter og sammenligner data fra webform og ProfileTabel
        public static SqlCommand checkLogin( string parameterEmail, string parameterPass) // Sql conn benyttes for at hente pass og email fra db  // taget fra Marcus - FinalThesis/ ConnectClass.cs
        { // Indeholder metoden til at tjecke om email og pass fra db er det samme som fra Lokalparatrene/webforms textfeldter.
            SqlConnection conn = GetConnection();
            string queryString = "StoPresChreckLogin"; // navn på StoPres  ("queryString" initialiseres for senere at holde query fra stoPres)
            SqlCommand command = new SqlCommand(queryString, conn); // SqlCommand tager som parameter en quiry(en udførende commando=Stored precedier) og en connection.
            command.CommandType = CommandType.StoredProcedure;   // skal vide at det er en stoPress

            SqlParameter parameterEmailFraDBweb = new SqlParameter();  // der lAVES TO "pAREMETER" OBJECTER af sqlParameter classen fra framework
            SqlParameter parameterPassFraDBweb = new SqlParameter(); // Objekterne/instanserne som skal holde data fra DB(kommer fra stoPres) & data fra lokalparametrene (Value)
            parameterEmailFraDBweb.ParameterName = "@pEmail"; // fra SQL api benyttes metode "ParameterName" på instansen/objectet "parameterEmailFraDBweb" 
            parameterPassFraDBweb.ParameterName = "@pPassword"; // Metoden SqlCommand checkLogin, skal vide navnet på Parametrene "her password"" fra db fundet via Stopres.

            parameterEmailFraDBweb.SqlDbType = SqlDbType.VarChar;  
            parameterPassFraDBweb.SqlDbType = SqlDbType.VarChar; // stoPres skal kende datatype
            parameterEmailFraDBweb.Direction = ParameterDirection.Input;
            parameterPassFraDBweb.Direction = ParameterDirection.Input;// stoPres skal vide hvilken vej (fra pro til DB visa versa)
         
            parameterEmailFraDBweb.Value = parameterEmail;  // verdierne fra webform sætter value i enstansen/objecte "parameterEmailFraDBweb"  
            parameterPassFraDBweb.Value = parameterPass;   //
            // metoden command fra aaapi benyttes ! på xxxxxxDBweb, som er en collection af mindst 2 verdier nemlig fx pass fra webform og pass fra DB
            command.Parameters.Add(parameterEmailFraDBweb);
            command.Parameters.Add(parameterPassFraDBweb);
            
            conn.Open();  
            SqlDataReader rdr = command.ExecuteReader(); // Nu benyttes SqldataReader på den nyåbnede Connection "con" Læser i db 
            // ( "ExecuteNonquery(); benyttes hvis vi vil gemme i db)
            while(rdr.Read()){

                try{  // obs det er nu de rigtige entitetsnavne fra db, der skal benyttes 
                    if(rdr["Email"].ToString().Equals(parameterEmail) && rdr["Password"].ToString().Equals(parameterPass))
                    {                       
                        Access = true;// sætter parameter der senere gir adgang
                        AccessAloud = rdr["Email"].ToString(); // sætter string indeholdende Email fra db
                        //HENTER ProfileId og sætte parameter AccessProfileId
                        AccessProfileId = Convert.ToInt32(rdr["ProfileID"].ToString()); // til oprettelse af ForeignKey i SurvayTabel!
                     }
                       else
                    {
                        Access = false;
                    }
                }
                catch (Exception ex) // try/catch
                {
                    Console.WriteLine(ex.Message);
                    AccessAloud = "Database Error";  
                    Access = false;
                }
            }
            rdr.Close();
            conn.Close();
            return command;
        }



      
        //DENNE Metode er til at tjecke om opretter-profilen i forevejen har survey med dette navn!
        public static bool SurveyNameTaken
        {
            get;
            set;
        }
    
        public static void CheckSurvayName(string newSurVeyName)  // 
        {
            SqlConnection conn = GetConnection();
            string queryString = "checkSurveyNameSP"; // navn på stored procedure!
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = CommandType.StoredProcedure;
/*
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@newSurVeyName";//
            parameter.SqlDbType = SqlDbType.VarChar;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = newSurVeyName;//
            command.Parameters.Add(parameter);
*/
            SqlParameter parameter1 = new SqlParameter(); 
            SqlParameter parameter2 = new SqlParameter(); 
            parameter1.ParameterName = "@newSurVeyName";
            parameter2.ParameterName = "@pProfileID";

            parameter1.SqlDbType = SqlDbType.VarChar;
            parameter2.SqlDbType = SqlDbType.Int; // stoPres skal kende datatype
            parameter1.Direction = ParameterDirection.Input;
            parameter2.Direction = ParameterDirection.Input;// stoPres skal vide hvilken vej (fra pro til DB visa versa)

            parameter1.Value = newSurVeyName;  // verdierne fra webform sætter value i enstansen/objecte "parameterEmailFraDBweb"  
            parameter2.Value = AccessProfileId;   // fra global parameter AccessProfileId
            // metoden command fra aaapi benyttes ! på xxxxxxDBweb, som er en collection af mindst 2 verdier nemlig fx pass fra webform og pass fra DB
            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);

            conn.Open();
            SqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                if (newSurVeyName == rdr["SurveyNavn"].ToString() && AccessProfileId == Convert.ToInt32(rdr["ProfileID"].ToString()))
                {
                    SurveyNameTaken = true;
                }
            }
        }
 

        //DENNE Metode er til at, GEMME EN ROW I SurveyTabel
        public static SqlCommand makeNameForRow(string pSurveyNavn) // fra webform/textboxe
        {
            SqlConnection conn = GetConnection();
            conn.Open();
            string queryString = "spAddSurvey";  // Opret række i Survey tabel! via SP
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter profileId = command.Parameters.Add("@profileId", SqlDbType.Int);
            SqlParameter surveyNavn = command.Parameters.Add("@surveyNavn", SqlDbType.VarChar);

            profileId.Value = AccessProfileId;
            surveyNavn.Value = pSurveyNavn;

            command.ExecuteNonQuery();
            conn.Close();
            return command;            
            // Skal evt. returnere PrimaryKey value fra Surveytabel, så denne kan bruges til forraignkey i
            // QuestionTabel og de spørgsmål(rows) der nu oprettes der, inden man endeligt færdiggør Surveyen !
        }


        //DENNE Metode Gemmer i QuestionTable
        //evt. variabler her
        public static String storeQuestions(int surveyId, int profileId, string surveyNavn) // fra webform/textboxe
        {
            SqlConnection conn = GetConnection();
            conn.Open();

            return "something";
        } 

        //DENNE Metode Gemmer i ProfileTable
        public int profileId; // alle disse sættes i "Opret.aspx.cs" (eller hvad marcus har valgt at kalde webform til profilOprettelse!
        public string Navn;
        public string Butik;
        public string Adresse;
        public string Password;
        public int Count = 0;
        public string Email;

        public static string storeProfile(/*int profileId */string Navn, string Butik, string Adresse, string Password, int Count, string Email) // fra webform/textboxe
        {
            SqlConnection conn = GetConnection();
            conn.Open();
            // metode til at oprette en række i profileTabel i Database med Sequence PrimaryKey og Navn på Bruger!
            //profileId = profileId; // Her kan man vel også sætte lokalvariabel til brug ved oprettelse af surveyTabel, Når man opretter en survay.
            return "profileId"; // Eller Skal vi returnere PrimaryKey value fra profileTabel, så denne kan bruges til forraignkey i surveyTabel, Når man opretter en survay.
        }

        /*
          ALTER PROC spAddUser
	      @pNavn VARCHAR(50),
	      @pAdresse VARCHAR(50),
	      @pPassword VARCHAR(64),
	      @pEmail VARCHAR(50)
       AS

        INSERT INTO dbo.ProfileTabel
	        (Navn, Adresse, Password, Email)
        VALUES
	        (@pNavn, @pAdresse, @pPassword, @pEmail);
        */
        public static void AddUser(string pNavn, string pAdresse, string pPassword, string pEmail)
        {
            SqlConnection conn = GetConnection();
            string queryString = "spAddUser";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter Navn = command.Parameters.Add("@pNavn", SqlDbType.VarChar);
            SqlParameter Adresse = command.Parameters.Add("@pAdresse", SqlDbType.VarChar);
            SqlParameter Password = command.Parameters.Add("@pPassword", SqlDbType.VarChar);
            SqlParameter Email = command.Parameters.Add("@pEmail", SqlDbType.VarChar);

            Navn.Value = pNavn;
            Adresse.Value = pAdresse;
            Password.Value = pPassword;
            Email.Value = pEmail;

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
         /*
         CREATE PROC spAddShopOwner
	        @pNavn VARCHAR(50),
	        @pButik VARCHAR(50),
	        @pAdresse VARCHAR(50),
	        @pPassword VARCHAR(64),
	        @pEmail VARCHAR(50)
        AS

        INSERT INTO dbo.ProfileTabel
	        (Navn, Butik, Adresse, Password, Email)
        VALUES
	        (@pNavn, @pButik, @pAdresse, @pPassword, @pEmail);
         */
        public static void AddShopOwner(string pNavn, string pButik, string pAdresse, string pPassword, string pEmail)
        {
            SqlConnection conn = GetConnection();
            string queryString = "spAddUser";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter Navn = command.Parameters.Add("@pNavn", SqlDbType.VarChar);
            SqlParameter Butik = command.Parameters.Add("@pButik", SqlDbType.VarChar);
            SqlParameter Adresse = command.Parameters.Add("@pAdresse", SqlDbType.VarChar);
            SqlParameter Password = command.Parameters.Add("@pPassword", SqlDbType.VarChar);
            SqlParameter Email = command.Parameters.Add("@pEmail", SqlDbType.VarChar);

            Navn.Value = pNavn;
            Butik.Value = pButik;
            Adresse.Value = pAdresse;
            Password.Value = pPassword;
            Email.Value = pEmail;

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}



//Dokumentation:: Concept: programmets formål.Consept, Mening.
//Procedure:: Hvordan man gør, evt. hvilke sekventielle handlinger det medfører rent teknisk., evt. Classer, Domæner.
//Parametre i classerne; tech, design.
// @Sven
        