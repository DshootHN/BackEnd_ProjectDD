using Microsoft.EntityFrameworkCore;
using AppWebAPI.Models;

namespace AppWebAPI.Data;

    public class DataContext : DbContext
    {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Reserva> Reserva { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Usuario>().ToTable("usuarios");

        modelBuilder.Entity<Usuario>().Property(u => u.Nombre).HasColumnName("name");
        modelBuilder.Entity<Usuario>().Property(u => u.Correo).HasColumnName("email");
        modelBuilder.Entity<Usuario>().Property(u => u.Contrasena).HasColumnName("password");
        modelBuilder.Entity<Usuario>().Property(u => u.Compania).HasColumnName("company");
        modelBuilder.Entity<Usuario>().Property(u => u.CreatedAt).HasColumnName("created_at");

        modelBuilder.Entity<Proveedor>().ToTable("proveedores");

        modelBuilder.Entity<Proveedor>().Property(p => p.NombreProv).HasColumnName("name");
        modelBuilder.Entity<Proveedor>().Property(p => p.Correo).HasColumnName("email");   
        modelBuilder.Entity<Proveedor>().Property(p => p.Contacto).HasColumnName("contact");
        modelBuilder.Entity<Proveedor>().Property(p => p.Contrasena).HasColumnName("password");
        modelBuilder.Entity<Proveedor>().Property(p => p.AnosExperiencia).HasColumnName("exp_years");
        modelBuilder.Entity<Proveedor>().Property(p => p.Tecnologia).HasColumnName("tech");
        modelBuilder.Entity<Proveedor>().Property(p => p.Precio).HasColumnName("price");
        modelBuilder.Entity<Proveedor>().Property(p => p.CreatedAt).HasColumnName("created_at");    

        modelBuilder.Entity<Reserva>().ToTable("reserva");

        modelBuilder.Entity<Reserva>().Property(r => r.FechaInicial).HasColumnName("date_init");
        modelBuilder.Entity<Reserva>().Property(r => r.Contacto).HasColumnName("contact");
        modelBuilder.Entity<Reserva>().Property(r => r.Horas).HasColumnName("hours");
        modelBuilder.Entity<Reserva>().Property(r => r.NombreCliente).HasColumnName("name_contact");
        modelBuilder.Entity<Reserva>().Property(r => r.NombreProveedor).HasColumnName("name_prov");  
        modelBuilder.Entity<Reserva>().Property(r => r.NombreEmpresa).HasColumnName("name_company");
        modelBuilder.Entity<Reserva>().Property(r => r.PrecioTotal).HasColumnName("price_total");
        modelBuilder.Entity<Reserva>().Property(r => r.Urgencia).HasColumnName("urgent");
        modelBuilder.Entity<Reserva>().Property(r => r.CreatedAt).HasColumnName("created_at");  

    }

}
