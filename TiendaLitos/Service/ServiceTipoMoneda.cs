using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaLitos.Context;

namespace TiendaLitos.Service
{
    public class ServiceTipoMoneda
    {
        public TiendaLitosEntities _Context { get; set; }
        public ServiceTipoMoneda(TiendaLitosEntities Context)
        {
            _Context = Context;
        }

        public List<TipoMoneda> GetAllTipoMoneda()
        {

            return (from a in _Context.TIPOMONEDA
                    select new TipoMoneda
                    {
                        IdTipoMoneda = a.IdTipoMoneda,
                        Activo = a.Activo ?? default,
                        TasaCambio = a.TasaCambio ?? default,
                        TMoneda = a.TMoneda

                    }).ToList();
        }

        public TipoMoneda GetTipoMonedaById(int IdTipoMoneda)
        {

            return _Context.TIPOMONEDA.Where(y => y.IdTipoMoneda == IdTipoMoneda).Select(x => new TipoMoneda
            {
                IdTipoMoneda = x.IdTipoMoneda,
                Activo = x.Activo ?? default,
                TasaCambio = x.TasaCambio ?? default,
                TMoneda = x.TMoneda

            }).FirstOrDefault();
        }

        public Result CreateTipoMoneda(TIPOMONEDA tIPOMONEDA)
        {
            var existe = _Context.TIPOMONEDA.FirstOrDefault(x => x.TMoneda == tIPOMONEDA.TMoneda);
            if (existe != null)
                return new Result { SuccesFull = false, Message = $"Ya existe un tipo de moneda con el nombre {tIPOMONEDA.TMoneda}" };

            _Context.TIPOMONEDA.Add(tIPOMONEDA);
            _Context.SaveChanges();

            return new Result { SuccesFull = true, Message = "Tipo de moneda guardado exitosamente." };
        }

        public Result UpdateTipoMoneda(TIPOMONEDA tIPOMONEDA)
        {
            var existe = _Context.TIPOMONEDA.FirstOrDefault(x => x.TMoneda == tIPOMONEDA.TMoneda && x.IdTipoMoneda != tIPOMONEDA.IdTipoMoneda);
            if (existe != null)
                return new Result { SuccesFull = false, Message = $"Ya existe un tipo de moneda con el nombre {tIPOMONEDA.TMoneda}" };

            var art = _Context.TIPOMONEDA.Find(tIPOMONEDA.IdTipoMoneda);
            art.TMoneda = tIPOMONEDA.TMoneda;
            art.TasaCambio = tIPOMONEDA.TasaCambio;
            art.Activo = tIPOMONEDA.Activo;
            _Context.SaveChanges();

            return new Result { SuccesFull = true, Message = "Tipo de moneda modificado exitosamente." };
        }
    }
}