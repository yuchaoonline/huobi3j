<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Shops.Vouchers.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ -���������ƾ֤
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">�������ƾ֤</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <table class="searchTable">
        <tr>
            <td class="key" style="width: 70px">���⣺</td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="120px" />
                <asp:Button ID="btnSubmit" runat="server" Text="����" OnClick="btnSubmit_Click" />
                <%-- <a href="New.aspx">�½�ƾ֤</a>--%>
            </td>

            <%--<td >
                ����ʱ�䣺</td>
            <td>
		        &nbsp;<input id="txtBeginTime" runat="server" readonly="readonly" type="text"/> ��<input 
                    id="txtEndTime" runat="server" readonly="readonly" type="text"/>
                <input name="submit" type="submit" value="����" /></td>--%>
        </tr>
    </table>


    <asp:GridView ID="gvData" runat="server" CssClass="gridView"
        SkinID="userGridViewSkin" AutoGenerateColumns="False">
        <Columns>

            <%--  
    <asp:TemplateField HeaderText="ͼƬ">
    <ItemTemplate>
                <a  href="/Shop/Product.aspx?product_id=<%#Eval("ID") %>">
                    <img src="<%#Eval("Picture0") %>" onload="isc.util.zoomImg(this,80,80)" border="0" />
                </a>
                <br />
                <br />
            </ItemTemplate>
    </asp:TemplateField>
            --%>
            <asp:TemplateField HeaderText="����" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
                <ItemTemplate>
                    <%# Eval("Title")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="�̼�����" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
                <ItemTemplate>
                    <%# Eval("CorpName")%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="����ʱ��" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title">
                <ItemTemplate>
                    <%# Eval("CreateTime")%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="�鿴" HeaderStyle-CssClass="col_option" ItemStyle-CssClass="col_option">
                <ItemTemplate>

                    <a href='View.aspx?id=<%#Eval("ID") %>'>�鿴��ϸ</a>

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>


    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>


</asp:Content>
