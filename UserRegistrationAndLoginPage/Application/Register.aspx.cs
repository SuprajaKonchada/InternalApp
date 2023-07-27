using System;
using System.Data.SqlClient;
using BusinessModel;
using Literals;

namespace Application
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { }
        /// <summary>
        ///  Registers using the details provided
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            BALAuthentication BALAuth = new BALAuthentication();
            BALValidations BALValid = new BALValidations();
            string username = txtUsername.Text.Trim().ToLower();
            string email = txtEmail.Text.Trim().ToLower();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            if((BALValid.IsValidUsername(username) && BALValid.IsValidEmail(email) && BALValid.IsValidPassword(password)) == true)
            {
                //checks whether password matches or not
                if (BALAuth.IsPasswordMatch(password, confirmPassword) == false)
                {
                    lblMessage.Text = StringLiterals.NotMatch;
                    lblMessage.Visible = true;
                    return;
                }
            }
            else
            {
                lblMessage.Text = StringLiterals.InvalidInformation;
                lblMessage.Visible = true;
                return;
            }
            
            string encryptedPassword = BALAuth.EncryptPassword(password);

            try
            {
                BALAuth.InsertUserInfo(username, email, encryptedPassword);
                Response.Redirect(StringLiterals.ToRegSuccess);
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
        /// <summary>
        /// button which navigates to login page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnloginPage_Click(object sender, EventArgs e)
        {
            Response.Redirect(StringLiterals.ToLogin);
        }
    }
}
