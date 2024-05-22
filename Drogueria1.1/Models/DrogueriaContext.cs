using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Drogueria1._1_.Models;

public partial class DrogueriaContext : DbContext
{
    public DrogueriaContext()
    {
    }

    public DrogueriaContext(DbContextOptions<DrogueriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bodega> Bodegas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Detalledocumento> Detalledocumentos { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Enfermedad> Enfermedads { get; set; }

    public virtual DbSet<Farmacium> Farmacia { get; set; }

    public virtual DbSet<Ingrediente> Ingredientes { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Laboratorio> Laboratorios { get; set; }

    public virtual DbSet<Presentacion> Presentacions { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Tipodocumento> Tipodocumentos { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //        => optionsBuilder.UseSqlServer("");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bodega>(entity =>
        {
            entity.HasKey(e => e.IdBodega).HasName("PK_BODEGAS");

            entity.ToTable("BODEGA");

            entity.Property(e => e.IdBodega)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_BODEGA");
            entity.Property(e => e.DirBodega)
                .HasMaxLength(250)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("DIR_BODEGA");
            entity.Property(e => e.NombreBod)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("NOMBRE_BOD");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("CLIENTE");

            entity.Property(e => e.IdCliente)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("ID_CLIENTE");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("CORREO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DIRECCION");
            entity.Property(e => e.IdEnfermedad)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("ID_ENFERMEDAD");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Telefono)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("TELEFONO");

            entity.HasOne(d => d.IdEnfermedadNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdEnfermedad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CLIENTES_ENFERMEDADES");
        });

        modelBuilder.Entity<Detalledocumento>(entity =>
        {
            entity.HasKey(e => new { e.CodigoDoc, e.NumeroDoc }).HasName("PK_DETALLEDOCUMENTOS_1");

            entity.ToTable("DETALLEDOCUMENTO");

            entity.Property(e => e.CodigoDoc)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("CODIGO_DOC");
            entity.Property(e => e.NumeroDoc)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("NUMERO_DOC");
            entity.Property(e => e.Cantidad)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("CANTIDAD");
            entity.Property(e => e.Costo)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("COSTO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Descuento)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("DESCUENTO");
            entity.Property(e => e.IdProducto)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.Precio)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("PRECIO");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Detalledocumentos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETALLEDOCUMENTOS_PRODUCTOS");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => new { e.CodigoDoc, e.NumeroDoc }).HasName("PK_DOCUMENTOS");

            entity.ToTable("DOCUMENTO");

            entity.Property(e => e.CodigoDoc)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("CODIGO_DOC");
            entity.Property(e => e.NumeroDoc)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("NUMERO_DOC");
            entity.Property(e => e.Descuento)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("DESCUENTO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.IdBodega)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_BODEGA");
            entity.Property(e => e.IdCliente)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("ID_CLIENTE");
            entity.Property(e => e.IdEmpleado)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_EMPLEADO");
            entity.Property(e => e.Iva)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("IVA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Numerofac)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("NUMEROFAC");
            entity.Property(e => e.Seriefac)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SERIEFAC");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("SUBTOTAL");
            entity.Property(e => e.Totaldoc)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("TOTALDOC");

            entity.HasOne(d => d.CodigoDocNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.CodigoDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DOCUMENTOS_TIPODOCUMENTOS");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DOCUMENTOS_CLIENTES");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DOCUMENTOS_EMPLEADOS");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK_EMPLEADOS");

            entity.ToTable("EMPLEADO");

            entity.Property(e => e.IdEmpleado)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_EMPLEADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Telefono)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Enfermedad>(entity =>
        {
            entity.HasKey(e => e.IdEnfermedad).HasName("PK_ENFERMEDADES");

            entity.ToTable("ENFERMEDAD");

            entity.Property(e => e.IdEnfermedad)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_ENFERMEDAD");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Farmacium>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PK_SUCURSAL");

            entity.ToTable("FARMACIA");

            entity.Property(e => e.IdSucursal)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_SUCURSAL");
            entity.Property(e => e.DireccionSucursal)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DIRECCION_SUCURSAL");
            entity.Property(e => e.NombreSucursal)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("NOMBRE_SUCURSAL");
        });

        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.HasKey(e => e.IdIngredientea).HasName("PK_INGREDIENTES");

            entity.ToTable("INGREDIENTE");

            entity.Property(e => e.IdIngredientea)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_INGREDIENTEA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => new { e.IdProducto, e.IdBodega, e.IdUbicacion }).HasName("PK_INVENTARIOS_1");

            entity.ToTable("INVENTARIO");

            entity.Property(e => e.IdProducto)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.IdBodega)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_BODEGA");
            entity.Property(e => e.IdUbicacion)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_UBICACION");
            entity.Property(e => e.Entradas)
                .HasColumnType("numeric(4, 4)")
                .HasColumnName("ENTRADAS");
            entity.Property(e => e.Final)
                .HasColumnType("numeric(4, 4)")
                .HasColumnName("FINAL");
            entity.Property(e => e.Salidas)
                .HasColumnType("numeric(4, 4)")
                .HasColumnName("SALIDAS");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INVENTARIOS_PRODUCTOS");

            entity.HasOne(d => d.IdUbicacionNavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.IdUbicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INVENTARIOS_UBICACIONES");
        });

        modelBuilder.Entity<Laboratorio>(entity =>
        {
            entity.HasKey(e => e.IdLaboratorio).HasName("PK_LABORATORIOS");

            entity.ToTable("LABORATORIO");

            entity.Property(e => e.IdLaboratorio)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_LABORATORIO");
            entity.Property(e => e.NombreLab)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("NOMBRE_LAB");
        });

        modelBuilder.Entity<Presentacion>(entity =>
        {
            entity.HasKey(e => e.IdPresentacion).HasName("PK_PRESENTACIONES");

            entity.ToTable("PRESENTACION");

            entity.Property(e => e.IdPresentacion)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_PRESENTACION");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK_PRODUCTOS");

            entity.ToTable("PRODUCTO");

            entity.Property(e => e.IdProducto)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ID_PRODUCTO");
            entity.Property(e => e.Costo).HasColumnName("COSTO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.IdIngredientea)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_INGREDIENTEA");
            entity.Property(e => e.IdLaboratorio)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_LABORATORIO");
            entity.Property(e => e.IdPresentacion)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_PRESENTACION");
            entity.Property(e => e.PrecioMayorista).HasColumnName("PRECIO_MAYORISTA");
            entity.Property(e => e.PrecioPublico).HasColumnName("PRECIO_PUBLICO");

            entity.HasOne(d => d.IdIngredienteaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdIngredientea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCTOS_INGREDIENTES");

            entity.HasOne(d => d.IdLaboratorioNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdLaboratorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCTOS_LABORATORIOS");

            entity.HasOne(d => d.IdPresentacionNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdPresentacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCTOS_PRESENTACIONES");
        });

        modelBuilder.Entity<Tipodocumento>(entity =>
        {
            entity.HasKey(e => e.CodigoDoc).HasName("PK_TIPODOCUMENTOS");

            entity.ToTable("TIPODOCUMENTO");

            entity.Property(e => e.CodigoDoc)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("CODIGO_DOC");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.IdBodega)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_BODEGA");
            entity.Property(e => e.IdSucursal)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_SUCURSAL");
            entity.Property(e => e.Tipotran)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("TIPOTRAN");

            entity.HasOne(d => d.IdBodegaNavigation).WithMany(p => p.Tipodocumentos)
                .HasForeignKey(d => d.IdBodega)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TIPODOCUMENTOS_BODEGAS");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Tipodocumentos)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TIPODOCUMENTOS_FARMACIAS");
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion).HasName("PK_UBICACIONES");

            entity.ToTable("UBICACION");

            entity.Property(e => e.IdUbicacion)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ID_UBICACION");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DESCRIPCION");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
