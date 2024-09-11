<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjetoFinal_DotNET._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="my-4">Artigos</h1>
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
