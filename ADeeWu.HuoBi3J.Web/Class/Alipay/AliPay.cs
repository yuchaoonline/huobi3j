using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;


namespace ADeeWu.HuoBi3J.Web.Class.Alipay
{


    /// <summary>
    /// created by sunzhizhi 2006.5.21,sunzhizhi@msn.com。
    /// </summary>
    public class AliPay
    {

        /// <summary>
        /// 创建使用支付宝即时到帐接口地址
        /// </summary>
        /// <param name="out_trade_no">网站内部使用交易唯一单号</param>
        /// <param name="subject">交易对象名称 如:商品001</param>
        /// <param name="body">交易描述</param>
        /// <param name="price">单价</param>
        /// <param name="total_fee">交易总金额</param>
        /// <param name="return_url">用户交费成功后返回地址</param>
        /// <param name="notify_url">支付宝帐号通知时，传递信息的站内使用地址</param>
        /// <returns></returns>
        public string CreatDirectPayUrl(
             string out_trade_no,
             string subject,
             string body,
             string total_fee,
             string return_url,
             string notify_url
             )
        {



            ///////////////////////以下参数是需要设置的相关配置参数，设置后不会更改的///////////////////////////
            string partner = "2088002797726242";                                     //合作身份者ID
            string key = "k2zawv6e5g5p0zaenrv9obvqc2kt5977";                         //安全检验码
            string seller_email = "kenlin11@163.com";                             //签约支付宝账号或卖家支付宝帐户
            string input_charset = "utf-8";                                          //字符编码格式 目前支持 gb2312 或 utf-8
            //string notify_url = "http://www.xxx.com/js_vs2005_utf8/notify_url.aspx"; //交易过程中服务器通知的页面 要用 http://格式的完整路径，不允许加?id=123这类自定义参数
            //string return_url = "http://localhost:2340/js_vs2005_utf8/return_url.aspx"; //付完款后跳转的页面 要用 http://格式的完整路径，不允许加?id=123这类自定义参数
            //string show_url = "http://www.xxx.com/myorder.aspx";                     //网站商品的展示地址，不允许加?id=123这类自定义参数
            string show_url = "http://www.ADeeWu.HuoBi3J.com";
            string sign_type = "MD5";                                                //加密方式 不需修改
            string antiphishing = "0";                                               //防钓鱼功能开关，'0'表示该功能关闭，'1'表示该功能开启。默认为关闭
            //一旦开启，就无法关闭，根据商家自身网站情况请慎重选择是否开启。
            //申请开通方法：联系我们的客户经理或拨打商户服务电话0571-88158090，帮忙申请开通
            //若要使用防钓鱼功能，建议使用POST方式请求数据

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            ///////////////////////以下参数是需要通过下单时的订单数据传入进来获得////////////////////////////////
            //必填参数
            //string out_trade_no = DateTime.Now.ToString("yyyyMMddHHmmss");  //请与贵网站订单系统中的唯一订单号匹配
            //string subject = "订单名称";                                    //订单名称，显示在支付宝收银台里的“商品名称”里，显示在支付宝的交易管理的“商品名称”的列表里。
            //string body = "订单描述备注";                                   //订单描述、订单详细、订单备注，显示在支付宝收银台里的“商品描述”里
            //string total_fee = "0.01";                                      //订单总金额，显示在支付宝收银台里的“应付总额”里

            //扩展功能参数——网银提前
            string paymethod = "bankPay";                                   //默认支付方式，四个值可选：bankPay(网银); cartoon(卡通); directPay(余额); CASH(网点支付)
            string defaultbank = "CMB";                                     //默认网银代号，代号列表见http://club.alipay.com/read.php?tid=8681379

            //扩展功能参数——防钓鱼
            string encrypt_key = "";                                        //防钓鱼时间戳，初始值
            string exter_invoke_ip = "";                                    //客户端的IP地址，初始值
            if (antiphishing == "1")
            {
                encrypt_key = AlipayFunction.Query_timestamp(partner);
                exter_invoke_ip = "";                                       //获取客户端的IP地址，建议：编写获取客户端IP地址的程序
            }

            //扩展功能参数——其他
            string extra_common_param = "";                //自定义参数，可存放任何内容（除=、&等特殊字符外），不会显示在页面上
            string buyer_email = "";			                            //默认买家支付宝账号

            //扩展功能参数——分润(若要使用，请按照注释要求的格式赋值)
            string royalty_type = "";                                   //提成类型，该值为固定值：10，不需要修改
            string royalty_parameters = "";
            //提成信息集，与需要结合商户网站自身情况动态获取每笔交易的各分润收款账号、各分润金额、各分润说明。最多只能设置10条
            //提成信息集格式为：收款方Email_1^金额1^备注1|收款方Email_2^金额2^备注2
            //如：
            //royalty_type = "10";
            //royalty_parameters = "111@126.com^0.01^分润备注一|222@126.com^0.01^分润备注二";

            //扩展功能参数——自定义超时(若要使用，请按照注释要求的格式赋值)
            //该功能默认不开通，需联系客户经理咨询
            string it_b_pay = "";  //超时时间，不填默认是15天。八个值可选：1h(1小时),2h(2小时),3h(3小时),1d(1天),3d(3天),7d(7天),15d(15天),1c(当天)

            /////////////////////////////////////////////////////////////////////////////////////////////////////

            //构造请求函数
            AlipayService aliService = new AlipayService(
                partner, 
                seller_email, 
                return_url, 
                notify_url, 
                show_url, 
                out_trade_no, 
                subject, 
                body, 
                total_fee, 
                paymethod, 
                defaultbank, 
                encrypt_key, 
                exter_invoke_ip, 
                extra_common_param, 
                buyer_email,
                royalty_type,
                royalty_parameters, 
                it_b_pay, 
                key, 
                input_charset, 
                sign_type);

            //GET方式传递
            string url = aliService.Create_url();

            //POST方式传递，得到加密结果字符串。想POST方式传递，请把下面那句注释去掉。
            //string sHtmlText = aliService.Build_postform();

            return url;
        }




    }
}