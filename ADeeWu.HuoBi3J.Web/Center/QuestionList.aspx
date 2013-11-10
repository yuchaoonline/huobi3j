<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="QuestionList.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.QuestionList" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    货比三家 - 提问列表
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
    <link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.watermark.js"></script>
    <script type="text/javascript" src="/js/user.js"></script>
    <script src="/ueditor/ueditor.config.js" type="text/javascript"></script>
    <script src="/ueditor/ueditor.all.min.js" type="text/javascript"></script>
    <script>
        function <%=this.syncSelectorShopProductCategories.ClientOnRenederedCallback %>(e){
            $('#searchProduct').click(function(){
                var item = <%=this.syncSelectorShopProductCategories.ID%>.getSelectedItem();
	        if(item==null){
	            alert('请选择商品分类!');
	            return false;
	        }
		
	        if( item.depth<3 ){
	            alert('至少选择四级分类!');
	            return false;
	        }
		
	        var productName = $('input[name=productName]').val();

	        $.getJSON('/ajax/center.ashx',{method: 'getproductlist', cateid: item.key, name: productName},function(data){
	            if(data!=null&&data.statue){
	                var productID = $('#productID');
	                var html="<option value='-1'>请选择</option>";
	                if(data.products){
	                    for(i=0;i<data.products.length;i++){
	                        var item = data.products[i];
	                        html+="<option value="+item.productid+">"+item.name+"</option>";
	                    }
	                }else{
                        
	                }
	                productID.html(html);
	            }else{
	                alert(data.msg);
	            }                
	        })
		
	        return false;
	    });
    }

    $(function () {
        var editor = UE.getEditor('editor');

        if ($.IsLogin()) {
            $('#PostQustion').show();
        } else {
            $('#loginBar').show();
        }

        var manageKey = $.GetKeyManageByKID({kid: '<%= Request["kid"] %>'});
        if (manageKey == false) {
            $('.btnManage').show().click(function () {
                if (!$.IsLogin()) {
                    location.href = '/login.aspx?url=<%= Request.RawUrl %>';
                    return false;
                }
            });
            $('.managertr').hide();
        } else {
            $('.btnManage').hide();
            $('.managertr').show();
            $('.managertr').find('span.managername').text(manageKey.loginname);
        }

        $('.newQuestion').btnLogin({ title: '发表提问', target: '#PostQustion' });

        $('.attentionCount').click(function () {
            var kid = $(this).parent().find('[name=kid]').val();
            $.getJSON('/ajax/center.ashx', { method: 'getattention', kid: kid }, function (data) {
                if (data != null) {
                    var html = "<ul class='attentionList'>";
                    for (i = 0; i < data.length; i++) {
                        var item = data[i];
                        html += "<li><a href='#" + item.UID + "'>" + item.UName + "</a></li>";
                    }
                    html += "</ul>";

                    $('#attentionDialog').html(html).dialog({ modal: true });
                }
            })
        })

        $('#btnSubmit').click(function () {
            if (!$.IsLogin()) {
                alert("请登录！");
                location.href = '/Login.aspx?url=' + document.location.href;
                return false;
            }
            var parent = $(this).parent();
            var kid = parent.find('input[name=kid]:hidden').val();
            var uid = parent.find('input[name=uid]:hidden').val();
            var content = editor.getContent();
            var productID = $('#productID').val();

            if (!editor.hasContents()) {
                alert('提问内容不能为空！');
                return false;
            }

            if($('#addProduct:checkbox').attr('checked')=='checked'&&productID==-1){
                alert('请选择商品！');
                return false;
            }

            $.getJSON('/ajax/center.ashx', { method: 'AddQuestion', kid: kid, uid: uid, content: content,productID: productID,typeid: 1 }, function (data) {
                if (data.statue) {
                    alert('在有赠送券商家处消费后可向商家领取20元或20元以上面值现金赠送券');
                    parent.hide();
                    location.href = '<%= Request.RawUrl %>';
                } else {
                    var msg = '提交错误，请重试！';
                    if(data.msg!='')msg = data.msg;
                    parent.append("<font color='red'>"+msg+"</font>");
                }
            })

            return false;
        })

        $("#addProduct").change(function(){
            var checked = $(this).attr('checked');

            if(checked=='checked'){
                $("#productCategory").show();
            }else{
                $("#productCategory").hide();
            }
        })

        $('.arc_title img').ReduceImage();

        $('#btnShowKeyOwnerInfo').click(function(){
            $('#Key_Owner_Info').dialog({
                title: '关键字编辑人信息',
                width: 500,
                height: 300,
            })   
        })
    })
    </script>
    <style>
        .dline a {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <input type="hidden" name="inform" value="<%=UserID %>" kid="<%= Request["kid"] %>" />
    <div id="center_list">
        <div class="centerP_body">
            <asp:Repeater ID="rpKey" runat="server">
                <ItemTemplate>
                    <div class="body_content font14 black70">
                        <p>
                            <span>关键字名称：<label class="fb black32 "><%# Eval("KName") %></label></span><span>关注列表：
                                    <input type="hidden" name="kid" value="<%# Eval("kid") %>" />
                                <a href="#" class="attentionCount">点击查看</a></span>
                            <%--<span>添加时间：<label class="black32"><%# Eval("kcreatetime") %></label></span>--%>
                        </p>
                        <p class="mt10">
                            <span>所属商圈：
                                <label class="black32 dline"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %></label>
                            </span>
                            <span class="gjbj1">所属地区：<label class="black32"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"),Eval("aname"),Eval("cid"),Eval("cname"),Eval("pid"),Eval("pname")," - ") %></label></span><span class="gjbj"><a href="#" id="btnShowKeyOwnerInfo">关键字编辑人信息</a></span>
                        </p>

                        <p class="mt10">
                            <span>操作：                            
                                <asp:Button ID="btnManage" runat="server" Text="申请管理" CssClass="btn_blue89 btnManage" OnClick="btnManage_Click" Style="display: none;" />
                                <a href="#" class="btn_blue inform" contentid="<%= Request["kid"] %>" typeid="1" title="举报" style="display: none;">举报</a>
                                <%if (IsDefaultKey.HasValue && IsDefaultKey.Value)
                                  { %><a href="/center/MoveCircle.aspx?kid=<%=Request["kid"] %>" class="btn_blue89">指定商圈</a>
                                <%} %>
                            </span>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div id="Key_Owner_Info" style="display: none;">
                <table class="formTable">
                    <asp:Repeater ID="rpInfo" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="tdLeft">编辑人：
                                </td>
                                <td class="tdRight">
                                    <strong style="color: #FF9933;">
                                        <%# Eval("Name") %></strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLeft">QQ：
                                </td>
                                <td class="tdRight">
                                    <%# Eval("QQ") %>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLeft">联系方式：
                                </td>
                                <td class="tdRight">
                                    <%# Eval("Phone") %>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLeft">公司名称：
                                </td>
                                <td class="tdRight">
                                    <%# Eval("companyname") %>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLeft">公司地址：
                                </td>
                                <td class="tdRight">
                                    <%# Eval("companyaddress") %>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLeft">简介：
                                </td>
                                <td class="tdRight">
                                    <%# Eval("memo") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
        <div class="centerP_head"></div>
    </div>

    <div id="center_content">
        <div class="l left" style="width: 950px; margin: 0 0 -20px -20px;">
            <ul class="list">
                <li class="zoom">
                    <label class="bb">发表询价</label>
                    <span class="orange">请填写尽量多的资料，包括产品名称、产品型号、生产厂家、规格、购买数量、图片等资料，以便商家能更好报价</span>
                </li>
            </ul>
        </div>
    </div>

    <div class="item">
        <div id="PostQustion" style="display: none; float: left;">
            <input type="hidden" name="kid" value="<%= Request["kid"] %>" />
            <input type="hidden" name="uid" value="<%= UserID %>" />
            <script type="text/plain" id="editor" name="content" style="width: 800px; height: 34px;"></script>
            <br />
            <input type="checkbox" id="addProduct" />选择相关商品
            <div id="productCategory" style="display: none">
                商品分类：<IscControl:SyncSelector ID="syncSelectorShopProductCategories" runat="server"
                    DataSourceURL="<%$Resources:SyncSelector,ShopProductCategories_DataSourceURL %>"
                    DataSourceName="<%$Resources:SyncSelector,ShopProductCategories_DataSourceName %>"
                    ClientPostNames="<%$Resources:SyncSelector,ShopProductCategories_ClientPostNames %>" />
                <br />
                商品名称：<input type="text" name="productName" />&nbsp;&nbsp;&nbsp;
                <button id="searchProduct" class="btn_blue89">搜索产品</button>
                <br />
                选择商品：<select id="productID"><option value="-1">请选择</option>
                </select>
                <br />
                <p>
                    <strong style="color: #FF9933;">操作流程：</strong>选择“商品分类”，输入商品名称（亦可不输入内容），点击“搜索产品”按纽；然后在”选择商品“找到需要的商品提交。添加相关的商品，<a href="AddProduct.aspx" target="_blank" style="color: #FF9933;">点击添加</a>
                </p>
            </div>
            <br />
            <br />
            <button id="btnSubmit" class="btn_blue">提交</button>
            <br />
            <br />
        </div>
        <div id="loginBar" style="display: none;">
            <a href="/login.aspx?url=<%= Request.RawUrl %>" id="btnLogin" title="请登录" class="btn_blue">请登录</a>
        </div>
    </div>
    <div id="attentionDialog"></div>

    <br />

    <div class="cl"></div>

    <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0">
        <thead>
            <tr height="30px" class="black70 fb font12">
                <td class="arc_title" width="625px">标题</td>
                <td width="140px ">提问人</td>
                <td width="100px">回复数</td>
                <td width="120px">提问时间</td>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rpQuestions" runat="server">
                <ItemTemplate>
                    <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                        <td class="arc_title">
                            <a href="#" class="btn_blue inform" contentid="<%# Eval("QID") %>" typeid="2" title="举报">举报</a>
                            <a class="xst question" href="question.aspx?qid=<%# Eval("QID") %>"><%# GetTitle(Eval("Title")) %></a></td>
                        <td><%# Eval("LoginName") %></td>
                        <td class="orange"><%# Eval("AnswerCount") %></td>
                        <td><%# Eval("CreateTime")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

    <IscControl:Pager3 ID="Pager1" runat="server" />

</asp:Content>
