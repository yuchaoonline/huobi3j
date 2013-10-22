<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.CorpAgent.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 营销代理商 - 网络营销专员
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">营销专员(提交简历)</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <div align="center">
        <strong>注:带<span class="require">*</span> 表示必填项</strong><br />
        <br />
        <asp:Label ID="labTips" runat="server" Text="" ForeColor="#FF0000"></asp:Label>
    </div>

    <table class="formTable">
        <tr>
            <td class="tdLeft">真实姓名：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtRealName" runat="server" CssClass="txtUserName"></asp:TextBox>
                <span class="require">*</span><span class="tips">请填写您的真实姓名</span>
                <asp:RequiredFieldValidator ID="rfvTxtRealName" ControlToValidate="txtRealName" runat="server" ErrorMessage="请填写！" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">性　　别：
            </td>
            <td class="tdRight">
                <asp:DropDownList ID="ddlSex" runat="server">
                    <asp:ListItem Text="请选择" Value="" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="男" Value="男"></asp:ListItem>
                    <asp:ListItem Text="女" Value="女"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">出生日期：
            </td>
            <td class="tdRight">
                <ADeeWuControl:DateTimeSelector ID="txtBirthday" runat="server" CssClass="txtDate"></ADeeWuControl:DateTimeSelector>
                <span class="require">*</span><span class="tips">请填写您的出生日期</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">所在地区：
            </td>
            <td class="tdRight">
                <ADeeWuControl:SyncSelector ID="syncSelectorLocation" runat="server"
                    DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>"
                    DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>"
                    ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>" />
                <span class="require">*</span> <span class="tips">请选择您所在的地区</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">具体地址：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtAddress" runat="server" CssClass="txtAddress"></asp:TextBox>
                <span class="require">*</span><span class="tips">请填写您所在的地址</span>
                <asp:RequiredFieldValidator ID="rfvTxtAddress" ControlToValidate="txtAddress" runat="server" ErrorMessage="请填写！" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">邮政编码：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtZipCode" runat="server" CssClass="txtZipCode"></asp:TextBox>
                <span class="tips">请填您所在地的邮政编码</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">学　　历：
            </td>
            <td class="tdRight">
                <ADeeWuControl:SyncSelector ID="syncSelectorEducation" runat="server"
                    DataSourceURL="<%$Resources:SyncSelector,Education_DataSourceURL %>"
                    DataSourceName="<%$Resources:SyncSelector,Education_DataSourceName %>"
                    ClientPostNames="<%$Resources:SyncSelector,Education_ClientPostNames %>" />
                <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">工作经验：
            </td>
            <td class="tdRight">
                <ADeeWuControl:SyncSelector ID="syncSelectorWorkExp" runat="server"
                    DataSourceURL="<%$Resources:SyncSelector,WorkExp_DataSourceURL %>"
                    DataSourceName="<%$Resources:SyncSelector,WorkExp_DataSourceName %>"
                    ClientPostNames="<%$Resources:SyncSelector,WorkExp_ClientPostNames %>" />
                <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">毕业学校：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtSchool" runat="server" CssClass="txtAddress"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">专　　业：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtSpeciality" runat="server" CssClass="txtBox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">技　　能：
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtSkill" runat="server" TextMode="MultiLine" CssClass="txtNotes" Columns="50" Rows="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">备　　注：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" CssClass="txtNotes" Columns="50" Rows="5"></asp:TextBox>
                <span class="tips">这里可以填写你代理的时间段，让商家更快找到您。
                </span>
            </td>
        </tr>
        <asp:PlaceHolder ID="phIsHidden" runat="server">
            <tr>
                <td class="tdLeft">隐　　藏：</td>
                <td class="tdRight">
                    <asp:CheckBox ID="chkSetHidden" runat="server" Text="是" AutoPostBack="true"
                        OnCheckedChanged="chkSetHidden_CheckedChanged" />
                    <span class="tips">钩选后立即隐藏您的简历，让商家不能再搜索到您的简历</span>
                </td>

            </tr>
            <tr>
                <td class="tdLeft">推广链接：</td>
                <td class="tdRight">
                    <span id="PromotionLink">
                        <asp:TextBox ID="txtPromotionLink" runat="server" ReadOnly="true" Width="400px"></asp:TextBox>
                    </span><%--<a href="javascript:if( isc.util.copyToClipboard($('#txtPromotionLink').val()) ) alert('链接地址已复制到粘贴板中'); void(0);">复制</a>--%>
                    <div class="tips">商家通过该链接进行注册帐号以后，该商家立即成为您的业务客户。</div>
                </td>
            </tr>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phCheckState" runat="server">
            <tr>
                <td class="tdLeft">当前状态：</td>
                <td class="tdRight">
                    <asp:Literal ID="liteCheckState" runat="server"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="提交申请"
                    OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>





</asp:Content>
