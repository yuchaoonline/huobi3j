<%@ Page Language="C#" Title="" MasterPageFile="~/MMyCorp.master" CodeBehind="Default.aspx.cs" Inherits="ADeeWu.HuoBi3J.Web.My.Corp.Default" %>

<%@ Register Assembly="ADeeWu.HuoBi3J.WebUI" Namespace="ADeeWu.HuoBi3J.WebUI" TagPrefix="IscControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    商家控制面板 - 基本资料
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="siteposition" runat="server">
    <span class="spl"></span><span class="curPos">基本资料</span>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">

    <%if (this.entCorp != null)
      { %>

    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">动态信息</label>
        </div>
        <div class="box_body">
            <table>
                <tbody>
                    <%if (this.LoginUser.IsCashTicketPartner)
                      {%>
                    <tr height="35px">
                        <td class="tr">现金赠送券：</td>
                        <td class="font14 black4B">
                            <label class="orange ">
                                <asp:Literal ID="liteNumOfCashTickets" runat="server"></asp:Literal></label>
                            张</td>
                    </tr>
                    <%}%>
                    <%if (this.LoginUser.IsPromotionCorp)
                      {%>
                    <tr height="35px">
                        <td class="tr">商家推广：</td>
                        <td class="font14 black4B">已设置
                            <label class="orange">
                                <asp:Literal ID="liteNumOfPromotionKeys" runat="server"></asp:Literal></label>
                            个关键字</td>
                    </tr>
                    <%}%>
                    <tr height="35px">
                        <td class="tr">在线招聘：</td>
                        <td class="font14 black4B">已发布
                            <label class="orange">
                                <asp:Literal ID="liteNumOfJobs" runat="server"></asp:Literal></label>
                            个职位</td>
                    </tr>
                    <tr height="35px">
                        <td class="tr">在线营销：</td>
                        <td class="font14 black4B">已发布
                            <label class="orange">
                                <asp:Literal ID="liteNumOfProducts" runat="server"></asp:Literal></label>
                            件商品，客户订单：<label class="orange"><asp:Literal ID="liteOrders" runat="server"></asp:Literal></label>
                            张</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <div class="box">
        <div class="box_head1">
            <label class="fb font14 black70">企业信息</label>
        </div>
        <div class="box_body">
            <table>
                <tbody>
                    <tr height="35px">
                        <td class="tr black70" width="77px">公司名称：</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtCorpName" runat="server" CssClass="txtBox" Width="300" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">行　　业：</td>
                        <td class="font14 black4B">
                            <IscControl:SyncSelector ID="syncSelectorCalling" runat="server"
                                DataSourceURL="<%$Resources:SyncSelector,Calling_DataSourceURL %>"
                                DataSourceName="<%$Resources:SyncSelector,Calling_DataSourceName %>"
                                ClientPostNames="<%$Resources:SyncSelector,Calling_ClientPostNames %>" />
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">性　　质：</td>
                        <td class="font14 black4B">
                            <asp:DropDownList ID="ddlProperty" runat="server">
                                <asp:ListItem Value="个体户">个体户</asp:ListItem>
                                <asp:ListItem Value="私营企业">私营企业</asp:ListItem>
                                <asp:ListItem Value="国有企业">国有企业</asp:ListItem>
                                <asp:ListItem Value="有限责任公司">有限责任公司</asp:ListItem>
                                <asp:ListItem Value="股份有限公司">股份有限公司</asp:ListItem>
                                <asp:ListItem Value="其它">其它</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">规　　模：</td>
                        <td class="font14 black4B">
                            <asp:DropDownList ID="ddlEmployees" runat="server">
                                <asp:ListItem Value="少于50人">少于50人</asp:ListItem>
                                <asp:ListItem Value="50-149人">50-149人</asp:ListItem>
                                <asp:ListItem Value="150-499人">150-499人</asp:ListItem>
                                <asp:ListItem Value="500-999人">500-999人</asp:ListItem>
                                <asp:ListItem Value="1000人以上">1000人以上</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">负 责 人：</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtLinkMan" runat="server" CssClass="txtBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">联系电话：</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtTel" runat="server" CssClass="txtBox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">所属地区：</td>
                        <td class="font14 black4B">
                            <IscControl:SyncSelector ID="syncSelectorLocation" runat="server"
                                DataSourceURL="<%$Resources:SyncSelector,Location_DataSourceURL %>"
                                DataSourceName="<%$Resources:SyncSelector,Location_DataSourceName %>"
                                ClientPostNames="<%$Resources:SyncSelector,Location_ClientPostNames %>" />
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">公司地址：</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtAddress" runat="server" Width="300" CssClass="txtAddress"></asp:TextBox>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">世界坐标：</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtLat" runat="server" Width="200px" /><br />
                            经度 -
                    <asp:TextBox ID="txtLng" runat="server" Width="200px" /><br />
                            <a href="/Map/?lat=<%=this.txtLat.Text%>&lng=<%=this.txtLng.Text%>&title=<%=HttpUtility.HtmlEncode(this.txtCorpName.Text)%>&summary=<%=HttpUtility.HtmlEncode(this.txtAddress.Text)%>" target="_blank">查看当前地图位置</a> | <a href="/Map/GetPosition.html" target="_blank">获取地图坐标</a>(在地图上定位后，把对应的纬度、经度数值粘帖到文本框中)
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">公司介绍：</td>
                        <td class="font14 black4B">
                            <asp:TextBox ID="txtIntro" runat="server" TextMode="MultiLine" Rows="20" Columns="70" CssClass="txtNotes"></asp:TextBox>
                        </td>
                    </tr>
                    <tr height="35px">
                        <td class="tr black70" width="77px">审核状态：</td>
                        <td class="font14 black4B">
                            <label class="orange font14">
                                <%= ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                    this.entCorp.CheckState.ToString(),
                    "",
                    new string[][]{
						new string[]{"0","未通过审核"},
						new string[]{"1","已审核"},
						new string[]{"2","无效"},
						new string[]{"3","已过期"}
					}
                    )
                                %></label>
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
<asp:Content ID="Content5" ContentPlaceHolderID="afterform" runat="server">
</asp:Content>



