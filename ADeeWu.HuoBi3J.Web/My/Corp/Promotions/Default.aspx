<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Default" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 查看推广信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="../../../CSS/default.css">
<link rel="stylesheet" type="text/css" href="../CSS/default.css">

</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><span class="curPos">查看推广信息</span> 
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<asp:Repeater ID="rpPromotion" runat="server">
<ItemTemplate>
    <div style="padding:10px; border:1px dashed #ccc; margin-bottom:20px;">
    <div><%#Eval("Title") %></div>
    <%#Eval("Summary") %>
    <div>
    官方网站:<a href="http://<%#Eval("Url") %>" target="_blank">http://<%#Eval("Url") %></a>
    </div>
    </div>
    
    <div>
        当前审核状态:<strong><%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(Eval("CheckState").ToString(),
                   "未知",
                    new string[][]{
                        new string[]{ "0","<span style='color:#f00;'>待审核</span>" },
                        new string[]{ "1","通过审核" },
                        new string[]{ "2","过期" },
                        new string[]{ "3","无效" }
                    }) 
                   %>
                   </strong>
    </div>
</ItemTemplate>
</asp:Repeater>
<br />
<a href="Edit.aspx">修改推广信息</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>



