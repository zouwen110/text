using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class pro_updt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
   
        if (!IsPostBack)
        {

            string sql;
            sql = "select * from alllb order by id desc";
            getdata2(sql);
          //  string sql;
            sql = "select * from allpro where id=" + Request.QueryString["id"].ToString().Trim() ;
            getdata(sql);
        }
    }

    private void getdata2(string sql)
    {
        DataSet result = new DataSet();
        result = new Class1().hsggetdata(sql);
        if (result != null)
        {
            if (result.Tables[0].Rows.Count > 0)
            {
                int k = 0;
                for (k = 0; k < result.Tables[0].Rows.Count; k++)
                {
                    lb.Items.Add(result.Tables[0].Rows[k]["lb"].ToString().Trim());
                }

            }
        }
    }

    private void getdata(string sql)
    {
        DataSet result = new DataSet();
        result = new Class1().hsggetdata(sql);
        if (result != null)
        {
            if (result.Tables[0].Rows.Count > 0)
            {
                mc.Text = result.Tables[0].Rows[0]["mc"].ToString().Trim();
                lb.Text = result.Tables[0].Rows[0]["lb"].ToString().Trim();
                je.Text = result.Tables[0].Rows[0]["price1"].ToString().Trim();
                je2.Text = result.Tables[0].Rows[0]["price2"].ToString().Trim();
                content.Text = result.Tables[0].Rows[0]["content"].ToString().Trim();
                
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string sql;
        
        sql = "update allpro set mc='" + mc.Text.ToString().Trim() + "',lb='" + lb.SelectedItem.ToString().Trim() + "',price1=" + je.Text.ToString().Trim() + ",price2=" + je2.Text.ToString().Trim() + ",content='" + content.Text.ToString().Trim() + "' where id=" + Request.QueryString["id"].ToString().Trim();
        int result;
        result = new Class1().hsgexucute(sql);
        if (result == 1)
        {
            Response.Write("<script>javascript:alert('修改成功');</script>");
        }
        else
        {
            Response.Write("<script>javascript:alert('系统错误');</script>");
        }
    }
}
