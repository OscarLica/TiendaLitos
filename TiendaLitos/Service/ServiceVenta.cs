﻿using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using TiendaLitos.Context;

namespace TiendaLitos.Service
{
    public class ServiceVenta
    {
        public TiendaLitosEntities _Context { get; set; }
        public ServiceVenta(TiendaLitosEntities Context)
        {
            _Context = Context;
        }

        public List<Venta> ConsultarVentas()
        {

            var result = (from v in _Context.TbVenta
                          let detalle = (
                          from d in _Context.TbDetalleVenta
                          join ad in _Context.TbArticuloBodega on d.IdArticulo equals ad.IdArticuloBodega
                          join a in _Context.TbArticulo on ad.IdArticulo equals a.IdArticulo
                          join c in _Context.TbColor on ad.IdColor equals c.IdColor
                          join m in _Context.TbMedida on ad.IdMedida equals m.IdMedida
                          join ma in _Context.TbMarca on ad.IdMedida equals ma.IdMarca
                          join t in _Context.TbTalla on ad.IdTalla equals t.IdTalla
                          where d.IdVenta == v.IdVenta
                          select new DetVenta
                          {
                              Articulo = a.NombreArticulo,
                              Cantidad = d.Cantidad,
                              Color = c.NombreColor,
                              Descuento = d.Descuento,
                              Marca = ma.NombreMarca,
                              Medida = m.NombreMedida,
                              Precio = d.PrecioVenta,
                              SubTotal = d.SubTotal,
                              Talla = t.NombreTalla,
                          }
                            ).ToList()
                          select new Venta
                          {
                              IdVenta = v.IdVenta,
                              Cliente = v.NombreCliente,
                              FechaVenta = v.Fecha,
                              Iva = v.Iva,
                              SubTotal = v.SubTotal,
                              Total = v.Total,
                              detalle = detalle
                          }).ToList();

            return result;
        }
        public Result Vender(VentaRequest ventaRequest)
        {
            var nVentas = _Context.TbVenta.Count() + 1;
            var fActual = DateTime.Now;

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    var venta = new TbVenta
                    {
                        IdPromoción = 1,
                        Iva = ventaRequest.Venta.Iva,
                        Fecha = fActual,
                        IdUsuario = 1,
                        Anular = false,
                        NombreCliente = ventaRequest.Venta.Cliente,
                        Total = ventaRequest.Venta.TotalVenta,
                        SubTotal = ventaRequest.Venta.SubTotalVenta
                    };
                    _Context.TbVenta.Add(venta);

                    foreach (var item in ventaRequest.DetalleVenta)
                    {
                        _Context.TbDetalleVenta.Add(new TbDetalleVenta
                        {
                            IdVenta = venta.IdVenta,
                            Pago = item.Pago,
                            Cambio = item.Cambio,
                            PrecioVenta = item.PrecioVenta,
                            Cantidad = item.Cantidad,
                            DescripciónArticulo = "",
                            Descuento = item.Descuento,
                            IdArticulo = item.IdArticulo,
                            PrecioPorUnidad = item.PrecioPorUnida,
                            SubTotal = item.SubTotalArticulo,
                            UdMedidaVenta = item.UdMedidaVenta
                        });

                        var articuloBodega = _Context.TbArticuloBodega.FirstOrDefault(x =>
                            x.IdArticuloBodega == item.IdArticulo
                        );

                        articuloBodega.Existencia = (Convert.ToInt32(articuloBodega.Existencia) - item.Cantidad).ToString();
                    }
                    _Context.SaveChanges();
                    scope.Complete();

                }
                catch (Exception ex)
                {
                    return new Result { Message = "Error realizando la venta" };

                }
                return new Result
                {
                    SuccesFull = true,
                    Message = "Venta realizada exitosamente."
                };
            }
        }
    }
}