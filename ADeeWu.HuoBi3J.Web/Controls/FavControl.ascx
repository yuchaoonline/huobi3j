<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FavControl.ascx.cs" Inherits="ADeeWu.HuoBi3J.Web.Controls.FavControl"  %>
<link type="text/css" href="../JS/Jquery/theme/start/jquery-ui-1.8.23.custom.css" rel="stylesheet" />
<script src="../JS/jquery.js" type="text/javascript"></script>
<script src="../JS/Jquery/jquery-ui-1.8.23.custom.min.js" type="text/javascript"></script>

<style type="text/css">
.hover { background: #000; 
</style>
<script  type="text/javascript">
    function saveData()
    {
       if(<%=UserID %>==-1)
       {
          alert("您还没有登陆！");
          $('#content').dialogClose();
          return false;
       }
       $.ajax
               ({
                   type: "get", //使用get方法访问后台
                   dataType: "text", //返回json格式的数据
                   url: "../Handler/SaveFavsHandler.ashx",
                   data: "UserID=<%=UserID %>&ObjectID=<%=ObjectID %>&favtype=<%=FavType%>&remark="+getdata()+"&s="+new Date().getMilliseconds(),
                   success: function(msg) {  //msg为返回的数据，在这里做数据绑定
                       if(msg==2)
                       {
                         alert("您已经收藏过该信息了");
                       }else if(msg==1)
                       {
                         alert("收藏成功！");
                       }else if(msg==0)
                       {
                         alert("收藏失败！");
                       }
                       $('#content').dialogClose();
                   }
       });
    }
    function FavInfo()
    {
       if(<%=UserID %>==-1)
       {
          alert("您还没有登陆！");
          return false;
       }
       else
       {
           var remar= prompt("请输入收藏标签",""); 
            
           $.ajax
                   ({
                       type: "get", //使用get方法访问后台
                       dataType: "text", //返回json格式的数据
                       url: "../Handler/SaveFavsHandler.ashx",
                       data: "UserID=<%=UserID %>&ObjectID=<%=ObjectID %>&favtype=<%=FavType%>&remark="+escape(remar)+"&s="+new Date().getMilliseconds(),
                       success: function(msg) {  //msg为返回的数据，在这里做数据绑定
                           if(msg==2)
                           {
                             alert("您已经收藏过该信息了");
                           }else if(msg==1)
                           {
                             alert("收藏成功！");
                           }else if(msg==0)
                           {
                             alert("收藏失败！");
                           }
                          
                       }
           });
       }
    }
    function getdata()
    {
       var valuestr=$("#<%=this.txtRemark.ClientID%>").val();
       return escape(valuestr);
       
    }
    
</script>
<div class="playground">
	<div id="content" title='<%=Title %>' style="display:none;font-size:12px">
	    <asp:Label ID="lblremark" runat="server" style="font-size:12px"  Text="标签："></asp:Label>
        <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
        <input type="button" onclick="saveData()" style="display:inline" value="收藏" />
         
	</div>
	<br />
	<a style="display:none" href="#" onclick="$('#content').dialog({width: 290, height: 90,resizable:false});$('#content').dialogOpen();$('#content').show()"> [ 收 藏 ]</a>
	<a href="#" onclick="return FavInfo()"> [ 收 藏 ]</a>
     
</div>

