using Creacion_Manejo_API.Models;
using Creacion_Manejo_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Creacion_Manejo_API.Controllers;

[ApiController]
[Router("[controller]")]
public class PizzaController : ControllerBase{
    public PizzaController(){
    }

    //GET All action
    [httpGet]
    public ActionResult<List<Pizza>> GetAll =>
        PizzaService.GetAll();

    //GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id){
        var pizza = PizzaService.Get(id);

        if(pizza == null){
            return NotFound();
        }
        return pizza;
    }

    //POST action
    [HttpPost]
    public IActionResult Create(Pizza pizza){
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new{id = pizza.Id}, pizza);
    }

    //PUT action
    [HttpPut]
    public IActionResult Update(int id, Pizza pizza){
        if(id != pizza.ID)
            return BadRequest();
        
        var existingPizza = PizzaService.Get(id);
        if(existingPizza is null)
            return NotFound();
        
        pizzaService.Update(pizza);

        return NoContent();
    }

    //DELETE action
    [HttpDelete]
    public IActionResult Delete(int id){
        var pizza = pizzaService.Get(id);

        if(pizza is null)
            return NoFound();
        
        pizzaService.Delete(id);

        return NoContent();
    }
}