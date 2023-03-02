using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using BlackcofferAssigment.Models;
using Microsoft.AspNetCore.Components;

namespace BlackcofferAssigment.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginUser modelLogin)
        {
            string mainconn = "Data Source=DESKTOP-8J5HIL7 ; Initial Catalog=Blackcoffer ;trusted_connection=SSPI ; Encrypt=false;TrustServerCertificate=true";

            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select Uemail,Pwd from registrations where Uemail = @Uemail and Pwd=@Pwd";
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlcomm.Parameters.AddWithValue("@Uemail", modelLogin.Uemail);
            sqlcomm.Parameters.AddWithValue("@Pwd", modelLogin.Pwd);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            if (sdr.Read())
            {
                {
                    List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,modelLogin.Uemail),
                    new Claim("OtherProperties", "Example Role")
                };

                    ClaimsIdentity ClaimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = modelLogin.KeepLoggedIn
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(ClaimsIdentity), properties);

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewData["ValidateMessage"] = "user Not Found !";
            }
            sqlconn.Close();
            return View();
        }
    }
}
