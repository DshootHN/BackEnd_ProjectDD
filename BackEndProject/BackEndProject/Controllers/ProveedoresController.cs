using Microsoft.AspNetCore.Mvc;
using AppWebAPI.Services;
using AppWebAPI.Models;

namespace AppWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProveedoresController : ControllerBase
{
    private readonly ProveedorService _proveedoresService;

    public ProveedoresController(ProveedorService usuarioService)
    {
        _proveedoresService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Proveedor>>> ObtenerProveedor()
    {
        var proveedores = await _proveedoresService.ObtenerProveedor();
        return Ok(proveedores);
    }

    [HttpPost]
    public async Task<ActionResult> CrearProveedor([FromBody]Proveedor proveedores)
    {
        if (proveedores == null)
        {
            return BadRequest("Datos del proveedor estan vacios");
        }
        var nuevoProveedor = await _proveedoresService.CrearProveedor(proveedores);
        return Ok(nuevoProveedor);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> ActualizarProveedor(Guid id, [FromBody] Proveedor proveedorActualizado)
    {
        if (proveedorActualizado == null)
        {
            return BadRequest("Datos del proveedor estan vacios");
        }

        var response = await _proveedoresService.ActualizarProveedor(id, proveedorActualizado);

        if (response == false)
        {
            return NotFound("Proveedor no encontrada en la base de datos");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> EliminarProveedor(Guid id)
    {
        var response = await _proveedoresService.EliminarProveedor(id);
        if (response == false)
        {
            return NotFound("Proveedor no encontrado en base de datos");
        }
        return NoContent();
    }
    
}