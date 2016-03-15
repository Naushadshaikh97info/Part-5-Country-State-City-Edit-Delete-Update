using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DataClassesDataContext lnq_obj = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;
        fill_data();
    }
    private void fill_data()
    {
        var id = (from a in lnq_obj.Country_msts
                  select new
                  {
                      code = a.intglcode,
                      country = a.Country
                  }).ToList();  
        GridView1.DataSource = id;
        GridView1.DataBind();
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        lnq_obj.insert_Country(txt_country.Text);
        lnq_obj.SubmitChanges();
        txt_country.Text = "";
        fill_data();
        
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int code = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value.ToString());
        ViewState["id"] = code;
        var id = (from a in lnq_obj.Country_msts
                  select a).Single();
        txt_country.Text = id.Country;
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        lnq_obj.Delete_Country(Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()));
        lnq_obj.SubmitChanges();
        fill_data();
    }
    protected void btn_update_Click(object sender, EventArgs e)
    {
        lnq_obj.update_Country(Convert.ToInt32(ViewState["id"].ToString()), txt_country.Text);
        lnq_obj.SubmitChanges();

        fill_data();
        Response.Redirect("Country.aspx");
            
    }
}
