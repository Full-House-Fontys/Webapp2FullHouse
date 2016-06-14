<%@ Page Title="Laatste meldingen" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="GetMessagesFromCims.aspx.cs" Inherits="PTS_4_Full_House.Webpages.GetMessagesFromCims" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h1><%: Title %></h1>

    <div class="allMessages">
        <asp:Panel ID="MessagePanel" runat="server">
        </asp:Panel>

    </div>
</asp:Content>
