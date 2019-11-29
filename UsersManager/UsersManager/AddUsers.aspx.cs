using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsersManager
{
    public partial class AddUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ddluImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            imguImage.ImageUrl = imguImage.ImageUrl.Substring(0, imguImage.ImageUrl.LastIndexOf("/") + 1) + ddluImage.SelectedValue;      }
    }
}