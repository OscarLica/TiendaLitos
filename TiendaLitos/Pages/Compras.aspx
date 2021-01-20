<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="TiendaLitos.Pages.Compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="top">

        <div class="row">
            <div class="col-md-12">
                <nav aria-label="breadcrumb">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="#" data-href="ListadoCompras">Lista de compras</a></li>
                        <li class="breadcrumb-item"><a href="#" data-href="Compras">Formulario de compras</a></li>
                    </ol>
                </nav>
            </div>
            <div class="col-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-white">Compra</h6>

                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Fecha</label>
                                    <input type="datetime" readonly class="form-control" id="FechaCompra" />
                                </div>
                            </div>


                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Iva aplicable</label>
                                    <input type="number" readonly id="Iva" class="form-control" placeholder="Iva aplicable" value="15" min="0" data-compra="true" required data-required="El campo Iva es requerido" />
                                    <span class="text-danger" hidden id="span-Iva"></span>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Sub total</label>
                                    <input type="text" readonly id="SubTotalCompra" class="form-control" placeholder="0.00" data-compra="true" required data-required="El campo Sub Total es requerido" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Total</label>
                                    <input type="text" readonly id="TotalCompra" class="form-control" placeholder="0.00" data-compra="true" required data-required="El campo Total es requerido" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Proveedor</label>
                                    <select class="form-control" id="IdProveedor" data-compra="true" required data-required="El campo Proveedor es requerido"></select>
                                    <span class="text-danger" hidden id="span-IdProveedor"></span>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Bodega</label>
                                    <select class="form-control" id="IdBodega" data-compra="true" required data-required="El campo Bodega es requerido"></select>
                                    <span class="text-danger" hidden id="span-IdBodega"></span>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Tipo de moneda</label>
                                    <select class="form-control" id="IdTipoMoneda" data-compra="true" required data-required="El campo Tipo de moneda es requerido"></select>
                                    <span class="text-danger" hidden id="span-IdTipoMoneda"></span>
                                </div>
                            </div>
                            <div class="col-md-8"></div>
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
                        <h6 class="m-0 font-weight-bold text-white">Detalle de la compra</h6>

                    </div>
                    <div class="card-body">
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Información del articulo
                            </legend>
                            <input id="IdDetalle" hidden data-detalle="true" />
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Árticulo</label>
                                        <select class="form-control" id="IdArticulo" data-detalle="true" required data-required="El campo Árticulo es requerido"></select>
                                        <span class="text-danger" hidden id="span-IdArticulo"></span>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Sub categoria</label>
                                        <input class="form-control" id="subcategoria" placeholder="Sub categoria" readonly />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Medida</label>
                                        <select class="form-control" id="IdMedida" data-detalle="true" required data-required="El campo Medida es requerido"></select>
                                        <span class="text-danger" hidden id="span-IdMedida"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Marca</label>
                                        <select class="form-control" id="IdMarca" data-detalle="true" required data-required="El campo Marca es requerido"></select>
                                        <span class="text-danger" hidden id="span-IdMarca"></span>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Color</label>
                                        <select class="form-control" id="IdColor" data-detalle="true" required data-required="El campo Color es requerido"></select>
                                        <span class="text-danger" hidden id="span-IdColor"></span>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Talla</label>
                                        <select class="form-control" id="IdTalla" data-detalle="true" required data-required="El campo Talla es requerido"></select>
                                        <span class="text-danger" hidden id="span-IdTalla"></span>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                        <fieldset class="scheduler-border">
                            <legend class="scheduler-border">Datos de compra
                            </legend>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Cantidad</label>
                                    <input type="number" id="Cantidad" min="0" data-calculate="true" class="form-control" data-detalle="true" data-only-number="true" placeholder="0" required data-required="El campo Cantidad es requerido" />
                                    <span class="text-danger" hidden id="span-Cantidad"></span>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Precio Compra</label>
                                    <input type="number" id="Precio" min="0" data-calculate="true" class="form-control" data-detalle="true" data-only-number="true" placeholder="0.00" required data-required="El campo Precio Compra es requerido" />
                                    <span class="text-danger" hidden id="span-Precio"></span>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Precio Venta</label>
                                    <input type="number" id="PrecioVenta" min="0" data-calculate="true" class="form-control" data-detalle="true" data-only-number="true" placeholder="0.00" required data-required="El campo Precio Venta es requerido" />
                                    <span class="text-danger" hidden id="span-PrecioVenta"></span>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Descuento</label>
                                    <input type="number" id="Descuento" min="0" data-calculate="true" class="form-control" data-detalle="true" data-only-number="true" placeholder="0.00" />
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
                        </fieldset>
                        <button type="button" class="btn btn-success float-right" data-comprar="true">Agregar</button>
                        <table class="table table-hover table-stripped table-condensed">
                            <thead>
                                <tr>
                                    <th>Articulo</th>
                                    <th>Cantidad</th>
                                    <th>Precio</th>
                                    <th>Descuento</th>
                                    <th>Sub total</th>
                                    <th>Sub total(moneda local)</th>
                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <tbody id="result"></tbody>
                        </table>
                        <button type="button" class="btn btn-primary float-right" data-save-comprar="true">Comprar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../Scripts/vistas/compra.js"></script>
</asp:Content>
