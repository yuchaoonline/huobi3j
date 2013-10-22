<%@ Page Language="C#" Title="" MasterPageFile="~/MMyUser.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.User.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="ADeeWuControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    个人控制面板 - 基本资料
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .item {
            margin-bottom: 20px;
        }

        .itemTitle {
            font-weight: bold;
            border-bottom: 1px dotted #ccc;
            margin-bottom: 10px;
            height: 24px;
            line-height: 24px;
        }

            .itemTitle span {
                float: right;
                font-weight: normal;
            }
    </style>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">基本资料</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
    <%if (this.entUser != null)
      { %>

    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">基本信息</label>
        </div>
        <div class="box_body">
            <table>
                <tbody>
                    <tr height="35px">
                        <td class="tr">登陆帐号：</td>
                        <td class="font14 black4B"><%=this.entUser.LoginName %></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">密　　码：</td>
                        <td class="font14 black4B"><a href="Password.aspx">修改</a></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">用户名称：</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">全民通讯UIN：</td>
                        <td class="font14 black4B"><%=this.entUser.UIN %></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">用户类型：</td>
                        <td class="font14 black4B">
                            <%= ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                        this.entUser.UserType.ToString(),
						"",
                        new string[][]{
                            new string[]{"0","个人用户(普通用户)"},
                            new string[]{"1","企业用户(商家)"},
                            new string[]{"2","商家代表(网络营销代理商)"}
                        }               
                        )
                            %></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">用户状态：</td>
                        <td class="font14 black4B">
                            <%= ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                        this.entUser.CheckState.ToString(),
						"",
                        new string[][]{
                            new string[]{"0","未通过审核"},
                            new string[]{"1","正常使用中"},
                            new string[]{"2","用户帐号无效"},
							new string[]{"3","用户帐号已过期"}
                        }               
                        )
                            %>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">联系方式</label>
        </div>
        <div class="box_body">
            <table>
                <tbody>
                    <tr height="35px">
                        <td class="tr">联系电话：</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtTel" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">E-mail：</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">所属地区：</td>
                        <td class="font14 black4B">
                            <ADeeWuControl:SyncSelector ID="syncSelectorLocation" runat="server"
                                DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>"
                                DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>"
                                ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">帐户信息</label>
        </div>
        <div class="box_body">
            <table>
                <tbody>
                    <tr height="35px">
                        <td class="tr">帐户余额：</td>
                        <td class="font14 black4B"><%=string.Format("{0:0.00}",this.entUser.Money) %>元 | <a href="VMoney/">历史记录</a></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">货　　币：</td>
                        <td class="font14 black4B"><%=this.entUser.Coins %>个 | <a href="Coins/">历史记录</a></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">积　　分：</td>
                        <td class="font14 black4B">
                            <%=this.entUser.Points %>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">支付宝帐号：</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtAlipayAccount" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">注册/登陆信息</label>
        </div>
        <div class="box_body">
            <table>
                <tbody>
                    <tr height="35px">
                        <td class="tr">注册时间：</td>
                        <td class="font14 black4B"><%=this.entUser.RegTime %></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">上次登陆：</td>
                        <td class="font14 black4B"><%=this.entUser.LastLogin %></td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">登陆次数：</td>
                        <td class="font14 black4B">
                            <%=this.entUser.LoginTimes %>次
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div align="center">
        <asp:Button ID="btnSubmit" runat="server" Text="修改资料" OnClick="btnSubmit_Click" />
    </div>

    <%} %>
</asp:Content>



