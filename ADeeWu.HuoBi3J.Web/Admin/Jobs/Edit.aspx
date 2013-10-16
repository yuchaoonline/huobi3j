<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Admin/MAdmin.master" CodeBehind="Edit.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.Admin.Jobs.Edit"  %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
无标题文档
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span>在线出租</span> &gt; <a href="List.aspx">列表</a> &gt; 修改
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    
    <div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
           <tr  >
               <td class="tdLeft" style="width:16%">公司名称：</td>
               <td colspan="2">
                   <asp:Label ID="lblCorpName" runat="server"></asp:Label>
               </td>
           </tr>  
           <tr  >
               <td class="tdLeft" style="width:16%">职位名称：</td>
               <td colspan="2"><input name="jobName" type="text"   id="jobName" size="38" runat="server"/>
                <span class="require">*</span></td>
           </tr>  
           <tr>
              <td align="left" valign="middle">所在区域：</td>
              <td colspan="2">
                     <IscControl:SyncSelector ID="syncSelectorLocation" runat="server" DataSourceURL="/js/data/Location.js" DataSourceName="aryLocation" ClientPostNames="province,city,area" /><span class="require">*</span></td>
           </tr>
           <tr   >
              <td>具体地址：</td>
              <td colspan="2"><input name="jobAddress" type="text"  id="jobAddress" size="38" runat="server"/>
                <span class="require">*</span></td>
           </tr>
           
           <tr>
              <td>职位分类：</td>
              <td colspan="2">
              <IscControl:SyncSelector ID="syncSelectorJobCategory" runat="server" 
                DataSourceURL="<%$Resources:SyncSelector,JobCategories_DataSourceURL %>" 
                DataSourceName="<%$Resources:SyncSelector,JobCategories_DataSourceName %>" 
                ClientPostNames="<%$Resources:SyncSelector,JobCategories_ClientPostNames %>"
                />
              <span class="require">*</span></td>
           </tr>
           <tr   >
              <td>性别要求：</td>
              <td colspan="2">
			  <label>
			  <select name="jobSex" id="jobSex" runat=server>
			    <option value="0">不限</option>
			    <option value="1">男</option>
			    <option value="2">女</option>
			    </select>
			  </label></td>
           </tr>
           
           <tr>
              <td valign="top">学历要求：</td>
              <td colspan="2">
              <select name="jobEducation" id="Education" runat="server">
                <option value="0">小学</option>
                <option value="1">初中</option>
                <option value="2">高中</option>
                <option value="3">中技</option>
                <option value="4">中专</option>
                <option value="5" selected="selected">大专</option>
                <option value="6">本科</option>
                <option value="7">MBA</option>
                <option value="8">硕士</option>
                <option value="9">博士</option>
                <option value="10">其他</option>
              </select>              </td>
           </tr>
           <tr   >
              <td valign="top">工作经验：</td>
              <td colspan="2"><select name="jobExp" id="jobExp" runat="server">
                <option value="0">在读学生</option>
                <option value="1">应届毕业生</option>
                 <option value="2">二年以上</option>
                 <option value="3">三年以上</option>
                 <option value="4">五年以上</option>
                 <option value="5">八年以上</option>
                  <option value="6">十年以上</option>
                  <option value="7">不限</option>
              </select>                <span class="require">*</span></td>
              </tr>
            
           <tr>
             <td valign="top">工作方式：</td>
             <td>
            <select id="workType" name='workType'  runat="server">
                <option value='0' >全职</option>
                <option value='1' >兼职</option>
                <option value='2'>全职/兼职皆可</option>
			</select>
            </td>
             <td>&nbsp;</td>
           </tr>
           <tr>
             <td valign="top">月 薪：</td>
             <td><label>
               <input name="MonthlyPay" runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" type="text" id="MonthlyPay" size="10" /> 
                 元</label></td>
             <td>&nbsp;</td>
           </tr>
           <tr>
             <td valign="top">招聘人数：</td>
             <td><input name="JobCount" runat="server"  onkeyup="value=value.replace(/[^\d]/g,'') " onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" type="text" id="JobCount" size="10"  />人</td>
             <td>&nbsp;</td>
           </tr>
            <tr>
             <td valign="top">年龄要求：</td>
             <td><input name="txtAgeArea" type="text"  id="txtAgeArea" size="38" 
                     runat="server"/>如：19岁-23岁</td>
             <td>&nbsp;</td>
           </tr>
           <tr>
         <td valign="top">职位简述：</td>
             <td><textarea id="jobSumny" name="jobSumny" runat=server cols="75"  rows="5">请输入该职位的简要内容！</textarea>
              </td>
             <td> <span class="require">*</span></td>
           </tr>
           <tr>
             <td valign="top">职位详细：</td>
             <td><textarea id="jobDesc" name="jobDesc" runat=server  cols="75"  rows="5">请输入该职位的详细描述！</textarea>
               </td>
             <td><span class="require">*</span></td>
           </tr>
           <tr>
              <td>截止时间：</td>
              <td colspan="2">
                  <IscControl:DateTimeSelector ID="DateTimeSelector1" runat="server"></IscControl:DateTimeSelector>               </td>
           </tr>
           <tr  >
        <td class="tdLeft" style="width:10%">审核状态：</td><td>
               &nbsp;<asp:RadioButton ID="radstate"  GroupName="state" runat="server" Checked=true Text="不修改状态" />
               <asp:RadioButton ID="cbochecktrue" GroupName="state" runat="server" Text="通过" />
               &nbsp;<asp:RadioButton ID="cbocheckfalse" GroupName="state"  runat="server" Text="不通过" />
               &nbsp;<asp:RadioButton ID="cboStateEnd"  GroupName="state" runat="server" Text="标记为过期" />

        </td>
      </tr>  
           <tr   >
              <td>&nbsp;</td><td colspan="2">&nbsp;</td>
           </tr>
           <tr   >
             <td colspan="3">
             <hr/>
             </td>
             </tr>
            <tr   >
             <td colspan="3">如果该职位由专人负责招聘，不想采用公司资料中的联系方式，请填写以下三项</td>
             </tr>
            <tr   >
             <td>联系人姓名：</td>
             <td colspan="2"><label>
               <input type="text" runat="server" name="LinkName" id="LinkName" />
             </label></td>
           </tr>
           <tr   >
              <td>联系人电话：</td><td colspan="2"><label>
                <input type="text" runat="server" name="LinkPhone" id="LinkPhone" />
              </label></td>
           </tr>
           <tr>
              <td>联系人邮件：</td><td colspan="2">
                <input type="text" runat="server" name="LinkEmail" id="LinkEmail" />
              </td>
           </tr>
           <tr>
              <td>&nbsp;</td><td colspan="2">
               <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" />
               </td>
           </tr>
           <tr   >
              <td>&nbsp;</td><td colspan="2">&nbsp;
               </td>
           </tr>
           
  </table>
    </div>
    
</asp:Content>

