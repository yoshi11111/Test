using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected string Token = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Token = GenerateToken();
        }
    }
    public static string GenerateToken()
    {
        var token = Guid.NewGuid().ToString();
        HttpContext.Current.Session["RequestVerificationToken"] = token;
        return token;
    }


    public static void UtilityIsValidCsrfToken()
    {
        // ■解決策2
        var context = HttpContext.Current;
        HttpRequest request = context.Request;
        // get session token
        string sessionToken = context.Session["RequestVerificationToken"] as string;
        // get header token
        string token = request.Headers["X-CSRF-TOKEN"];
        if (token != sessionToken)
        {
            throw new Exception("CSRF異常");

        }

    }
}
