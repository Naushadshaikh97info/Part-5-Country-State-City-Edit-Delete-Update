using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Statet : System.Web.UI.Page
{
    DataClassesDataContext lnq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_Country();
        fill_data();
    }
    private void fill_Country()
    {
        var id = (from a in lnq_obj.Country_msts
                  select a).ToList();
        ddl_country.DataSource = id;
        ddl_country.DataBind();
        ddl_country.Items.Insert(0, "----Select----");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        lnq_obj.insert_State(Convert.ToInt32(ddl_country.SelectedValue), txt_state.Text);
        lnq_obj.SubmitChanges();
        txt_state.Text = "";                                    
        ddl_country.SelectedIndex = 0;
        fill_data();
    }
    private void fill_data()
    {
        var id = (from a in lnq_obj.State_msts
                  join b in lnq_obj.Country_msts on a.Country_id equals b.intglcode
                  select new
                  {
                      code = a.intglcode,
                      Country_id = b.Country,
                      state = a.State
                  }).ToList();
        GridView1.DataSource = id;
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int code = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value.ToString());
        ViewState["id"] = code;
        var id = (from a in lnq_obj.State_msts
                  where a.intglcode == code
                  select a).Single();
        ddl_country.SelectedValue = id.Country_id.ToString();
        txt_state.Text = id.State;
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        lnq_obj.Delete_State(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
        lnq_obj.SubmitChanges();
        fill_data();
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        lnq_obj.update_State(Convert.ToInt32(ViewState["id"].ToString()), Convert.ToInt32(ddl_country.SelectedValue), txt_state.Text);
        lnq_obj.SubmitChanges();

        fill_data();
        Response.Redirect("State.aspx");
    }
}