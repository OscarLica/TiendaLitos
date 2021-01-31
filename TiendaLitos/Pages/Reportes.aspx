<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="TiendaLitos.Pages.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="top">
            <div class="row">
            <div class="col-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-white">Filtro de reporte</h6>

                    </div>
                    <div class="card-body">
                           <div class="col-md-4">
                               <div class="form-group">
                                   <label>Tipo de reporte</label>
                                   <select class="form-control" id="TipoReporte">
                                       <option value="1">Reporte de ventas</option>
                                       <option value="2">Reporte de compras</option>
                                       <option value="3">Reporte de articulo en bodega</option>
                                       <option value="4">Reporte de productos más vendidos</option>
                                   </select>
                               </div>
                           </div>
                            <div class="col-md-4">
                                 <div class="form-group">
                                     <label>Fecha de inicio</label>
                                     <input type="date" class="form-control" id="FInicio"/>
                                 </div>
                            </div>
                            <div class="col-md-4">
                                 <div class="form-group">
                                     <label>Fecha de fin</label>
                                     <input type="date" class="form-control" id="FFinal"/>
                                 </div>
                            </div>
                        <button type="button" class="btn btn-primary float-right" data-generar-reporte="true">Generar</button>
                        </div>
                    
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-white">Reporte</h6>

                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12 text-center embed-responsive embed-responsive-16by9" id="reporte-avance-procesos">
                                <label id="lblSinResultados">Sin resultados</label>
                                <iframe width="1000" height="600" id="embedReporte" class="embed-responsive-item"></iframe>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="../Scripts/vistas/reporte.js"></script>
</asp:Content>
