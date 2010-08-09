using System.Web;
using System.Text;
using System.Security.Cryptography;
using System;
using System.Net;
using System.IO;

/// <summary>
/// Interface for AliPay
/// </summary>
public class AliPay
{
    /// <summary>
    /// ��ASP���ݵ�MD5�����㷨
    /// </summary>
    public static string GetMD5(string s, string _input_charset)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(s));
        StringBuilder sb = new StringBuilder(32);
        for (int i = 0; i < t.Length; i++)
        {
            sb.Append(t[i].ToString("x").PadLeft(2, '0'));
        }
        return sb.ToString();
    }

    /// <summary>
    /// ð������
    /// ������ĸ���д�a��z��˳������
    /// </summary>
    public static string[] BubbleSort(string[] r)
    {
        int i, j; //������־ 
        string temp;

        bool exchange;

        for (i = 0; i < r.Length; i++) //�����R.Length-1������ 
        {
            exchange = false; //��������ʼǰ��������־ӦΪ��

            for (j = r.Length - 2; j >= i; j--)
            {
                if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)��//��������
                {
                    temp = r[j + 1];
                    r[j + 1] = r[j];
                    r[j] = temp;

                    exchange = true; //�����˽������ʽ�������־��Ϊ�� 
                }
            }

            if (!exchange) //��������δ������������ǰ��ֹ�㷨 
            {
                break;
            }
        }
        return r;
    }

    /// <summary>
    /// ��ȡԶ�̷�����ATN���
    /// </summary>
    /// <param name="a_strUrl"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    public static String Get_Http(String a_strUrl, int timeout)
    {
        string strResult;
        try
        {
            HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(a_strUrl);
            myReq.Timeout = timeout;
            HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
            Stream myStream = HttpWResp.GetResponseStream();
            StreamReader sr = new StreamReader(myStream, Encoding.Default);
            StringBuilder strBuilder = new StringBuilder();
            while (-1 != sr.Peek())
            {
                strBuilder.Append(sr.ReadLine());
            }

            strResult = strBuilder.ToString();
        }
        catch (Exception exp)
        {

            strResult = "����" + exp.Message;
        }
        return strResult;
    }

    /// <summary>
    /// URL�������ɣ���ʱ���ʽӿڣ�
    /// </summary>
    /// <param name="gateway">����</param>
    /// <param name="service">�������</param>
    /// <param name="partner">�������ID</param>
    /// <param name="sign_type">��������</param>
    /// <param name="out_trade_no">������</param>
    /// <param name="subject">��Ʒ���ƻ򶩵�����</param>
    /// <param name="body">�����뱸ע</param>
    /// <param name="total_fee">�ܽ��</param>
    /// <param name="show_url">չʾ��ַ�������顱�����ӵ�ַ</param>
    /// <param name="seller_email">�̼�֧�����ʺţ��տ���֧�����ʺ�</param>
    /// <param name="key">��ȫУ����</param>
    /// <param name="return_url">��ת����ҳ</param>
    /// <param name="_input_charset">�����ʽ</param>
    /// <param name="notify_url">����֪ͨҳ</param>
    /// <returns>���ɵ�URL�����ַ���</returns>
    public static string CreatUrl(
        string gateway, 
        string service, 
        string partner, 
        string sign_type,
        string out_trade_no,
        string subject, 
        string body,
        string total_fee, 
        string show_url, 
        string seller_email, 
        string key, 
        string return_url,
        string _input_charset,
        string notify_url
        )
    {
        int i;
       
         //�������飻
         //�������鼴�ǲ�����ܵĲ�������������ֵ������Ϊ�գ����ò���Ϊ�գ���Ҫ��Ϊ�������Ԫ��
            string[] Oristr ={ 
            "service="+service, 
            "partner=" + partner, 
            "subject=" + subject, 
            "body=" + body, 
            "out_trade_no=" + out_trade_no, 
            "total_fee=" + total_fee, 
            "show_url=" + show_url,  
            "payment_type=1", 
            "seller_email=" + seller_email, 
            "notify_url=" + notify_url,
            "_input_charset="+_input_charset,          
            "return_url=" + return_url
            };
        
        //��������
        string[] Sortedstr = BubbleSort(Oristr);

        //�����md5ժҪ�ַ��� ��
        StringBuilder prestr = new StringBuilder();

        for (i = 0; i < Sortedstr.Length; i++)
        {
            if (i == Sortedstr.Length - 1)
            {
                prestr.Append(Sortedstr[i]);
            }
            else
            {

                prestr.Append(Sortedstr[i] + "&");
            }
        }

        prestr.Append(key);

        //����Md5ժҪ��
        string sign = GetMD5(prestr.ToString(), _input_charset);

        //����֧��Url
        char[] delimiterChars = { '=' };
        StringBuilder parameter = new StringBuilder();
        parameter.Append(gateway);
        for (i = 0; i < Sortedstr.Length; i++)
        {//UTF-8��ʽ�ı���ת��
            parameter.Append(Sortedstr[i].Split(delimiterChars)[0] + "=" + HttpUtility.UrlEncode(Sortedstr[i].Split(delimiterChars)[1]) + "&");
        }

        parameter.Append("sign=" + sign + "&sign_type=" + sign_type);

        //����֧��Url��
        return parameter.ToString();
    }

    /// <summary>
    /// URL�������ɣ���׼�ӿڣ��ֽ����ܽӿڣ�
    /// </summary>
    /// <param name="gateway"></param>
    /// <param name="service"></param>
    /// <param name="partner"></param>
    /// <param name="sign_type"></param>
    /// <param name="out_trade_no"></param>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    /// <param name="payment_type"></param>
    /// <param name="total_fee"></param>
    /// <param name="show_url"></param>
    /// <param name="seller_email"></param>
    /// <param name="key"></param>
    /// <param name="return_url"></param>
    /// <param name="_input_charset"></param>
    /// <param name="notify_url"></param>
    /// <param name="logistics_type"></param>
    /// <param name="logistics_fee"></param>
    /// <param name="logistics_payment"></param>
    /// <param name="logistics_type_1"></param>
    /// <param name="logistics_fee_1"></param>
    /// <param name="logistics_payment_1"></param>
    /// <param name="quantity"></param>
    /// <returns></returns>
    public static string CreatUrl(
            string gateway,
            string service,
            string partner,
            string sign_type,
            string out_trade_no,
            string subject,
            string body,
            string payment_type,
            string total_fee,
            string show_url,
            string seller_email,
            string key,
            string return_url,
            string _input_charset,
            string notify_url,
            string logistics_type,
            string logistics_fee,
            string logistics_payment,
            string quantity
            )
    {
        int i;

        //�������飻
        string[] Oristr ={ 
                "service="+service, 
                "partner=" + partner, 
                "subject=" + subject, 
                "body=" + body, 
                "out_trade_no=" + out_trade_no, 
                "price=" + total_fee, 
                "show_url=" + show_url,  
                "payment_type=" + payment_type, 
                "seller_email=" + seller_email, 
                "notify_url=" + notify_url,
                "_input_charset="+_input_charset,          
                "return_url=" + return_url,
                "quantity="+quantity,
                "logistics_type="+logistics_type,
                "logistics_fee="+logistics_fee ,
                "logistics_payment="+logistics_payment
                };

        //��������
        string[] Sortedstr = BubbleSort(Oristr);


        //�����md5ժҪ�ַ��� ��
        StringBuilder prestr = new StringBuilder();

        for (i = 0; i < Sortedstr.Length; i++)
        {
            if (i == Sortedstr.Length - 1)
            {
                prestr.Append(Sortedstr[i]);

            }
            else
            {

                prestr.Append(Sortedstr[i] + "&");
            }

        }

        prestr.Append(key);

        //����Md5ժҪ��
        string sign = GetMD5(prestr.ToString(), _input_charset);

        //����֧��Url��
        char[] delimiterChars = { '=' };
        StringBuilder parameter = new StringBuilder();
        parameter.Append(gateway);
        for (i = 0; i < Sortedstr.Length; i++)
        {

            parameter.Append(Sortedstr[i].Split(delimiterChars)[0] + "=" + HttpUtility.UrlEncode(Sortedstr[i].Split(delimiterChars)[1]) + "&");
        }

        parameter.Append("sign=" + sign + "&sign_type=" + sign_type);

        //����֧��Url��
        return parameter.ToString();
    }
}