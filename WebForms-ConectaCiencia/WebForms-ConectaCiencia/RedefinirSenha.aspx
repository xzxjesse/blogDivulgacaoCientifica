<%@ Page Title="Redefinir Senha" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RedefinirSenha.aspx.cs" Inherits="WebForms_ConectaCiencia.RedefinirSenha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-100">
        <div class="login-box border p-4 shadow" style="width: 100%; max-width: 400px;">
            <h2 class="text-center">Redefinir Senha</h2>

            <div class="form-group d-flex justify-content-center">
                <asp:TextBox ID="txtNovaSenha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Nova Senha*" />
            </div>

            <div class="form-group d-flex justify-content-center">
                <asp:TextBox ID="txtConfirmarSenha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirmar Senha*" />
            </div>

            <div class="text-center">
                <asp:Button ID="btnRedefinir" runat="server" Text="Redefinir Senha" CssClass="btn btn-primary" OnClick="btnRedefinir_Click" />
            </div>

            <div>
                <asp:Label ID="lblMensagem" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>