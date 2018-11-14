using Entities;
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

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        _getData();
    }
    //保存修改
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var id = Guid.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
        using (var context = new DataContext.StuDBContext())
        {
            //查询出要修改这条记录
            var p = context.Students.Find(id);
            //读出gridview中用户编辑的字段，给每个允许修改的实体属性赋值
            //获取用户编辑的这一行
            var row = GridView1.Rows[e.RowIndex];
            var sn = (row.Cells[0].Controls[0] as TextBox).Text.Trim();
            var name = (row.Cells[1].Controls[1] as TextBox).Text.Trim();
            var phone = (row.Cells[2].Controls[2] as TextBox).Text.Trim();
            var department = (row.Cells[3].Controls[3] as TextBox).Text.Trim();
            p.StudentCode = sn;
            p.Name = name;
            p.Phone = phone;
            p.Department = context.Departments.Single(x => x.Name == department);
            context.SaveChanges();
        }
        GridView1.EditIndex = -1;
        _getData();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        _getData();
    }

    protected string GetName(object obj)
    {
        if (obj !=null)
            return((Department))
    }


}