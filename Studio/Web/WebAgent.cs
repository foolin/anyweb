using System;
using System.IO;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Collections;

using System.Messaging;

namespace Studio.Web
{
    /// <summary>
    /// Name:Web代理
    /// Description:实现Web页面常用功能
    /// </summary>	
    public class WebAgent
    {
        /// <summary>
        /// 制作压缩图片
        /// </summary>
        /// <param name="originalImagePath"></param>
        /// <param name="thumbnailPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="mode"></param>
        /// <param name="imgFormat"></param>
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode, ImageFormat imgFormat)
        {
            Image image = Image.FromFile(originalImagePath);
            int num = width;
            int num2 = height;
            int x = 0;
            int y = 0;
            int num5 = image.Width;
            int num6 = image.Height;
            string text = mode;
            if ((text != null) && (text != "HW"))
            {
                if (text == "W")
                {
                    num2 = (image.Height * width) / image.Width;
                }
                else if (text == "H")
                {
                    num = (image.Width * height) / image.Height;
                }
                else if (text == "Cut")
                {
                    if ((((double)image.Width) / ((double)image.Height)) > (((double)num) / ((double)num2)))
                    {
                        num6 = image.Height;
                        num5 = (image.Height * num) / num2;
                        y = 0;
                        x = (image.Width - num5) / 2;
                    }
                    else
                    {
                        num5 = image.Width;
                        num6 = (image.Width * height) / num;
                        x = 0;
                        y = (image.Height - num6) / 2;
                    }
                }
            }
            Image image2 = new Bitmap(num, num2);
            Graphics graphics = Graphics.FromImage(image2);
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.Transparent);
            graphics.DrawImage(image, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num5, num6), GraphicsUnit.Pixel);
            try
            {
                try
                {
                    image2.Save(thumbnailPath, (imgFormat == null) ? ImageFormat.Jpeg : imgFormat);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            finally
            {
                image.Dispose();
                image2.Dispose();
                graphics.Dispose();
            }
        }

        /// <summary>
        /// 上传并压缩图片，只适应宽度
        /// </summary>
        /// <param name="file"></param>
        /// <param name="saveOrginalTo"></param>
        /// <param name="saveTo"></param>
        /// <param name="maxWidth"></param>
        public static void SaveFile(HttpPostedFile file, string saveOrginalTo, string saveTo, int maxWidth)
        {
            string contentType = file.ContentType;
            Image image = Image.FromStream(file.InputStream);
            int width = image.Width;
            int height = image.Height;
            double a = 0;
            double num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = width;
            int num8 = height;
            if ((maxWidth == 0) || (width <= maxWidth))
            {
                maxWidth = width;
            }
            a = width;
            num4 = height;
            if (width > maxWidth)
            {
                a = maxWidth;
                num4 = height * (a / ((double)width));
            }
            num5 = int.Parse(Math.Ceiling(a).ToString());
            num6 = int.Parse(Math.Ceiling(num4).ToString());
            if (saveOrginalTo != string.Empty)
            {
                image.Save(saveOrginalTo);
            }
            if (num5 != width)
            {
                ImageFormat imageFormat = GetImageFormat(contentType);
                string filename = saveTo + ".temp";
                image.Save(filename, imageFormat);
                MakeThumbnail(filename, saveTo, num5, num6, "W", imageFormat);
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
            }
            else
            {
                image.Save(saveTo);
            }
            image.Dispose();
            file.InputStream.Close();
        }



        /// <summary>
        /// 保存上传的文件,并生成缩略图
        /// </summary>
        /// <param name="file">上传的文件</param>
        /// <param name="saveTo">保存的文件路径</param>
        /// <param name="maxWidth">缩略图最大宽度</param>
        /// <param name="maxHeight">缩略图最大高度</param>
        public static void SaveFile(HttpPostedFile file, string saveTo, int maxWidth, int maxHeight, out int orginalWidth, out int orginalHeight, bool orginal)
        {
            string contentType = file.ContentType;
            Image img = System.Drawing.Image.FromStream(file.InputStream);
            int w = img.Width, h = img.Height;
            double w1 = 0, h1 = 0; int w0 = 0, h0 = 0;

            orginalWidth = w;
            orginalHeight = h;

            if (maxWidth == 0) maxWidth = w;
            if (maxHeight == 0) maxHeight = h;
            //计算缩放比例
            w1 = w; h1 = h;
            if (w > maxWidth)
            {
                w1 = maxWidth;
                h1 = h * (w1 / w);
            }
            if (h1 > maxHeight)
            {
                w1 = w1 * (maxHeight / h1);
                h1 = maxHeight;
            }
            w0 = int.Parse(System.Math.Ceiling(w1).ToString()); h0 = int.Parse(System.Math.Ceiling(h1).ToString());

            if (orginal) img.Save(saveTo.Replace("S_", ""));

            if (w0 != w || h1 != h)	//当高或宽不相同时生成缩略图
            {
                //simg = img.GetThumbnailImage(w0, h0, null, System.IntPtr.Zero);
                //simg.Save( saveTo, GetImageFormat(contentType));
                //simg.Dispose();
                ImageFormat imageFormat = GetImageFormat(contentType);
                string filename = saveTo + ".temp";
                img.Save(filename, imageFormat);
                MakeThumbnail(filename, saveTo, w0, h0, "W", imageFormat);
                if (File.Exists(filename)) File.Delete(filename);
            }
            else
            {
                img.Save(saveTo);
            }

            img.Dispose();

            file.InputStream.Close();
        }


        public static void SaveFile(HttpPostedFile file, string saveTo, out int orginalWidth, out int orginalHeight)
        {
            string contentType = file.ContentType;
            Image img = System.Drawing.Image.FromStream(file.InputStream);
            int w = img.Width, h = img.Height;

            orginalWidth = w;
            orginalHeight = h;

            img.Save(saveTo);

            img.Dispose();

            file.InputStream.Close();
        }

        public static void SaveFile(HttpPostedFile file, string saveOrginalTo, string saveTo, int maxWidth, int maxHeight, out int orginalWidth, out int orginalHeight)
        {
            string contentType = file.ContentType;
            Image img = System.Drawing.Image.FromStream(file.InputStream);
            int w = img.Width, h = img.Height;
            double w1 = 0, h1 = 0; int w0 = 0, h0 = 0;

            orginalWidth = w;
            orginalHeight = h;

            if (maxWidth == 0) maxWidth = w;
            if (maxHeight == 0) maxHeight = h;
            //计算缩放比例
            w1 = w; h1 = h;
            if (w > maxWidth)
            {
                w1 = maxWidth;
                h1 = h * (w1 / w);
            }
            if (h1 > maxHeight)
            {
                w1 = w1 * (maxHeight / h1);
                h1 = maxHeight;
            }
            w0 = int.Parse(System.Math.Ceiling(w1).ToString()); h0 = int.Parse(System.Math.Ceiling(h1).ToString());

            if (saveOrginalTo != string.Empty) img.Save(saveOrginalTo);

            if (w0 != w || h1 != h)	//当高或宽不相同时生成缩略图
            {
                //simg = img.GetThumbnailImage(w0, h0, null, System.IntPtr.Zero);
                //simg.Save( saveTo, GetImageFormat(contentType));
                //simg.Dispose();
                ImageFormat imageFormat = GetImageFormat(contentType);
                string filename = saveTo + ".temp";
                img.Save(filename, imageFormat);
                MakeThumbnail(filename, saveTo, w0, h0, "W", imageFormat);
                if (File.Exists(filename)) File.Delete(filename);
            }
            else
            {
                img.Save(saveTo);
            }

            img.Dispose();

            file.InputStream.Close();
        }

        /// <summary>
        /// 保存上传的文件生成缩略图
        /// </summary>
        /// <param name="file">上传的文件</param>
        /// <param name="saveTo">保存的文件路径</param>
        /// <param name="maxWidth">缩略图最大宽度</param>
        /// <param name="maxHeight">缩略图最大高度</param>
        /// <param name="orginal">是否保存原图</param>
        public static void SaveFile(HttpPostedFile file, string saveTo, int maxWidth, int maxHeight, bool orginal)
        {
            int w, h;
            SaveFile(file, saveTo, maxWidth, maxHeight, out w, out h, orginal);
        }

        /// <summary>
        /// 保存上传的文件生成缩略图
        /// </summary>
        /// <param name="file">上传的文件</param>
        /// <param name="saveTo">保存的文件路径</param>
        /// <param name="maxWidth">缩略图最大宽度</param>
        /// <param name="maxHeight">缩略图最大高度</param>
        /// 
        public static void SaveFile(HttpPostedFile file, string saveTo, int maxWidth, int maxHeight)
        {
            int w, h;
            SaveFile(file, saveTo, maxWidth, maxHeight, out w, out h, true);
        }

        //获取图片文件类型
        static System.Drawing.Imaging.ImageFormat GetImageFormat(string strContentType)
        {
            switch (strContentType.ToString().ToLower())
            {
                case "image/pjpeg":
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
                case "image/gif":
                    return System.Drawing.Imaging.ImageFormat.Gif;
                case "image/bmp":
                    return System.Drawing.Imaging.ImageFormat.Bmp;
                case "image/tiff":
                    return System.Drawing.Imaging.ImageFormat.Tiff;
                case "image/x-icon":
                    return System.Drawing.Imaging.ImageFormat.Icon;
                case "image/x-png":
                    return System.Drawing.Imaging.ImageFormat.Png;
                case "image/x-emf":
                    return System.Drawing.Imaging.ImageFormat.Emf;
                case "image/x-exif":
                    return System.Drawing.Imaging.ImageFormat.Exif;
                case "image/x-wmf":
                    return System.Drawing.Imaging.ImageFormat.Wmf;
                default:
                    return System.Drawing.Imaging.ImageFormat.MemoryBmp;
            }
        }

        /// <summary>
        /// 判断是否为图片
        /// </summary>
        /// <param name="strContentType">POST过来的ContentType文件类型信息</param>
        /// <returns>是图片为true,否则为false</returns>
        public static bool IsImage(string strContentType)
        {
            switch (strContentType.ToString().ToLower())
            {
                case "image/pjpeg":
                case "image/gif":
                case "image/bmp":
                case "image/tiff":
                case "image/x-icon":
                case "image/x-png":
                case "image/x-emf":
                case "image/x-exif":
                case "image/x-wmf":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// 判断是否为图片
        /// </summary>
        /// <param name="strContentType">POST过来的ContentType文件类型信息</param>
        /// <returns>图片类型</returns>
        public static string GetImageFix(string strContentType)
        {
            switch (strContentType.ToString().ToLower())
            {
                case "image/pjpeg": return ".jpg";
                case "image/gif": return ".gif";
                case "image/bmp": return ".bmp";
                case "image/tiff": return ".tiff";
                case "image/x-icon": return ".icon";
                case "image/x-png": return ".png";
                case "image/x-emf": return ".emf";
                case "image/x-exif": return ".exif";
                case "image/x-wmf": return ".wmf";
                default: return ".gif";
            }
        }

        /// <summary>
        /// 判断字符串是否是为字符和数字
        /// Author:Turboc
        /// Date:2006-2-6
        /// </summary>
        public static bool IsString(string str)
        {
            Regex rex = new Regex(@"\W");
            return !rex.IsMatch(str);
        }

        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        public static bool IsNumeric(string s)
        {
            if (s == null || s.Equals(String.Empty))
            {
                return false;
            }

            foreach (char c in s)
            {
                if (!Char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 判断字符串是否是Int32数字(系统预设9位)
        /// </summary>
        public static bool IsInt32(string s)
        {
            if (s == null || s.Equals(String.Empty) || s.Length > 9)
            {
                return false;
            }

            foreach (char c in s)
            {
                if (!Char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 判断字符串是否是Int16数字(系统预设4位)
        /// </summary>
        public static bool IsInt16(string s)
        {
            if (s == null || s.Equals(String.Empty) || s.Length > 4)
            {
                return false;
            }

            foreach (char c in s)
            {
                if (!Char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 判断字符串是否是日期类型
        /// </summary>
        public static bool IsDate(string s)
        {
            if (s == null || s.Equals(String.Empty))
                return false;
            else
                return Regex.IsMatch(s, "^\\s*((\\d{4})|(\\d{2}))([-./])(\\d{1,2})\\4(\\d{1,2})\\s*$");
        }

        /// <summary>
        /// 判断字符串是否是有效的Url地址
        /// </summary>
        public static bool IsUrl(string s)
        {
            return Regex.IsMatch(s, @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        }

        /// <summary>
        /// 判断字符串是否是有效的电子邮件地址
        /// </summary>
        public static bool IsEmail(string s)
        {
            return Regex.IsMatch(s, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }

        /// <summary>
        /// 判断字符串是否是有效的身份证号码
        /// </summary>
        public static bool IsIDCard(string s)
        {
            return Regex.IsMatch(s, @"\d{18}|\d{15}");
        }

        /// <summary>
        /// 从Url里取一个QueryString的键值
        /// </summary>
        public static string GetKeyFromUrl(string urlString, string key)
        {
            string key1 = '?' + key + '=';
            string key2 = '&' + key + '=';
            int idx = 0, begin;
            string valu = String.Empty;
            if (urlString.LastIndexOf(key1) > 0)
            {
                begin = urlString.LastIndexOf(key1) + key1.Length;
                idx = urlString.IndexOf('&', urlString.Length - 1);
                if (idx > begin)
                {
                    valu = urlString.Substring(begin, idx - begin);
                }
                else
                {
                    valu = urlString.Substring(begin);
                }
                return valu;
            }
            if (urlString.LastIndexOf(key2) > 0)
            {
                begin = urlString.LastIndexOf(key2) + key2.Length;
                idx = urlString.LastIndexOf('&', urlString.Length - 1);
                if (idx > begin)
                {
                    valu = urlString.Substring(begin, idx - begin);
                }
                else
                {
                    valu = urlString.Substring(begin);
                }
                return valu;
            }

            return valu;
        }

        /// <summary>
        /// 提取字符串的左边length个字符
        /// </summary>
        /// <param name="input">从中提取的字符串</param>
        /// <param name="length">左起要提取的长度</param>
        /// <returns>左起length个字符（带tag标签）</returns>
        public static string GetLeft(string input, int length)
        {
            return GetLeft(input, length, true);
        }

        public static string ReplaceRepeatBR(object input)
        {
            string str = input.ToString();
            while ((str.IndexOf("<BR><BR>") != -1) || (str.IndexOf("<br><br>") != -1))
            {
                str = str.Replace("<BR><BR>", "<BR>");
                str = str.Replace("<br><br>", "<br>");
            }
            return str;
        }

        /// <summary>
        /// 提取字符串的左边length个字符
        /// </summary>
        /// <param name="input">从中提取的字符串</param>
        /// <param name="length">左起要提取的长度</param>
        /// <param name="keepAlt">是否保留alt说明</param>
        /// <returns>左起length个字符（带tag标签）</returns>
        public static string GetLeft(string input, int length, bool keepAlt)
        {
            if (input == null)
                return "";

            if (input.Length <= length)
                return input;
            else
                if (keepAlt)
                    return "<span title='" + input.Replace("'", "\"") + "'>" + input.Substring(0, length) + "...</span>";
                else
                    return input.Substring(0, length) + "...";
        }


        /// <summary>
        /// 去除指定字符组合内的字符串，如去除html标记
        /// </summary>
        /// <param name="input">要处理的字符串</param>
        /// <param name="beginTag">标记前缀</param>
        /// <param name="endTag">标记后缀</param>
        /// <returns>清理后的字符串</returns>
        public static string CleanTag(string input, char beginTag, char endTag)
        {
            return ClearTag(input, beginTag, endTag, true);
        }

        /// <summary>
        /// 去除指定字符组合内的字符串，如去除html标记
        /// </summary>
        /// <param name="input">要处理的字符串</param>
        /// <param name="beginTag">标记前缀</param>
        /// <param name="endTag">标记后缀</param>
        /// <param name="keepBR">是否保留HTML代码的BR标记</param>
        /// <returns>清理后的字符串</returns>
        public static string ClearTag(string input, char beginTag, char endTag, bool keepBR)
        {
            if (beginTag == endTag)	//前后缀不能相同
            {
                return input;
            }

            if (keepBR)
            {
                input = input.Replace("<BR>", "\r\n");
            }

            int begin = input.IndexOf(beginTag);
            int end;
            while (begin > -1)
            {
                end = input.IndexOf(endTag, begin);
                if (end < begin)
                {
                    if (keepBR)
                    {
                        input = input.Replace("\r\n", "<BR>");
                    }
                    return input;
                }
                else		//去除前后缀之间的字符
                {
                    input = input.Substring(0, begin) + ((end < input.Length - 1) ? input.Substring(end + 1) : "");
                }
                begin = input.IndexOf(beginTag);
            }

            if (keepBR)
            {
                input = input.Replace("\r\n", "<BR>");
            }

            return input;
        }

        /// <summary>
        /// 获取从文本框输入的文字的HTML表示形式
        /// </summary>
        /// <param name="text">从文本框输入的文字内容</param>
        /// <returns>转换相关标记后的HTML文字内容</returns>
        public static string GetDisplayText(string text)
        {
            return text.Replace("\r\n", "<br>").Replace(" ", "&nbsp;");
        }

        /// <summary>
        /// 检测PostBack过来的带","的字符串
        /// </summary>
        /// <param name="filterstring">要检测的字符串</param>
        /// <returns>返回的字符</returns>
        public static bool FilterDotString(string filterstring)
        {
            if (filterstring == "") return false;
            string[] splits = filterstring.Split(new char[] { ',' });
            foreach (string str in splits)
            {
                if (!WebAgent.IsNumeric(str)) return false;
            }
            return true;
        }
        /// <summary>
        /// 增加截断字符串的函数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetShortString(string str, int length)
        {
            if (System.Text.Encoding.Default.GetByteCount(str) <= length) return str;
            return System.Text.Encoding.Default.GetString(System.Text.Encoding.Default.GetBytes(str), 0, length - 3) + "...";
        }

        /// <summary>
        /// 获取高亮显示字体
        /// </summary>
        /// <param name="str"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string GetObviousString(string str, string keyword, string color)
        {
            if (color.Trim() == "") color = "red";
            string[] arr = keyword.Split(' ');
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Trim() == "") continue;
                str = str.Replace(arr[i], string.Format("<font color={0}>{1}</font>", color, arr[i]));
            }
            return str;
        }

        /// <summary>
        /// 创建一段代码,将页面上的编辑域隐藏
        /// </summary>
        /// <param name="p">要添加代码的Page对象</param>
        /// <param name="editMode">当前是否是编辑状态</param>
        public static void CreateViewScript(Page p, bool editMode)
        {
            if (!p.IsStartupScriptRegistered("StudioViewScript"))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script language='javascript'>									\n")
                    .Append("var editCtls = document.getElementsByName(\"editTag\");		\n")
                    .Append("for(i=0;i<editCtls.length;i++)									\n")
                    .Append("{editCtls[i].style.display='" + (editMode ? "block" : "none") + "';}						\n")
                    .Append("</script>");

                p.RegisterStartupScript("StudioViewScript", sb.ToString());

                if (editMode)
                {
                    CreateEditScript(p);
                }
            }
        }

        /// <summary>
        /// 添加一段代码,将一些PostBack操作简化,用普通Form方式处理回传信息
        /// </summary>
        /// <param name="p">要添加代码的Page对象</param>
        public static void CreateEditScript(Page p)
        {
            if (!p.IsStartupScriptRegistered("StudioEditScript"))
            {

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script language='javascript'>							\n")
                    .Append("function DoMethod(src,cmd,args){						\n")
                    .Append("	var opform=document.getElementById(\"opform\");			\n")
                    .Append("	if( opform == null){			\n")
                    .Append("		opform=document.createElement(\"<form id='opform' method='post'></form>\");			\n")
                    .Append("		document.body.insertBefore(opform);			\n")
                    .Append("		opform.insertBefore(document.createElement(\"<input type=hidden name='EventSource'>\"));			\n")
                    .Append("		opform.insertBefore(document.createElement(\"<input type=hidden name='EventName'>\"));			\n")
                    .Append("		opform.insertBefore(document.createElement(\"<input type=hidden name='EventArgs'>\"));			\n")
                    .Append("	}			\n")
                    .Append("	opform.EventSource.value = src;				\n")
                    .Append("	opform.EventName.value = cmd;				\n")
                    .Append("	opform.EventArgs.value = args;				\n")
                    .Append("	opform.submit();					\n")
                    .Append("}\n")
                    .Append("</script>");

                p.RegisterStartupScript("StudioEditScript", sb.ToString());
            }
        }

        /// <summary>
        /// 创建弹出信息
        /// </summary>
        /// <param name="msg">弹出的信息</param>
        public static void Alert(string msg)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>alert('" + msg.Replace("'", "") + "');</script>");
        }

        /// <summary>
        /// 创建弹出信息并返回原页面
        /// </summary>
        /// <param name="msg">弹出的信息</param>
        public static void AlertAndBack(string msg)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write("<script language='javascript'>alert('" + msg.Replace("'", "") + "');history.go(-1);</script>");
            HttpContext.Current.Response.End();
        }

        public static void ConfirmGo(string msg, string trueUrl, string falseUrl)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(string.Format("<script language='javascript'>if( confirm('{0}')) document.location.href='{1}'; else document.location.href='{2}';</script>", msg.Replace("'", ""), trueUrl, falseUrl));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 弹出一条成功消息,点确定后跳转到指定Url
        /// </summary>
        /// <param name="msg">弹出的信息</param>
        /// <param name="goUrl">要跳转的Url</param>
        public static void SuccAndGo(string msg, string goUrl)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(String.Format("<script language='javascript'>alert('{0}');document.location.href='{1}';</script>", msg.Replace("'", ""), goUrl));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 弹出一条成功消息,点确定后跳转到指定Url
        /// </summary>
        /// <param name="msg">弹出的信息</param>
        /// <param name="goUrl">要跳转的Url</param>
        public static void SuccAndGo(string msg)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(String.Format("<script language='javascript'>alert('{0}');history.back();</script>", msg.Replace("'", "")));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 弹出一条失败消息,点确定后跳转到指定Url
        /// </summary>
        /// <param name="msg">弹出的信息</param>
        /// <param name="goUrl">要跳转的Url</param>
        public static void FailAndGo(string msg, string goUrl)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(String.Format("<script language='javascript'>alert('{0}');document.location.href='{1}';</script>", msg.Replace("'", ""), goUrl));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 弹出一条失败消息,点确定后跳转回原页面
        /// Author:turboc
        /// CreateDate:2006-02-05
        /// </summary>
        /// <param name="msg">弹出的信息</param>
        public static void FailAndGo(string msg)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(String.Format("<script language='javascript'>alert('{0}');history.back();</script>", msg.Replace("'", "")));
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 在当前请求中输出一个隐藏的Iframe
        /// </summary>
        /// <param name="url">Iframe在源地址</param>
        public static void CreateHiddenIFrame(string url)
        {
            HttpContext.Current.Response.Write("<iframe style='width:100px;height:100px;' frameborder=0 src='" + url + "'></iframe>");
        }

        /// <summary>
        /// 在页面上停留一段时间(通常是几钞钟),显示一条等待信息,然后跳转到指定页面
        /// </summary>
        /// <param name="sec">停留时间(单位:秒)</param>
        /// <param name="alterMsg">等待信息内容</param>
        /// <param name="goUrl">跳转的地址</param>
        /// <param name="clearResp">是否清除响应内容</param>
        public static void WaitAndGo(int sec, string alterMsg, string goUrl, bool clearResp)
        {
            if (clearResp)
            {
                HttpContext.Current.Response.Clear();
            }

            HttpContext.Current.Response.Write(alterMsg);
            HttpContext.Current.Response.Write(String.Format("<script language='javascript'>setTimeout(\"document.location.href='{1}';\", {2}*1000);</script>", alterMsg.Replace("'", ""), goUrl, sec));

            HttpContext.Current.Response.End();
        }

        public static string NewKey()
        {
            return NewKey(KeyCreationType.Time);
        }

        public static string NewKey(KeyCreationType t)
        {
            switch (t)
            {
                case KeyCreationType.Time:
                    {
                        return DateTime.Now.ToString("yyMMddHHmmssfff");
                    }
                default: return NewKey(KeyCreationType.Time);
            }
        }

        /// <summary>
        /// 随机获取一个指定数量的列表
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <param name="getCount">要获取的元素个数</param>
        /// <returns></returns>
        public static IList GetRandomList(IList list, int getCount)
        {
            ArrayList resultList = new ArrayList();
            if (list.Count <= getCount)
            {
                return list;
            }

            Random rd = new Random();
            while (resultList.Count < getCount)
            {
                resultList.Add(list[rd.Next(list.Count)]);
            }

            return resultList;
        }

        /// <summary>
        /// 触发Web事件
        /// </summary>
        /// <param name="e">事件数据</param>
        public static void RaiseEvent(WebEvent e)
        {
            string msgPath = System.IO.Path.GetTempPath() + "webevent.log";
            IO.LogAgent.WriteLogFile(msgPath, e.ToString());
        }

        /// <summary>
        /// 转换UBB代码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UbbCode(string str)
        {
            str = str.Replace("\n", "<br>");
            str = Regex.Replace(str, @"\[b](?<x>[^\[]*)\[/b]", "<B>$1</B>", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\[u](?<x>[^\[]*)\[/u]", "<U>$1</U>", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\[i](?<x>[^\[]*)\[/i]", "<I>$1</I>", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\[em(?<x>([0-9]*))]", "<img src='http://public.anyp.net/images/ubb/em/$1.gif'>", RegexOptions.IgnoreCase);


            str = Regex.Replace(str, @"\[pic](?<x>[^\]]*)\[/pic]", "<img src='$1'>", RegexOptions.IgnoreCase);

            str = Regex.Replace(str, @"\[url](?<x>[^\]]*)\[/url]", "<a href='$1' target='_blank'>$1</a>", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\[color=(?<x>[^\]]*)](?<y>[^\]]*)\[/color]", "<font color='$1'>$2</font>", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\[url=(?<x>[^\]]*)](?<y>[^\]]*)\[/url]", "<a href='$1' target='_blank'>$2</a>", RegexOptions.IgnoreCase);

            str = Regex.Replace(str, @"\[flash=(?<x>([0-9]*)),(?<y>([0-9]*))](?<z>[^\]]*)\[/flash]", "<embed src='$3' width='$1' height='$2' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' name='Adodb MacroMedia Flash Player'></embed>", RegexOptions.IgnoreCase);
            return str;
        }

        /// <summary>
        /// 修正IP,最后一段用*代替
        /// </summary>
        /// <param name="ip">完整IP</param>
        /// <returns></returns>
        public static string FixIP(string ip)
        {
            if (ip.IndexOf('.') > 0)
                return ip.Substring(0, ip.LastIndexOf('.') + 1) + '*';
            else
                return ip;
        }
    }

    public enum KeyCreationType
    {
        Time = 1
    }
}
