<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="TiendaLitos.Pages.Ventas" %>

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
                        <h6 class="m-0 font-weight-bold text-white">Venta</h6>

                    </div>
                    <div class="card-body">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Fecha</label>
                                <input type="datetime" readonly class="form-control" id="FechaVenta" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Iva aplicable</label>
                                <input type="text" id="Iva" readonly class="form-control" placeholder="Iva aplicable" value="10" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Sub total</label>
                                <input type="text" readonly id="SubTotalVenta" class="form-control" placeholder="0.00" data-compra="true" required data-required="El campo Sub Total es requerido" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Total</label>
                                <input type="text" readonly id="TotalVenta" class="form-control" placeholder="0.00" data-compra="true" required data-required="El campo Total es requerido" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label>Cliente</label>
                                <input type="text" data-venta="true" Id="Cliente" class="form-control" placeholder="Cliente" required data-required="El campo Cliente es requerido"/>
                                <span class="text-danger" hidden id="span-Cliente"></span>
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
                        <h6 class="m-0 font-weight-bold text-white">Detalle de la venta</h6>

                    </div>
                    <div class="card-body">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Información del articulo
                            </legend>
                            <input id="IdDetalle" hidden data-detalle="true" />
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Articulo</label>
                                    <select class="form-control" id="IdArticulo" data-detalle="true" required data-required="El campo Articulo es requerido"></select>
                                    <span class="text-danger" hidden id="span-IdArticulo"></span>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Medida</label>
                                    <input class="form-control" readonly id="Medida" data-inf="true"/>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Marca</label>
                                    <input class="form-control" readonly id="Marca" data-inf="true"/>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Color</label>
                                    <input class="form-control" readonly id="Color" data-inf="true"/>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Talla</label>
                                    <input class="form-control" readonly id="Talla" data-inf="true"/>
                                </div>
                            </div>
                        </fieldset>
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Datos de venta
                            </legend>
                             <div class="col-md-4">
                                <div class="form-group">
                                    <label>Cantidad</label>
                                    <input type="number" data-calculate="true" id="Cantidad" min="0" data-calculate="true" class="form-control" data-detalle="true" data-only-number="true" placeholder="0" required data-required="El campo Cantidad es requerido" />
                                    <span class="text-danger" hidden id="span-Cantidad"></span>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Unidad de medida de venta</label>
                                    <input type="text" id="UdMedidaVenta" class="form-control" data-detalle="true" placeholder="M" required data-required="El campo Unidad de Medidad de Venta es requerido" />
                                    <span class="text-danger" hidden id="span-UdMedidaVenta"></span>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Precio por Unida</label>
                                    <input type="number" id="PrecioPorUnida" data-inf="true" min="0" data-calculate="true" class="form-control" data-detalle="true" data-only-number="true" placeholder="0.00" required data-required="El campo Precio por Unida es requerido" />
                                    <span class="text-danger" hidden id="span-PrecioPorUnida"></span>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Precio Venta</label>
                                    <input type="number" data-calculate="true" id="PrecioVenta" min="0" data-calculate="true" class="form-control" data-detalle="true" data-only-number="true" placeholder="0.00" required data-required="El campo Precio Venta es requerido" />
                                    <span class="text-danger" hidden id="span-PrecioVenta"></span>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Descuento</label>
                                    <input type="number" data-calculate="true" id="Descuento" min="0" data-calculate="true" class="form-control" data-detalle="true" data-only-number="true" placeholder="0.00" />
                                    <span class="text-danger" hidden id="span-Descuento"></span>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Sub Total</label>
                                    <input type="text" readonly id="SubTotalArticulo" class="form-control" data-detalle="true" placeholder="0.00" required data-required="El campo Sub total es requerido" />
                                    <span class="text-danger" hidden id="span-SubTotalArticulo"></span>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Pago</label>
                                    <input type="text" data-calculat-cambio="true" id="Pago" class="form-control" data-detalle="true" placeholder="0.00" required data-required="El campo Pago es requerido" />
                                    <span class="text-danger" hidden id="span-Pago"></span>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <div class="form-group">
                                    <label>Cambio</label>
                                    <input type="text" readonly id="Cambio" class="form-control" data-detalle="true" placeholder="0.00" required data-required="El campo Cambio es requerido" />
                                    <span class="text-danger" hidden id="span-Cambio"></span>
                                </div>
                            </div>

                        </fieldset>
                        <button type="button" class="btn btn-success float-right" data-vender="true">Agregar</button>
                        <table class="table table-hover table-stripped table-condensed">
                            <thead>
                                <tr>
                                    <th>Articulo</th>
                                    <th>Cantidad</th>
                                    <th>Precio</th>
                                    <th>Descuento</th>
                                    <th>Sub total</th>
                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <tbody id="result"></tbody>
                        </table>
                        <button type="button" class="btn btn-primary float-right" data-save-vender="true">Vender</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../Scripts/vistas/ventas.js"></script>
</asp:Content>
