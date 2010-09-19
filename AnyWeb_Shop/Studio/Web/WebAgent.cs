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
	/// Name:Web����
	/// Description:ʵ��Webҳ�泣�ù���
	/// Author:л��
	/// CreateDate:2005-07-11
	/// </summary>	
	public class WebAgent
	{
        /// <summary>
        /// ����ѹ��ͼƬ
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
        /// �ϴ���ѹ��ͼƬ��ֻ��Ӧ����
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
		/// �����ϴ����ļ�,����������ͼ
		/// </summary>
		/// <param name="file">�ϴ����ļ�</param>
		/// <param name="saveTo">������ļ�·��</param>
		/// <param name="maxWidth">����ͼ������</param>
		/// <param name="maxHeight">����ͼ���߶�</param>
		public static void SaveFile( HttpPostedFile file, string saveTo, int maxWidth, int maxHeight, out int orginalWidth, out int orginalHeight, bool orginal)
		{
			string contentType = file.ContentType;
			Image img = System.Drawing.Image.FromStream(file.InputStream), simg;
			int w = img.Width, h = img.Height;
			double w1 = 0, h1 = 0;int w0 = 0, h0 = 0;
			
			orginalWidth = w;
			orginalHeight = h;
			
			if(maxWidth == 0) maxWidth = w;
			if(maxHeight == 0) maxHeight = h;
			//�������ű���
			w1 = w; h1 = h;
			if(w > maxWidth)
			{
				w1 = maxWidth;
				h1 = h * (w1 / w);
			}
			if(h1 > maxHeight)
			{
				w1 = w1 * (maxHeight / h1);
				h1 = maxHeight;
			}
			w0 = int.Parse(System.Math.Ceiling(w1).ToString()); h0 = int.Parse(System.Math.Ceiling(h1).ToString());

			if(orginal) img.Save( saveTo.Replace("S_", ""));

			if( w0 != w || h1 != h)	//���߻������ͬʱ��������ͼ
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
				img.Save( saveTo);
			}
						
			img.Dispose();

			file.InputStream.Close();
		}

		
		public static void SaveFile( HttpPostedFile file, string saveTo, out int orginalWidth, out int orginalHeight)
		{
			string contentType = file.ContentType;
			Image img = System.Drawing.Image.FromStream(file.InputStream);
			int w = img.Width, h = img.Height;
			
			orginalWidth = w;
			orginalHeight = h;

			img.Save( saveTo);
						
			img.Dispose();

			file.InputStream.Close();
		}

        /// <summary>
        /// ���沢��������ͼ
        /// </summary>
        /// <param name="file"></param>
        /// <param name="saveOrginalTo">����ԭ��С��ͼƬ��·��</param>
        /// <param name="saveTo">����ѹ�����ͼƬ��·��</param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <param name="orginalWidth"></param>
        /// <param name="orginalHeight"></param>
        public static void SaveFile(HttpPostedFile file , string saveOrginalTo , string saveTo , int maxWidth , int maxHeight , out int orginalWidth , out int orginalHeight)
        {

            string contentType = file.ContentType;

            Image img = System.Drawing.Image.FromStream( file.InputStream ) , simg;
            int w = img.Width , h = img.Height;
            double w1 = 0 , h1 = 0; int w0 = 0 , h0 = 0;

            orginalWidth = w;
            orginalHeight = h;

            if ( maxWidth == 0 ) maxWidth = w;
            if ( maxHeight == 0 ) maxHeight = h;
            //�������ű���
            w1 = w; h1 = h;
            if ( w > maxWidth )
            {
                w1 = maxWidth;
                h1 = h * ( w1 / w );
            }
            if ( h1 > maxHeight )
            {
                w1 = w1 * ( maxHeight / h1 );
                h1 = maxHeight;
            }
            w0 = int.Parse( System.Math.Ceiling( w1 ).ToString() ); h0 = int.Parse( System.Math.Ceiling( h1 ).ToString() );

            if ( saveOrginalTo != string.Empty ) img.Save( saveOrginalTo );

            if ( w0 != w || h1 != h )	//���߻������ͬʱ��������ͼ
            {
                //simg = img.GetThumbnailImage(w0, h0, null, System.IntPtr.Zero);
                //simg.Save( saveTo, GetImageFormat(contentType));
                //simg.Dispose();
                ImageFormat imageFormat = GetImageFormat( contentType );
                string filename = saveTo + ".temp";
                img.Save( filename , imageFormat );
                MakeThumbnail( filename , saveTo , w0 , h0 , "W" , imageFormat );
                if ( File.Exists( filename ) ) File.Delete( filename );
            }
            else
            {
                img.Save( saveTo );
            }

            img.Dispose();

            file.InputStream.Close();
        }

        /// <summary>
        /// ѹ������ͼƬ
        /// </summary>
        /// <param name="oldFile">����ͼƬ·��</param>
        /// <param name="saveTo">�����·��</param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <param name="orginalWidth"></param>
        /// <param name="orginalHeight"></param>
        public static void SaveFile(string oldFile  , string saveTo , int maxWidth , int maxHeight , out int orginalWidth , out int orginalHeight)
        {
            string contentType = "";

            contentType = oldFile.Substring( 16 , oldFile.Length - 16 );

            FileStream fs = new FileStream( oldFile , FileMode.Open );

            Image img = System.Drawing.Image.FromStream( fs ) ;
            int w = img.Width , h = img.Height;
            double w1 = 0 , h1 = 0; int w0 = 0 , h0 = 0;

            orginalWidth = w;
            orginalHeight = h;

            if ( maxWidth == 0 ) maxWidth = w;
            if ( maxHeight == 0 ) maxHeight = h;
            //�������ű���
            w1 = w; h1 = h;
            if ( w > maxWidth )
            {
                w1 = maxWidth;
                h1 = h * ( w1 / w );
            }
            if ( h1 > maxHeight )
            {
                w1 = w1 * ( maxHeight / h1 );
                h1 = maxHeight;
            }
            w0 = int.Parse( System.Math.Ceiling( w1 ).ToString() ); h0 = int.Parse( System.Math.Ceiling( h1 ).ToString() );

            //if ( saveOrginalTo != string.Empty ) img.Save( saveOrginalTo );

            if ( w0 != w || h1 != h )	//���߻������ͬʱ��������ͼ
            {
                //simg = img.GetThumbnailImage(w0, h0, null, System.IntPtr.Zero);
                //simg.Save( saveTo, GetImageFormat(contentType));
                //simg.Dispose();
                ImageFormat imageFormat = GetImageType( contentType );
                string filename = saveTo + ".temp";
                img.Save( filename , imageFormat );
                MakeThumbnail( filename , saveTo , w0 , h0 , "W" , imageFormat );
                if ( File.Exists( filename ) ) File.Delete( filename );
            }
            else
            {
                img.Save( saveTo );
            }

            img.Dispose();

            fs.Close();
        }

        //public static void SaveFile( Stream fs, string saveOrginalTo, string saveTo, int maxWidth, int maxHeight, out int orginalWidth, out int orginalHeight)
        //{
        //    string contentType = file.ContentType;
           
        //    Image img = System.Drawing.Image.FromStream( fs ) , simg;
        //    int w = img.Width, h = img.Height;
        //    double w1 = 0, h1 = 0;int w0 = 0, h0 = 0;
			
        //    orginalWidth = w;
        //    orginalHeight = h;
			
        //    if(maxWidth == 0) maxWidth = w;
        //    if(maxHeight == 0) maxHeight = h;
        //    //�������ű���
        //    w1 = w; h1 = h;
        //    if(w > maxWidth)
        //    {
        //        w1 = maxWidth;
        //        h1 = h * (w1 / w);
        //    }
        //    if(h1 > maxHeight)
        //    {
        //        w1 = w1 * (maxHeight / h1);
        //        h1 = maxHeight;
        //    }
        //    w0 = int.Parse(System.Math.Ceiling(w1).ToString()); h0 = int.Parse(System.Math.Ceiling(h1).ToString());

        //    if(saveOrginalTo!=string.Empty) img.Save( saveOrginalTo);

        //    if( w0 != w || h1 != h)	//���߻������ͬʱ��������ͼ
        //    {
        //        //simg = img.GetThumbnailImage(w0, h0, null, System.IntPtr.Zero);
        //        //simg.Save( saveTo, GetImageFormat(contentType));
        //        //simg.Dispose();
        //        ImageFormat imageFormat = GetImageFormat( contentType );
        //        string filename = saveTo + ".temp";
        //        img.Save(filename, imageFormat);
        //        MakeThumbnail(filename, saveTo, w0, h0, "W", imageFormat);
        //        if (File.Exists(filename)) File.Delete(filename);
        //    }
        //    else
        //    {
        //        img.Save( saveTo);
        //    }
						
        //    img.Dispose();

        //    fs.Close();
        //}
		
		/// <summary>
		/// �����ϴ����ļ���������ͼ
		/// </summary>
		/// <param name="file">�ϴ����ļ�</param>
		/// <param name="saveTo">������ļ�·��</param>
		/// <param name="maxWidth">����ͼ������</param>
		/// <param name="maxHeight">����ͼ���߶�</param>
		/// <param name="orginal">�Ƿ񱣴�ԭͼ</param>
		public static void SaveFile( HttpPostedFile file, string saveTo, int maxWidth, int maxHeight, bool orginal)
		{
			int w,h;
			SaveFile( file, saveTo, maxWidth, maxHeight, out w, out h, orginal);
		}

		/// <summary>
		/// �����ϴ����ļ���������ͼ
		/// </summary>
		/// <param name="file">�ϴ����ļ�</param>
		/// <param name="saveTo">������ļ�·��</param>
		/// <param name="maxWidth">����ͼ������</param>
		/// <param name="maxHeight">����ͼ���߶�</param>
		/// 
		public static void SaveFile( HttpPostedFile file, string saveTo, int maxWidth, int maxHeight)
		{
			int w,h;
			SaveFile( file, saveTo, maxWidth, maxHeight, out w, out h, true);
		}

		//��ȡͼƬ�ļ�����
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

        static System.Drawing.Imaging.ImageFormat GetImageType(string strContentType)
        {
            switch ( strContentType.ToString().ToLower() )
            {
                case "jpeg":
                    return System.Drawing.Imaging.ImageFormat.Jpeg;
                case "gif":
                    return System.Drawing.Imaging.ImageFormat.Gif;
                case "bmp":
                    return System.Drawing.Imaging.ImageFormat.Bmp;
                case "tiff":
                    return System.Drawing.Imaging.ImageFormat.Tiff;
                case "icon":
                    return System.Drawing.Imaging.ImageFormat.Icon;
                case "png":
                    return System.Drawing.Imaging.ImageFormat.Png;
                case "emf":
                    return System.Drawing.Imaging.ImageFormat.Emf;
                case "exif":
                    return System.Drawing.Imaging.ImageFormat.Exif;
                case "wmf":
                    return System.Drawing.Imaging.ImageFormat.Wmf;
                default:
                    return System.Drawing.Imaging.ImageFormat.MemoryBmp;
            }
        }

		/// <summary>
		/// �ж��Ƿ�ΪͼƬ
		/// </summary>
		/// <param name="strContentType">POST������ContentType�ļ�������Ϣ</param>
		/// <returns>��ͼƬΪtrue,����Ϊfalse</returns>
		public static  bool IsImage(string strContentType)
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
		/// �ж��Ƿ�ΪͼƬ
		/// </summary>
		/// <param name="strContentType">POST������ContentType�ļ�������Ϣ</param>
		/// <returns>ͼƬ����</returns>
		public static string GetImageFix(string strContentType)
		{
			switch (strContentType.ToString().ToLower())
			{
				case "image/pjpeg":		return ".jpg";
				case "image/gif":		return ".gif";
				case "image/bmp":		return ".bmp";
				case "image/tiff":		return ".tiff";
				case "image/x-icon":	return ".icon";
				case "image/x-png":		return ".png";
				case "image/x-emf":		return ".emf";
				case "image/x-exif":	return ".exif";
				case "image/x-wmf":		return ".wmf";
				default:				return ".gif";
			}
		}
		
		/// <summary>
		/// �ж��ַ����Ƿ���Ϊ�ַ�������
		/// Author:Turboc
		/// Date:2006-2-6
		/// </summary>
		public static bool IsString(string str)
		{
			Regex rex = new Regex(@"\W");
			return !rex.IsMatch(str);
		}

		/// <summary>
		/// �ж��ַ����Ƿ�������
		/// </summary>
		public static bool IsNumeric( string s )
		{
			if( s == null || s.Equals(String.Empty) )
			{
				return false;
			}

			foreach(char c in s)
			{
				if( !Char.IsNumber(c))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// �ж��ַ����Ƿ���Int32����(ϵͳԤ��9λ)
		/// </summary>
		public static bool IsInt32( string s )
		{

			if( s == null || s.Equals(String.Empty) || s.Length > 9)
			{
				return false;
			}

            if (s.Substring(0, 1) == "-")
                s = s.Substring(1);

			foreach(char c in s)
			{
				if( !Char.IsNumber(c))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// �ж��ַ����Ƿ���Int16����(ϵͳԤ��4λ)
		/// </summary>
		public static bool IsInt16( string s )
		{
			if( s == null || s.Equals(String.Empty) || s.Length > 4)
			{
				return false;
			}

			foreach(char c in s)
			{
				if( !Char.IsNumber(c))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// �ж��ַ����Ƿ�����������
		/// </summary>
		public static bool IsDate( string s )
		{
			if( s == null || s.Equals(String.Empty))
				return false;
			else
				return Regex.IsMatch(s, "^\\s*((\\d{4})|(\\d{2}))([-./])(\\d{1,2})\\4(\\d{1,2})\\s*$");
		}

		/// <summary>
		/// �ж��ַ����Ƿ�����Ч��Url��ַ
		/// </summary>
		public static bool IsUrl( string s )
		{
			return Regex.IsMatch( s, @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?" );
		}

		/// <summary>
		/// �ж��ַ����Ƿ�����Ч�ĵ����ʼ���ַ
		/// </summary>
		public static bool IsEmail( string s )
		{
			return Regex.IsMatch( s, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" );
		}

		/// <summary>
		/// �ж��ַ����Ƿ�����Ч������֤����
		/// </summary>
		public static bool IsIDCard( string s )
		{
			return Regex.IsMatch( s, @"\d{18}|\d{15}" );
		}

		/// <summary>
		/// ��Url��ȡһ��QueryString�ļ�ֵ
		/// </summary>
		public static string GetKeyFromUrl(string urlString, string key)
		{
			string key1 = '?' + key + '=';
			string key2 = '&' + key + '=';
			int idx= 0,begin;
			string valu = String.Empty;
			if( urlString.LastIndexOf(key1) > 0)
			{
				begin = urlString.LastIndexOf(key1) + key1.Length;
				idx = urlString.IndexOf('&', urlString.Length - 1);
				if(idx > begin)
				{
					valu = urlString.Substring(begin, idx - begin);
				}
				else
				{
					valu = urlString.Substring(begin);
				}
				return valu;
			}
			if( urlString.LastIndexOf(key2) > 0)
			{
				begin = urlString.LastIndexOf(key2) + key2.Length;
				idx = urlString.LastIndexOf('&', urlString.Length - 1);
				if(idx > begin)
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
		/// ��ȡ�ַ��������length���ַ�
		/// </summary>
		/// <param name="input">������ȡ���ַ���</param>
		/// <param name="length">����Ҫ��ȡ�ĳ���</param>
		/// <returns>����length���ַ�����tag��ǩ��</returns>
		public static string GetLeft( string input, int length)
		{
			return GetLeft( input, length, true);
		}

		public static string ReplaceRepeatBR( object input)
		{
			string str = input.ToString();
			while( (str.IndexOf("<BR><BR>")!=-1) || (str.IndexOf("<br><br>")!=-1))
			{
				str = str.Replace("<BR><BR>","<BR>");
				str = str.Replace("<br><br>","<br>");
			}
			return str;
		}

		/// <summary>
		/// ��ȡ�ַ��������length���ַ�
		/// </summary>
		/// <param name="input">������ȡ���ַ���</param>
		/// <param name="length">����Ҫ��ȡ�ĳ���</param>
		/// <param name="keepAlt">�Ƿ���alt˵��</param>
		/// <returns>����length���ַ�����tag��ǩ��</returns>
		public static string GetLeft( string input, int length, bool keepAlt)
		{
			if( input == null)
				return "";

			if( input.Length <= length)
				return input;
			else
				if( keepAlt)
					return "<span title='" + input.Replace("'","\"") + "'>" + input.Substring(0, length) + "...</span>";
				else
					return input.Substring(0, length) + "...";
		}

        /// <summary>
        /// ȥ��ָ���ַ�����html���
        /// </summary>
        /// <param name="strHtml">Ҫ�������ַ���</param>
        /// <returns>��������ַ���</returns>
        public static string stripHtml(string strHtml)
        {
            Regex regex = new Regex("<(.|\n)+?>");
            string input = regex.Replace(strHtml, "").Replace("<", "&lt;").Replace(">", "&gt;");
            Regex regex2 = new Regex(@"\s+");
            return regex2.Replace(input, " ").Trim();
        }
		
		/// <summary>
		/// ȥ��ָ���ַ�����ڵ��ַ�������ȥ��html���
		/// </summary>
		/// <param name="input">Ҫ�������ַ���</param>
		/// <param name="beginTag">���ǰ׺</param>
		/// <param name="endTag">��Ǻ�׺</param>
		/// <returns>��������ַ���</returns>
		public static string CleanTag(string input, char beginTag, char endTag)
		{
			return ClearTag( input, beginTag, endTag, true);
		}

		/// <summary>
		/// ȥ��ָ���ַ�����ڵ��ַ�������ȥ��html���
		/// </summary>
		/// <param name="input">Ҫ�������ַ���</param>
		/// <param name="beginTag">���ǰ׺</param>
		/// <param name="endTag">��Ǻ�׺</param>
		/// <param name="keepBR">�Ƿ���HTML�����BR���</param>
		/// <returns>��������ַ���</returns>
		public static string ClearTag(string input, char beginTag, char endTag, bool keepBR)
		{
            if (beginTag == '<' && endTag == '>')
            {
                return stripHtml(input);
            }

			if( beginTag == endTag)	//ǰ��׺������ͬ
			{
				return input;
			}

			if( keepBR)
			{
				input = input.Replace("<BR>", "\r\n");
			}

			int begin = input.IndexOf(beginTag);	
			int end;
			while( begin > -1)
			{
				end = input.IndexOf( endTag, begin);
				if( end < begin) 
				{
					if( keepBR)
					{
						input = input.Replace("\r\n", "<BR>");
					}
					return input;
				}
				else		//ȥ��ǰ��׺֮����ַ�
				{
					input = input.Substring(0, begin) + ((end < input.Length -1)? input.Substring( end + 1):"");
				}
				begin = input.IndexOf( beginTag);
			}

			if( keepBR)
			{
				input = input.Replace("\r\n", "<BR>");
			}

			return input;
		}

		/// <summary>
		/// ��ȡ���ı�����������ֵ�HTML��ʾ��ʽ
		/// </summary>
		/// <param name="text">���ı����������������</param>
		/// <returns>ת����ر�Ǻ��HTML��������</returns>
		public static string GetDisplayText(string text)
		{
			return text.Replace("\r\n", "<br>").Replace(" ", "&nbsp;");
		}

		/// <summary>
		/// ���PostBack�����Ĵ�","���ַ���
		/// </summary>
		/// <param name="filterstring">Ҫ�����ַ���</param>
		/// <returns>���ص��ַ�</returns>
		public static bool FilterDotString(string filterstring)
		{
			if(filterstring == "") return false;
			string[] splits = filterstring.Split(new char[]{','}); 
			foreach(string str in splits)
			{
				if(!WebAgent.IsNumeric(str)) return false;
			}
			return true;
		}
		/// <summary>
		/// ���ӽض��ַ����ĺ���
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string GetShortString( string str, int length )
		{
			if(System.Text.Encoding.Default.GetByteCount(str) <= length)	return str;
			return System.Text.Encoding.Default.GetString(System.Text.Encoding.Default.GetBytes(str),0,length-3)+"...";
		}

		/// <summary>
		/// ��ȡ������ʾ����
		/// </summary>
		/// <param name="str"></param>
		/// <param name="color"></param>
		/// <returns></returns>
		public static string GetObviousString( string str,string keyword, string color )
		{
			if (color.Trim() == "") color = "red";
			string[] arr = keyword.Split(' ');
			for (int i=0;i<arr.Length;i++)
			{
				if (arr[i].Trim() == "") continue;
				str = str.Replace(arr[i],string.Format("<font color={0}>{1}</font>",color,arr[i]));
			}
			return str;
		}

		/// <summary>
		/// ����һ�δ���,��ҳ���ϵı༭������
		/// </summary>
		/// <param name="p">Ҫ���Ӵ����Page����</param>
		/// <param name="editMode">��ǰ�Ƿ��Ǳ༭״̬</param>
		public static void CreateViewScript(Page p, bool editMode)
		{
			if( !p.IsStartupScriptRegistered("StudioViewScript"))
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder();
				sb.Append("<script language='javascript'>									\n")
					.Append("var editCtls = document.getElementsByName(\"editTag\");		\n")
					.Append("for(i=0;i<editCtls.length;i++)									\n")
					.Append("{editCtls[i].style.display='" + (editMode?"block":"none") + "';}						\n")
					.Append("</script>");
				
				p.RegisterStartupScript("StudioViewScript",sb.ToString());

				if( editMode)
				{
					CreateEditScript( p);
				}
			}
		}

		/// <summary>
		/// ����һ�δ���,��һЩPostBack������,����ͨForm��ʽ�����ش���Ϣ
		/// </summary>
		/// <param name="p">Ҫ���Ӵ����Page����</param>
		public static void CreateEditScript(Page p)
		{
			if( !p.IsStartupScriptRegistered("StudioEditScript"))
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
				
				p.RegisterStartupScript("StudioEditScript",sb.ToString());
			}
		}
			
		/// <summary>
		/// ����������Ϣ
		/// </summary>
		/// <param name="msg">��������Ϣ</param>
		public static void Alert(string msg)
		{
			HttpContext.Current.Response.Write("<script language='javascript'>alert('" + msg.Replace("'", "") + "');</script>");
		}
			
		/// <summary>
		/// ����������Ϣ������ԭҳ��
		/// </summary>
		/// <param name="msg">��������Ϣ</param>
		public static void AlertAndBack(string msg)
		{
			HttpContext.Current.Response.Clear();
			HttpContext.Current.Response.Write("<script language='javascript'>alert('" + msg.Replace("'", "") + "');history.go(-1);</script>");
			HttpContext.Current.Response.End();
		}

		public static void ConfirmGo(string msg, string trueUrl, string falseUrl)
		{
			HttpContext.Current.Response.Clear();
			HttpContext.Current.Response.Write( string.Format( "<script language='javascript'>if( confirm('{0}')) document.location.href='{1}'; else document.location.href='{2}';</script>",msg.Replace("'",""), trueUrl, falseUrl) );
			HttpContext.Current.Response.End();
		}

		/// <summary>
		/// ����һ���ɹ���Ϣ,��ȷ������ת��ָ��Url
		/// </summary>
		/// <param name="msg">��������Ϣ</param>
		/// <param name="goUrl">Ҫ��ת��Url</param>
		public static void SuccAndGo(string msg, string goUrl)
		{
			HttpContext.Current.Response.Clear();
			HttpContext.Current.Response.Write(String.Format("<script language='javascript'>alert('{0}');document.location.href='{1}';</script>", msg.Replace("'",""), goUrl));
			HttpContext.Current.Response.End();
		}

		/// <summary>
		/// ����һ���ɹ���Ϣ,��ȷ������ת��ָ��Url
		/// </summary>
		/// <param name="msg">��������Ϣ</param>
		/// <param name="goUrl">Ҫ��ת��Url</param>
		public static void SuccAndGo(string msg)
		{
			HttpContext.Current.Response.Clear();
			HttpContext.Current.Response.Write(String.Format("<script language='javascript'>alert('{0}');history.back();</script>", msg.Replace("'","")));
			HttpContext.Current.Response.End();
		}
		
		/// <summary>
		/// ����һ��ʧ����Ϣ,��ȷ������ת��ָ��Url
		/// </summary>
		/// <param name="msg">��������Ϣ</param>
		/// <param name="goUrl">Ҫ��ת��Url</param>
		public static void FailAndGo(string msg, string goUrl)
		{
			HttpContext.Current.Response.Clear();
			HttpContext.Current.Response.Write(String.Format("<script language='javascript'>alert('{0}');document.location.href='{1}';</script>", msg.Replace("'",""), goUrl));
			HttpContext.Current.Response.End();
		}

		/// <summary>
		/// ����һ��ʧ����Ϣ,��ȷ������ת��ԭҳ��
		/// Author:turboc
		/// CreateDate:2006-02-05
		/// </summary>
		/// <param name="msg">��������Ϣ</param>
		public static void FailAndGo(string msg)
		{
			HttpContext.Current.Response.Clear();
			HttpContext.Current.Response.Write(String.Format("<script language='javascript'>alert('{0}');history.back();</script>", msg.Replace("'","")));
			HttpContext.Current.Response.End();
		}

		/// <summary>
		/// �ڵ�ǰ���������һ�����ص�Iframe
		/// </summary>
		/// <param name="url">Iframe��Դ��ַ</param>
		public static void CreateHiddenIFrame( string url)
		{
			HttpContext.Current.Response.Write("<iframe style='width:100px;height:100px;' frameborder=0 src='" + url + "'></iframe>");
		}

		/// <summary>
		/// ��ҳ����ͣ��һ��ʱ��(ͨ���Ǽ�����),��ʾһ���ȴ���Ϣ,Ȼ����ת��ָ��ҳ��
		/// </summary>
		/// <param name="sec">ͣ��ʱ��(��λ:��)</param>
		/// <param name="alterMsg">�ȴ���Ϣ����</param>
		/// <param name="goUrl">��ת�ĵ�ַ</param>
		/// <param name="clearResp">�Ƿ������Ӧ����</param>
		public static void WaitAndGo( int sec, string alterMsg, string goUrl, bool clearResp)
		{
			if( clearResp)
			{
				HttpContext.Current.Response.Clear();
			}

			HttpContext.Current.Response.Write(alterMsg);
			HttpContext.Current.Response.Write(String.Format("<script language='javascript'>setTimeout(\"document.location.href='{1}';\", {2}*1000);</script>", alterMsg.Replace("'",""), goUrl, sec));

			HttpContext.Current.Response.End();
		}

		public static string NewKey()
		{
			return NewKey( KeyCreationType.Time);
		}

		public static string NewKey( KeyCreationType t)
		{
			switch (t)
			{
				case KeyCreationType.Time:
				{
					return DateTime.Now.ToString("yyMMddHHmmssfff");
				}
				default:return NewKey( KeyCreationType.Time);
			}
		}

		/// <summary>
		/// �����ȡһ��ָ���������б�
		/// </summary>
		/// <param name="list">�����б�</param>
		/// <param name="getCount">Ҫ��ȡ��Ԫ�ظ���</param>
		/// <returns></returns>
		public static IList GetRandomList( IList list, int getCount)
		{
			ArrayList resultList = new ArrayList();
			if( list.Count <= getCount)
			{
				return list;
			}

			Random rd = new Random();
			while( resultList.Count < getCount)
			{
				resultList.Add( list[rd.Next(list.Count)]);
			}

			return resultList;
		}

		/// <summary>
		/// ����Web�¼�
		/// </summary>
		/// <param name="e">�¼�����</param>
		public static void RaiseEvent( WebEvent e)
		{
			string msgPath = System.IO.Path.GetTempPath() + "webevent.log";
			IO.LogAgent.WriteLogFile( msgPath, e.ToString());
		}

		/// <summary>
		/// ת��UBB����
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

			//str = Regex.Replace(str, @"\[em=(?<x>([0-9]*))\]", "<img src='http://public.anyp.net/images/ubb/em/$1.gif'>", RegexOptions.IgnoreCase);

			str = Regex.Replace(str, @"\[pic](?<x>[^\]]*)\[/pic]", "<img src='$1'>", RegexOptions.IgnoreCase);

			str = Regex.Replace(str, @"\[url](?<x>[^\]]*)\[/url]", "<a href='$1' target='_blank'>$1</a>", RegexOptions.IgnoreCase);
			str = Regex.Replace(str, @"\[color=(?<x>[^\]]*)](?<y>[^\]]*)\[/color]", "<font color='$1'>$2</font>", RegexOptions.IgnoreCase);
			str = Regex.Replace(str, @"\[url=(?<x>[^\]]*)](?<y>[^\]]*)\[/url]", "<a href='$1' target='_blank'>$2</a>", RegexOptions.IgnoreCase);

			//str = Regex.Replace(str, @"\[mp=(?<x>([0-9]*)),(?<y>([0-9]*))](?<z>[^\]]*)\[/mp]", "<OBJECT ID='Windows Media Player' WIDTH='$1' HEIGHT='$2' CLASSID='CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6'><param name=url value='$1'></OBJECT>", RegexOptions.IgnoreCase);

			str = Regex.Replace(str, @"\[flash=(?<x>([0-9]*)),(?<y>([0-9]*))](?<z>[^\]]*)\[/flash]", "<embed src='$3' width='$1' height='$2' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' name='Adodb MacroMedia Flash Player'></embed>", RegexOptions.IgnoreCase);
			//str = Regex.Replace(str, @"\[rm=(?<x>([0-9]*)),(?<y>([0-9]*))](?<z>[^\]]*)\[/rm]", "<OBJECT classid=clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA class=OBJECT id=RAOCX width=$1 height=$2><PARAM NAME=SRC VALUE='$3'><PARAM NAME=CONSOLE VALUE=Clip1><PARAM NAME=CONTROLS VALUE=imagewindow><PARAM NAME=AUTOSTART VALUE=true></OBJECT><br><OBJECT classid=CLSID:CFCDAA03-8BE4-11CF-B84B-0020AFBBCCFA height=32 id=video2 width=$1><PARAM NAME=SRC VALUE='$3'><PARAM NAME=AUTOSTART VALUE=-1><PARAM NAME=CONTROLS VALUE=controlpanel><PARAM NAME=CONSOLE VALUE=Clip1></OBJECT>", RegexOptions.IgnoreCase);
			return str;
		}

		/// <summary>
		/// ����IP,���һ����*����
		/// </summary>
		/// <param name="ip">����IP</param>
		/// <returns></returns>
		public static string FixIP( string ip)
		{
			if( ip.IndexOf('.') > 0)
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