<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="New.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Jobs.New" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 发布招聘职位信息
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/Jobs/">招聘管理</a><span class="spl">　</span><span class="curPos">发布职位信息</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
     
   <table border="0" cellpadding="0" cellspacing="0">
           <tr >
               <td class="tdLeft">职位名称：</td>
               <td class="tdRight"><input name="jobName" type="text"   id="jobName" size="38" runat="server"/>
                <span class="require">*</span></td>
           </tr>  
           <tr>
              <td class="tdLeft">所在区域：</td>
              <td class="tdRight">
                      <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" 
                        DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>" 
                        DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>" 
                        ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>"
                        />
                <span class="require">*</span></td>
           </tr>
           <%--<tr   >
              <td class="tdLeft">具体地址：</td>
              <td colspan="2" class="tdRight"><input name="jobAddress" type="text"  id="jobAddress" size="38" runat="server"/>
                <span class="require">*</span></td>
           </tr>--%>
           
           <tr>
              <td class="tdLeft">职位分类：</td>
              <td class="tdRight">
              <IscControl:SyncSelector ID="syncSelectorJobCategory" runat="server" 
			  	DataSourceURL="<%$Resources:SyncSelector,JobCategories_DataSourceURL %>" 
                DataSourceName="<%$Resources:SyncSelector,JobCategories_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,JobCategories_ClientPostNames %>"
              />
              <span class="require">*</span>
              </td>
           </tr>
		   <tr>
              <td class="tdLeft">行业分类：</td>
              <td class="tdRight">
              <IscControl:SyncSelector ID="syncSelectorCalling" runat="server" 
 				DataSourceURL="<%$Resources:SyncSelector,JobCallings_DataSourceURL %>"
                DataSourceName="<%$Resources:SyncSelector,JobCallings_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,JobCallings_ClientPostNames %>"        
			  />
              <span class="require">*</span>
              </td>
           </tr>
           <tr>
              <td class="tdLeft">性别要求：</td>
              <td class="tdRight">
			 
			  <select name="jobSex" id="jobSex" runat=server>
			    <option value="0">不限</option>
			    <option value="1">男</option>
			    <option value="2">女</option>
			    </select>
			  </td>
           </tr>
           
           <tr>
              <td class="tdLeft">学历要求：</td>
              <td class="tdRight">
              <asp:DropDownList ID="ddlEducation" runat="server">
                  <asp:ListItem Selected="True" Value="0">不限</asp:ListItem>
                  <asp:ListItem Value="1">高中以下</asp:ListItem>
                  <asp:ListItem Value="2">高中以上</asp:ListItem>
                  <asp:ListItem Value="3">大专以上</asp:ListItem>
                  <asp:ListItem Value="4">大学以上</asp:ListItem>
                  <asp:ListItem Value="5">本科以上</asp:ListItem>
              
              </asp:DropDownList>
              
            </td>
           </tr>
           <tr>
              <td class="tdLeft">工作经验：</td>
              <td class="tdRight">
               <asp:DropDownList ID="ddlExp" runat="server">
                   <asp:ListItem Selected="True" Value="0">不限</asp:ListItem>
                   <asp:ListItem Value="1">一年以上</asp:ListItem>
                   <asp:ListItem Value="2">两年以上</asp:ListItem>
                   <asp:ListItem Value="3">三年以上</asp:ListItem>
                   <asp:ListItem Value="4">五年以上</asp:ListItem>
               
               </asp:DropDownList>
               <span class="require">*</span></td>
           </tr>
           <tr>
             <td class="tdLeft">工作方式：</td>
             <td class="tdRight">
            <select id="workType" name='workType'  runat="server">
                <option value='0' >全职</option>
                <option value='1' >兼职</option>
                <option value='2'>全职/兼职皆可</option>
			</select>
            </td>
             <td class="tdRight">&nbsp;</td>
           </tr>
           <tr>
             <td class="tdLeft">月　　薪：</td>
             <td class="tdRight">
               <input name="MonthlyPay" runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" type="text" id="MonthlyPay" size="10" /> 
                元
				<span class="require">*</span><span class="tips">输入0表示面议</span>
				</td>
             <td class="tdRight">&nbsp;</td>
           </tr>
           <tr>
             <td class="tdLeft">招聘人数：</td>
             <td class="tdRight"><input name="JobCount" runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" type="text" id="JobCount" size="10"  />人
             <span class="require">*</span><span class="tips">输入0表示 "若干" </span>
             </td>
             <td class="tdRight">&nbsp;</td>
           </tr>
           <tr>
             <td class="tdLeft">年龄要求：</td>
             <td class="tdRight"><input name="txtAgeArea" type="text"  id="txtAgeArea" width="20" runat="server"/>如：19岁-23岁</td>
             <td class="tdRight">&nbsp;</td>
           </tr>
           <%--<tr>
             <td valign="top">职位简述：</td>
             <td><textarea id="jobSumny" runat="server" name="jobSumny"  cols="75"  rows="5">请输入该职位的简要内容！</textarea>
              </td>
             <td> <span class="require">*</span></td>
           </tr>--%>
           <tr>
             <td class="tdLeft">职位详细：</td>
             <td class="tdRight"><textarea id="jobDesc" name="jobDesc" runat="server" class="txtNotes"  cols="60"  rows="15">请输入该职位的详细描述！</textarea>
               <span class="require">*</span>               
			 </td>
             <td class="tdRight">&nbsp;</td>
           </tr>
           <tr>
              <td class="tdLeft">截止时间：</td>
              <td class="tdRight">
                <IscControl:DateTimeSelector ID="DateTimeSelector1" runat="server"></IscControl:DateTimeSelector>  <span class="require">*</span>             </td>
           </tr>
            <tr>
             <td class="tdLeft">联 系 人：</td>
             <td class="tdRight">
               <input type="text" runat="server" name="LinkName" id="LinkName" />
            </td>
           </tr>
           <tr>
              <td class="tdLeft">联系电话：</td>
              <td class="tdRight">
                <input type="text" runat="server" name="LinkPhone" id="LinkPhone" />
              </td>
           </tr>
           <tr>
              <td class="tdLeft">联系邮件：</td>
              <td class="tdRight">
                <input type="text" runat="server" name="LinkEmail" id="LinkEmail" />
              </td>
           </tr>
           <tr>
              <td>&nbsp;</td><td colspan="2">&nbsp;
               </td>
           </tr>
           <tr   >
              <td>&nbsp;</td><td colspan="2"><asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" /></td>
           </tr>
  </table>
     
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>



