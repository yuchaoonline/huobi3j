<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Fav_Houses.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Houses.Fav_Houses" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 房源出租信息收藏夹
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">房源出租信息收藏夹</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">



    <asp:GridView Width="100%" ID="gvData" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderStyle-CssClass="col_id" ItemStyle-CssClass="col_id" HeaderText="编号">
                <ItemTemplate>
                    <a href="/Houses/View.aspx?id=<%#Eval("HouseID")%>" target="_blank"><%#Eval("homeCode") %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="标题" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_datetime" DataField="Title"></asp:BoundField>
            <asp:BoundField HeaderText="結构" HeaderStyle-CssClass="col_notes" ItemStyle-CssClass="col_notes" DataField="HouseStructText"></asp:BoundField>

            <asp:TemplateField HeaderText="户型" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money">
                <ItemTemplate>
                    <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("HouseType").ToString(),
                new string[][]{
                    new string[]{"0","住宅"},
                    new string[]{"1","商铺"},
                    new string[]{"2","写字楼"},
                    new string[]{"3","工厂"}
                }               
                )
                    %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="房屋性质" HeaderStyle-CssClass="col_money" ItemStyle-CssClass="col_money">
                <ItemTemplate>
                    <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("Properity").ToString(),
                            "其他",
                new string[][]{
                    new string[]{"0","出租"},
                    new string[]{"1","转让"}
                }         
                )
                    %>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:BoundField DataField="EndTime" HeaderText="截止日期" HtmlEncode="true" DataFormatString="{0:yyyy-MM-dd}" />
        </Columns>
    </asp:GridView>
    <table width="100%" class="dataGrid_Footer" style="margin-top: -5px;">
        <tr>
            <td class="options">
                <!-- <a href="#" onclick="setCheckGroup('<% = gvData.ClientID %>',true); void(0);">全选</a> <a href="#" onclick="resverSelect('<% = gvData.ClientID %>'); void(0);">反选</a> -->
            </td>
            <td class="pagerBox">
                <IscControl:Pager ID="Pager1" runat="server" />
            </td>
        </tr>
    </table>






</asp:Content>


