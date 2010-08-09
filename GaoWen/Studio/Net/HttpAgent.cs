using System;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Web;
using System.Text;

namespace Studio.Net
{
	/// <summary>
	/// Name:Http协议数据代理
	/// Description:实现基于Http协议的一些常用功能
	/// Author:谢康
	/// CreateDate:2005-07-11
	/// 
	/// </summary>
	public class HttpAgent
	{

        /// <summary>
        /// 请求(GET)远程http资源，并返回响应结果
        /// </summary>
        /// <param name="url">资源url</param>
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
		/// 请求(POST)远程http资源，并返回响应结果
		/// </summary>
		/// <param name="url">资源url</param>
		/// <param name="postData">POST数据</param>
		/// <param name="cookies">cookies值</param>
		/// <returns>返回响应结果</returns>
		public static string ReadRemoteFileByPost( string url,NameValueCollection postData)
		{
            return ReadRemoteFileByPost(url, postData, Encoding.Default);
		}

        /// <summary>
        /// 请求(POST)远程http资源，并返回响应结果
        /// </summary>
        /// <param name="url">资源url</param>
        /// <param name="postData">POST数据</param>
        /// <param name="cookies">cookies值</param>
        /// <returns>返回响应结果</returns>
        public static string ReadRemoteFileByPost(string url, NameValueCollection postData, Encoding ec)
        {
            string strPostData = "";
            for (int i = 0; i < postData.Count; i++)
            {
                strPostData += postData.Keys[i] + "=" + HttpUtility.UrlEncode(postData[i], ec) + "&";
            }
            strPostData = strPostData.Substring(0, strPostData.Length - 1);

            byte[] bufferData = ec.GetBytes(strPostData);

            //Post请求
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bufferData.Length;
            req.Method = "POST";
            //req.Timeout			= 6000;
            //req.CookieContainer.Add(cookies);

            Stream spost = req.GetRequestStream();
            spost.Write(bufferData, 0, bufferData.Length);
            spost.Close();

            //返回数据 
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
