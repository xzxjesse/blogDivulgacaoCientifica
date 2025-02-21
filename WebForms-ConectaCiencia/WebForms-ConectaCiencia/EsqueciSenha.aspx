<%@ Page Title="Esqueci a Senha" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EsqueciSenha.aspx.cs" Inherits="WebForms_ConectaCiencia.EsqueciSenha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-100">
        <div class="login-box border p-4 shadow" style="width: 100%; max-width: 400px;">
            <h2 class="text-center">Esqueci a Senha</h2>

            <div class="form-group d-flex justify-content-center">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="E-mail*" />
            </div>

            <div class="text-center">
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="btnEnviar_Click" />
            </div>

            <div>
                <asp:Label ID="lblMensagem" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>