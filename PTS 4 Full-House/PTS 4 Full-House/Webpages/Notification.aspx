<%@ Page Title="Notificatie maken" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notification.aspx.cs" Inherits="PTS_4_Full_House.Notification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="form-group">
                        <asp:Label runat="server" AssociateID="NotificationTitle" CssClass="col-md-2 control-label">Titel</asp:Label>
                        <div class="col-md-10">
                           <asp:TextBox runat="server" ID="NotificationTitle" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NotificationTitle" CssClass="text-danger" ErrorMessage="The title field is required." />
                        </div>
     </div>
    <div class="form-group">
                        <asp:Label runat="server" AssociateID="Message" CssClass="col-md-2 control-label">Bericht</asp:Label>
                        <div class="col-md-10">
                           <asp:TextBox runat="server" ID="Message" CssClass="form-control" />
                              <asp:RequiredFieldValidator runat="server" ControlToValidate="Message" CssClass="text-danger" ErrorMessage="The Message field is required." />
                        </div>
     </div>
    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="MakeNotification" Text="Make notification" CssClass="btn btn-default" />
                        </div>
                    </div>
</asp:Content>
