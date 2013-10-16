<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Shops.Vouchers.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 -　购物电子凭证
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">购物电子凭证</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key" style="width: 70px">标题：</td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="120px" />
                <asp:Button ID="btnSubmit" runat="server" Text="搜索" OnClick="btnSubmit_Click" />
                <%-- <a href="New.aspx">新建凭证</a>--%>
            </td>

            <%--<td >
                发布时间：</td>
            <td>
		        &nbsp;<input id="txtBeginTime" runat="server" readonly="readonly" type="text"/> 至<input 
                    id="txtEndTime" runat="server" readonly="readonly" type="text"/>
                <input name="submit" type="submit" value="搜索" /></td>--%>
        </tr>
    </table>


    <asp:GridView ID="gvData" runat="server" CssClass="gridView"
        SkinID="userGridViewSkin" AutoGenerateColumns="False">
        <Columns>

            <%--  
    <asp:TemplateField HeaderText="图片">
    <ItemTemplate>
                <a  href="/Shop/Product.aspx?product_id=<%#Eval("ID") %>">
                    <img src="<%#Eval("Picture0") %>" onload="isc.util.zoomImg(this,80,80)" border="0" />
                </a>
                <br />
                <br />
            </ItemTemplate>
    </asp:TemplateField>
            --%>
            <asp:TemplateField HeaderText="标题" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
                <ItemTemplate>
                    <%# Eval("Title")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="商家名称" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
                <ItemTemplate>
                    <%# Eval("CorpName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="发布时间" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
                <ItemTemplate>
                    <%# Eval("CreateTime")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="查看" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
                <ItemTemplate>

                    <a href='View.aspx?id=<%#Eval("ID") %>'>查看明细</a>

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>


    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>


</asp:Content>
