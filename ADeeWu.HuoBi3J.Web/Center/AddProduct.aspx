<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master"  AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.AddProduct" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
即时报价 - 添加相关商品
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
<link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery.watermark.js" ></script>
<script type="text/javascript" src="/js/user.js" ></script>
<script src="/kindeditor/kindeditor.js" type="text/javascript"></script>
<script>
    $(function () {
        
    })
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">    
    <div class="item">
        <div class="itemTitle">
            添加商品
        </div>
        <table class="formTable">
            <tr>
                <td class="tdLeft">商品名称：
                </td>
                <td class="tdRight">
                    <asp:TextBox ID="txtProductName" runat="server" CssClass="txtBox" Width="400px"></asp:TextBox><span class="require">*</span><asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductName" ErrorMessage="请填写产品标题!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">商品分类：
                </td>
                <td class="tdRight">
                    <IscControl:SyncSelector ID="syncSelectorShopProductCategories" runat="server" 
                    DataSourceURL="<%$Resources:SyncSelector,ShopProductCategories_DataSourceURL %>" 
                    DataSourceName="<%$Resources:SyncSelector,ShopProductCategories_DataSourceName %>" 
                    ClientPostNames="<%$Resources:SyncSelector,ShopProductCategories_ClientPostNames %>" />
                    <span class="require">*</span>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">商品内容：
                </td>
                <td class="tdRight">
                    <asp:TextBox ID="txtContent" runat="server" CssClass="txtBox" Width="400px" TextMode="MultiLine"></asp:TextBox><span class="require">*</span><asp:RequiredFieldValidator
            ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContent" ErrorMessage="请填写商品内容!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">商品图片：
                </td>
                <td class="tdRight">
                    <IscControl:FileUploadEx ID="filePicture" runat="server" AllowFileSize="512000" AllowFileExt="jpg|jpeg|gif|png|bmp" /><span class="require">*</span>
                </td>
            </tr>
            <tr>
                <td class="tdLeft"></td>
                <td class="tdRight">
                    <asp:Button ID="btnSubmit" runat="server" Text="添加" onclick="btnSubmit_Click" CssClass="button" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>