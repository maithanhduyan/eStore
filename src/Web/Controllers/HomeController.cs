using System.Diagnostics;
using EStore.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IProductService _productService;

    public HomeController(ILogger<HomeController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public IActionResult Index()
    {
        return View(_productService.GetAll());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Cart()
    {
        return View();
    }

    public IActionResult Shop()
    {
        return View();
    }

    public IActionResult WishList()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
