<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ProjetoFinal_DotNET.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-container">
        <div class="section">
            <h2>Objetivo</h2>
            <p>O Conecta Ciência tem como objetivo facilitar o acesso ao conhecimento científico, promovendo a disseminação de temas acadêmicos de forma acessível e interativa. Nosso propósito é criar um espaço para professores, estudantes e pesquisadores discutirem, explorarem e compartilharem ciência.</p>
        </div>
        <div class="section">
            <h2>Como Funciona</h2>
            <p>Aqui, você pode encontrar todo tipo de artigos organizados cronologicamente e por categoria. Além disso, você pode sugerir temas e artigos, contribuindo ativamente com a ciência.</p>
        </div>
        <div class="section">
            <h2>Contato</h2>
            <p>Quer falar com a gente? Entre em contato através de <a href="mailto:jessicaeveline.sa@gmail.com">jessicaeveline.sa@gmail.com</a> ou envie uma sugestão de tema ou artigo pelo formulário Sua Voz na Ciência.</p>
        </div>
    </div>

<style>
    .main-container {
        display: flex;
        justify-content: space-between;
        margin: 20px;
    }

    .section {
        flex: 1;
        margin: 0 20px;
    }

    .section h2 {
        font-size: 1.5em;
        margin-bottom: 10px;
        text-align: center;
    }

    .section p {
        font-size: 1.1em;
        text-align: justify;
    }

    .footer {
        text-align: center;
        margin-top: 40px;
        padding: 20px;
        border-top: 1px solid #ccc;
        font-size: 0.9em;
    }

    a {
        color: #000;
        text-decoration: none;
    }
</style>
</asp:Content>
