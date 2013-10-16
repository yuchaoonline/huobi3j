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
    /// created by sunzhizhi 2006.5.21,sunzhizhi@msn.com��
    /// </summary>
    public class AliPay
    {

        /// <summary>
        /// ����ʹ��֧������ʱ���ʽӿڵ�ַ
        /// </summary>
        /// <param name="out_trade_no">��վ�ڲ�ʹ�ý���Ψһ����</param>
        /// <param name="subject">���׶������� ��:��Ʒ001</param>
        /// <param name="body">��������</param>
        /// <param name="price">����</param>
        /// <param name="total_fee">�����ܽ��</param>
        /// <param name="return_url">�û����ѳɹ��󷵻ص�ַ</param>
        /// <param name="notify_url">֧�����ʺ�֪ͨʱ��������Ϣ��վ��ʹ�õ�ַ</param>
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



            ///////////////////////���²�������Ҫ���õ�������ò��������ú󲻻���ĵ�///////////////////////////
            string partner = "2088002797726242";                                     //���������ID
            string key = "k2zawv6e5g5p0zaenrv9obvqc2kt5977";                         //��ȫ������
            string seller_email = "kenlin11@163.com";                             //ǩԼ֧�����˺Ż�����֧�����ʻ�
            string input_charset = "utf-8";                                          //�ַ������ʽ Ŀǰ֧�� gb2312 �� utf-8
            //string notify_url = "http://www.xxx.com/js_vs2005_utf8/notify_url.aspx"; //���׹����з�����֪ͨ��ҳ�� Ҫ�� http://��ʽ������·�����������?id=123�����Զ������
            //string return_url = "http://localhost:2340/js_vs2005_utf8/return_url.aspx"; //��������ת��ҳ�� Ҫ�� http://��ʽ������·�����������?id=123�����Զ������
            //string show_url = "http://www.xxx.com/myorder.aspx";                     //��վ��Ʒ��չʾ��ַ���������?id=123�����Զ������
            string show_url = "http://www.ADeeWu.HuoBi3J.com";
            string sign_type = "MD5";                                                //���ܷ�ʽ �����޸�
            string antiphishing = "0";                                               //�����㹦�ܿ��أ�'0'��ʾ�ù��ܹرգ�'1'��ʾ�ù��ܿ�����Ĭ��Ϊ�ر�
            //һ�����������޷��رգ������̼�������վ���������ѡ���Ƿ�����
            //���뿪ͨ��������ϵ���ǵĿͻ�����򲦴��̻�����绰0571-88158090����æ���뿪ͨ
            //��Ҫʹ�÷����㹦�ܣ�����ʹ��POST��ʽ��������

            ////////////////////////////////////////////////////////////////////////////////////////////////////

            ///////////////////////���²�������Ҫͨ���µ�ʱ�Ķ������ݴ���������////////////////////////////////
            //�������
            //string out_trade_no = DateTime.Now.ToString("yyyyMMddHHmmss");  //�������վ����ϵͳ�е�Ψһ������ƥ��
            //string subject = "��������";                                    //�������ƣ���ʾ��֧��������̨��ġ���Ʒ���ơ����ʾ��֧�����Ľ��׹���ġ���Ʒ���ơ����б��
            //string body = "����������ע";                                   //����������������ϸ��������ע����ʾ��֧��������̨��ġ���Ʒ��������
            //string total_fee = "0.01";                                      //�����ܽ���ʾ��֧��������̨��ġ�Ӧ���ܶ��

            //��չ���ܲ�������������ǰ
            string paymethod = "bankPay";                                   //Ĭ��֧����ʽ���ĸ�ֵ��ѡ��bankPay(����); cartoon(��ͨ); directPay(���); CASH(����֧��)
            string defaultbank = "CMB";                                     //Ĭ���������ţ������б��http://club.alipay.com/read.php?tid=8681379

            //��չ���ܲ�������������
            string encrypt_key = "";                                        //������ʱ�������ʼֵ
            string exter_invoke_ip = "";                                    //�ͻ��˵�IP��ַ����ʼֵ
            if (antiphishing == "1")
            {
                encrypt_key = AlipayFunction.Query_timestamp(partner);
                exter_invoke_ip = "";                                       //��ȡ�ͻ��˵�IP��ַ�����飺��д��ȡ�ͻ���IP��ַ�ĳ���
            }

            //��չ���ܲ�����������
            string extra_common_param = "";                //�Զ���������ɴ���κ����ݣ���=��&�������ַ��⣩��������ʾ��ҳ����
            string buyer_email = "";			                            //Ĭ�����֧�����˺�

            //��չ���ܲ�����������(��Ҫʹ�ã��밴��ע��Ҫ��ĸ�ʽ��ֵ)
            string royalty_type = "";                                   //������ͣ���ֵΪ�̶�ֵ��10������Ҫ�޸�
            string royalty_parameters = "";
            //�����Ϣ��������Ҫ����̻���վ���������̬��ȡÿ�ʽ��׵ĸ������տ��˺š��������������˵�������ֻ������10��
            //�����Ϣ����ʽΪ���տEmail_1^���1^��ע1|�տEmail_2^���2^��ע2
            //�磺
            //royalty_type = "10";
            //royalty_parameters = "111@126.com^0.01^����עһ|222@126.com^0.01^����ע��";

            //��չ���ܲ��������Զ��峬ʱ(��Ҫʹ�ã��밴��ע��Ҫ��ĸ�ʽ��ֵ)
            //�ù���Ĭ�ϲ���ͨ������ϵ�ͻ�������ѯ
            string it_b_pay = "";  //��ʱʱ�䣬����Ĭ����15�졣�˸�ֵ��ѡ��1h(1Сʱ),2h(2Сʱ),3h(3Сʱ),1d(1��),3d(3��),7d(7��),15d(15��),1c(����)

            /////////////////////////////////////////////////////////////////////////////////////////////////////

            //����������
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

            //GET��ʽ����
            string url = aliService.Create_url();

            //POST��ʽ���ݣ��õ����ܽ���ַ�������POST��ʽ���ݣ���������Ǿ�ע��ȥ����
            //string sHtmlText = aliService.Build_postform();

            return url;
        }




    }
}