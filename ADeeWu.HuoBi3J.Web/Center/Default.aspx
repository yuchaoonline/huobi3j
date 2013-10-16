<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.Default" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<%@ Register Src="~/Controls/Category.ascx" TagPrefix="UserControl" TagName="Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
ȫ���� - ��ʱ����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/js/jquery.watermark.js"></script>
    <script type="text/javascript" src="/js/user.js"></script>
    <script>
        $(function () {
            var val = $('.txtKeyword').val();
            if(val=='')
                val='���������ؼ���';
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
                var sync = <%=syncSelectorLocation.ID%>;
                var values = sync.getValues().split(',');
                var newVal = $(".txtKeyword").val();
                if(newVal=='')
                    newVal=val;
                if(newVal=='���������ؼ���')
                    newVal='';
                var url = "<%=HttpContext.Current.Request.FilePath %>?keyword=" + newVal + "&" + [ "province="+values[0] , "city="+values[1] , "area="+values[2] ].join('&');
		        location.href=url;
		        return false;
            });

            $('.no-record').hide();

        $('.result img').ReduceImage();
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
    <div>
        <img src="/images/centerbiaoti.png" width="950px" alt="ȫ��Ӫ��������ʱͨѶӪ��ƽ̨">
    </div>

    <div id="center">
		<div class="centerP_body">
			<div class="body_content" style="float: left;">
				<p>
					<span>
						��&nbsp;&nbsp;&nbsp;&nbsp;����
						<IscControl:SyncSelector 
                            ID="syncSelectorLocation" runat="server" 
                            DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>"
                            DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
                            ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
                            InitClientDependency="true" />
						<a href="add.aspx" class="orange" style="text-decoration: underline;">����������Ȧ</a>
					</span>
				</p>
				<p class="mt10">
					<span>�� �� �֣� <%--<asp:TextBox ID="txtKeyword" CssClass="text txtKeyword" runat="server" Text="" ></asp:TextBox>--%>
                        <input type="text" id="txtKeyword" name="txtKeyword" class="text txtKeyword" value="<%=Request["keyword"] %>" />
						<input type="button" class="btn_blue btn_search" value="�� ��">
                        <a href="TicketSearch.aspx" class="orange" style="text-decoration: underline;">������ȯ���̼Һ͹ؼ���</a>
					</span>
				</p>
				<p class="mt10">
				<span>����ѯ�����̣�������Ʒ�����&gt;&gt;ѡ��ؼ���&gt;&gt;��������&gt;&gt;�յ��ظ�����</span></p>
					        
			</div>
            <div class="body_right">
                <div id="other" class="r">
                    <div class="title_short1">ʹ�ò���ָ��</div>
                    <ul class="menu_list">
                        <li><a href="1.aspx" target="_blank">�����߼�ʱ����̼ұ�������</a></li>
                        <li><a href="2.aspx" target="_blank">�̼ұ���ʹ������</a></li>
                        <li><a href="3.aspx" target="_blank">�û���ȡ�ֽ���������</a></li>
                    </ul>
                    <div class="b3"></div>
                    <div class="b2"></div>
                    <div class="b1"></div>
                </div>
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
                                    <div align="right">�ظ�����<%# Eval("AnswerCount") %>��</div>
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
                            <a href="QuestionList.aspx?kid=<%# Eval("KID") %>" title="<%# Eval("KName") %>" target="_blank" ><span class="STYLE1 result"><%# Eval("KName") %></span></a>
                            <span class="db intro">
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"), Eval("aname"), Eval("cid"), Eval("cname"), Eval("pid"), Eval("pname"), "-") %>>>
                                <%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %>
                                <label>
                                    <div align="right"><span class="attentionCount">��ע������<%# Eval("AttentionCount") %>��</span>��������<%# Eval("QuestionCount") %>��</div>
                                </label>
                            </span>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="pager" align="center">
        <IscControl:Pager3 ID="Pager1" runat="server"  />
    </div>

    <div id="noresult" runat="server" class="orange">
        <p>����<a href="/Center/Add.aspx" title="�����Ȧ">�����Ȧ</a>����ӹؼ��֣������Ƽ��ؼ����б�Ϊ�ؼ���ָ����Ȧ���ٽ���ѯ�ۡ�</p>
    </div>

    <br />
    <br />
    <br />
    <asp:Repeater ID="rpDefaultCenter" runat="server">
        <HeaderTemplate>
            <h3>�Ƽ��ؼ����б�</h3>
        </HeaderTemplate>
        <ItemTemplate>
            <div id="recruit_list">
                <div class="frame zoom">
                    <div class="info1 l zoom">
                        <%# Eval("KName") %>
                        <div align="right">
                            <a href="MoveCircle.aspx?kid=<%# Eval("kid") %>" class="btn_blue">ָ����Ȧ</a>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div id="attentionDialog"></div>
</asp:Content>