using BusinessModels;
using ConsoleApp;

namespace Presentation_layer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool exit = false;
            Authentication auth = new Authentication();
            while (!exit)
            {
                WriteAndReadMethods.Writeline(Literals.register);
                WriteAndReadMethods.Writeline(Literals.login);
                WriteAndReadMethods.Writeline(Literals.GetUserdetails);
                WriteAndReadMethods.Writeline(Literals.exit);
                WriteAndReadMethods.Writeline(Literals.enterchoice);
                int choice = Convert.ToInt32(WriteAndReadMethods.Readline());
                switch ((MenuChoice)choice)
                {
                    case MenuChoice.Register:
                        exit = auth.register();
                        break;
                    case MenuChoice.Login:
                        exit = auth.login();
                        break;
                    case MenuChoice.GetUserDetails:
                        exit = auth.GetUser();
                        break;
                    case MenuChoice.Exit:
                        auth.exit();
                        break;
                    default:
                        WriteAndReadMethods.Writeline(Literals.invalidChoice);
                        break;
                }
            }
        }
    }
}
