﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjetoFinal_DotNET._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="my-4">Artigos</h1>

        <div class="container mt-4">
            <div class="d-flex flex-rows gap-3 mb-4">
                <asp:TextBox ID="txtTextoPesquisa" runat="server" CssClass="form-control" Placeholder="Busca..." />
                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Selecione uma Categoria" Value="" />
                </asp:DropDownList>
                <asp:TextBox ID="txtDataPublicacao" runat="server" CssClass="form-control" TextMode="Date" Placeholder="Data de Publicação" />
                <asp:Button ID="BtnPesquisar" runat="server" Text="Pesquisar" OnClick="BtnPesquisar_Click" CssClass="btn btn-primary" />
            </div>

            <div class="container mt-4 text-center">
                <asp:Label ID="lblMensagem" runat="server" CssClass="alert alert-info" Visible="false"></asp:Label>
            </div>

            <asp:Repeater ID="Repeater1" runat="server">
            </asp:Repeater>
        </div>

        <asp:Repeater ID="ArticlesRepeater" runat="server">
            <ItemTemplate>
                <div class="card mb-4">
                    <div class="card-body">
                        <h2 class="card-title"><%# Eval("titulo") %></h2>
                        <p class="card-text"><%# Eval("conteudo") %></p>
                        <footer class="blockquote-footer">
                            Publicado por <%# Eval("nome") %> em <%# Eval("data", "{0:dd/MM/yyyy}") %>
                        </footer>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>