using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Making_Backend_To_Free_Website_Template.Models;

namespace Making_Backend_To_Free_Website_Template.Controllers;

public class NightController : Controller
{
    private readonly ILogger<NightController> _logger;

    public NightController(ILogger<NightController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Ticket()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
