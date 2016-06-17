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
        { //parameter1 der senere gir adgang
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


        
         //DENNE Metode Henter og sammenligner data fra webform og ProfileTabel
        public static SqlCommand checkLogin( string parameterEmail, string parameterPass) // Sql conn benyttes for at hente pass og email fra db  // taget fra Marcus - FinalThesis/ ConnectClass.cs
        { // Indeholder metoden til at tjecke om email og pass fra db er det samme som fra Lokalparatrene/webforms textfeldter.
            SqlConnection conn = GetConnection();
            string queryString = "StoPresChreckLogin"; // navn på StoPres  ("queryString" initialiseres for senere at holde query fra stoPres)
            SqlCommand command = new SqlCommand(queryString, conn); // SqlCommand tager som parameter1 en quiry(en udførende commando=Stored precedier) og en connection.
            command.CommandType = CommandType.StoredProcedure;   // skal vide at det er en stoPress Vigtigt &&Her defineres måske hvis quetes/link/orm/mySql ect..

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
                        Access = true;// sætter parameter1 der senere gir adgang
                        AccessAloud = rdr["Email"].ToString(); // sætter string indeholdende Email fra db
                        //HENTER ProfileId og sætte parameter1 AccessProfileId
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

            SqlParameter parameter1 = new SqlParameter(); 
            SqlParameter parameter2 = new SqlParameter(); 
            parameter1.ParameterName = "@newSurVeyName";
            parameter2.ParameterName = "@pProfileID";

            parameter1.SqlDbType = SqlDbType.VarChar;
            parameter2.SqlDbType = SqlDbType.Int; // stoPres skal kende datatype
            parameter1.Direction = ParameterDirection.Input;
            parameter2.Direction = ParameterDirection.Input;// stoPres skal vide hvilken vej (fra pro til DB visa versa)

            parameter1.Value = newSurVeyName;  // verdierne fra webform sætter value i enstansen/objecte "parameterEmailFraDBweb"  
            parameter2.Value = AccessProfileId;   // fra global parameter1 AccessProfileId
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
        public static void makeNameForRow(string pSurveyNavn) // fra webform/textboxe
        {
            SqlConnection conn = GetConnection();
           
            string queryString = "spAddSurvey";  // Opret række i Survey tabel! via SP
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter profileId = command.Parameters.Add("@profileId", SqlDbType.Int);
            SqlParameter surveyNavn = command.Parameters.Add("@surveyNavn", SqlDbType.VarChar);

            profileId.Value = AccessProfileId;
            surveyNavn.Value = pSurveyNavn;
            conn.Open();

            command.ExecuteNonQuery();
            conn.Close();
            NewpSurveyNavn = pSurveyNavn;
            
            //return command;
           // GetSurveyId(); kaldes istedet når du slipper enter knappen  i Profile.asps.cs og opretter surveyNavn
            // Skal evt. returnere PrimaryKey value fra Surveytabel, så denne kan bruges til forraignkey i
            // QuestionTabel og de spørgsmål(rows) der nu oprettes der, inden man endeligt færdiggør Surveyen !
        }

        public static string NewpSurveyNavn
        {
            get;
            set;
        }


        //DENNE Metode finder SurveyId hvor ProfileId = surveyNavn. 
       
//Refactor        
        public static void GetSurveyId()
        {
            SqlConnection conn = GetConnection();
            string queryString = "checkSurveyNameSP"; // navn på stored procedure!
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            SqlParameter parameter2 = new SqlParameter();
            parameter1.ParameterName = "@newSurVeyName";
            parameter2.ParameterName = "@pProfileID";
            
            parameter1.SqlDbType = SqlDbType.VarChar;
            parameter2.SqlDbType = SqlDbType.Int; // stoPres skal kende datatype
            parameter1.Direction = ParameterDirection.Input;
            parameter2.Direction = ParameterDirection.Input;//

            parameter1.Value = NewpSurveyNavn;  // fra global parameter1 NewpSurveyNavn
            parameter2.Value = AccessProfileId;   // fra global parameter1 AccessProfileId
            // metoden command fra aaapi benyttes ! på xxxxxxDBweb, som er en collection af mindst 2 verdier nemlig fx pass fra webform og pass fra DB
            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);
            
            conn.Open();
            SqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                if (NewpSurveyNavn == rdr["SurveyNavn"].ToString() && AccessProfileId == Convert.ToInt32(rdr["ProfileId"].ToString()))
                {
                    SurveyId = Convert.ToInt32(rdr["SurveyId"]);
                }
            }
        }

        public static int SurveyId  // til oprettelse af ForeignKey i QuestionTabel!
        {
            get;
            set;
        }

       public static int pCorrect
       {
           get;
           set;
       }
     


        //DENNE Metode Gemmer i Spørgsmålet og spgsType i QuestionTable 
        public static SqlCommand storeQuestions(string pTextBoxQuestion, int pQuistionType) // fra webform/textboxe chosefirstQType.aspx
        {
            pCorrect = 0; // sætter int pCorrect = 0; Og henviser dermed til at ingen SpørgsmålsType er valgt , endnu!

            SqlConnection conn = GetConnection();
            string queryString = "spAddQuestion";
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = CommandType.StoredProcedure;
            // sequence param laver QuestionId [Not Null] i QuestionTabel
            SqlParameter Survey = command.Parameters.Add("@SurveyId", SqlDbType.Int);
            SqlParameter TextBoxQuestion = command.Parameters.Add("@TextBoxQuestion", SqlDbType.VarChar);
            SqlParameter QuistionType = command.Parameters.Add("@QuistionType", SqlDbType.Int);
            SqlParameter Correct = command.Parameters.Add("@Correct", SqlDbType.Int);
             
            
            // og som anvist øverst sættes til 0
            // vi benytter "yesNoQuistions.aspx" i vores SPIKE, pga vi kun behandler "Yes,No" spørgsmål"
            conn.Open();

            Survey.Value = SurveyId; // SurveyId [Not Null] er gemt globalt her i Classen connect
            TextBoxQuestion.Value = pTextBoxQuestion;
            QuistionType.Value = pQuistionType;  // pQuietionType [Not Null] angives i webform/textboxe chosefirstQType.aspx   og via switch angiver hvilken TABEL vi gemmer i.
            Correct.Value = pCorrect; // pCorrect Korrekt [Null], angives her til 0 øverst!, og senere i webform/textboxe i aspx siderne for de nævnte spørgsmålTyper.aspx 
            
            command.ExecuteNonQuery();
            conn.Close();
            pQuestion = pTextBoxQuestion; // Question oprettet i QuestionTabel(og SurveyId) sættes til at finde QuestionId 
            return command;
                       
        }
        public static string pQuestion // Question oprettet i QuestionTabel(og SurveyId), til at sætte correctnes 
        {
            get;
            set;
        }

        public static int pQuestionId  ////!!! kunne også benyttes ved Multible question choyse, til at gemme flere svarmuligheder I DataTabel(hvad skal Dén holde?)
        {                               //  < << 777!!!   Hvis Ikke vi bare lave en ny row, med samme 

            get;
            set;
        }

        public static void GetQuestionId()  // QuestionId til setCorrectnes()
        {
            SqlConnection conn = GetConnection();
            string queryString = "SPgetQuestionId"; // navn på stored procedure!
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            SqlParameter parameter2 = new SqlParameter();
            parameter1.ParameterName = "@Question"; // @Question VARCHAR(50)
            parameter2.ParameterName = "@pSurveyId";// @pSurveyID int,  

            parameter1.SqlDbType = SqlDbType.VarChar;
            parameter2.SqlDbType = SqlDbType.Int; // stoPres skal kende datatype
            parameter1.Direction = ParameterDirection.Input;
            parameter2.Direction = ParameterDirection.Input;

            parameter1.Value = pQuestion;  // fra global parameter1 ""QUESTION
            parameter2.Value = SurveyId;   // fra global parameter1 AccessProfileId
            // metoden command fra aaapi benyttes ! på xxxxxxDBweb, som er en collection af mindst 2 verdier nemlig fx pass fra webform og pass fra DB
            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);
             
            conn.Open();
            SqlDataReader rdr = command.ExecuteReader();

            while (rdr.Read())
            {
                if (pQuestion == rdr["Question"].ToString() && SurveyId == Convert.ToInt32(rdr["SurveyId"].ToString()))
                {
                    pQuestionId = Convert.ToInt32(rdr["QuestionId"]);  
                    // her vil blive flere en én ud, når multiquestion spørgsmål, da flere rows m samme SurveyId og Question ???
                    // Hvordan sikre, at jeg har gang i "nuværende" Spørgsmål ??
                }
            }
        }
       
        public static void setCorrectnes(int pSetcorrect)  // ja/nej 0-2, skala 0-4, mutible questions 0-n 
        {
            SqlConnection conn = GetConnection();
            string queryString = "spSetCorrectnes"; // navn på stored procedure!
            SqlCommand command = new SqlCommand(queryString, conn);
            command.CommandType = CommandType.StoredProcedure;
            
            // sequence param sætter Correct [Null] i QuestionTabel

            SqlParameter Survey = command.Parameters.Add("@pQuestionId", SqlDbType.Int);
            SqlParameter SurveyQ = command.Parameters.Add("@Question", SqlDbType.VarChar);
            SqlParameter pCorrect = command.Parameters.Add("@pCorrect", SqlDbType.Int);

            conn.Open();

            Survey.Value = pQuestionId;
            SurveyQ.Value = pQuestion;
            pCorrect.Value = pSetcorrect;
            

            command.ExecuteNonQuery();
            conn.Close();
           
        }


       
      
    }
}



//Dokumentation:: Concept: programmets formål.Consept, Mening.
//Procedure:: Hvordan man gør, evt. hvilke sekventielle handlinger det medfører rent teknisk., evt. Classer, Domæner.
//Parametre i classerne; tech, design.
// @Sven