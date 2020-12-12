using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using TiendaLitos.Context;

namespace TiendaLitos.Service
{
    public class ServiceCompras
    {
        public TiendaLitosEntities _Context { get; set; }
        public ServiceCompras(TiendaLitosEntities Context)
        {
            _Context = Context;
        }

        public List<Proveedor> GetAllProveedores()
        {
            var proveedores = _Context.TbProveedor.Select(x => new Proveedor
            {
                IdProveedor = x.IdProveedor,
                Nombre = x.NombreEmpresa
            }).ToList();
            return proveedores;
        }

        public Result Comprar(CompraRequest compraRequest)
        {

            foreach (var detalle in compraRequest.DetalleCompra)
            {
                var pdescuento = detalle.Descuento / 100;
                var descuento = (detalle.Cantidad * detalle.Precio) * pdescuento;
                var subtotal = (detalle.Cantidad * detalle.Precio - descuento);

                detalle.SubTotalArticulo = subtotal;
            }

            var nCompras = _Context.TbCompra.Count() + 1;
            var fechaActual = DateTime.Now;
            using (TransactionScope scope = new TransactionScope())
            {

                try
                {
                    var compra = new TbCompra
                    {
                        FechaCompra = DateTime.Now,
                        IdProveedor = compraRequest.Compra.IdProveedor,
                        IdUsuario = 1,
                        SubTotal = compraRequest.Compra.SubTotalCompra,
                        Iva = compraRequest.Compra.Iva,
                        Total = compraRequest.Compra.TotalCompra,
                        NoFactura = $"{fechaActual.Year}{fechaActual.Month}{fechaActual.Day}{nCompras}"
                    };
                    _Context.TbCompra.Add(compra);

                    foreach (var detalle in compraRequest.DetalleCompra)
                    {

                        _Context.TbDetalleCompra.Add(new TbDetalleCompra
                        {
                            IdCompra = compra.IdCompra,
                            Cantidad = detalle.Cantidad,
                            Descuento = detalle.Descuento,
                            IdArticulo = detalle.IdArticulo,
                            Precio = detalle.Precio,
                            SubTotal = detalle.SubTotalArticulo
                        });

                        var existencia = _Context.TbArticuloBodega.Where(x => x.IdArticulo == detalle.IdArticulo && x.IdBodega == detalle.IdBodega);

                        int totalExistencia = 0;
                        foreach (var exi in existencia)
                        {
                            totalExistencia += Convert.ToInt32(exi.Existencia);
                        }
                        _Context.TbArticuloBodega.Add(new TbArticuloBodega
                        {
                            Descuento = detalle.Descuento,
                            DescuentoMaximo = detalle.Descuento,
                            IdArticulo = detalle.IdArticulo,
                            IdBodega = detalle.IdBodega,
                            IdColor = detalle.IdColor,
                            IdMarca = detalle.IdMarca,
                            IdMedida = detalle.IdMedida,
                            IdTalla = detalle.IdTalla,
                            PrecioCompra = detalle.Precio,
                            PrecioVenta = detalle.PrecioVenta,
                            Existencia = (totalExistencia + detalle.Cantidad).ToString(),

                        });
                    }

                    _Context.SaveChanges();

                    scope.Complete();
                }
                catch (Exception ex)
                {

                }
            }
            return new Result { Message = "Compra reaizada exitosamente", SuccesFull = true };
        }

        public List<Compra> ConsultarComprar()
        {
            var compras = (from c in _Context.TbCompra
                           join pro in _Context.TbProveedor on c.IdProveedor equals pro.IdProveedor
                           let detalle = (from de in _Context.TbDetalleCompra
                                          join a in _Context.TbArticulo on de.IdArticulo equals a.IdArticulo
                                          
                                         
                                          where de.IdCompra == c.IdCompra
                                          select new DetCompra
                                          {
                                              Articulo = a.NombreArticulo,
                                              Cantidad = de.Cantidad,
                                              Descuento = de.Descuento,
                                              Precio = de.Precio,
                                              SubTotalArticulo = de.SubTotal
                                          })
                           select new Compra
                           {
                               IdCompra = c.IdCompra,
                               FechaCompra = c.FechaCompra,
                               Iva = c.Iva,
                               NoFactura = c.NoFactura,
                               SubTotal = c.SubTotal,
                               Total = c.Total,
                               Proveedor = pro.NombreEmpresa,
                               detalle = detalle
                           });

            var result = new List<Compra>();
            foreach (var item in compras)
            {
                item.Fecha = item.FechaCompra.Value.ToShortDateString();
                result.Add(item);
            }

            return result;
        }
    }
}