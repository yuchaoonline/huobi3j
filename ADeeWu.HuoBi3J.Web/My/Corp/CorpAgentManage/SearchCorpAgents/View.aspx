<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="View.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.SearchCorpAgents.View" %>
<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControls" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
商家控制面板 - 查看代理商简历
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
  <asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
<span class="spl">　</span><a href="/My/Corp/CorpAgentManage/SearchCorpAgents/">查找代理商</a><span class="spl">　</span><span class="curPos">查看代理商简历</span>
  </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hfUserID" runat="server" />
<table class="formTable">
        <tr>
            <td class="tdLeft">
            真实姓名：
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteRealName" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            性&nbsp;&nbsp;&nbsp;&nbsp;别：
            </td>
            <td class="tdRight">
                 <asp:Literal ID="liteSex" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            出生日期：
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteBirthday" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            所在地区：
            </td>
            <td class="tdRight">
               <asp:Literal ID="liteLocation" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            具体地址：
            </td>
            <td class="tdRight">
               <asp:Literal ID="liteAddress" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            邮政编码：
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteZipCode" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            学&nbsp;&nbsp;&nbsp;&nbsp;历：
            </td>
            <td class="tdRight">
               <asp:Literal ID="liteEducation" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            工作经验：
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteWorkExp" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            毕业学校：
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteSchool" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            专&nbsp;&nbsp;&nbsp;&nbsp;业：
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteSpeciality" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">
            技&nbsp;&nbsp;&nbsp;&nbsp;能：
            </td>
            <td class="tdRight">
                <asp:Literal ID="liteSkill" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">备&nbsp;&nbsp;&nbsp;&nbsp;注：</td>
            <td class="tdRight">
            <asp:Literal ID="liteNote" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft">申请时间：</td>
            <td class="tdRight">
            <asp:Literal ID="liteCreateTime" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="tdLeft"></td>
            <td class="tdRight">
                <asp:PlaceHolder ID="ph01" runat="server">
                <asp:Button ID="btnSubmit" runat="server" Text="邀请" onclick="btnSubmit_Click" /> <span class="strew">在提交邀请并且通过审核后，双方关系最终才会确定下来。(商家与网络营销代理商)</span>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="ph02" runat="server">
                <span class="strew">该用户已成为贵企业/公司的营销代理商</span>
                </asp:PlaceHolder>
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">

</asp:Content>

