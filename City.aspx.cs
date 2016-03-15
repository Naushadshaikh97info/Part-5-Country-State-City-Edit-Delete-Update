using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class City : System.Web.UI.Page
{
    DataClassesDataContext lnq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_State();
        fill_data();
        
    }
    private void fill_State()
    {
        var id = (from a in lnq_obj.State_msts
                  select a).ToList();
        ddl_State.DataSource = id;
        ddl_State.DataBind();
        ddl_State.Items.Insert(0, "----Select----");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        lnq_obj.insert_city(Convert.ToInt32(ddl_State.SelectedValue), txt_city.Text);
        lnq_obj.SubmitChanges();
        txt_city.Text = "";
        ddl_State.SelectedIndex = 0;
        fill_data();
    }
    private void fill_data()
    {
        var id = (from a in lnq_obj.City_msts
                  join b in lnq_obj.State_msts on a.State_id equals b.intglcode
                  select new
                  {
                      code = a.intglcode,
                      state_id = b.State,
                      city = a.City
                  }).ToList();
        GridView1.DataSource = id;
        GridView1.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int code = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value.ToString());
        ViewState["id"] = code;
        var id = (from a in lnq_obj.City_msts
                  where a.intglcode == code
                  select a).Single();
        ddl_State.SelectedValue = id.State_id.ToString();
        txt_city.Text = id.City;
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        lnq_obj.Delete_City(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
        lnq_obj.SubmitChanges();
        fill_data();
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        lnq_obj.update_city(Convert.ToInt32(ViewState["id"].ToString()), Convert.ToInt32(ddl_State.SelectedValue), txt_city.Text);
        lnq_obj.SubmitChanges();
        fill_data();
        Response.Redirect("City.aspx");
    }
}