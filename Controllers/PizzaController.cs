using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    // GET /api/pizza
    [HttpGet] // 👈 This is like router.get('/', ...)
    public ActionResult<List<Pizza>> GetAllThePizzas()
    {
      // Send back the List of Pizza instances as
      // the response! (Also, it's going to get serialized
      // into the JSON [{...},{...}] structure you know and
      // love.)
      return PizzaService.GetAll();
    }

    // GET /api/pizza/:id
    [HttpGet("{id}")] // 👈 This is like router.get('/:id', ...)
    public ActionResult<Pizza> GetOnePizza(int id)
    {
        var pizza = PizzaService.Get(id);

        // If we didn't find the pizza:
        if (pizza == null)
        { 
            // res.sendStatus(404)
            return NotFound();
        }
        else // If we did find the pizza:
        {
          // res.send(pizza)
          return pizza;
        }
    }

    // POST /api/pizza
    [HttpPost]
    public IActionResult CreatePizza(Pizza pizza)
    {            
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(GetOnePizza), new { id = pizza.Id }, pizza);
    }

    // PUT action

    // DELETE action
}