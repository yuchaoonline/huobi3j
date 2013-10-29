<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="SearchPrice.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.SearchPrice" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>
<%@ Register Src="~/Controls/ucNav.ascx" TagPrefix="uc1" TagName="ucNav" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    即时报价 - 即时报价
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/js/jquery.watermark.js"></script>
    <script type="text/javascript" src="/js/user.js"></script>
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
        })
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <uc1:ucNav runat="server" ID="ucNav" />

    <div id="center">
        <div class="centerP_body">
            <div class="body_content" style="float: left;">
                <p>
                    <span>价格： <%--<asp:TextBox ID="txtKeyword" CssClass="text txtKeyword" runat="server" Text="" ></asp:TextBox>--%>
                        <input type="text" id="txtKeyword" name="txtKeyword" class="text txtKeyword" value="<%=Request["keyword"] %>" />
                        <input type="button" class="btn_blue btn_search" value="搜 索">
                    </span>
                </p>
            </div>
        </div>
    </div>

    <div class="cl"></div>

    <div id="searchResult">
        <asp:Repeater ID="rpResult" runat="server">
            <HeaderTemplate>
                <table id="rentP_list1" class="table_list" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr height="30px" class="black70">
                            <td width="20%" class="arc_title">价格</td>
                            <td width="30%">简单描述</td>
                            <td width="25%">商家</td>
                            <td width="25%">所在商圈</td>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                    <td class="arc_title"><a href="View.aspx?id=460" target="_blank"><%# GetMoney(Eval("price")) %></a></td>
                    <td><%# Eval("simpledesc") %></td>
                    <td><%# Eval("companyname") %></td>
                    <td><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <div class="pager" align="center">
        <ADeeWuControl:Pager3 ID="Pager1" runat="server" />
    </div>
</asp:Content>
