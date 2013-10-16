<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="ADeeWu.HuoBi3J.Web.Controls.Category" %>
<link rel="stylesheet" type="text/css" href="/CSS/CategoryNav.css">
<script type="text/javascript" src="/JS/CategoryNav.js"></script>
<%
    this.bindCategoryNav();
%>
<div class="CategoryNav-Wrap">
    <ul class="CategoryNav">
        <li data="categoryNav-data01" style="width: 95px;">
            <strong>百货消费</strong>
        </li>
        <li data="categoryNav-data02" style="width: 80px;">
            <strong>原材料</strong>
        </li>
        <li data="categoryNav-data03" style="width: 100px;">
            <strong>机电设备</strong>
        </li>
        <li class="break"></li>
    </ul>

    <div class="CategoryNav-Search">
        <input type="text" id="txtProKey" value="<%=HttpUtility.HtmlAttributeEncode(Request["key"] + "") %>" />
        <button id="btnProSearch">搜索</button>
    </div>

    <div class="break"></div>
    <div class="CategoryNav-Data-Box">
        <div class="categoryNav-data" id="categoryNav-data01">
            <asp:Repeater ID="rpCateNavData01" runat="server" OnItemDataBound="rpCateNavSub_ItemDataBound">
                <ItemTemplate>
                    <h2><a href="/Shop/Products/?cid=<%#Eval("ID")%>"><%#Eval("Name")%></a></h2>
                    <div class="categoryNav-lv03">
                        <asp:Repeater ID="rpSub" runat="server" OnItemDataBound="rpCateNavSub_ItemDataBound">
                            <ItemTemplate>
                                <a href="/Shop/Products/?cid=<%#Eval("ID")%>" class="c3"><%#Eval("Name")%></a>
                                <div class="categoryNav-lv04">
                                    <asp:Repeater ID="rpSub" runat="server">
                                        <%--OnItemDataBound="rpCateNavSub_ItemDataBound"--%>
                                        <ItemTemplate>
                                            <span>
                                                <a href="/Shop/Products/?cid=<%#Eval("ID")%>" class="c4" cid="<%#Eval("ID")%>"><%#Eval("Name")%></a>
                                                <div class="categoryNav-lv05">
                                                    <asp:Repeater ID="rpSub" runat="server">
                                                        <ItemTemplate>
                                                            <a href="/Shop/Products/?cid=<%#Eval("ID")%>" class="c5"><%#Eval("Name")%></a>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                                <!--class="categoryNav-lv05"-->
                                            </span>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <!--class="categoryNav-lv04"-->
                                <div class="break"></div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!--class="categoryNav-lv03"-->
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!--class="categoryNav-data"-->
        <div class="categoryNav-data" id="categoryNav-data02">
            <asp:Repeater ID="rpCateNavData02" runat="server" OnItemDataBound="rpCateNavSub_ItemDataBound">
                <ItemTemplate>
                    <h2><a href="/Shop/Products/?cid=<%#Eval("ID")%>"><%#Eval("Name")%></a></h2>
                    <div class="categoryNav-lv03">
                        <asp:Repeater ID="rpSub" runat="server" OnItemDataBound="rpCateNavSub_ItemDataBound">
                            <ItemTemplate>
                                <a href="/Shop/Products/?cid=<%#Eval("ID")%>" class="c3"><%#Eval("Name")%></a>
                                <div class="categoryNav-lv04">
                                    <ul>
                                        <asp:Repeater ID="rpSub" runat="server">
                                            <%--OnItemDataBound="rpCateNavSub_ItemDataBound"--%>
                                            <ItemTemplate>
                                                <li>
                                                    <a href="/Shop/Products/?cid=<%#Eval("ID")%>" class="c4" cid="<%#Eval("ID")%>"><%#Eval("Name")%></a>
                                                    <div class="categoryNav-lv05">
                                                        <asp:Repeater ID="rpSub" runat="server">
                                                            <ItemTemplate>
                                                                <a href="/Shop/Products/?cid=<%#Eval("ID")%>" class="c5"><%#Eval("Name")%></a>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                    <!--class="categoryNav-lv05"-->
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                                <!--class="categoryNav-lv04"-->
                                <div class="break"></div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!--class="categoryNav-lv03"-->
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!--class="categoryNav-data"-->
        <div class="categoryNav-data" id="categoryNav-data03">
            <asp:Repeater ID="rpCateNavData03" runat="server" OnItemDataBound="rpCateNavSub_ItemDataBound">
                <ItemTemplate>
                    <h2><a href="/Shop/Products/?cid=<%#Eval("ID")%>"><%#Eval("Name")%></a></h2>
                    <div class="categoryNav-lv03">
                        <asp:Repeater ID="rpSub" runat="server" OnItemDataBound="rpCateNavSub_ItemDataBound">
                            <ItemTemplate>
                                <a href="/Shop/Products/?cid=<%#Eval("ID")%>" class="c3"><%#Eval("Name")%></a>
                                <div class="categoryNav-lv04">
                                    <ul>
                                        <asp:Repeater ID="rpSub" runat="server">
                                            <%--OnItemDataBound="rpCateNavSub_ItemDataBound"--%>
                                            <ItemTemplate>
                                                <li>
                                                    <a href="/Shop/Products/?cid=<%#Eval("ID")%>" class="c4" cid="<%#Eval("ID")%>"><%#Eval("Name")%></a>
                                                    <div class="categoryNav-lv05">
                                                        <asp:Repeater ID="rpSub" runat="server">
                                                            <ItemTemplate>
                                                                <a href="/Shop/Products/?cid=<%#Eval("ID")%>" class="c5"><%#Eval("Name")%></a>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                    <!--class="categoryNav-lv05"-->
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                                <!--class="categoryNav-lv04"-->
                                <div class="break"></div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!--class="categoryNav-lv03"-->
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!--class="categoryNav-data"-->
    </div>
    <!--class="CategoryNav-Data-Box"-->
    <div class="break"></div>
</div>
<!--class="CategoryNav-Wrap"-->
