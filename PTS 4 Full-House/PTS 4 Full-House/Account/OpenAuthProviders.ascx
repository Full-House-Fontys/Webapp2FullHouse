<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAuthProviders.ascx.cs" Inherits="PTS_4_Full_House.Account.OpenAuthProviders" %>

<div id="socialLoginList">
    <h4>Use another service to log in.</h4>
    <hr />
    <asp:ListView runat="server" ID="providerDetails" ItemType="System.String"
        SelectMethod="GetProviderNames" ViewStateMode="Disabled">
        <ItemTemplate>
            <p>
                <button type="submit" class="btn btn-default" name="provider" value="<%#: Item %>"
                    title="Log in using your <%#: Item %> account.">
                    <%#: Item %>
                </button>
            </p>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>
                <p>
                    <asp:Button runat="server" OnClick="LogInWithFacebook" CausesValidation="False" Text="F" CssClass="btn btn-social-facebook" ImageUrl="Images/twitter-icon.png"/>
                    <asp:Button runat="server" OnClick="LogInWithTwitter" CausesValidation="False" Text="T" CssClass="btn btn-default" ImageUrl="Images/twitter-icon.png"/>
                </p>
            </div>   
        </EmptyDataTemplate>
    </asp:ListView>
</div>
