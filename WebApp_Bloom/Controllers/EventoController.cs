using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp_Bloom.Models;

namespace WebApp_Bloom.Controllers
{
    public class EventoController : Controller
    {
        private readonly ILogger<EventoController> _logger;
        private readonly Contexto db;
        public EventoController(ILogger<EventoController> logger, Contexto _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index()
        {
           

            return View();
        }
        public IActionResult Evento()
        {

            ListaEventosViewModel model = new ListaEventosViewModel();
            model.TodosCasamentos = db.CASAMENTOS.ToList();

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}