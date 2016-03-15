using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Information : System.Web.UI.Page
{
    DataClassesDataContext lnq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_country();
        fill_data();
    }
    private void fill_country()
    {
        var id = (from a in lnq_obj.Country_msts
                  select a).ToList();
        ddl_country.DataSource = id;
        ddl_country.DataBind();
        ddl_country.Items.Insert(0, "-----Select-----");
        
    }
    private void fill_state()
    {
        var id = (from a in lnq_obj.State_msts
                  where a.Country_id == Convert.ToInt32(ddl_country.SelectedValue)
                  select a).ToList();
        ddl_state.DataSource = id;
        ddl_state.DataBind();
        ddl_state.Items.Insert(0, "----Select-----");
    }
    private void fill_city()
    {
        var id = (from a in lnq_obj.City_msts
                  where a.State_id == Convert.ToInt32(ddl_state.SelectedValue)
                  select a).ToList();
        ddl_city.DataSource = id;
        ddl_city.DataBind();

    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        lnq_obj.insert_information(Convert.ToInt32(ddl_country.SelectedValue), Convert.ToInt32(ddl_state.SelectedValue), Convert.ToInt32(ddl_city.SelectedValue));
        lnq_obj.SubmitChanges();
        ddl_country.SelectedIndex = 0;
        ddl_state.SelectedIndex = 0;
        ddl_city.SelectedIndex = 0;
        fill_data();
    }
    protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_state();
    }
    protected void ddl_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill_city();
    }
    private void fill_data()
    {
        var id = (from a in lnq_obj.Information_msts
                  join b in lnq_obj.Country_msts on a.Country_id equals b.intglcode
                  join c in lnq_obj.State_msts on a.State_id equals c.intglcode
                  join d in lnq_obj.City_msts on a.City_id equals d.intglcode
                  select new
                  {
                      code = a.intglcode,
                      country_id = b.Country,
                      state_id = c.State,
                      city_id = d.City
                  }).ToList();
        GridView1.DataSource = id;
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int code = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value.ToString());
        ViewState["id"] = code;
        var id = (from a in lnq_obj.Information_msts
                  where a.intglcode == code
                  select a).Single();
        ddl_country.SelectedValue = id.Country_id.ToString();
        fill_country();
        ddl_state.SelectedValue = id.State_id.ToString();
        fill_state();
        ddl_city.SelectedValue = id.City_id.ToString();
        fill_city();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        lnq_obj.Delete_Information (Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
        lnq_obj.SubmitChanges();
        fill_data();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        lnq_obj.update_information(Convert.ToInt32(ViewState["id"].ToString()), Convert.ToInt32(ddl_country.SelectedValue), Convert.ToInt32(ddl_state.SelectedValue),Convert.ToInt32(ddl_city.SelectedValue));
        lnq_obj.SubmitChanges();

        fill_data();
        Response.Redirect("Information.aspx");

    }
}