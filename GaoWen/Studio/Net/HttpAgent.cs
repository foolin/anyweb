using System;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Web;
using System.Text;

namespace Studio.Net
{
	/// <summary>
	/// Name:HttpЭ�����ݴ���
	/// Description:ʵ�ֻ���HttpЭ���һЩ���ù���
	/// Author:л��
	/// CreateDate:2005-07-11
	/// 
	/// </summary>
	public class HttpAgent
	{

        /// <summary>
        /// ����(GET)Զ��http��Դ����������Ӧ���
        /// </summary>
        /// <param name="url">��Դurl</param>
        /// <returns></returns>
        public static string ReadRemoteFile(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse res = null;
            StreamReader sr = null;
            string encode = "gb2312";
            string contentString = String.Empty;

            try
            {
                res = (HttpWebResponse)req.GetResponse();
                if (res.CharacterSet != "")
                {
                    encode = res.CharacterSet;
                }

                sr = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding(encode));
                contentString = sr.ReadToEnd();
                return contentString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sr != null) sr.Close();
                if(res != null) res.Close();
            }
        }

		/// <summary>
		/// ����(POST)Զ��http��Դ����������Ӧ���
		/// </summary>
		/// <param name="url">��Դurl</param>
		/// <param name="postData">POST����</param>
		/// <param name="cookies">cookiesֵ</param>
		/// <returns>������Ӧ���</returns>
		public static string ReadRemoteFileByPost( string url,NameValueCollection postData)
		{
            return ReadRemoteFileByPost(url, postData, Encoding.Default);
		}

        /// <summary>
        /// ����(POST)Զ��http��Դ����������Ӧ���
        /// </summary>
        /// <param name="url">��Դurl</param>
        /// <param name="postData">POST����</param>
        /// <param name="cookies">cookiesֵ</param>
        /// <returns>������Ӧ���</returns>
        public static string ReadRemoteFileByPost(string url, NameValueCollection postData, Encoding ec)
        {
            string strPostData = "";
            for (int i = 0; i < postData.Count; i++)
            {
                strPostData += postData.Keys[i] + "=" + HttpUtility.UrlEncode(postData[i], ec) + "&";
            }
            strPostData = strPostData.Substring(0, strPostData.Length - 1);

            byte[] bufferData = ec.GetBytes(strPostData);

            //Post����
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bufferData.Length;
            req.Method = "POST";
            //req.Timeout			= 6000;
            //req.CookieContainer.Add(cookies);

            Stream spost = req.GetRequestStream();
            spost.Write(bufferData, 0, bufferData.Length);
            spost.Close();

            //�������� 
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), ec);
            string contentString = String.Empty;
            try
            {
                contentString = sr.ReadToEnd();
                return contentString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sr != null) sr.Close();
                //if(spost != null) spost.Close();
                res.Close();
            }
        }
	}
}
