<%@ Page Title="Log in met Facebook" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginFacebook.aspx.cs" Inherits="PTS_4_Full_House.Account.LoginFacebook" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Gebruik een Facebook account om in te loggen.</h4>
                    <hr />

                    <asp:Button ID="btnLogin" runat="server" Text="Login with FaceBook" OnClick="LogInWithFacebook" />
                    <asp:Panel ID="pnlFaceBookUser" runat="server" Visible="false">
                    <hr />
                    <table>
                        <tr>
                            <td rowspan="5" valign="top">
                                <asp:Image ID="ProfileImage" runat="server" Width="50" Height="50" />
                            </td>
                        </tr>
                        <tr>
                            <td>ID:<asp:Label ID="lblId" runat="server" Text="s"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>UserName:<asp:Label ID="lblUserName" runat="server" Text="d"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Name:<asp:Label ID="lblName" runat="server" Text="a"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Email:<asp:Label ID="lblEmail" runat="server" Text="g"></asp:Label></td>
                        </tr>
                    </table>
                    </asp:Panel>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                </p>
                <p>
                    <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                    --%>
                </p>
            </section>
        </div>

        <div class="col-md-4">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>
    </div>
</asp:Content>
