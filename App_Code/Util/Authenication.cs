
using System.Web;

public class Authenication
{
    private static object authSession;

    public static bool LoggedIn
    {
        get
        {
            authSession = HttpContext.Current.Session["hb_login_name"];
            return authSession != null;
        }
    }

    public static string LoginName
    {
        get
        {
            if (LoggedIn)
            {
                return (string)authSession;
            }
            else
            {
                return "n.a";
            }
        }
    }
}