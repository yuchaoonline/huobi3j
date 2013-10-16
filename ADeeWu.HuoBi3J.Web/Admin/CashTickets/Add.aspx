<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Add.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.CashTickets.Add" %>




<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Admin - CashTickets - Add
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
            <span>现金券管理</span> &gt; <a href="List.aspx">列表</a> &gt; 系统生成
            </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" class="formTable">
            <%--<tr>
    <td class="tdLeft">商家:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCorp" runat="server">
        </asp:DropDownList> <span class="require">*</span>
    </td>
  </tr>--%>
            <tr>
                <td class="tdLeft">流水号生成前缀:</td>
                <td class="tdRight">
                    <asp:TextBox ID="txtPrefix" runat="server" CssClass="txtBox"></asp:TextBox>
                    <span class="require">*</span>
                    例:输入CashTicket,将生成CashTicket00001,<span class="strewColor">CashTicket</span>00002</td>
            </tr>
            <tr>
                <td class="tdLeft">流水号号码生成长度:</td>
                <td class="tdRight">
                    <asp:TextBox ID="txtNumLength" runat="server" CssClass="txtBox"></asp:TextBox>
                    <span class="require">*</span>
                    除流水号前缀外的长度,例:输入值5可生成CashTicket<span class="strewColor">00001</span>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">流水号号码起始数:</td>
                <td class="tdRight">
                    <asp:TextBox ID="txtStartNum" runat="server" CssClass="txtBox"></asp:TextBox>
                    <span class="require">*</span>
                    流水号开始生成的号码,例:输入值5,将会从CashTicket0000<span class="strewColor">5</span>开始生成到CashTicket00030
                </td>
            </tr>
            <tr>
                <td class="tdLeft">生成数量:</td>
                <td class="tdRight">
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtNum"></asp:TextBox>
                    <span class="require">*</span>
                </td>
            </tr>
            <tr>
                <td class="tdLeft">金额:</td>
                <td class="tdRight">
                    <asp:TextBox ID="txtMoney" runat="server" CssClass="txtNum"></asp:TextBox>
                    <span class="require">*</span>
                </td>
            </tr>
            <%--<tr>
    <td class="tdLeft">默认状态:</td>
    <td class="tdRight">
        <asp:DropDownList ID="ddlCheckState" runat="server">
            <asp:ListItem Value="0">待审核</asp:ListItem>
            <asp:ListItem Value="1">通过审核</asp:ListItem>
            <asp:ListItem Value="2">无效</asp:ListItem>
            <asp:ListItem Value="3">过期</asp:ListItem>
        </asp:DropDownList>
    </td>
  </tr>--%>
            <tr>
                <td class="tdLeft">&nbsp;</td>
                <td class="tdRight">
                    <asp:Button ID="btnSubmit" runat="server" Text="提交" OnClick="btnSubmit_OnClick" />
                </td>
            </tr>
        </table>

        <asp:GridView ID="gvData" runat="server" CssClass="dataGrid" SkinID="gridviewSkin" AutoGenerateColumns="False" BorderStyle="None">
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="ID">
                    <ItemTemplate>
                        <input type="checkbox" name="<% = gvData.ClientID %>" value="<%#Eval("ID") %>" />
                        <%#Eval("ID")%>
                    </ItemTemplate>

<HeaderStyle CssClass="col_id"></HeaderStyle>

<ItemStyle CssClass="col_id"></ItemStyle>
                </asp:TemplateField>

                <asp:HyperLinkField HeaderText="现金券序列号" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataNavigateUrlFields="id" DataNavigateUrlFormatString="Edit.aspx?id={0}" DataTextField="SerialNum" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
                </asp:HyperLinkField>
                <asp:BoundField HeaderText="现金券验证码" HeaderStyle-CssClass="col_title" ItemStyle-CssClass="col_title" DataField="ValidCode" >
<HeaderStyle CssClass="col_title"></HeaderStyle>

<ItemStyle CssClass="col_title"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Money" HeaderText="金额" />
                <asp:BoundField HeaderText="生成时间" HeaderStyle-CssClass="col_datetime" ItemStyle-CssClass="col_datetime" DataField="CreateTime" HtmlEncode="true" DataFormatString="{0:d}" >

<HeaderStyle CssClass="col_datetime"></HeaderStyle>

<ItemStyle CssClass="col_datetime"></ItemStyle>
                </asp:BoundField>

                <asp:TemplateField HeaderStyle-CssClass="col_state" ItemStyle-CssClass="col_state" HeaderText="状态">
                    <ItemTemplate>
                        <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[][]{
                    new string[]{"0","待审核"},
                    new string[]{"1","已审核"},
                    new string[]{"2","无效"},
                    new string[]{"3","过期"}
                }               
                )
                        %>
                    </ItemTemplate>

<HeaderStyle CssClass="col_state"></HeaderStyle>

<ItemStyle CssClass="col_state"></ItemStyle>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>


        </asp:Content>

