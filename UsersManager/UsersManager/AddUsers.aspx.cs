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
            imguImage.ImageUrl = imguImage.ImageUrl.Substring(0, imguImage.ImageUrl.LastIndexOf("/") + 1) + ddluImage.SelectedValue;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            UsersDataContext lq = new UsersDataContext();
            Users user = new Users();
            user.uName = txtuName.Text;
            user.uPwd = txtuPwd.Text;
            user.uRealName = txtuRealName.Text;
            user.uSex = rbluSex.SelectedValue;
            user.uAge = Convert.ToInt16(txtuAge.Text);
            for (int i = 0; i < cbluHobby.Items.Count; i++)
                if (cbluHobby.Items[i].Selected)
                    user.uHobby += cbluHobby.Items[i].Value;
            user.uEmail = txtuEmail.Text;
            user.uQQ = txtuQQ.Text;
            user.uPhone = txtuPhone.Text;
            user.uImage = imguImage.ImageUrl.Substring(0, imguImage.ImageUrl.LastIndexOf("/") + 1);
            user.uRegTime = System.DateTime.Now;
            lq.Users.InsertOnSubmit(user);
            lq.SubmitChanges();
            Response.Redirect("UsersManager.aspx");
        }
    }
}