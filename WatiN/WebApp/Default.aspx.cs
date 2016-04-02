using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        //do some logic to check if the nickname is already used.
        //i'll return true for all nicknames but "gsus"
        if (txtNickName.Text != "gsus")
            lblResult.Text = "The nickname is already in use";
        else
            lblResult.Text = "The nickname is not used";
    }
}
