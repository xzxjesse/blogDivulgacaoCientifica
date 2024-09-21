<%@ Page Title="SignIn" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="ProjetoFinal_DotNET.SignIn" Async="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-center align-items-center vh-100"> 

        <div class="login-box border p-4 shadow" style="width: 100%; max-width: 400px;">
            <h2 class="text-center">Cadastro</h2>

            <div class="form-group d-flex justify-content-center">
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control text-center" placeholder="Nome" style="width: 100%; max-width: 300px;"></asp:TextBox>
            </div>
            
            <div class="form-group d-flex justify-content-center">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control text-center" placeholder="E-mail" style="width: 100%; max-width: 300px;"></asp:TextBox>
            </div>

            <div class="form-group d-flex justify-content-center">
                    <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control text-center" TextMode="Password" placeholder="Senha" style="width: 100%; max-width: 300px;"></asp:TextBox>
            </div>

            <div class="text-center">
                <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
            </div>

            <div>
                <asp:Label ID="lblMensagem" runat="server" CssClass="text-danger text-center" Visible="false"></asp:Label>
            </div>

            <div class="text-center mt-3">
                <p>Já tem uma conta? <a href="Login.aspx">Acesse aqui</a></p>
            </div>
        </div>
    </div>
</asp:Content>
