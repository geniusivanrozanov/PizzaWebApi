using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using PizzaWebApi.Models;
using PizzaWebApi.Repositories;
using PizzaWebApi.Services;

namespace PizzaWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PizzaController : ControllerBase
{
    private readonly IPizzaRepository _pizzas;
    public PizzaController(IPizzaRepository pizzas)
    {
        _pizzas = pizzas;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pizza>>> GetAll() => Ok(await _pizzas.Get());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var pizza = await _pizzas.Get(id);

        if (pizza is null)
            return NotFound();

        return Ok(pizza);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Pizza pizza)
    {
        if (pizza is null)
            return BadRequest();

        await _pizzas.Create(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();

        try
        {
            await _pizzas.Update(pizza);
        }
        catch
        {
            return NotFound();
        }

        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pizza = await _pizzas.Get(id);

        if (pizza is null)
            return NotFound();

        await _pizzas.Delete(id);

        return NoContent();
    }
}
