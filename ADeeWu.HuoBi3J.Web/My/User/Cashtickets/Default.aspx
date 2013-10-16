<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Cashtickets.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ���˿������ - �ҵ��ֽ�ȯ
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function showNotes(s) {
            s = jQuery.trim(s);
            if (s.length == 0)
                alert("��ǰû�б�ע��Ϣ!");
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
    <span class="spl"></span><span class="curPos">�ҵ��ֽ�ȯ</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <asp:GridView ID="gvDataList" runat="server" CssClass="gridView" SkinID="userGridViewSkin" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" ItemStyle-CssClass="col_ID" >
<ItemStyle CssClass="col_ID"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="�̼�����" DataField="CorpName" />
            <asp:BoundField HeaderText="�ֽ�ȯ���" DataField="SerialNum" />
            <asp:BoundField HeaderText="�������" DataField="ReturnMoney" />
            <asp:BoundField HeaderText="��������" DataField="CostDate" DataFormatString="{0:d}" HtmlEncode="true" />

            <asp:TemplateField HeaderText="״̬">
                <ItemTemplate>
                    <%# ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                Eval("CheckState").ToString(),
                new string[,]{
                    {"0","�����"},
                    {"1","�����"},
                    {"2","��Ч"},
                    {"3","����"}
                }               
                )
                    %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="�ύ����" DataField="CreateTime" />
            <asp:TemplateField HeaderText="����������Ʒ�����">
                <ItemTemplate>
                    <a href="javascript:void(0);" onclick="var c=$(this); c.hide();c.next().show();">�鿴</a>
                    <div style="display: none;">
                        <a href="javascript:void(0);" class="closeNotes" onclick="var c=$(this); c.parent().hide(); c.parent().prev().show();">�ر�</a><br />
                        <%#Eval("Summary")%>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="��ע">
                <ItemTemplate>
                    <a href="javascript:void(0);" onclick="var c=$(this); c.hide();c.next().show();">�鿴</a>
                    <div style="display: none;">
                        <a href="javascript:void(0);" class="closeNotes" onclick="var c=$(this); c.parent().hide(); c.parent().prev().show();">�ر�</a><br />
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



