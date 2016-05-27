<%@ Page Title="Laatste meldingen" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="GetMessagesFromCims.aspx.cs" Inherits="PTS_4_Full_House.Webpages.GetMessagesFromCims" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h1><%: Title %></h1>

    <div class="allMessages">
        <div class="message">
            <h2>Titel</h2>
            <p>Lorem ipsum dolor sit amet.... Dit is de inhoud van een melding.</p>
        </div>
        <div class="message">
            <h2>Titel2</h2>
            <p>Lorem ipsum dolor sit amet.... Dit is de inhoud van een melding.</p>
        </div>
    </div>
</asp:Content>