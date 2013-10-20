<%@ Page Language="C#" Title="" MasterPageFile="~/MIndex.master"  AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Center.Add" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
��ʱ���� - ���
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
<link href="/CSS/forum_common.css" rel="stylesheet" type="text/css" />
<link href="/CSS/forum_forumdisplay.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery.watermark.js" ></script>
<script type="text/javascript" src="/js/user.js" ></script>
<script type="text/javascript">
    $(function () {
        $('[name=BName]').watermark('������Ȧ����');

        $('#btnSubmit').click(function(){
            if(!$.IsLogin()){
                location.href = '/login.aspx?url=<%=Request.RawUrl %>';
                return false;
            }

            var parent = $(this).parent();

            var sync = <%=syncSelectorLocation.ID%>;
            var values = sync.getValues().split(',');
            if(values[0]=="-1"){
                alert("��ѡ��ʡ�ݣ�");
                return false;
            }
            if(values[1]=="-1"){
                alert("��ѡ����У�");
                return false;
            }
            if(values[2]=="-1"){
                alert("��ѡ������");
                return false;
            }
            var aid = values[2];
            var bName = $('input[name=BName]').val();
            if(bName==''){
                alert("��Ȧ���Ʋ���Ϊ�գ�");
                return false;
            }

            $.getJSON('/ajax/center.ashx',{method: 'AddBusinessCircle', aid: aid, name: bName},function(data){
                if(data.statue){
                    parent.hide();
                    location.href = '/center/businesscircle.aspx?bid='+data.bid;
                }else{
                    if (data.msg)
                        alert(data.msg);
                    else
                        parent.append("<font color='red'>�ύ���������ԣ�</font>");
                }
            })

            return false;
        })
    })
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">    
    <div class="item">
        <div class="itemTitle">
            �����Ȧ
        </div>
        <table class="formTable">
            <tr>
                <td class="tdLeft">������
                </td>
                <td class="tdRight">
                    <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>"
                    DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
                    InitClientDependency="true" />
                </td>
            </tr>
            <tr>
                <td class="tdLeft">��Ȧ���ƣ�
                </td>
                <td class="tdRight">
                    <input type="text" name="BName" />
                </td>
            </tr>
            <tr>
                <td class="tdLeft"></td>
                <td class="tdRight">
                    <input type="button" id="btnSubmit" value="���" class="btn_blue" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>