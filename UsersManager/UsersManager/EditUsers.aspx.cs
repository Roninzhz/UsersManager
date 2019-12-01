using System;
using System.Linq;

namespace UsersManager
{
    public partial class EditUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["id"] == null)
                Response.Redirect("UsersManager.aspx");
            else
            {
                int id = int.Parse(Request["id"].ToString());
                if (!IsPostBack)
                {
                    UsersDataContext lq = new UsersDataContext();
                    var users = from gt in lq.Users
                                where gt.uID == id
                                select gt;
                    foreach (Users user in users)
                    {
                        txtuName.Text = user.uName;
                        txtuPwd.Text = user.uPwd;
                        txtuRealName.Text = user.uRealName;
                        if (user.uSex == "女")
                            rbluSex.Items[1].Selected = true;
                        else
                            rbluSex.Items[0].Selected = true;
                        txtuAge.Text = user.uAge.ToString();
                        string[] hobbys = user.uHobby.Split(',');
                        for (int i = 0; i < cbluHobby.Items.Count; i++)
                            for (int j = 0; j < hobbys.Length; j++)
                                if (cbluHobby.Items[i].Value == hobbys[j])
                                {
                                    cbluHobby.Items[i].Selected = true;
                                    break;
                                }
                        txtuEmail.Text = user.uEmail;
                        txtuQQ.Text = user.uQQ;
                        txtuPhone.Text = user.uPhone;
                        ddluImage.SelectedValue = user.uImage.Substring(user.uImage.Length - 5, 5);
                        imguImage.ImageUrl = user.uImage;
                    }
                }
            }
        }

        protected void ddluImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            imguImage.ImageUrl = imguImage.ImageUrl.Substring(0, imguImage.ImageUrl.LastIndexOf("/") + 1) + ddluImage.SelectedValue;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request["id"].ToString());
            UsersDataContext lq = new UsersDataContext();
            var users = from gt in lq.Users where gt.uID == id select gt;
            foreach (Users user in users)
            {
                user.uName = txtuName.Text;
                user.uPwd = txtuPwd.Text;
                user.uRealName = txtuRealName.Text;
                user.uSex = rbluSex.SelectedValue;
                user.uAge = Convert.ToInt16(txtuAge.Text);
                user.uHobby = "";
                for (int i = 0; i < cbluHobby.Items.Count; i++)
                {
                    if (cbluHobby.Items[i].Selected)
                        user.uHobby += cbluHobby.Items[i].Value + ",";
                }
                user.uEmail = txtuEmail.Text;
                user.uQQ = txtuQQ.Text;
                user.uPhone = txtuPhone.Text;
                user.uImage = imguImage.ImageUrl.Substring(0, imguImage.ImageUrl.LastIndexOf("/") + 1)+ddluImage.SelectedValue;
                user.uRegTime = System.DateTime.Now;
            }
            lq.SubmitChanges();
            Response.Redirect("UsersManager.aspx");
        }
    }
}