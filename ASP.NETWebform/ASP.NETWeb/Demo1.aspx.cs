using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demo1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var text1 = TextBox1.Text;
        Response.Redirect("~/demo2.aspx?t"+text1);
    }
}