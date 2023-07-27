using System;
using Literals;

namespace Application
{
    /// <summary>
    /// consists two method which one redirects to register page and another one redirects to login page
    /// </summary>
    public partial class RegistrationSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// redirects to register page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegisterPage_Click(object sender, EventArgs e)
        {
            Response.Redirect(StringLiterals.ToRegister);
        }
        /// <summary>
        /// redirects to login page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        protected void btnloginPage_Click(object sender, EventArgs e)
        {
            Response.Redirect(StringLiterals.ToLogin);
        }
    }
}