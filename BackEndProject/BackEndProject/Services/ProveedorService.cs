using Microsoft.EntityFrameworkCore;
using AppWebAPI.Data;
using AppWebAPI.Models;

namespace AppWebAPI.Services;

public class ProveedorService
{
    private readonly DataContext _context;

    public ProveedorService(DataContext context)
    {
        _context = context;
    }

    //obtener todos las proveedor
    public async Task<List<Proveedor>> ObtenerProveedor()
    {
        return await _context.Proveedores.ToListAsync();
    }
    
    //crear un proveedor 
    public async Task<Proveedor> CrearProveedor(Proveedor proveedor )
    {
        proveedor.Id = Guid.NewGuid();
        proveedor.CreatedAt = DateTime.UtcNow;

        _context.Proveedores.Add(proveedor);
        await _context.SaveChangesAsync();
        
        return proveedor;
    }

    //actualizar un proveedor
    public async Task<bool> ActualizarProveedor(Guid id, Proveedor tareaActualizado)
    {
        var proveedor = await _context.Proveedores.FindAsync(id);
        if (proveedor == null) return false;

        proveedor.NombreProv = tareaActualizado.NombreProv;
        proveedor.Contacto = tareaActualizado.Contacto;
        proveedor.Correo = tareaActualizado.Correo;
        proveedor.Contrasena = tareaActualizado.Contrasena;
        proveedor.AnosExperiencia = tareaActualizado.AnosExperiencia;
        proveedor.Tecnologia = tareaActualizado.Tecnologia; 
        proveedor.Precio = tareaActualizado.Precio; 

        await _context.SaveChangesAsync();
        return true;
    }
    
    //eliminar un proveedor
    public async Task<bool> EliminarProveedor(Guid id)
    {
        var proveedor = await _context.Proveedores.FindAsync(id);
        if (proveedor == null) return false;

        _context.Proveedores.Remove(proveedor);
        await _context.SaveChangesAsync();
        return true;
    } 
}