using BusinessModel;
using Literals;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Application
{
    public partial class ForgotPassword : System.Web.UI.Page

    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// reset's the password of the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            BALAuthentication BALAuth = new BALAuthentication();
            string username = txtUsername.Text.Trim().ToLower();
            string newpassword = txtPassword.Text;
            string confirmPassword = txtConfirmpwd.Text;
            if(BALAuth.IsPasswordMatch(newpassword, confirmPassword)==false)
            {
                lblMessage.Text = StringLiterals.NotMatch;
                lblMessage.Visible = true;
                return;
            }
            string encryptedPassword = BALAuth.EncryptPassword(newpassword);
            try
            {
                BALAuth.UpdateInfo(username, encryptedPassword);
                Response.Redirect(StringLiterals.ToLogin);
            }
            catch (SqlException ex)
            {
                // Handle specific SQL Server exceptions here
                lblMessage.Text = StringLiterals.DataBaseError + ex.Message;
                lblMessage.Visible = true;
            }
            catch (Exception ex)
            {
                // Handle other general exceptions here
                lblMessage.Text = StringLiterals.UnexpectedError + ex.Message;
                lblMessage.Visible = true;
            }
        }
    }
}
