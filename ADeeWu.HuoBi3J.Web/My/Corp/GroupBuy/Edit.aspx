<%@ Page Title="" Language="C#" MasterPageFile="~/MMyCorp.master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.GroupBuy.Edit" ValidateRequest="false" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%@ Register Src="~/Controls/Category.ascx" TagPrefix="UserControl" TagName="Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    返现列表 - 添加返现
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #txtSearchAddress {
            width: 300px;
        }

        .search_tips {
            margin-top: 10px;
            color: #666;
        }

        #MainContentWrap {
            float: none;
            width: 960px;
        }
    </style>

    <script src="http://ditu.google.cn/maps?file=api&v=2&key=AIzaSyCjcgNJUDK6ty1JgsR67Usa8xUooJBmflU&sensor=false" type="text/javascript"></script>
    <script type="text/javascript" src="/map/js/markermanager_packed.js"></script>
    <script type="text/javascript" src="/js/isc.js"></script>
    <script type="text/javascript" src="/map/js/GetPosition.html.js"></script>
    <script src="/kindeditor/kindeditor.js" type="text/javascript"></script>
    <script src="/kindeditor/Globalkindeditor.js" type="text/javascript"></script>
    <script>
        $(function () {
            multEdit('<%=txtDetail.ClientID%>');
            multEdit('<%=txtRemind.ClientID%>');
            multEdit('<%=txtSellerIntro.ClientID%>');
            multEdit('<%=txtProductIntro.ClientID%>');
        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    - 返现列表 - 添加返现
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
        <asp:HiddenField ID="hfID" runat="server" />
        <table border="0" cellspacing="0" cellpadding="0" class="formTable">
        <tr>
            <td class="tdLeft">标题：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtTitle" runat="server" CssClass="txtBox" Width="400px"></asp:TextBox><span class="require">*</span><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="请填写标题！"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">比价连接：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtBuyLink" runat="server" CssClass="txtBox" Width="400px"></asp:TextBox><span class="require">不是比价返现活动请留空</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">发布地：</td>
            <td class="tdRight">
                <IscControl:SyncSelector
                    ID="syncSelectorLocation" runat="server"
                    DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>"
                    DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>"
                    ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
                    InitClientDependency="true" />
            </td>
        </tr>
        <tr>
            <td class="tdLeft">图片：</td>
            <td class="tdRight">
                <asp:HiddenField ID="hfPhoto" runat="server" />
                <IscControl:FileUploadEx ID="fuPhoto" runat="server" AllowFileExt="gif|jpg|jpeg" AllowFileSize="4096000"  />
                <span class="require">*上传文件类型必须为<%=fuPhoto.AllowFileExt %>,文件大小<%=fuPhoto.AllowFileSize %>字节</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">分类：</td>
            <td class="tdRight">
                <%--<asp:TextBox ID="txtCategory" runat="server" CssClass="txtBox" ></asp:TextBox>--%>
                <asp:DropDownList runat="server" ID="ddlCategory"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">预订数：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtSummary" runat="server" CssClass="txtBox" ></asp:TextBox><span class="require">*</span><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSummary" ErrorMessage="请填写预订数！"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">单价：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtPrice" runat="server" CssClass="txtBox" ></asp:TextBox><span class="require">*</span><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPrice" ErrorMessage="请填写单价！"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">市场价：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtMarketPrice" runat="server" CssClass="txtBox" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">热门圈：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtHotPlace" runat="server" CssClass="txtBox" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">开始预订时间：</td>
            <td class="tdRight">
                <IscControl:DateTimeSelector ID="dtsPassDate" runat="server"></IscControl:DateTimeSelector><span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">结束时间：</td>
            <td class="tdRight">
                <IscControl:DateTimeSelector ID="dtsEndDate" runat="server"></IscControl:DateTimeSelector><span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">详情：</td>
            <td class="tdRight">
                <textarea id="txtDetail" cols="100" rows="8" style="width: 586px; height: 200px; visibility: hidden;" runat="server"></textarea>
                <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">温馨提示：</td>
            <td class="tdRight">
                <textarea id="txtRemind" cols="100" rows="8" style="width: 586px; height: 200px; visibility: hidden;" runat="server"></textarea><span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">产品介绍：</td>
            <td class="tdRight">
                <textarea id="txtProductIntro" cols="100" rows="8" style="width: 586px; height: 200px; visibility: hidden;" runat="server"></textarea>
                <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">商家介绍：</td>
            <td class="tdRight">
                <textarea id="txtSellerIntro" cols="100" rows="8" style="width: 586px; height: 200px; visibility: hidden;" runat="server"></textarea>
                <span class="require">*</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">商家位置：</td>
            <td class="tdRight">
                <asp:TextBox ID="txtMapLocation" runat="server" CssClass="none maplocation"></asp:TextBox>
                地址：<input type="text" id="txtSearchAddress" /><span class="require">*</span>
                <input type="button" id="btnSearchAddress" value="搜索" />
                <span class="search_tips">例:广东省广州市北京路</span>
                <div class="search_tips">试一下输入您想要找的位置，然后在地图上点击左键，找到您想要定位的位置。</div>
                <div id="map_canvas" style="width: 650px; height: 450px;"></div>
            </td>
        </tr>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="修改" OnClick="btnSubmit_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">
</asp:Content>
