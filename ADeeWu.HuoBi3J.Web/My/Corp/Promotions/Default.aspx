<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Default" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
�̼ҿ������ - �鿴�ƹ���Ϣ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="../../../CSS/default.css">
<link rel="stylesheet" type="text/css" href="../CSS/default.css">

</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">��</span><span class="curPos">�鿴�ƹ���Ϣ</span> 
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

<asp:Repeater ID="rpPromotion" runat="server">
<ItemTemplate>
    <div style="padding:10px; border:1px dashed #ccc; margin-bottom:20px;">
    <div><%#Eval("Title") %></div>
    <%#Eval("Summary") %>
    <div>
    �ٷ���վ:<a href="http://<%#Eval("Url") %>" target="_blank">http://<%#Eval("Url") %></a>
    </div>
    </div>
    
    <div>
        ��ǰ���״̬:<strong><%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(Eval("CheckState").ToString(),
                   "δ֪",
                    new string[][]{
                        new string[]{ "0","<span style='color:#f00;'>�����</span>" },
                        new string[]{ "1","ͨ�����" },
                        new string[]{ "2","����" },
                        new string[]{ "3","��Ч" }
                    }) 
                   %>
                   </strong>
    </div>
</ItemTemplate>
</asp:Repeater>
<br />
<a href="Edit.aspx">�޸��ƹ���Ϣ</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>



