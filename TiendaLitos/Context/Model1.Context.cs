﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TiendaLitos.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TiendaLitosEntities : DbContext
    {
        public TiendaLitosEntities()
            : base("name=TiendaLitosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TbArticulo> TbArticulo { get; set; }
        public virtual DbSet<TbArticuloBaja> TbArticuloBaja { get; set; }
        public virtual DbSet<TbArticuloBodega> TbArticuloBodega { get; set; }
        public virtual DbSet<TbBodega> TbBodega { get; set; }
        public virtual DbSet<TbCategoria> TbCategoria { get; set; }
        public virtual DbSet<TbColor> TbColor { get; set; }
        public virtual DbSet<TbCompra> TbCompra { get; set; }
        public virtual DbSet<TbConfiguración> TbConfiguración { get; set; }
        public virtual DbSet<TbDetalleCompra> TbDetalleCompra { get; set; }
        public virtual DbSet<TbDetalleVenta> TbDetalleVenta { get; set; }
        public virtual DbSet<TbDevoluciònVenta> TbDevoluciònVenta { get; set; }
        public virtual DbSet<TbMarca> TbMarca { get; set; }
        public virtual DbSet<TbMedida> TbMedida { get; set; }
        public virtual DbSet<TbMovimientoArticulo> TbMovimientoArticulo { get; set; }
        public virtual DbSet<TbPromoción> TbPromoción { get; set; }
        public virtual DbSet<TbProveedor> TbProveedor { get; set; }
        public virtual DbSet<TbRol> TbRol { get; set; }
        public virtual DbSet<TbSubCategoria> TbSubCategoria { get; set; }
        public virtual DbSet<TbTalla> TbTalla { get; set; }
        public virtual DbSet<TbTipoMovimiento> TbTipoMovimiento { get; set; }
        public virtual DbSet<TbUsuario> TbUsuario { get; set; }
        public virtual DbSet<TbVenta> TbVenta { get; set; }
        public virtual DbSet<TIPOMONEDA> TIPOMONEDA { get; set; }
        public virtual DbSet<TbRolUsuario> TbRolUsuario { get; set; }
    }
}
