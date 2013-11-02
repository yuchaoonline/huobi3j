<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="SearchPrice.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.SearchPrice" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>
<%@ Register Src="~/Controls/ucNav.ascx" TagPrefix="uc1" TagName="ucNav" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    即时报价 - 即时报价
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/js/jquery.watermark.js"></script>
    <script type="text/javascript" src="/js/user.js"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=D10a875567626012d06af2387efa088e"></script>
    <script type="text/javascript">
        $(function () {
            var val = $('.txtKeyword').val();
            if(val=='')
                val='输入价格';
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
                if(newVal=='输入价格')
                    newVal='';
                var url = "<%=HttpContext.Current.Request.FilePath %>?keyword=" + newVal;
                location.href=url;
                return false;
            });

            $('.no-record').hide();

            $('.result img').ReduceImage();

            $('#txtKeyword').enter($('.btn_search'));

            var map = new BMap.Map("allmap");
            map.enableScrollWheelZoom();    //启用滚轮放大缩小，默认禁用
            map.enableContinuousZoom();    //启用地图惯性拖拽，默认禁用
            map.centerAndZoom('<%=ADeeWu.HuoBi3J.Web.Class.AccountHelper.City%>', 14);

            $.each(JSON.parse($('#<%=hfData.ClientID%>').val()), function (index, item) {
                var marker = new BMap.Marker(new BMap.Point(item.pointY, item.pointX));
                map.addOverlay(marker);

                var html = '<table class="table_list" cellpadding="0" cellspacing="0" width="450px"><thead><tr height="30px" class="black70"><td width="30%" class="arc_title">价格</td><td width="30%">简单描述</td><td width="30%">商家</td><td width="10%">操作</td></tr><thead><tbody>';
                $.each(item.data, function (i, product) {
                    html+='<tr height="40px" onmouseover="this.className=\'jobMenu_hover\'" onmouseout="this.className=" class="">';
                    html += '<td>' + product.price + '</td>';
                    html += '<td>' + product.simpledesc + '</td>';
                    html += '<td>' + product.companyname + '</td>';
                    html += '<td><a class="btn_blue" target="_blank" href="details.aspx?id=' + product.id + '">查看</a></td>';
                    html+='</tr>';
                })
                html += '</tbody></table>';

                //创建信息窗口
                var infoWin = new BMap.InfoWindow(html);
                marker.addEventListener("click", function () { this.openInfoWindow(infoWin); });
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <uc1:ucNav runat="server" ID="ucNav" />

    <div class="cl"></div>

    <div id="searchResult">
        <div style="width: 950px;">
            <div id="allmap"style="width: 950px; height: 555px;"></div>
            <asp:HiddenField ID="hfData" runat="server" />
        </div>
        <asp:Repeater ID="rpResult" runat="server">
            <HeaderTemplate>
                <table id="rentP_list1" class="table_list" cellpadding="0" cellspacing="0" width="950px">
                    <thead>
                        <tr height="30px" class="black70">
                            <td width="20%" class="arc_title">价格</td>
                            <td width="25%">简单描述</td>
                            <td width="20%">商家</td>
                            <td width="25%">所在商圈</td>
                            <td width="10%">查看</td>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                    <td class="arc_title"><%# GetMoney(Eval("price")) %></td>
                    <td><%# Eval("simpledesc") %></td>
                    <td><a href="SaleMan4Product.aspx?userid=<%# Eval("createuserid") %>" target="_blank"><%# Eval("companyname") %></a></td>
                    <td><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %></td>
                    <td><a href="Details.aspx?id=<%# Eval("id") %>" class="btn_blue">详情</a></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <div class="cl"></div>

    <div class="pager" align="center">
        <ADeeWuControl:Pager3 ID="Pager1" runat="server" />
    </div>
</asp:Content>
