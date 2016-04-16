using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibraryControl; // References/h-clik/ad-ref og derefter skriv også her!

namespace SurveySpike
{
    public partial class index : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Connect.Access = false;
            TextBoxPass.TextMode = TextBoxMode.Password; // her deffineres"mit password det står med prikker"
        }

        protected void ButtonEnter_Click(object sender, EventArgs e)
        {
            Response.Redirect("account.aspx");
        }

        }
  }
