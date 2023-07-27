using System;
using BusinessLayer;
using Literals;

namespace Application
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { }
        /// <summary>
        /// Login's to the Mainpage using the information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            UserBusinessLogic userBusinessLogic = new UserBusinessLogic();
            //authendicates the username and password
            if (userBusinessLogic.AuthenticateUser(username, password))
            {
                Response.Redirect(StringLiterals.ToMainPage);
            }
            else
            {
                lblMessage.Text = StringLiterals.InvalidDetails;
                lblMessage.Visible = true;
            }
        }
        /// <summary>
        /// redirects to the register page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegisterPage_Click(object sender, EventArgs e)
        {
            Response.Redirect(StringLiterals.ToRegister);
        }
    }
}
