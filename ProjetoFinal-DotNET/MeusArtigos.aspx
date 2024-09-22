<%@ Page Title="Meus Artigos" Language="C#" AutoEventWireup="true" CodeBehind="MeusArtigos.aspx.cs" Inherits="ProjetoFinal_DotNET.MeusArtigos" MasterPageFile="~/Site.master" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="my-4">Meus Artigos</h1>

        <div class="form-group d-flex justify-content-center">
            <asp:Button ID="btnPublicar" runat="server" Text="Publicar" CssClass="btn btn-primary w-100" OnClick="btnPublicar_Click"/>
        </div>

        <div class="container mt-4 text-center">
            <asp:Label ID="lblMensagem" runat="server" CssClass="alert alert-info" Visible="false"></asp:Label>
        </div>

        <asp:Repeater ID="ArticlesRepeater" runat="server">
            <ItemTemplate>
                <div class="card mb-4 border p-2 shadow">
                    <div class="card-body">
                        <h2 class="card-title d-flex justify-content-between align-items-center">
                            <%# Eval("Titulo") %>
                            <button class="btn btn-light" type="button" data-bs-toggle="collapse" data-bs-target="#optionsCollapse<%# Container.ItemIndex %>" aria-expanded="false" aria-controls="optionsCollapse<%# Container.ItemIndex %>">
                                <i class="fas fa-ellipsis-v"></i>
                            </button>
                        </h2>
                        <div class="collapse" id="optionsCollapse<%# Container.ItemIndex %>">
                            <div class="row justify-content-end">
                                <div class="col-auto">
                                    <div class="list-group">
                                        <a href="Editar.aspx" class="list-group-item list-group-item-action" style="width: 200px; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;">
                                            <i class="fas fa-edit"></i> Editar
                                        </a>
                                        <a href="#" class="list-group-item list-group-item-action text-danger" style="width: 200px; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;">
                                            <i class="fas fa-trash-alt"></i> Excluir
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <p class="card-text"><%# Eval("Conteudo") %></p>
                        <footer class="blockquote-footer">
                            Publicado por <%# Eval("Usuario.Nome") %> em <%# Eval("Data", "{0:dd/MM/yyyy}") %>
                        </footer>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">

    </div>
</asp:Content>
