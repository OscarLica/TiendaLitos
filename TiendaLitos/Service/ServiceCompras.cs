﻿using CapaEntidades;
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
                    _Context.SaveChanges();
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
                            IdCompra = compra.IdCompra,
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
                                          join ad in _Context.TbArticuloBodega on de.IdCompra equals ad.IdCompra
                                          join a in _Context.TbArticulo on de.IdArticulo equals a.IdArticulo
                                          join co in _Context.TbColor on ad.IdColor equals co.IdColor
                                          join m in _Context.TbMedida on ad.IdMedida equals m.IdMedida
                                          join ma in _Context.TbMarca on ad.IdMarca equals ma.IdMarca
                                          join t in _Context.TbTalla on ad.IdTalla equals t.IdTalla
                                          where de.IdCompra == c.IdCompra
                                          group new {de, ad, a, co, m, ma, t} by a.NombreArticulo
                                          into grupo
                                          select new DetCompra
                                          {
                                              Articulo = grupo.Key,
                                              Cantidad = grupo.FirstOrDefault().de.Cantidad,
                                              Descuento = grupo.FirstOrDefault().de.Descuento,
                                              Precio = grupo.FirstOrDefault().de.Precio,
                                              SubTotalArticulo = grupo.FirstOrDefault().de.SubTotal,
                                              Color = grupo.FirstOrDefault().co.NombreColor,
                                              Marca = grupo.FirstOrDefault().ma.NombreMarca,
                                              Talla = grupo.FirstOrDefault().t.NombreTalla,
                                              Medida = grupo.FirstOrDefault().m.NombreMedida
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