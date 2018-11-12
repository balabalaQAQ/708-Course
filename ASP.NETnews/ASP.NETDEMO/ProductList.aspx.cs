using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            _getData();

    }
    private void _getData()
    {
        using (var context = new DataContext.StuDBContext())
        {
            var list = context.Students.OrderBy(x=>x.StudentCode).ToList();
            
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new DataContext.StuDBContext())
        {
            //删除这条记录
            var delstudent = context.Students.Find(id);
            context.Students.Remove(delstudent);
            context.SaveChanges();

        }
        _getData();
    }



    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        _getData();
    }
}