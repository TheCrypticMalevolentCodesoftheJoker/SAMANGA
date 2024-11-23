using HOSPEDAJE.Models;
using Microsoft.EntityFrameworkCore;

namespace HOSPEDAJE.Data;
public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCategoria> TblCategoria { get; set; }

    public virtual DbSet<TblCliente> TblCliente { get; set; }

    public virtual DbSet<TblDetalleCliente> TblDetalleCliente { get; set; }

    public virtual DbSet<TblDetalleHabitacion> TblDetalleHabitacion { get; set; }

    public virtual DbSet<TblDetalleReserva> TblDetalleReserva { get; set; }

    public virtual DbSet<TblDetalleUsuario> TblDetalleUsuario { get; set; }

    public virtual DbSet<TblEstado> TblEstado { get; set; }

    public virtual DbSet<TblHabitacion> TblHabitacion { get; set; }

    public virtual DbSet<TblImagenHabitacion> TblImagenHabitacion { get; set; }

    public virtual DbSet<TblListaEspera> TblListaEspera { get; set; }

    public virtual DbSet<TblMantenimientoLimpieza> TblMantenimientoLimpieza { get; set; }

    public virtual DbSet<TblReporteProblema> TblReporteProblema { get; set; }

    public virtual DbSet<TblReserva> TblReserva { get; set; }

    public virtual DbSet<TblRol> TblRol { get; set; }

    public virtual DbSet<TblUsuario> TblUsuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCategoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__tbl_cate__CD54BC5A180312E4");

            entity.ToTable("tbl_categoria");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Categoria");
        });

        modelBuilder.Entity<TblCliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__tbl_clie__677F38F500759DB8");

            entity.ToTable("tbl_cliente");

            entity.HasIndex(e => e.Correo, "UQ__tbl_clie__2A586E0BAFF776D7").IsUnique();

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.FechaUltimaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ultima_modificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblDetalleCliente>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCliente).HasName("PK__tbl_deta__026C6C9BBA93B72D");

            entity.ToTable("tbl_detalle_cliente");

            entity.Property(e => e.IdDetalleCliente).HasColumnName("id_detalle_cliente");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado_civil");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FechaUltimaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ultima_actualizacion");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("genero");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Idioma)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idioma");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.NotasAdicionales)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("notas_adicionales");
            entity.Property(e => e.Ocupacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ocupacion");
            entity.Property(e => e.Preferencias)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("preferencias");
            entity.Property(e => e.RedesSociales)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("redes_sociales");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TblDetalleClientes)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_detalle_cliente_cliente");
        });

        modelBuilder.Entity<TblDetalleHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdDetalleHabitacion).HasName("PK__tbl_deta__28FB77BDAAA93EC9");

            entity.ToTable("tbl_detalle_habitacion");

            entity.Property(e => e.IdDetalleHabitacion).HasColumnName("id_detalle_habitacion");
            entity.Property(e => e.Accesibilidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("accesibilidad");
            entity.Property(e => e.AireAcondicionado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("aire_acondicionado");
            entity.Property(e => e.Calefaccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("calefaccion");
            entity.Property(e => e.CapacidadPersonas).HasColumnName("capacidad_personas");
            entity.Property(e => e.Ducha)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ducha");
            entity.Property(e => e.Extras)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("extras");
            entity.Property(e => e.FrigoBar)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("frigo_bar");
            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.NumeroCamas).HasColumnName("numero_camas");
            entity.Property(e => e.Piso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("piso");
            entity.Property(e => e.ServiciosAdicionales)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("servicios_adicionales");
            entity.Property(e => e.TamanioHabitacion)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("tamanio_habitacion");
            entity.Property(e => e.Television)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("television");
            entity.Property(e => e.TipoBano)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo_bano");
            entity.Property(e => e.TipoCama)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_cama");
            entity.Property(e => e.Ventilador)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ventilador");
            entity.Property(e => e.Vistas)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vistas");
            entity.Property(e => e.Wifi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("wifi");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.TblDetalleHabitacion)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__tbl_detal__id_ha__4F7CD00D");
        });

        modelBuilder.Entity<TblDetalleReserva>(entity =>
        {
            entity.HasKey(e => new { e.IdReserva, e.IdHabitacion }).HasName("PK__tbl_deta__654F4CD258E788E8");

            entity.ToTable("tbl_detalle_reserva");

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.CantidadPersonas).HasColumnName("cantidad_personas");
            entity.Property(e => e.CostoServicio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costo_servicio");
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado_pago");
            entity.Property(e => e.FechaPago)
                .HasColumnType("datetime")
                .HasColumnName("fecha_pago");
            entity.Property(e => e.FechaUltimaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ultima_modificacion");
            entity.Property(e => e.PagoParcial)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("pago_parcial");
            entity.Property(e => e.TipoServicio)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo_servicio");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.TblDetalleReserva)
                .HasForeignKey(d => d.IdHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_detal__id_ha__5FB337D6");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.TblDetalleReservas)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK__tbl_detal__id_re__5EBF139D");
        });

        modelBuilder.Entity<TblDetalleUsuario>(entity =>
        {
            entity.HasKey(e => e.IdDetalleUsuario).HasName("PK__tbl_deta__994D1CA0172EA8DB");

            entity.ToTable("tbl_detalle_usuario");

            entity.Property(e => e.IdDetalleUsuario).HasColumnName("id_detalle_usuario");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado_civil");
            entity.Property(e => e.FechaContratacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_contratacion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FechaUltimaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ultima_actualizacion");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("genero");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Idioma)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("idioma");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.NotasAdicionales)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("notas_adicionales");
            entity.Property(e => e.Ocupacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ocupacion");
            entity.Property(e => e.Preferencias)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("preferencias");
            entity.Property(e => e.RedesSociales)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("redes_sociales");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TblDetalleUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_detalle_usuario_usuario");
        });

        modelBuilder.Entity<TblEstado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__tbl_esta__86989FB2F42343CE");

            entity.ToTable("tbl_estado");

            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Estado");
        });

        modelBuilder.Entity<TblHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("PK__tbl_habi__773F28F323B2EC70");

            entity.ToTable("tbl_habitacion");

            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("numero");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.TblHabitacions)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_habit__id_ca__4BAC3F29");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.TblHabitacions)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_habit__id_es__4CA06362");
        });

        modelBuilder.Entity<TblImagenHabitacion>(entity =>
        {
            entity.HasKey(e => e.IdImagen).HasName("PK__tbl_imag__27CC2689CC6C989A");

            entity.ToTable("tbl_imagen_habitacion");

            entity.Property(e => e.IdImagen).HasColumnName("id_imagen");
            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url_imagen");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.TblImagenHabitacion)
                .HasForeignKey(d => d.IdHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_image__id_ha__52593CB8");
        });

        modelBuilder.Entity<TblListaEspera>(entity =>
        {
            entity.HasKey(e => e.IdEspera).HasName("PK__tbl_list__A6C643D7C53F7E81");

            entity.ToTable("tbl_lista_espera");

            entity.Property(e => e.IdEspera).HasColumnName("id_espera");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaSolicitud)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_solicitud");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Prioridad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("prioridad");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TblListaEsperas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_lista__id_cl__68487DD7");
        });

        modelBuilder.Entity<TblMantenimientoLimpieza>(entity =>
        {
            entity.HasKey(e => e.IdManLimp).HasName("PK__tbl_mant__28AFD31DCE1E3965");

            entity.ToTable("tbl_mantenimiento_limpieza");

            entity.Property(e => e.IdManLimp).HasColumnName("id_man_limp");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.TipoActividad)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tipo_actividad");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.TblMantenimientoLimpieza)
                .HasForeignKey(d => d.IdHabitacion)
                .HasConstraintName("FK__tbl_mante__id_ha__571DF1D5");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TblMantenimientoLimpiezas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_mante__id_us__5812160E");
        });

        modelBuilder.Entity<TblReporteProblema>(entity =>
        {
            entity.HasKey(e => e.IdProblema).HasName("PK__tbl_repo__811B51C6888A2E18");

            entity.ToTable("tbl_reporte_problema");

            entity.Property(e => e.IdProblema).HasColumnName("id_problema");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaReporte)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_reporte");
            entity.Property(e => e.FechaResolucion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_resolucion");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TblReporteProblemas)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__tbl_repor__id_cl__6477ECF3");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.TblReporteProblema)
                .HasForeignKey(d => d.IdHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_repor__id_ha__6383C8BA");
        });

        modelBuilder.Entity<TblReserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__tbl_rese__423CBE5D33D23C1F");

            entity.ToTable("tbl_reserva");

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaEntrada).HasColumnName("fecha_entrada");
            entity.Property(e => e.FechaReserva)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_reserva");
            entity.Property(e => e.FechaSalida).HasColumnName("fecha_salida");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.TotalPago)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_pago");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TblReservas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_reser__id_cl__5BE2A6F2");
        });

        modelBuilder.Entity<TblRol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__tbl_rol__6ABCB5E0D47A69BA");

            entity.ToTable("tbl_rol");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rol");
        });

        modelBuilder.Entity<TblUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__tbl_usua__4E3E04AD9AC61A30");

            entity.ToTable("tbl_usuario");

            entity.HasIndex(e => e.Correo, "UQ__tbl_usua__2A586E0BAFA0788D").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.TblUsuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_usuar__id_ro__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
