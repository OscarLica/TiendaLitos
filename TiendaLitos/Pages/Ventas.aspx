<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="TiendaLitos.Pages.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="top">
        <div class="row">
            <div class="col-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-white">Venta</h6>

                    </div>
                    <div class="card-body">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Fecha</label>
                                <input type="datetime" readonly class="form-control" Id="FechaCompra"/>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Factura</label>
                                <input type="text" readonly class="form-control" placeholder="Nº de factura" />
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Iva aplicable</label>
                                <input type="text" readonly class="form-control" placeholder="Iva aplicable" value="10"/>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Sub total</label>
                                <input type="text" readonly class="form-control" placeholder="0.00"/>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Total</label>
                                <input type="text" readonly class="form-control" placeholder="0.00" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Proveedor</label>
                                <select class="form-control" id="Proveedor"></select>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-white">Detalle de venta</h6>

                    </div>
                    <div class="card-body">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Articulo</label>
                                <select class="form-control"></select>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Cantidad</label>
                                <input type="text" readonly class="form-control" placeholder="Ingrese la cantidad" />
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Precio </label>
                                <input type="text" readonly class="form-control" placeholder="Ingrese el precio" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Descuento</label>
                                <input type="text" readonly class="form-control" placeholder="Descuento" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Sub Total</label>
                                <input type="text" readonly class="form-control" placeholder="SubTotal" />
                            </div>
                        </div>


                        <table class="table table-hover table-stripped table-condensed">
                            <thead>
                                <tr>
                                    <th>Articulo</th>
                                    <th>Cantidad</th>
                                    <th>Precio</th>
                                    <th>Descuento</th>
                                    <th>Sub total</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
