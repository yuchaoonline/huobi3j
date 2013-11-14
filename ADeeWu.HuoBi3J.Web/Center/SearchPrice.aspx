<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="SearchPrice.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.SearchPrice" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>
<%@ Register Src="~/Controls/ucNav.ascx" TagPrefix="uc1" TagName="ucNav" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    �������� - ��������
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/JS/jquery.simplemodal.js"></script>
    <script type="text/javascript" src="/js/jquery.watermark.js"></script>
    <script type="text/javascript" src="/js/user.js"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=D10a875567626012d06af2387efa088e"></script>
    <!-- Contact Form CSS files -->
    <link type='text/css' href='/css/basic.css' rel='stylesheet' media='screen' />

    <!-- IE6 "fix" for the close png image -->
    <!--[if lt IE 7]>
    <link type='text/css' href='/css/basic_ie.css' rel='stylesheet' media='screen' />
    <![endif]-->
    <script type="text/javascript">
        $(function () {
            var val = $('.txtKeyword').val();
            if(val=='')
                val='����۸�';
            $('.txtKeyword').val('');
            $('.txtKeyword').watermark(val);

            $('.attentionCount').click(function(){
                var kid = $(this).parents('#recruit_list').find('[name=kid]').val();
                $.getJSON('/ajax/center.ashx',{method: 'getattention',kid: kid},function(data){
                    if(data!=null){
                        var html = "<ul class='attentionList'>";
                        for(i=0;i<data.length;i++){
                            var item = data[i];
                            html+="<li><a href='#"+item.UID+"'>"+item.UName+"</a></li>";
                        }
                        html+="</ul>";

                        $('#attentionDialog').html(html).dialog({modal: true});
                    }
                })
            }).css('cursor','pointer');

            $('.btn_search').click(function(){
                var newVal = $(".txtKeyword").val();
                if(newVal=='')
                    newVal=val;
                if(newVal=='����۸�')
                    newVal='';
                var url = "<%=HttpContext.Current.Request.FilePath %>?keyword=" + newVal;
                location.href=url;
                return false;
            });

            $('.no-record').hide();

            $('.result img').ReduceImage();

            $('#txtKeyword').enter($('.btn_search'));

            var map = new BMap.Map("allmap");
            map.enableScrollWheelZoom();    //���ù��ַŴ���С��Ĭ�Ͻ���
            map.enableContinuousZoom();    //���õ�ͼ������ק��Ĭ�Ͻ���
            map.centerAndZoom('<%=ADeeWu.HuoBi3J.Web.Class.AccountHelper.City%>', 14);
            map.addEventListener("tilesloaded", function () {
                getData();
            });
            map.addEventListener("dragend", function () {
                getData();
            });

            function getData() {
                var bs = map.getBounds();   //��ȡ��������
                var bssw = bs.getSouthWest();   //�����������½�
                var bsne = bs.getNorthEast();   //�����������Ͻ�
                var keyword = '<%=Request["keyword"]%>';
                //console.log("��ǰ��ͼ���ӷ�Χ�ǣ�" + bssw.lng + "," + bssw.lat + "��" + bsne.lng + "," + bsne.lat);

                $.getJSON('/ajax/center.ashx', { method: 'getpricedata', bssw_lng: bssw.lng, bssw_lat: bssw.lat, bsne_lng: bsne.lng, bsne_lat: bsne.lat,keyword: keyword }, function (data) {
                    if (data && data.statue) {
                        var products = JSON.parse(data.data);

                        if (products.length <= 0) {
                            alert('û�в�ѯ�� '+keyword+' �ı�����Ϣ���볢�������ؼ��֣�');
                            return false;
                        }

                        var allRows = "";
                        $.each(products, function (index, item) {
                            var marker = new BMap.Marker(new BMap.Point(item.pointY, item.pointX));
                            map.addOverlay(marker);

                            var html = '<table class="table_list" cellpadding="0" cellspacing="0" width="450px"><thead><tr height="30px" class="black70"><td width="30%" class="arc_title">�۸�</td><td width="30%">������</td><td width="30%">�̼�</td><td width="10%">����</td></tr><thead><tbody>';
                            $.each(item.data, function (i, product) {
                                html += '<tr height="40px" onmouseover="this.className=\'jobMenu_hover\'" onmouseout="this.className=\'\'" class="">';
                                html += '<td>' + product.price + '</td>';
                                html += '<td>' + product.simpledesc + '</td>';
                                html += '<td>' + product.companyname + '</td>';
                                html += '<td><a class="btn_blue" target="_blank" href="details.aspx?id=' + product.id + '">�鿴</a></td>';
                                html += '</tr>';

                                allRows += '<tr height="40px" onmouseover="this.className=\'jobMenu_hover\'" onmouseout="this.className=\'\'" class="">';
                                allRows += '<td><a target="_blank" href="details.aspx?id=' + product.id + '">'+product.price+'</a></td>';
                                allRows += '<td>' + product.simpledesc + '</td>';
                                allRows += '<td>' + product.companyname + '</td>';
                                allRows += '<td>' + product.bname + '</td>';
                                allRows += '<td><a class="btn_blue" target="_blank" href="details.aspx?id=' + product.id + '">�鿴</a></td>';
                                allRows += '</tr>';
                            })
                            html += '</tbody></table>';

                            //������Ϣ����
                            var infoWin = new BMap.InfoWindow(html);
                            marker.addEventListener("click", function () { this.openInfoWindow(infoWin); });
                        })
                        $('#rentP_list1 tbody').empty().html(allRows);
                    } else {
                        alert(data.msg);
                    }
                })
            }
        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div class="cl"></div>

    <div id="searchResult">
        <div style="width: 950px;">
            <div id="allmap"style="width: 950px; height: 555px;"></div>
            <asp:HiddenField ID="hfData" runat="server" />
        </div>
        <table id="rentP_list1" class="table_list" cellpadding="0" cellspacing="0" width="950px">
            <thead>
                <tr height="30px" class="black70">
                    <td width="20%" class="arc_title">�۸�</td>
                    <td width="25%">������</td>
                    <td width="20%">�̼�</td>
                    <td width="25%">������Ȧ</td>
                    <td width="10%">�鿴</td>
                </tr>
            </thead>
            <tbody></tbody>
        </table>
    </div>

    <div class="cl"></div>

    <div class="pager" align="center">
        <ADeeWuControl:Pager3 ID="Pager1" runat="server" />
    </div>
    <div id="loading"></div>
</asp:Content>
