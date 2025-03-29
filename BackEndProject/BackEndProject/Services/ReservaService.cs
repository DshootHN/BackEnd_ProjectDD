using Microsoft.EntityFrameworkCore;
using AppWebAPI.Data;
using AppWebAPI.Models;

namespace AppWebAPI.Services;

public class ReservaService
{
    private readonly DataContext _context;

    public ReservaService(DataContext context)
    {
        _context = context;
    }

    //obtener todos las reserva
    public async Task<List<Reserva>> ObtenerReserva()
    {
        return await _context.Reserva.ToListAsync();
    }
    
    //crear un reserva 
    public async Task<Reserva> CrearReserva(Reserva reserva )
    {
        reserva.Id = Guid.NewGuid();
        reserva.CreatedAt = DateTime.UtcNow;

        _context.Reserva.Add(reserva);
        await _context.SaveChangesAsync();
        
        return reserva;
    }

    //actualizar un reserva
    public async Task<bool> ActualizarReserva(Guid id, Reserva reservaActualizada)
    {
        var reserva = await _context.Reserva.FindAsync(id);
        if (reserva == null) return false;

        reserva.Horas = reservaActualizada.Horas;
        reserva.Urgencia = reservaActualizada.Urgencia;
        reserva.Contacto= reservaActualizada.Contacto;
        reserva.FechaInicial = reservaActualizada.FechaInicial;
        reserva.PrecioTotal = reservaActualizada.PrecioTotal;

        await _context.SaveChangesAsync();
        return true;
    }
    
    //eliminar un reserva
    public async Task<bool> EliminarReserva(Guid id)
    {
        var reserva = await _context.Reserva.FindAsync(id);
        if (reserva == null) return false;

        _context.Reserva.Remove(reserva);
        await _context.SaveChangesAsync();
        return true;
    } 
}