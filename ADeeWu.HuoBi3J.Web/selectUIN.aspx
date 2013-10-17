<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectUIN.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.selectUIN" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="CSS/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
	window.UINSelector = 
	{
		onSelected : null,
		raiseEvent : function(map)
		{
			if(this.onSelected && (typeof this.onSelected == 'function') )
			{
				this.onSelected(map);
			}
		},
		onLoad : function()
		{
			if( typeof window.parent.UINSelector_OnLoad == 'function' )
				window.parent.UINSelector_OnLoad(this);
		}
	};
	window.onload = function()
	{
		UINSelector.onLoad();
	};
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table>
         <tr>
           <td>
            搜搜你想要的通讯号码：<asp:TextBox ID="key" runat="server"></asp:TextBox>
        <asp:Button ID="btnQuery" runat="server" Text="搜索" />
           </td>
         </tr>
         <tr>
           <td>
              <asp:DataList ID="rptData" runat="server" RepeatColumns="5" 
                   RepeatDirection="Horizontal" >
                <ItemTemplate>
                  <input type="radio" id="cbo" name="selecbo" onclick="UINSelector.raiseEvent({id:'<%# Eval("ID") %>',uin:'<%# Eval("UIN") %>'})" /> <%# Eval("UIN") %>
                </ItemTemplate>
              </asp:DataList>
           </td>
         </tr>
         <tr>
           <td>
            <div class="pager" style="margin-top:-20px">
    <IscControl:Pager ID="Pager1" runat="server"  />
</div>
           </td>
         </tr>
       </table>
      
    </form>
</body>
</html>
