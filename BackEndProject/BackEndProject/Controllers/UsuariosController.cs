using Microsoft.AspNetCore.Mvc;
using AppWebAPI.Services;
using AppWebAPI.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace AppWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UsuariosController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuariosController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Usuario>>> ObtenerUsuarios()
    {
        var usuarios = await _usuarioService.ObtenerUsuarios();
        return Ok(usuarios);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest) // Marking method as async and changing return type to Task<IActionResult>
    {
        var usuarios = await _usuarioService.ObtenerUsuarios(); // Awaiting the ObtenerUsuarios method
        var usuario = usuarios.FirstOrDefault(u => u.Correo == loginRequest.Email && u.Contrasena == loginRequest.Password);
        if (usuario != null && usuario.Contrasena == loginRequest.Password)
        {
            return Ok(usuario);
        }
        return Unauthorized("Contraseña o Correo invalidos");
    }

    [HttpPost]
    public async Task<ActionResult> CrearUsuario([FromBody] Usuario usuario)
    {
        if (usuario == null)
        {
            return BadRequest("Datos de usuario vienen vacios");
        }
        var nuevoUsuario = await _usuarioService.CrearUsuario(usuario);
        return Ok(nuevoUsuario);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> ActualizarUsuario(Guid id, [FromBody] Usuario usuarioActualizado)
    {
        if (usuarioActualizado == null)
        {
            return BadRequest("Datos de usuario vienen vacios");
        }

        var response = await _usuarioService.ActualizarUsuario(id, usuarioActualizado);

        if (response == false)
        {
            return NotFound("Usuario no encontrado en base de datos");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> EliminarUsuario(Guid id)
    {
        var response = await _usuarioService.EliminarUsuario(id);
        if (response == false)
        {
            return NotFound("Usuario no encontrado en base de datos");
        }
        return NoContent();
    }

}
