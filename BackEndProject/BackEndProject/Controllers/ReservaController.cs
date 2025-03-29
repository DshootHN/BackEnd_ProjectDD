using Microsoft.AspNetCore.Mvc;
using AppWebAPI.Services;
using AppWebAPI.Models;

namespace AppWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ReservaController : ControllerBase
{
    private readonly ReservaService _reservaService;

    public ReservaController(ReservaService reservaService)
    {
        _reservaService = reservaService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Reserva>>> ObtenerReserva()
    {
        var reserva = await _reservaService.ObtenerReserva();
        return Ok(reserva);
    }

    [HttpPost]
    public async Task<ActionResult> CrearReserva([FromBody]Reserva reserva)
    {
        if (reserva == null)
        {
            return BadRequest("Datos de reserva vienen vacios");
        }
        var nuevaReserva = await _reservaService.CrearReserva(reserva);
        return Ok(nuevaReserva);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> ActualizarReserva(Guid id, [FromBody] Reserva reservaActualizado)
    {
        if (reservaActualizado == null)
        {
            return BadRequest("Datos de reserva vienen vacios");
        }

        var response = await _reservaService.ActualizarReserva(id, reservaActualizado);

        if (response == false)
        {
            return NotFound("Reserva no encontrado en base de datos");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> EliminarReserva(Guid id)
    {
        var response = await _reservaService.EliminarReserva(id);
        if (response == false)
        {
            return NotFound("Reserva no encontrado en base de datos");
        }
        return NoContent();
    }
    
}