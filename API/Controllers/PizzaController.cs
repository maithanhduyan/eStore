using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{

    private readonly ILogger<PizzaController> _logger;
    public PizzaController(ILogger<PizzaController> logger)
    {
        _logger = logger;
    }

    // GET all action
    [HttpGet(Name = "GetAll")]
    public ActionResult<List<Pizza>> GetAll()
    {
        return PizzaService.GetAll();
    }

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza == null)
            return NotFound();

        return pizza;
    }

    // POST action

    // PUT action

    // DELETE action
}