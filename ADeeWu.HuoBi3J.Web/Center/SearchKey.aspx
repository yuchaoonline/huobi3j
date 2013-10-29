<%@ Page Title="" Language="C#" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="SearchKey.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.SearchKey" %>
<%@ Register Src="~/Controls/ucNav.ascx" TagPrefix="uc1" TagName="ucNav" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    即时报价 - 即时报价 - 搜索价格
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/js/jquery.watermark.js"></script>
    <script type="text/javascript" src="/js/user.js"></script>
    <script type="text/javascript">
        $(function () {
            var val = $('.txtKeyword').val();
            if(val=='')
                val='输入搜索关键字';
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
                if(newVal=='输入搜索关键字')
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
    <style>
        <!--
        .STYLE1 {
            font-size: 16px;
            color: #323232;
            /*font-weight: bold;*/
        }

        .intro a {
            text-decoration: underline;
        }

        .list li.conn {
            height: 30px;
            line-height: 30px;
            font-size: 14px;
        }

        .body_right {
            float: left;
            margin-left: 67px;
        }

            .body_right li a {
                font-size: 12px;
                color: #0066cc;
            }
        -->
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <uc1:ucNav runat="server" ID="ucNav" />

    <div id="center">
        <div class="centerP_body">
            <div class="body_content" style="float: left;">
                <p>
                    <span>关 键 字： <%--<asp:TextBox ID="txtKeyword" CssClass="text txtKeyword" runat="server" Text="" ></asp:TextBox>--%>
                        <input type="text" id="txtKeyword" name="txtKeyword" class="text txtKeyword" value="<%=Request["keyword"] %>" />
                        <input type="button" class="btn_blue btn_search" value="搜 索">
                        <a href="add.aspx" class="orange" style="text-decoration: underline;">添加区域或商圈</a>
                    </span>
                </p>
            </div>
        </div>
    </div>

    <div class="cl"></div>

    <div id="searchResult">
        <asp:Repeater ID="rpQuestionIndex" runat="server">
            <ItemTemplate>
                <div id="recruit_list">
                    <div class="frame zoom">
                        <div class="info1 l zoom">
                            <span class="STYLE1 result"><%# GetTitle(Eval("Title")) %></span>
                            <span class="db intro">
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"), Eval("aname"), Eval("cid"), Eval("cname"), Eval("pid"), Eval("pname"), "-") %>>>
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %>>>
						        <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetKey(Eval("kid"),Eval("kname")) %>
                                <label>
                                    <div align="right">回复数（<%# Eval("AnswerCount") %>）</div>
                                </label>
                            </span>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rpResult" runat="server">
            <ItemTemplate>
                <div id="recruit_list">
                    <input type="hidden" name="kid" value="<%# Eval("KID") %>" />
                    <div class="frame zoom">
                        <div class="info1 l zoom">
                            <a href="key4product.aspx?kid=<%# Eval("KID") %>" title="<%# Eval("KName") %>" target="_blank"><span class="STYLE1 result"><%# Eval("KName") %></span></a>
                            <span class="db intro">
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"), Eval("aname"), Eval("cid"), Eval("cname"), Eval("pid"), Eval("pname"), "-") %>>>
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %>
                                <label>
                                    <div align="right"><span class="attentionCount">关注人数（<%# Eval("AttentionCount") %>）</span>问题数（<%# Eval("QuestionCount") %>）</div>
                                </label>
                            </span>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="pager" align="center">
        <ADeeWuControl:Pager3 ID="Pager1" runat="server" />
    </div>

    <div id="noresult" runat="server" class="orange">
        <p>请先<a href="/Center/Add.aspx" title="添加商圈">添加商圈</a>并添加关键字，或在推荐关键字列表为关键字指定商圈，再进行询价。</p>
    </div>

    <br />
    <br />
    <br />
    <asp:Repeater ID="rpDefaultCenter" runat="server">
        <HeaderTemplate>
            <h3>推荐关键字列表</h3>
        </HeaderTemplate>
        <ItemTemplate>
            <div id="recruit_list">
                <div class="frame zoom">
                    <div class="info1 l zoom">
                        <%# Eval("KName") %>
                        <div align="right">
                            <a href="MoveCircle.aspx?kid=<%# Eval("kid") %>" class="btn_blue">指定商圈</a>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div id="attentionDialog"></div>
</asp:Content>
