namespace Literals
{
    /// <summary>
    /// these are all the string literals used in the Application 
    /// </summary>
    public static class StringLiterals
    {
        public static string NotMatch = "Password doesn't Match";
        public static string ToRegSuccess = "RegistrationSuccess.aspx";
        public static string DataBaseError = "An error occurred while executing the database operation: ";
        public static string UnexpectedError = "An unexpected error occurred: ";
        public static string ToLogin = "Login.aspx";
        public static string ToMainPage = "MainPage.aspx";
        public static string InvalidDetails = "Invalid Username or Password";
        public static string ToRegister = "Register.aspx";
        public static string InsertStatement = "INSERT INTO USERDETAILS (Username, EmailID, Password) VALUES (@Username, @EmailID, @Password)";
        public static string UpdateStatement = "UPDATE USERDETAILS SET Password = @Password WHERE Username = @Username";
        public static string SelectStatement = "SELECT Password FROM USERDETAILS WHERE Username = @Username";
        public static string InvalidInformation = "Invalid Details: Username can have any alphanumeric character or underscore and the username must be between 3 and 15 characters, Email must be Valid and the password can have at least one alphabetic character, at least one numeric digit, at least one special character with a minimum length of 8 characters";
    }
}
