<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="ProjetoFinal_DotNET.SignIn" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="text-center">Crie sua conta</h2>
            <div class="login-box">
                <div>
                    <label for="txtNome">Nome</label>
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" placeholder="Nome"></asp:TextBox>
                </div>
                <div>
                    <label for="txtEmail">E-mail</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="E-mail"></asp:TextBox>
                </div>
                <div>
                    <label for="txtSenha">Senha</label>
                    <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Senha"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-primary" OnClick="btnCadastrar_Click" />
                </div>
                <div>
                    <asp:Label ID="lblMensagem" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
