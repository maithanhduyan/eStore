using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Admin.Models;
using EStore.Domain.Services;
using EStore.Infrastructure.Data;
using EStore.Domain.Repositories;

namespace Admin.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public IActionResult List()
    {
        return View(_productService.GetAll());
    }
}