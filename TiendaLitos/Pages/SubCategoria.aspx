<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubCategoria.aspx.cs" Inherits="TiendaLitos.Pages.SubCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="top">
        <div class="row">
            <div class="col-12 mb-4">
                <button type="button" class="btn btn-success right" data-accion-crear="true">Crear</button>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-white">Sub categorias</h6>
                    </div>
                    <div class="card-body">
                        <table class="table table-stripped table-hover table-condensed">
                            <thead>
                                <tr>
                                    <th>Categoria</th>
                                    <th>Descripción</th>
                                    <th>Estado</th>
                                    <th>Acciones</th>
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


    <div class="modal fade" id="modal-sub-categoria" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="titulo"></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <input id="IdSubCategoria" hidden />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="col-form-label">Descripción:*</label>
                                <input type="text" class="form-control" id="Descripcion" placeholder="Ingrese el campo Descripción" required data-required="El campo Descripción es requerido">
                                <span class="text-danger" hidden id="span-Descripcion"></span>
                            </div>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="col-form-label">Categoria:*</label>
                                <select class="form-control" id="Categoria" required data-required="El campo Categoria es requerido">
                                </select>
                                <span class="text-danger" hidden id="span-Categoria"></span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                         <div class="col-md-4">
                            <div class="form-check">
                                <input type="checkbox" class="form-check-input" id="Estado">
                                <label class="form-check-label" for="exampleCheck1">Estado</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-primary" data-accion-guardar="true">Guardar</button>
                </div>
            </div>
        </div>
    </div>
    <script src="../Scripts/vistas/sub-categoria.js"></script>
</asp:Content>
