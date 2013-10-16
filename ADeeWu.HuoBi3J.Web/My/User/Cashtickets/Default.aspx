<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Cashtickets.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 我的现金券
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function showNotes(s) {
            s = jQuery.trim(s);
            if (s.length == 0)
                alert("当前没有备注信息!");
            else
                alert(unescape(s));
        }
    </script>
    <style type="text/css">
        .closeNotes {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">我的现金券</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <asp:GridView ID="gvDataList" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" ItemStyle-CssClass="col_ID" >
<ItemStyle CssClass="col_ID"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="商家名称" DataField="CorpName" />
            <asp:BoundField HeaderText="现金券序号" DataField="SerialNum" />
            <asp:BoundField HeaderText="返还金额" DataField="ReturnMoney" />
            <asp:BoundField HeaderText="消费日期" DataField="CostDate" DataFormatString="{0:d}" HtmlEncode="true" />

            <asp:TemplateField HeaderText="状态">
                <ItemTemplate>
                    <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[,]{
                    {"0","待审核"},
                    {"1","已审核"},
                    {"2","无效"},
                    {"3","过期"}
                }               
                )
                    %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="提交日期" DataField="CreateTime" />
            <asp:TemplateField HeaderText="具体消费商品及金额">
                <ItemTemplate>
                    <a href="javascript:void(0);" onclick="var c=$(this); c.hide();c.next().show();">查看</a>
                    <div style="display: none;">
                        <a href="javascript:void(0);" class="closeNotes" onclick="var c=$(this); c.parent().hide(); c.parent().prev().show();">关闭</a><br />
                        <%#Eval("Summary")%>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="备注">
                <ItemTemplate>
                    <a href="javascript:void(0);" onclick="var c=$(this); c.hide();c.next().show();">查看</a>
                    <div style="display: none;">
                        <a href="javascript:void(0);" class="closeNotes" onclick="var c=$(this); c.parent().hide(); c.parent().prev().show();">关闭</a><br />
                        <%#Eval("Notes")%>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="pager">
        <IscControl:Pager ID="Pager1" runat="server" />
    </div>

</asp:Content>



