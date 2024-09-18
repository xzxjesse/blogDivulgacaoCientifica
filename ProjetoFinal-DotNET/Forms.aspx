<%@ Page Title="Formulários" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forms.aspx.cs" Inherits="ProjetoFinal_DotNET.Forms" Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <div class="alert alert-success d-none text-center" id="alertSuccess" role="alert">
            Dados salvos com sucesso!
        </div>

        <div class="alert alert-danger d-none text-center" id="alertError" role="alert">
            Ocorreu um erro, tente novamente mais tarde.
        </div>

        <div class="row mb-4">
            <div class="col-md-6 text-center">
                <h2>Sugerir Tema</h2>
                <asp:TextBox ID="txtNomeTema" CssClass="form-control mb-2 mx-auto" runat="server" Placeholder="Nome*" />
                <asp:TextBox ID="txtEmailTema" CssClass="form-control mb-2 mx-auto" runat="server" Placeholder="Email*" />
                <asp:TextBox ID="txtTema" CssClass="form-control mb-2 mx-auto" runat="server" TextMode="MultiLine" Placeholder="Tema*" />
                <asp:DropDownList ID="ddlCategoriaTema" runat="server" CssClass="form-control mx-auto">
                    <asp:ListItem Text="Selecione uma Categoria" Value="" />
                </asp:DropDownList>
                <asp:Button ID="BtnEnviarTema" CssClass="btn btn-primary mt-2" runat="server" Text="Enviar" OnClick="BtnEnviarTema_Click" Enabled="false" />
            </div>

            <div class="col-md-6 text-center">
                <h2>Sugerir Artigo</h2>
                <asp:TextBox ID="txtNomeArtigo" CssClass="form-control mb-2 mx-auto" runat="server" Placeholder="Nome*" />
                <asp:TextBox ID="txtEmailArtigo" CssClass="form-control mb-2 mx-auto" runat="server" Placeholder="Email*" />
                <asp:TextBox ID="txtTituloArtigo" CssClass="form-control mb-2 mx-auto" runat="server" Placeholder="Título*" />
                <asp:TextBox ID="txtConteudoArtigo" CssClass="form-control mb-2 mx-auto" runat="server" TextMode="MultiLine" Placeholder="Conteúdo*" />
                <asp:DropDownList ID="ddlCategoriaArtigo" runat="server" CssClass="form-control mx-auto">
                    <asp:ListItem Text="Selecione uma Categoria" Value="" />
                </asp:DropDownList>
                <asp:Button ID="BtnEnviarArtigo" CssClass="btn btn-primary mt-2" runat="server" Text="Enviar" OnClick="BtnEnviarArtigo_Click" Enabled="false" />
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function mostrarMensagem(idAlert, mensagem) {
            var alert = document.getElementById(idAlert);
            alert.textContent = mensagem;
            alert.classList.remove('d-none');
            setTimeout(function () {
                alert.classList.add('d-none');
            }, 5000);
        }

        function validarCamposTema() {
            var nomeTema = document.getElementById('<%= txtNomeTema.ClientID %>').value.trim();
            var emailTema = document.getElementById('<%= txtEmailTema.ClientID %>').value.trim();
            var tema = document.getElementById('<%= txtTema.ClientID %>').value.trim();
            var categoriaTema = document.getElementById('<%= ddlCategoriaTema.ClientID %>').value;

            var botaoEnviarTema = document.getElementById('<%= BtnEnviarTema.ClientID %>');

            if (nomeTema !== "" && emailTema !== "" && tema !== "" && categoriaTema !== "") {
                botaoEnviarTema.disabled = false;
            } else {
                botaoEnviarTema.disabled = true;
            }
        }

        function validarCamposArtigo() {
            var nome = document.getElementById('<%= txtNomeArtigo.ClientID %>').value.trim();
            var email = document.getElementById('<%= txtEmailArtigo.ClientID %>').value.trim();
            var titulo = document.getElementById('<%= txtTituloArtigo.ClientID %>').value.trim();
            var conteudo = document.getElementById('<%= txtConteudoArtigo.ClientID %>').value.trim();
            var categoria = document.getElementById('<%= ddlCategoriaArtigo.ClientID %>').value;

            var botaoEnviar = document.getElementById('<%= BtnEnviarArtigo.ClientID %>');

            if (nome !== "" && email !== "" && titulo !== "" && conteudo !== "" && categoria !== "") {
                botaoEnviar.disabled = false;
            } else {
                botaoEnviar.disabled = true;
            }
        }

        document.addEventListener('DOMContentLoaded', function () {
            document.getElementById('<%= txtNomeTema.ClientID %>').addEventListener('input', validarCamposTema);
            document.getElementById('<%= txtEmailTema.ClientID %>').addEventListener('input', validarCamposTema);
            document.getElementById('<%= txtTema.ClientID %>').addEventListener('input', validarCamposTema);
            document.getElementById('<%= ddlCategoriaTema.ClientID %>').addEventListener('change', validarCamposTema);
        });

        document.addEventListener('DOMContentLoaded', function () {
            document.getElementById('<%= txtNomeArtigo.ClientID %>').addEventListener('input', validarCamposArtigo);
            document.getElementById('<%= txtEmailArtigo.ClientID %>').addEventListener('input', validarCamposArtigo);
            document.getElementById('<%= txtTituloArtigo.ClientID %>').addEventListener('input', validarCamposArtigo);
            document.getElementById('<%= txtConteudoArtigo.ClientID %>').addEventListener('input', validarCamposArtigo);
            document.getElementById('<%= ddlCategoriaArtigo.ClientID %>').addEventListener('change', validarCamposArtigo);
        });
    </script>

</asp:Content>
