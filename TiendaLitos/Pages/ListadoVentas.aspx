<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoVentas.aspx.cs" Inherits="TiendaLitos.Pages.ListadoVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="top">
        <div class="row">
            <div class="col-md-12">
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#" data-href="ListadoVentas">Lista de ventas</a></li>
                        <li class="breadcrumb-item"><a href="#" data-href="Ventas">Formulario de ventas</a></li>
                    </ol>
                </nav>
            </div>
              <div class="col-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-white">Lista de Ventas</h6>

                    </div>
                    <div class="card-body">
                        <input class="form-control" placeholder="Ingrese el valor a buscar" data-search="true"/>
                        <table class="table table-hover table-stripped table-responsive">
                            <thead>
                                <tr>
                                    <th>Fecha de venta</th>
                                    <th>Monde venta</th>
                                    <th>Iva</th>
                                    <th>Sub total</th>
                                    <th>Sub total (local)</th>
                                    <th>Total</th>
                                    <th>Total (local)</th>
                                    <th>Cliente</th>
                                    <th>Detalle</th>
                                </tr>
                            </thead>
                            <tbody id="result">
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="detalleVenta" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="tituloDetalleVenta"></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <table class="table table-stripped table-condensed table-hover">
                        <thead>
                            <tr>
                                <th>Articulo </th>
                                <th>Sub categoria</th>
                                <th>Cantidad </th>
                                <th>Color </th>
                                <th>Medida </th>
                                <th>Marca </th>
                                <th>Talla </th>
                                <th>Precio </th>
                                <th>Descuento </th>
                                <th>Sub Total </th>
                            </tr>
                        </thead>
                        <tbody id="resultDetalle">

                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <script src="../Scripts/lisatoventas.js"></script>
</asp:Content>
