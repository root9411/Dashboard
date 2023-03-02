using BlackcofferAssigment.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using BlackcofferAssigment.DatabaseConnection;
using Microsoft.Data.SqlClient;

namespace BlackcofferAssigment.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("ErrorPage")]
        public IActionResult ErrorPage()
        {
            return View();
        }

        [Route("BlankPage")]
        public IActionResult BlankPage()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Access");
        }


        [HttpPost]
        public List<object> GetIntensity1()
        {
            List<object> data = new List<object>();
            List<int> labels = _context.AssigmentData.Select(p => p.intensity).ToList();
            data.Add(labels);

            List<int> LikeHood = _context.AssigmentData.Select(p => p.likelihood).ToList();
            data.Add(LikeHood);

            return data;
        }


        [HttpPost]
        public List<object> GetIntensity()
        {

            string connection = "Data Source=DESKTOP-8J5HIL7 ; database=Blackcoffer;trusted_connection=SSPI ; Encrypt=false;TrustServerCertificate=true";

            SqlConnection sqlconn1 = new SqlConnection(connection);
            string sqlquery1 = "select distinct intensity from AssigmentData";
            using (SqlCommand sqlcomm1 = new SqlCommand(sqlquery1, sqlconn1))
            {
                sqlconn1.Open();
                SqlDataReader sdr = sqlcomm1.ExecuteReader();
                List<object> data1 = new List<object>();

                while(sdr.Read())
                {
                    List<int> labels1 = new List<int>();
                    data1.Add(labels1);
                }
                
            sqlconn1.Close();
            return data1;
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}