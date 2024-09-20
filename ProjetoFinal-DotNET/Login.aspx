<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjetoFinal_DotNET.Login" Async="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-100">
        <div class="login-box border p-4 shadow " style="width: 100%; max-width: 400px;">
            <h2 class="text-center">Acesso</h2>

            <div class="form-group d-flex justify-content-center">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="E-mail" />
            </div>

            <div class="form-group d-flex justify-content-center">
                    <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Senha" />
            </div>

            <div class="text-center">
                <asp:Button ID="btnLogin" runat="server" Text="Entrar" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
            </div>

            <div>
                <asp:Label ID="lblMensagem" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            </div>

            <div class="text-center mt-3">
                <p>Não tem uma conta? <a href="SignIn.aspx">Cadastre-se aqui</a></p>
            </div>
        </div>
    </div>
</asp:Content>
