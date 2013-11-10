<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master" AutoEventWireup="true" CodeBehind="QuestionList.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.QuestionList" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    �������� - �����б�
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
	            alert('��ѡ����Ʒ����!');
	            return false;
	        }
		
	        if( item.depth<3 ){
	            alert('����ѡ���ļ�����!');
	            return false;
	        }
		
	        var productName = $('input[name=productName]').val();

	        $.getJSON('/ajax/center.ashx',{method: 'getproductlist', cateid: item.key, name: productName},function(data){
	            if(data!=null&&data.statue){
	                var productID = $('#productID');
	                var html="<option value='-1'>��ѡ��</option>";
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

        $('.newQuestion').btnLogin({ title: '��������', target: '#PostQustion' });

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
                alert("���¼��");
                location.href = '/Login.aspx?url=' + document.location.href;
                return false;
            }
            var parent = $(this).parent();
            var kid = parent.find('input[name=kid]:hidden').val();
            var uid = parent.find('input[name=uid]:hidden').val();
            var content = editor.getContent();
            var productID = $('#productID').val();

            if (!editor.hasContents()) {
                alert('�������ݲ���Ϊ�գ�');
                return false;
            }

            if($('#addProduct:checkbox').attr('checked')=='checked'&&productID==-1){
                alert('��ѡ����Ʒ��');
                return false;
            }

            $.getJSON('/ajax/center.ashx', { method: 'AddQuestion', kid: kid, uid: uid, content: content,productID: productID,typeid: 1 }, function (data) {
                if (data.statue) {
                    alert('��������ȯ�̼Ҵ����Ѻ�����̼���ȡ20Ԫ��20Ԫ������ֵ�ֽ�����ȯ');
                    parent.hide();
                    location.href = '<%= Request.RawUrl %>';
                } else {
                    var msg = '�ύ���������ԣ�';
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
                title: '�ؼ��ֱ༭����Ϣ',
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
                            <span>�ؼ������ƣ�<label class="fb black32 "><%# Eval("KName") %></label></span><span>��ע�б�
                                    <input type="hidden" name="kid" value="<%# Eval("kid") %>" />
                                <a href="#" class="attentionCount">����鿴</a></span>
                            <%--<span>���ʱ�䣺<label class="black32"><%# Eval("kcreatetime") %></label></span>--%>
                        </p>
                        <p class="mt10">
                            <span>������Ȧ��
                                <label class="black32 dline"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetBusinessCircle(Eval("bid"),Eval("bname")) %></label>
                            </span>
                            <span class="gjbj1">����������<label class="black32"><%# ADeeWu.HuoBi3J.Web.Class.Helper.GetLocation(Eval("aid"),Eval("aname"),Eval("cid"),Eval("cname"),Eval("pid"),Eval("pname")," - ") %></label></span><span class="gjbj"><a href="#" id="btnShowKeyOwnerInfo">�ؼ��ֱ༭����Ϣ</a></span>
                        </p>

                        <p class="mt10">
                            <span>������                            
                                <asp:Button ID="btnManage" runat="server" Text="�������" CssClass="btn_blue89 btnManage" OnClick="btnManage_Click" Style="display: none;" />
                                <a href="#" class="btn_blue inform" contentid="<%= Request["kid"] %>" typeid="1" title="�ٱ�" style="display: none;">�ٱ�</a>
                                <%if (IsDefaultKey.HasValue && IsDefaultKey.Value)
                                  { %><a href="/center/MoveCircle.aspx?kid=<%=Request["kid"] %>" class="btn_blue89">ָ����Ȧ</a>
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
                                <td class="tdLeft">�༭�ˣ�
                                </td>
                                <td class="tdRight">
                                    <strong style="color: #FF9933;">
                                        <%# Eval("Name") %></strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLeft">QQ��
                                </td>
                                <td class="tdRight">
                                    <%# Eval("QQ") %>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLeft">��ϵ��ʽ��
                                </td>
                                <td class="tdRight">
                                    <%# Eval("Phone") %>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLeft">��˾���ƣ�
                                </td>
                                <td class="tdRight">
                                    <%# Eval("companyname") %>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLeft">��˾��ַ��
                                </td>
                                <td class="tdRight">
                                    <%# Eval("companyaddress") %>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLeft">��飺
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
                    <label class="bb">����ѯ��</label>
                    <span class="orange">����д����������ϣ�������Ʒ���ơ���Ʒ�ͺš��������ҡ���񡢹���������ͼƬ�����ϣ��Ա��̼��ܸ��ñ���</span>
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
            <input type="checkbox" id="addProduct" />ѡ�������Ʒ
            <div id="productCategory" style="display: none">
                ��Ʒ���ࣺ<IscControl:SyncSelector ID="syncSelectorShopProductCategories" runat="server"
                    DataSourceURL="<%$Resources:SyncSelector,ShopProductCategories_DataSourceURL %>"
                    DataSourceName="<%$Resources:SyncSelector,ShopProductCategories_DataSourceName %>"
                    ClientPostNames="<%$Resources:SyncSelector,ShopProductCategories_ClientPostNames %>" />
                <br />
                ��Ʒ���ƣ�<input type="text" name="productName" />&nbsp;&nbsp;&nbsp;
                <button id="searchProduct" class="btn_blue89">������Ʒ</button>
                <br />
                ѡ����Ʒ��<select id="productID"><option value="-1">��ѡ��</option>
                </select>
                <br />
                <p>
                    <strong style="color: #FF9933;">�������̣�</strong>ѡ����Ʒ���ࡱ��������Ʒ���ƣ���ɲ��������ݣ��������������Ʒ����Ŧ��Ȼ���ڡ�ѡ����Ʒ���ҵ���Ҫ����Ʒ�ύ�������ص���Ʒ��<a href="AddProduct.aspx" target="_blank" style="color: #FF9933;">������</a>
                </p>
            </div>
            <br />
            <br />
            <button id="btnSubmit" class="btn_blue">�ύ</button>
            <br />
            <br />
        </div>
        <div id="loginBar" style="display: none;">
            <a href="/login.aspx?url=<%= Request.RawUrl %>" id="btnLogin" title="���¼" class="btn_blue">���¼</a>
        </div>
    </div>
    <div id="attentionDialog"></div>

    <br />

    <div class="cl"></div>

    <table id="rentP_list" class="table_list font14" cellpadding="0" cellspacing="0">
        <thead>
            <tr height="30px" class="black70 fb font12">
                <td class="arc_title" width="625px">����</td>
                <td width="140px ">������</td>
                <td width="100px">�ظ���</td>
                <td width="120px">����ʱ��</td>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rpQuestions" runat="server">
                <ItemTemplate>
                    <tr height="40px" onmouseover="this.className='jobMenu_hover'" onmouseout="this.className=''" class="">
                        <td class="arc_title">
                            <a href="#" class="btn_blue inform" contentid="<%# Eval("QID") %>" typeid="2" title="�ٱ�">�ٱ�</a>
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
