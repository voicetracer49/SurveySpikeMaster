using ClassLibraryControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SurveySpike
{
    public partial class yesNoQuistions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TextBoxSurveyName.Focus();

            // Her skal codes, onPageload sequenser"
        }
        protected void ButtonEnterRightAnswar_Click(object sender, EventArgs e)
            {
                Connect.GetQuestionId(); //QuestionId hentes via metoden GetQuestionId() i connect!!!

                if (RadioButton1.Checked == true)
                {
                    
                    Connect.setCorrectnes(1);
                    Response.Redirect("StoreQuestion.aspx");
                    //ToSetActualQuestion.Text = "Ja";
                }
                else if (RadioButton2.Checked == true)
                {
                    Connect.setCorrectnes(0);
                    Response.Redirect("StoreQuestion.aspx");
                    //ToSetActualQuestion.Text = "Nej";
                }
                else
                {
                    ToSetActualQuestion.Text = "Vælg";
                }
            }
        
       


    }

}