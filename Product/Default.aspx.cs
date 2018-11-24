using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataContext;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (var context = new ProductContext())
            {
                var product = context.Catagory.ToList();
                DropDownList1.DataSource = product;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "ID";
                DropDownList1.DataBind();
            
           
                var list = context.Cominfo
                    .Select(x => new
                    {
                        SN = x.SN,
                        Name = x.Name,
                        DSCN = x.DSCN,
                        Catagory = x.Catagory.Name
                    }).Take(20).ToList();
                GridView1.DataSource = list;
                GridView1.DataBind();

            }
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var id = DropDownList1.SelectedValue;
        using (var context = new ProductContext())
        {
            var list = context.Cominfo.Where(x => x.Catagory.ID == id)
                .Select(x => new
                {
                    SN = x.SN,
                    Name = x.Name,
                    DSCN = x.DSCN,
                    Catagory = x.Catagory.Name
                }).Take(20).ToList();
            GridView1.DataSource = list;
            GridView1.DataBind();

        }
    }
}