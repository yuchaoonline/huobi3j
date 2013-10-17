<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="RegSaleMan.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Center.RegSaleMan" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    ȫ��Ӫ�� - ���˹������� - �ҵĹؼ����б�
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=D10a875567626012d06af2387efa088e"></script>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <a href="/My/User/Center/MyQuestionList.aspx">��ʱ����</a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <div align="center">
        <strong>ע:��<span class="require">*</span> ��ʾ������</strong><br />
        <strong>�����ע�ؼ��ַ���ʱ����ȷ������˻�������50Ԫ�������޷�ͨ�����</strong><br />
        <br />
        <asp:Label ID="labTips" runat="server" Text="" ForeColor="#FF0000"></asp:Label>
    </div>
    <table class="formTable">
        <tr>
            <td class="tdLeft">���ƣ�
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtName" runat="server" CssClass="txtName"></asp:TextBox>
                <span class="require">*</span><span class="tips">����д����</span>
                <asp:RequiredFieldValidator ID="rfvTxtName" ControlToValidate="txtName" runat="server"
                    ErrorMessage="����д��" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��ϵ��ʽ��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="txtPhone"></asp:TextBox>
                <span class="tips">����д������ϵ��ʽ</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">QQ��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtQQ" runat="server" CssClass="txtQQ"></asp:TextBox>
                <span class="tips">����д����QQ</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">ְλ��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtJob" runat="server" CssClass="txtJob"></asp:TextBox>
                <span class="tips">����д����ְλ</span>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��˾���ƣ�
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="txtCompanyName"></asp:TextBox>
                <span class="require">*</span><span class="tips">����д���Ĺ�˾����</span>
                <asp:RequiredFieldValidator ID="rfvCompanyName" ControlToValidate="txtCompanyName" runat="server"
                    ErrorMessage="����д��" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��˾��ַ��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtCompanyAddress" runat="server" CssClass="txtCompanyAddress"></asp:TextBox>
                <span class="require">*</span><span class="tips">����д���Ĺ�˾��ַ</span>
                <button class="btn_blue btnPositionSearch">����</button>
                <asp:RequiredFieldValidator ID="rfvCompanyAddress" ControlToValidate="txtCompanyAddress" runat="server"
                    ErrorMessage="����д��" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��ͼ���꣺
            </td>
            <td class="tdRight">
                <asp:HiddenField ID="hfPosition" runat="server" />
                <div id="allmap" style="width: 650px; height: 400px;"></div>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">��ע��
            </td>
            <td class="tdRight">
                <asp:TextBox ID="txtMemo" runat="server" CssClass="txtMemo" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <asp:PlaceHolder ID="phCheckState" runat="server">
            <tr>
                <td class="tdLeft">��ǰ״̬��
                </td>
                <td class="tdRight">
                    <asp:Literal ID="liteCheckState" runat="server"></asp:Literal>
                </td>
            </tr>
        </asp:PlaceHolder>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:Button ID="btnSubmit" runat="server" Text="�ύ����" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>

    <script>
        var map = new BMap.Map("allmap");
        map.enableScrollWheelZoom();    //���ù��ַŴ���С��Ĭ�Ͻ���
        map.enableContinuousZoom();    //���õ�ͼ������ק��Ĭ�Ͻ���
        map.centerAndZoom("��ɽ��", 14);

        var initPoint = new BMap.Point(23.027705, 113.12843);
        var existVal = $('#<%=hfPosition.ClientID%>').val();
        if (existVal != '') {
            var a = existVal.split("|");
            initPoint = new BMap.Point(a[0], a[1]);
        }
        var marker = new BMap.Marker(initPoint);
        map.addOverlay(marker);
        marker.enableDragging();
        marker.addEventListener('dragend', function (type, target, pixel, point) {
            updatePosition(type.point);
        });

        function updatePosition(point) {
            $('#<%=hfPosition.ClientID%>').val(point.lat + '|' + point.lng);
        }

        $(function () {
            $('.btnPositionSearch').click(function () {
                var address = $('#<%=txtCompanyAddress.ClientID%>').val();
                var myGeo = new BMap.Geocoder();    // ������ַ������ʵ��
                myGeo.getPoint(address, function (point) {
                    if (point) {
                        marker.setPosition(point);
                        updatePosition(point);
                    }
                }, "��ɽ��");

                return false;
            })
        })
    </script>
</asp:Content>
