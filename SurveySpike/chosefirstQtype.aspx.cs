using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibraryControl;
namespace SurveySpike
{
    public partial class chosefirstQtype : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonEnterType_Click(object sender, EventArgs e)
        {
            //Retrieve Selected Text from Dropdown sættes i connect Class
            lblSelectedText.Text = DropDownList1.SelectedItem.Text;
            //Retrieve Selected Value from Dropdown sættes i connect Class
            lblSelectedValue.Text = DropDownList1.SelectedValue; //DISSE skal sætte labelse i evt: ..

            //String med spørgsmålet og spørgsmålstype sættes via metoden "storeQuestions(string,int)" i connect Class
            Connect.storeQuestions(TextBoxWriteQuestion.Text, Convert.ToInt32(DropDownList1.SelectedValue));

            if (DropDownList1.SelectedValue == "0")   // følgende burde vel foregå i connect class!? og/el. 
            {}
            if (DropDownList1.SelectedValue == "1")
            {
                // <asp:ListItem Text="Yes/No questions" Value="1"></asp:ListItem> fra webform!
               Response.Redirect("yesNoQuistions.aspx");           
            }
            if (DropDownList1.SelectedValue == "2")
            {}
            if (DropDownList1.SelectedValue == "3")
            {} 
            if (DropDownList1.SelectedValue == "4")
            {}

            
        }

        
    }
}