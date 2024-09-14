<%@ Page Title="Formulários" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forms.aspx.cs" Inherits="ProjetoFinal_DotNET.Forms" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <div class="row mb-4">
            <div class="col-md-6">
                <h2>Sugerir Tema</h2>
                <asp:TextBox ID="txtNomeTema" CssClass="form-control mb-2" runat="server" Placeholder="Seu Nome" />
                <asp:TextBox ID="txtEmailTema" CssClass="form-control mb-2" runat="server" Placeholder="Seu Email" />
                <asp:TextBox ID="txtTema" CssClass="form-control mb-2" runat="server" TextMode="MultiLine" Placeholder="Tema sugerido" />
                <asp:DropDownList ID="ddlCategoriaTema" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Selecione uma Categoria" Value="" />
                </asp:DropDownList>
                <asp:Button ID="BtnEnviarTema" CssClass="btn btn-primary mt-2" runat="server" Text="Enviar" OnClick="BtnEnviarTema_Click" />
            </div>

            <div class="col-md-6">
                <h2>Sugerir Artigo</h2>
                <asp:TextBox ID="txtNomeArtigo" CssClass="form-control mb-2" runat="server" Placeholder="Seu Nome" />
                <asp:TextBox ID="txtEmailArtigo" CssClass="form-control mb-2" runat="server" Placeholder="Seu Email" />
                <asp:TextBox ID="txtTituloArtigo" CssClass="form-control mb-2" runat="server" Placeholder="Título do Artigo" />
                <asp:TextBox ID="txtConteudoArtigo" CssClass="form-control mb-2" runat="server" TextMode="MultiLine" Placeholder="Conteúdo do Artigo" />
                <asp:DropDownList ID="ddlCategoriaArtigo" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Selecione uma Categoria" Value="" />
                </asp:DropDownList>
                <asp:Button ID="BtnEnviarArtigo" CssClass="btn btn-primary mt-2" runat="server" Text="Enviar" OnClick="BtnEnviarArtigo_Click" />
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
    </script>

</asp:Content>
