using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibraryControl; // References/h-clik/ad-ref og derefter skriv også her!

namespace SurveySpike
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        
        {
            TextBoxSurveyName.Focus();
            
            // Her skal codes, onPageload sequenser"
        }


        
        protected void ButtonMASenter_Click(object sender, EventArgs e)
        {
            Connect.SurveyNameTaken = false;

            Connect.CheckSurvayName(TextBoxSurveyName.Text);
            //(tjecke for givne profil)
            if (!Connect.SurveyNameTaken && TextBoxSurveyName.Text != string.Empty) // el != ""
            {
                Connect.makeNameForRow(TextBoxSurveyName.Text);
                // surveyId oprettes med sequence i db. AccessProfileId hentes, når tjeckes for email/pass!
                Connect.GetSurveyId();  //henter det nye surveyId 
                Response.Redirect("chosefirstQtype.aspx");
            }
            else
            {
                TextBoxSurveyName.Text = "";
                // evt. også Label-info om, at navn i forevejen findes i surveyTabel!
            }
 
            

        }
    }
}