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
    /// 与ASP兼容的MD5加密算法
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
    /// 冒泡排序法
    /// 按照字母序列从a到z的顺序排列
    /// </summary>
    public static string[] BubbleSort(string[] r)
    {
        int i, j; //交换标志 
        string temp;

        bool exchange;

        for (i = 0; i < r.Length; i++) //最多做R.Length-1趟排序 
        {
            exchange = false; //本趟排序开始前，交换标志应为假

            for (j = r.Length - 2; j >= i; j--)
            {
                if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)　//交换条件
                {
                    temp = r[j + 1];
                    r[j + 1] = r[j];
                    r[j] = temp;

                    exchange = true; //发生了交换，故将交换标志置为真 
                }
            }

            if (!exchange) //本趟排序未发生交换，提前终止算法 
            {
                break;
            }
        }
        return r;
    }

    /// <summary>
    /// 获取远程服务器ATN结果
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

            strResult = "错误：" + exp.Message;
        }
        return strResult;
    }

    /// <summary>
    /// URL链接生成（及时到帐接口）
    /// </summary>
    /// <param name="gateway">网关</param>
    /// <param name="service">服务参数</param>
    /// <param name="partner">合作伙伴ID</param>
    /// <param name="sign_type">加密类型</param>
    /// <param name="out_trade_no">订单号</param>
    /// <param name="subject">商品名称或订单名称</param>
    /// <param name="body">描述与备注</param>
    /// <param name="total_fee">总金额</param>
    /// <param name="show_url">展示地址，“详情”的链接地址</param>
    /// <param name="seller_email">商家支付宝帐号，收款人支付宝帐号</param>
    /// <param name="key">安全校验码</param>
    /// <param name="return_url">跳转返回页</param>
    /// <param name="_input_charset">编码格式</param>
    /// <param name="notify_url">请求通知页</param>
    /// <returns>生成的URL链接字符串</returns>
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
       
         //构造数组；
         //以下数组即是参与加密的参数，若参数的值不允许为空，若该参数为空，则不要成为该数组的元素
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
        
        //进行排序；
        string[] Sortedstr = BubbleSort(Oristr);

        //构造待md5摘要字符串 ；
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

        //生成Md5摘要；
        string sign = GetMD5(prestr.ToString(), _input_charset);

        //构造支付Url
        char[] delimiterChars = { '=' };
        StringBuilder parameter = new StringBuilder();
        parameter.Append(gateway);
        for (i = 0; i < Sortedstr.Length; i++)
        {//UTF-8格式的编码转换
            parameter.Append(Sortedstr[i].Split(delimiterChars)[0] + "=" + HttpUtility.UrlEncode(Sortedstr[i].Split(delimiterChars)[1]) + "&");
        }

        parameter.Append("sign=" + sign + "&sign_type=" + sign_type);

        //返回支付Url；
        return parameter.ToString();
    }

    /// <summary>
    /// URL链接生成（标准接口，又叫万能接口）
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

        //构造数组；
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

        //进行排序；
        string[] Sortedstr = BubbleSort(Oristr);


        //构造待md5摘要字符串 ；
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

        //生成Md5摘要；
        string sign = GetMD5(prestr.ToString(), _input_charset);

        //构造支付Url；
        char[] delimiterChars = { '=' };
        StringBuilder parameter = new StringBuilder();
        parameter.Append(gateway);
        for (i = 0; i < Sortedstr.Length; i++)
        {

            parameter.Append(Sortedstr[i].Split(delimiterChars)[0] + "=" + HttpUtility.UrlEncode(Sortedstr[i].Split(delimiterChars)[1]) + "&");
        }

        parameter.Append("sign=" + sign + "&sign_type=" + sign_type);

        //返回支付Url；
        return parameter.ToString();
    }
}