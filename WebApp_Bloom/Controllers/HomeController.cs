using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Security.Claims;
using WebApp_Bloom.Models;

namespace WebApp_Bloom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Home1(string username, string senha)
        {
            MySqlConnection mySqlConection = new MySqlConnection("server=bloomproject.mysql.dbaas.com.br;database=bloomproject;uid=bloomproject;password=Bloom@135");
            await mySqlConection.OpenAsync();

            MySqlCommand mySqlCommand = mySqlConection.CreateCommand();
            mySqlCommand.CommandText = $"SELECT * FROM usuarios WHERE username = '{username}' AND senha = '{senha}'";

            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            if (await reader.ReadAsync())
            {
                return RedirectToAction("Evento", "Evento");
            }

            return Json(new { Msg = "Oi" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
