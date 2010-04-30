using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace Studio.Web
{
    public class ImageWaterMark
    {
        internal ConvertEffect _converimageeffect;
        internal int _imagezipheight;
        internal int _imagezipwidth;
        internal int _miniatureimageheight;
        internal string _miniatureimagepath;
        internal int _miniatureimagewidth;
        internal string _savewatermarkimagepath;
        internal int _shadowdepthX;
        internal int _shadowdepthY;
        internal string _sourceimagepath;
        internal ImageAlign _watermarkalign;
        internal int _watermarkangle;
        internal string _watermarkimagegroundcolor;
        internal string _watermarkimagepath;
        internal int _watermarkplaceX;
        internal int _watermarkplaceY;
        internal string _watermarktext;
        internal string _watermarktextcolor;
        internal TextCSS _watermarktextcss;
        internal string _watermarktextfont;
        internal ShadowAlign _watermarktextshadowalign;
        internal string _watermarktextshadowcolor;
        internal int _watermarktextsize;
        internal int _watermarktransparence;
        internal readonly string AllowExt = ".jpg|.gif|.png|.tif|.bmp";
        private int AngleX;
        private int AngleY;
        private static Hashtable htmimes = new Hashtable();
        private string txtcolor;
        private string txtcss;
        private string txtfont;
        private string txtshadow;
        private int txtsize;
        private int wm_x;
        private int wm_y;
        private int wmangle;
        private int wmtransparence;
        private int zipheight;
        private int zipwidth;

        static ImageWaterMark()
        {
            htmimes[".gif"] = "image/gif";
            htmimes[".jpg"] = "image/jpeg";
            htmimes[".png"] = "image/png";
            htmimes[".tif"] = "image/tiff";
            htmimes[".bmp"] = "image/bmp";
        }

        /// <summary>
        /// 检查颜色是否正确
        /// </summary>
        /// <param name="getcolor"></param>
        /// <returns></returns>
        public string CheckColor(string getcolor)
        {
            Regex regex = new Regex("^#[a-f0-9]{6}$", RegexOptions.IgnoreCase);
            if (regex.Match(getcolor).Success)
            {
                return "True";
            }
            return "False";
        }

        /// <summary>
        /// 检查图片后缀是否合法
        /// </summary>
        /// <param name="sExt"></param>
        /// <returns></returns>
        internal bool CheckValidExt(string sExt)
        {
            string[] strArray = this.AllowExt.Split(new char[] { '|' });
            foreach (string str in strArray)
            {
                if (str.ToLower() == sExt)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取图像编码解码器
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        private static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo info in imageEncoders)
            {
                if (info.MimeType == mimeType)
                {
                    return info;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取文字形状
        /// </summary>
        internal void GetParameter()
        {
            switch (this.WaterMarkTextCSS)
            {
                case TextCSS.Bold:
                    this.txtcss = "Bold";
                    break;

                case TextCSS.Italic:
                    this.txtcss = "Italic";
                    break;

                case TextCSS.Underline:
                    this.txtcss = "Underline";
                    break;

                case TextCSS.Strikeout:
                    this.txtcss = "Strikeout";
                    break;

                default:
                    this.txtcss = "Regular";
                    break;
            }
        }

        public void GetToMiniatureImage()
        {
            string sExt = this.SaveWaterMarkImagePath.Substring(this.SaveWaterMarkImagePath.LastIndexOf(".")).ToLower();
            Image image = Image.FromFile(this.SaveWaterMarkImagePath);
            int num = (Math.Abs(this.MiniatureImageWidth) / 4) * 3;
            int width = image.Width;
            int height = image.Height;
            this.ImageZip(width, height, this.MiniatureImageWidth, this.MiniatureImageHeight);
            Bitmap bitmap = new Bitmap(this.zipwidth, this.zipheight, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.Clear(Color.Transparent);
            graphics.DrawImage(image, new Rectangle(0, 0, this.zipwidth, this.zipheight));
            image.Dispose();
            try
            {
                string savePath = (this.MiniatureImagePath == null) ? this.SaveWaterMarkImagePath : this.MiniatureImagePath;
                this.SaveImage(bitmap, savePath, GetCodecInfo((string)htmimes[sExt]));
                if (this.ConverImageEffect == ConvertEffect.Monochrome)
                {
                    this.GetToMonochrome(bitmap, savePath);
                }
                else if (this.ConverImageEffect == ConvertEffect.Negative)
                {
                    this.GetToNegative(savePath);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                bitmap.Dispose();
                graphics.Dispose();
            }
        }

        /// <summary>
        /// 保存黑白效果图片
        /// </summary>
        /// <param name="source"></param>
        /// <param name="fpath"></param>
        /// <returns></returns>
        public Bitmap GetToMonochrome(Bitmap source, string fpath)
        {
            Bitmap bitmap = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    Color pixel = source.GetPixel(j, i);
                    int red = (int)(((pixel.R * 0.3) + (pixel.G * 0.59)) + (pixel.B * 0.11));
                    bitmap.SetPixel(j, i, Color.FromArgb(red, red, red));
                }
            }
            bitmap.Save(fpath.Substring(0, fpath.Length - 6) + "_BW.jpg", ImageFormat.Jpeg);
            bitmap.Dispose();
            return bitmap;
        }

        /// <summary>
        /// 保存负片效果图片
        /// </summary>
        /// <param name="fpath"></param>
        public void GetToNegative(string fpath)
        {
            Bitmap image = new Bitmap(fpath);
            Graphics graphics = Graphics.FromImage(image);
            graphics.ScaleTransform(0.7f, 0.7f);
            int width = image.Width;
            int height = image.Height;
            graphics.DrawImage(image, new Rectangle(0, 0, width, height));
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Color pixel = image.GetPixel(i, j);
                    int red = 0xff - pixel.R;
                    int green = 0xff - pixel.G;
                    int blue = 0xff - pixel.B;
                    Color color = Color.FromArgb(0xff, red, green, blue);
                    image.SetPixel(i, j, color);
                }
                graphics.DrawImage(image, new Rectangle(width, 0, width, height));
            }
            image.Save(fpath.Substring(0, fpath.Length - 6) + "_N.jpg", ImageFormat.Jpeg);
            image.Dispose();
            graphics.Dispose();
        }

        /// <summary>
        /// 生成水印图片
        /// </summary>
        public void GetWaterMarkImage()
        {
            this.ValidateImage(this.SourceImagePath);
            string savePath = (this.SaveWaterMarkImagePath == null) ? this.SourceImagePath : this.SaveWaterMarkImagePath;
            string sExt = this.SourceImagePath.Substring(this.SourceImagePath.LastIndexOf(".")).ToLower();
            if (this.SourceImagePath.ToString() == string.Empty)
            {
                throw new NullReferenceException("图片路径为空或无效！");
            }
            if (!this.CheckValidExt(sExt))
            {
                throw new ArgumentException("原图片文件格式不正确,支持的格式有[ " + this.AllowExt + " ]");
            }
            FileStream stream = File.OpenRead(this.SourceImagePath);
            Image original = Image.FromStream(stream, true);
            stream.Close();

            int width = original.Width;
            int height = original.Height;
            float horizontalResolution = original.HorizontalResolution;
            float verticalResolution = original.VerticalResolution;
            this.ImageZip(width, height, this.ImageZipWidth, this.ImageZipHeight);
            Bitmap image = new Bitmap(original, this.zipwidth, this.zipheight);
            original.Dispose();
            image.SetResolution(1000f, 1000f);
            Graphics graphics = Graphics.FromImage(image);
            //图片水印
            if ((this.WaterMarkText == null) || (this.WaterMarkText.Trim().Length <= 0))
            {
                Image image2 = new Bitmap(this.WaterMarkImagePath);
                int num5 = image2.Width;
                int num6 = image2.Height;
                Bitmap bitmap2 = new Bitmap(image);
                image.Dispose();
                bitmap2.SetResolution(horizontalResolution, verticalResolution);
                Graphics graphics2 = Graphics.FromImage(bitmap2);
                ImageAttributes imageAttr = new ImageAttributes();
                //去除背景颜色
                if (this.WaterMarkImageGroundColor != null)
                {
                    if (this.CheckColor(this.WaterMarkImageGroundColor) != "True")
                    {
                        throw new ArgumentException("过滤水印图片颜色不是有效值！");
                    }
                    string str9 = this.WaterMarkImageGroundColor.Substring(1, 2);
                    string str10 = this.WaterMarkImageGroundColor.Substring(3, 2);
                    string str11 = this.WaterMarkImageGroundColor.Substring(5, 2);
                    ColorMap map = new ColorMap();
                    map.OldColor = Color.FromArgb(0xff, Convert.ToInt32(str9, 0x10), Convert.ToInt32(str10, 0x10), Convert.ToInt32(str11, 0x10));
                    imageAttr.SetRemapTable(new ColorMap[] { map }, ColorAdjustType.Bitmap);//去除背景色
                }
                //设置透明度
                if (this.WaterMarkTransparence == 0)
                {
                    this.wmtransparence = 100;
                }
                else
                {
                    this.wmtransparence = this.WaterMarkTransparence;
                }
                float[][] newColorMatrix = new float[5][];
                float[] numArray2 = new float[5];
                numArray2[0] = 1f;
                newColorMatrix[0] = numArray2;
                numArray2 = new float[5];
                numArray2[1] = 1f;
                newColorMatrix[1] = numArray2;
                numArray2 = new float[5];
                numArray2[2] = 1f;
                newColorMatrix[2] = numArray2;
                numArray2 = new float[5];
                numArray2[3] = ((float)this.wmtransparence) / 100f;
                newColorMatrix[3] = numArray2;
                numArray2 = new float[5];
                numArray2[4] = 1f;
                newColorMatrix[4] = numArray2;
                imageAttr.SetColorMatrix(new ColorMatrix(newColorMatrix), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                this.GetWaterMarkXY(this.zipwidth, this.zipheight, num5, num6);
                //旋转图片角度
                Matrix matrix2 = new Matrix();
                if (this.WaterMarkAngle == 0)
                {
                    this.wmangle = 0;
                }
                else
                {
                    this.wmangle = this.WaterMarkAngle;
                }
                matrix2.RotateAt((float)this.wmangle, new PointF((float)this.AngleX, (float)this.AngleY));
                graphics2.Transform = matrix2;
                graphics2.DrawImage(image2, new Rectangle(this.wm_x, this.wm_y, num5, num6), 0, 0, num5, num6, GraphicsUnit.Pixel, imageAttr);
                imageAttr.ClearColorMatrix();
                imageAttr.ClearRemapTable();
                image2.Dispose();
                graphics2.Dispose();
                try
                {
                    //保存图片
                    this.SaveImage(bitmap2, savePath, GetCodecInfo((string)htmimes[sExt]));
                    if (this.ConverImageEffect == ConvertEffect.Monochrome)
                    {
                        this.GetToMonochrome(bitmap2, savePath);
                    }
                    else if (this.ConverImageEffect == ConvertEffect.Negative)
                    {
                        this.GetToNegative(savePath);
                    }
                }
                catch (Exception exception2)
                {
                    throw exception2;
                }
                finally
                {
                    bitmap2.Dispose();
                }
            }
            else
            {
                //文字水印
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.DrawImage(image, new Rectangle(0, 0, this.zipwidth, this.zipheight), 0, 0, this.zipwidth, this.zipheight, GraphicsUnit.Pixel);
                //设置文字大小
                if (this.WaterMarkTextSize != 0)
                {
                    this.txtsize = Math.Abs(this.WaterMarkTextSize);
                }
                else
                {
                    this.txtsize = 2;
                }
                //设置文字形状
                Font font = null;
                SizeF ef = new SizeF(0f, 0f);
                this.GetParameter();
                //设置文字字体
                if (this.WaterMarkTextFont != null)
                {
                    this.txtfont = this.WaterMarkTextFont;
                }
                else
                {
                    this.txtfont = "Arial";
                }

                string txtcss = this.txtcss;
                if (txtcss == "Bold")
                {
                    font = new Font(this.txtfont, (float)this.txtsize, FontStyle.Bold);
                }
                else if (txtcss == "Italic")
                {
                    font = new Font(this.txtfont, (float)this.txtsize, FontStyle.Italic);
                }
                else if (txtcss == "Underline")
                {
                    font = new Font(this.txtfont, (float)this.txtsize, FontStyle.Strikeout);
                }
                else if (txtcss == "Strikeout")
                {
                    font = new Font(this.txtfont, (float)this.txtsize, FontStyle.Strikeout);
                }
                else
                {
                    font = new Font(this.txtfont, (float)this.txtsize, FontStyle.Regular);
                }
                ef = graphics.MeasureString(this.WaterMarkText, font);
                this.GetWaterMarkXY(this.zipwidth, this.zipheight, (ushort)ef.Width, (ushort)ef.Height);
                Matrix matrix = new Matrix();
                //设置旋转角度
                if (this.WaterMarkAngle == 0)
                {
                    this.wmangle = 0;
                }
                else
                {
                    this.wmangle = Math.Abs(this.WaterMarkAngle);
                }
                matrix.RotateAt((float)this.wmangle, new PointF((float)this.AngleX, (float)this.AngleY));
                graphics.Transform = matrix;
                //设置文字阴影
                StringFormat format = new StringFormat();
                if (this.WaterMarkTextShadowColor == null)
                {
                    this.txtshadow = "#666666";
                }
                else
                {
                    if (this.CheckColor(this.WaterMarkTextShadowColor) != "True")
                    {
                        throw new ArgumentException("绘制的水印文字阴影颜色不是有效值！");
                    }
                    this.txtshadow = this.WaterMarkTextShadowColor;
                }
                //设置文字颜色
                if (this.WaterMarkTextColor == null)
                {
                    this.txtcolor = "#CCCCCC";
                }
                else
                {
                    if (this.CheckColor(this.WaterMarkTextColor) != "True")
                    {
                        throw new ArgumentException("绘制的水印文字颜色不是有效值！");
                    }
                    this.txtcolor = this.WaterMarkTextColor;
                }
                //设置文字透明度
                if (this.WaterMarkTransparence > 100)
                {
                    throw new ArgumentException("透明度值超出应有的范围");
                }
                if (this.WaterMarkTransparence != 0)
                {
                    this.wmtransparence = Math.Abs(this.WaterMarkTransparence);
                }
                else
                {
                    this.wmtransparence = 100;
                }
                string str3 = this.txtshadow.Substring(1, 2);
                string str4 = this.txtshadow.Substring(3, 2);
                string str5 = this.txtshadow.Substring(5, 2);
                graphics.DrawString(this.WaterMarkText, font, new SolidBrush(Color.FromArgb(this.wmtransparence * 2, Convert.ToInt32(str3, 0x10), Convert.ToInt32(str4, 0x10), Convert.ToInt32(str5, 0x10))), new PointF((float)(this.wm_x + this.WaterMarkTextShadowDepthX), (float)(this.wm_y + this.WaterMarkTextShadowDepthY)), format);
                string str6 = this.txtcolor.Substring(1, 2);
                string str7 = this.txtcolor.Substring(3, 2);
                string str8 = this.txtcolor.Substring(5, 2);
                graphics.DrawString(this.WaterMarkText, font, new SolidBrush(Color.FromArgb(this.wmtransparence * 2, Convert.ToInt32(str6, 0x10), Convert.ToInt32(str7, 0x10), Convert.ToInt32(str8, 0x10))), new PointF((float)this.wm_x, (float)this.wm_y), format);
                format.Dispose();
                //保存图片
                this.SaveImage(image, savePath, GetCodecInfo((string)htmimes[sExt]));
                if (this.ConverImageEffect == ConvertEffect.Monochrome)
                {
                    this.GetToMonochrome(image, savePath);
                }
                else if (this.ConverImageEffect == ConvertEffect.Negative)
                {
                    this.GetToNegative(savePath);
                }
            }
        }

        /// <summary>
        /// 获取自定义水印位置
        /// </summary>
        /// <param name="s_imagewidth"></param>
        /// <param name="s_imageheight"></param>
        /// <param name="wm_imagewidth"></param>
        /// <param name="wm_imageheight"></param>
        internal void GetWaterMarkXY(int s_imagewidth, int s_imageheight, int wm_imagewidth, int wm_imageheight)
        {
            if ((((this.WaterMarkPlaceX != 0) && (this.WaterMarkPlaceY != 0)) || ((this.WaterMarkPlaceX != 0) && (this.WaterMarkPlaceY == 0))) || ((this.WaterMarkPlaceX == 0) && (this.WaterMarkPlaceY != 0)))
            {
                this.wm_x = Math.Abs(this.WaterMarkPlaceX);
                this.wm_y = Math.Abs(this.WaterMarkPlaceY);
                this.AngleX = (wm_imagewidth / 2) + this.wm_x;
                this.AngleY = (wm_imageheight / 2) + this.wm_y;
            }
            else if (this.WaterMarkAlign == ImageAlign.LeftTop)
            {
                this.wm_x = 10;
                this.wm_y = 10;
                this.AngleX = (wm_imagewidth / 2) + 10;
                this.AngleY = (wm_imageheight / 2) + 10;
            }
            else if (this.WaterMarkAlign == ImageAlign.LeftBottom)
            {
                this.wm_x = 10;
                this.wm_y = (s_imageheight - wm_imageheight) - 10;
                this.AngleX = (wm_imagewidth / 2) + 10;
                this.AngleY = (s_imageheight - wm_imagewidth) + 10;
            }
            else if (this.WaterMarkAlign == ImageAlign.RightTop)
            {
                this.wm_x = (s_imagewidth - wm_imagewidth) - 10;
                this.wm_y = 10;
                this.AngleX = (s_imagewidth - wm_imagewidth) + 10;
                this.AngleY = (wm_imageheight / 2) + 10;
            }
            else if (this.WaterMarkAlign == ImageAlign.RightBottom)
            {
                this.wm_x = (s_imagewidth - wm_imagewidth) - 10;
                this.wm_y = (s_imageheight - wm_imageheight) - 10;
                this.AngleX = (s_imagewidth - wm_imagewidth) + 10;
                this.AngleY = (s_imageheight - wm_imageheight) + 10;
            }
            else if (this.WaterMarkAlign == ImageAlign.Center)
            {
                this.wm_x = (s_imagewidth - wm_imagewidth) / 2;
                this.wm_y = (s_imageheight - wm_imageheight) / 2;
                this.AngleX = s_imagewidth / 2;
                this.AngleY = s_imageheight / 2;
            }
            else if (this.WaterMarkAlign == ImageAlign.CenterBottom)
            {
                this.wm_x = (s_imagewidth - wm_imagewidth) / 2;
                this.wm_y = (s_imageheight - wm_imageheight) - 10;
                this.AngleX = s_imagewidth / 2;
                this.AngleY = (s_imageheight - (wm_imageheight / 2)) + 10;
            }
            else if (this.WaterMarkAlign == ImageAlign.CenterTop)
            {
                this.wm_x = (s_imagewidth - wm_imagewidth) / 2;
                this.wm_y = 10;
                this.AngleX = s_imagewidth / 2;
                this.AngleY = (wm_imageheight / 2) + 10;
            }
            else if (this.WaterMarkAlign == ImageAlign.CenterLeft)
            {
                this.wm_x = 10;
                this.wm_y = (s_imageheight - wm_imageheight) / 2;
                this.AngleX = (wm_imagewidth / 2) + 10;
                this.AngleY = s_imageheight / 2;
            }
            else if (this.WaterMarkAlign == ImageAlign.CenterRight)
            {
                this.wm_x = (s_imagewidth - wm_imagewidth) - 10;
                this.wm_y = (s_imageheight - wm_imageheight) / 2;
                this.AngleX = (s_imagewidth - (wm_imagewidth / 2)) + 10;
                this.AngleY = s_imageheight / 2;
            }
        }

        /// <summary>
        /// 压缩图片
        /// </summary>
        /// <param name="Originalwidth"></param>
        /// <param name="Originalheight"></param>
        /// <param name="Newzipwidth"></param>
        /// <param name="Newzipheight"></param>
        internal void ImageZip(int Originalwidth, int Originalheight, int Newzipwidth, int Newzipheight)
        {
            if ((Newzipwidth > 0) && (Newzipheight > 0))
            {
                this.zipwidth = Newzipwidth;
                this.zipheight = Newzipheight;
            }
            else if ((Newzipwidth > 0) && (Newzipheight == 0))
            {
                double num = (Newzipwidth * Originalheight) / Originalwidth;
                this.zipwidth = Newzipwidth;
                this.zipheight = Convert.ToInt32(num);
            }
            else if ((Newzipwidth == 0) && (Newzipheight > 0))
            {
                double num2 = (Originalwidth * Newzipheight) / Originalheight;
                this.zipwidth = Convert.ToInt32(num2);
                this.zipheight = Newzipheight;
            }
            else
            {
                this.zipwidth = Originalwidth;
                this.zipheight = Originalheight;
            }
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="image"></param>
        /// <param name="savePath"></param>
        /// <param name="coderinfo"></param>
        internal void SaveImage(Image image, string savePath, ImageCodecInfo coderinfo)
        {
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 90L);
            image.Save(savePath, coderinfo, encoderParams);
            encoderParams.Dispose();
        }

        /// <summary>
        /// 检查图片格式
        /// </summary>
        /// <param name="filepath"></param>
        public void ValidateImage(string filepath)
        {
            try
            {
                Image image = Image.FromFile(filepath);
            }
            catch
            {
                throw new ArgumentException("图片格式错误，只支持{" + this.AllowExt + "}等格式！");
            }
        }

        /// <summary>
        /// 图片效果
        /// </summary>
        public ConvertEffect ConverImageEffect
        {
            get
            {
                return this._converimageeffect;
            }
            set
            {
                this._converimageeffect = value;
            }
        }

        /// <summary>
        /// 图片生成高度
        /// </summary>
        public int ImageZipHeight
        {
            get
            {
                return this._imagezipheight;
            }
            set
            {
                this._imagezipheight = value;
            }
        }

        /// <summary>
        /// 图片生成宽度
        /// </summary>
        public int ImageZipWidth
        {
            get
            {
                return this._imagezipwidth;
            }
            set
            {
                this._imagezipwidth = value;
            }
        }

        /// <summary>
        /// 缩略图高度
        /// </summary>
        public int MiniatureImageHeight
        {
            get
            {
                return this._miniatureimageheight;
            }
            set
            {
                this._miniatureimageheight = value;
            }
        }

        /// <summary>
        /// 缩略图保存路径
        /// </summary>
        public string MiniatureImagePath
        {
            get
            {
                return this._miniatureimagepath;
            }
            set
            {
                this._miniatureimagepath = value;
            }
        }

        /// <summary>
        /// 缩略图宽度
        /// </summary>
        public int MiniatureImageWidth
        {
            get
            {
                return this._miniatureimagewidth;
            }
            set
            {
                this._miniatureimagewidth = value;
            }
        }

        /// <summary>
        /// 保存图片路径
        /// </summary>
        public string SaveWaterMarkImagePath
        {
            get
            {
                return this._savewatermarkimagepath;
            }
            set
            {
                this._savewatermarkimagepath = value;
            }
        }

        /// <summary>
        /// 源图片路径
        /// </summary>
        public string SourceImagePath
        {
            get
            {
                return this._sourceimagepath;
            }
            set
            {
                this._sourceimagepath = value;
            }
        }

        /// <summary>
        /// 水印位置
        /// </summary>
        public ImageAlign WaterMarkAlign
        {
            get
            {
                return this._watermarkalign;
            }
            set
            {
                this._watermarkalign = value;
            }
        }

        /// <summary>
        /// 旋转角度
        /// </summary>
        public int WaterMarkAngle
        {
            get
            {
                return this._watermarkangle;
            }
            set
            {
                this._watermarkangle = value;
            }
        }

        /// <summary>
        /// 水印图片背景颜色
        /// </summary>
        public string WaterMarkImageGroundColor
        {
            get
            {
                return this._watermarkimagegroundcolor;
            }
            set
            {
                this._watermarkimagegroundcolor = value;
            }
        }

        /// <summary>
        /// 水印图片路径
        /// </summary>
        public string WaterMarkImagePath
        {
            get
            {
                return this._watermarkimagepath;
            }
            set
            {
                this._watermarkimagepath = value;
            }
        }

        /// <summary>
        /// 自定义水印位置X轴
        /// </summary>
        public int WaterMarkPlaceX
        {
            get
            {
                return this._watermarkplaceX;
            }
            set
            {
                this._watermarkplaceX = value;
            }
        }

        /// <summary>
        /// 自定义水印位置Y轴
        /// </summary>
        public int WaterMarkPlaceY
        {
            get
            {
                return this._watermarkplaceY;
            }
            set
            {
                this._watermarkplaceY = value;
            }
        }

        /// <summary>
        /// 水印文字
        /// </summary>
        public string WaterMarkText
        {
            get
            {
                return this._watermarktext;
            }
            set
            {
                this._watermarktext = value;
            }
        }

        /// <summary>
        /// 文字颜色
        /// </summary>
        public string WaterMarkTextColor
        {
            get
            {
                return this._watermarktextcolor;
            }
            set
            {
                this._watermarktextcolor = value;
            }
        }

        /// <summary>
        /// 文字形状(加粗、下划线、倾斜、中划线)
        /// </summary>
        public TextCSS WaterMarkTextCSS
        {
            get
            {
                return this._watermarktextcss;
            }
            set
            {
                this._watermarktextcss = value;
            }
        }

        /// <summary>
        /// 水印字体
        /// </summary>
        public string WaterMarkTextFont
        {
            get
            {
                return this._watermarktextfont;
            }
            set
            {
                this._watermarktextfont = value;
            }
        }

        /// <summary>
        /// 阴影位置
        /// </summary>
        public ShadowAlign WaterMarkTextShadowAlign
        {
            get
            {
                return this._watermarktextshadowalign;
            }
            set
            {
                this._watermarktextshadowalign = value;
            }
        }

        /// <summary>
        /// 文字阴影颜色
        /// </summary>
        public string WaterMarkTextShadowColor
        {
            get
            {
                return this._watermarktextshadowcolor;
            }
            set
            {
                this._watermarktextshadowcolor = value;
            }
        }

        /// <summary>
        /// 阴影深度X轴
        /// </summary>
        public int WaterMarkTextShadowDepthX
        {
            get
            {
                return this._shadowdepthX;
            }
            set
            {
                this._shadowdepthX = value;
            }
        }

        /// <summary>
        /// 阴影深度Y轴
        /// </summary>
        public int WaterMarkTextShadowDepthY
        {
            get
            {
                return this._shadowdepthY;
            }
            set
            {
                this._shadowdepthY = value;
            }
        }

        /// <summary>
        /// 文字大小
        /// </summary>
        public int WaterMarkTextSize
        {
            get
            {
                return this._watermarktextsize;
            }
            set
            {
                this._watermarktextsize = value;
            }
        }

        /// <summary>
        /// 透明度
        /// </summary>
        public int WaterMarkTransparence
        {
            get
            {
                return this._watermarktransparence;
            }
            set
            {
                this._watermarktransparence = value;
            }
        }

        public enum ConvertEffect : byte
        {
            Monochrome = 1,
            Negative = 2,
            None = 0
        }

        public enum ImageAlign : byte
        {
            Center = 4,
            CenterBottom = 5,
            CenterLeft = 7,
            CenterRight = 8,
            CenterTop = 6,
            LeftBottom = 1,
            LeftTop = 0,
            RightBottom = 3,
            RightTop = 2
        }

        public enum ShadowAlign : byte
        {
            LeftBottomShadow = 1,
            LeftTopShadow = 0,
            None = 4,
            RightBottomShadow = 3,
            RightTopShadow = 2
        }

        public enum TextCSS : byte
        {
            Bold = 0,
            Italic = 1,
            Strikeout = 3,
            Underline = 2
        }

        /// <summary>
        /// 上传水印图片
        /// </summary>
        /// <param name="file">上传的文件</param>
        /// <param name="fileName">文件名</param>
        /// <param name="saveTo">保存路径</param>
        /// <param name="wText">水印文字</param>
        /// <param name="font">字体</param>
        /// <param name="fontSize">文字大小</param>
        /// <param name="fontColor">文字颜色</param>
        /// <param name="ShadowColor">阴影颜色</param>
        /// <param name="fontCss">文字形状(加粗、下划线、倾斜、中划线)</param>
        /// <param name="transparence">透明度</param>
        /// <param name="placeX">阴影深度X轴</param>
        /// <param name="placeY">阴影深度Y轴</param>
        /// <param name="angle">旋转角度</param>
        /// <param name="align">位置</param>
        /// <param name="maxWidth">宽度</param>
        /// <param name="maxHeight">高度</param>
        /// <param name="minWidth">缩略图宽度</param>
        /// <param name="minHeight">缩略图高度</param>
        /// <param name="orginal">是否生成缩略图</param>
        public void SaveWaterMarkImageByText(HttpPostedFile file, string fileName, string saveTo, string wText, string font, int fontSize, string fontColor, string ShadowColor, ImageWaterMark.TextCSS fontCss, int transparence, int placeX, int placeY, int angle, ImageWaterMark.ImageAlign align, int maxWidth, int maxHeight, int minWidth, int minHeight, bool orginal)
        {
            string pt = saveTo + fileName + "_temp" + Path.GetExtension(file.FileName);
            file.SaveAs(pt);

            this.SaveWaterMarkImagePath = saveTo + fileName + ".jpg";
            this.SourceImagePath = pt;
            this.MiniatureImagePath = saveTo + "S_" + fileName + ".jpg";
            this.MiniatureImageWidth = minWidth;
            this.MiniatureImageHeight = minHeight;
            this.ImageZipWidth = maxWidth;
            this.ImageZipHeight = maxHeight;
            this.WaterMarkText = wText;
            this.WaterMarkTextFont = font;
            this.WaterMarkTextSize = fontSize;
            this.WaterMarkAlign = align;
            this.WaterMarkTextColor = fontColor;
            this.WaterMarkTextShadowColor = ShadowColor;
            this.WaterMarkTextCSS = fontCss;
            this.WaterMarkTransparence = transparence;
            this.WaterMarkTextShadowDepthX = placeX;
            this.WaterMarkTextShadowDepthY = placeY;

            this.GetWaterMarkImage();
            if (orginal)
            {
                this.GetToMiniatureImage();
            }
        }

        /// <summary>
        /// 上传水印图片
        /// </summary>
        /// <param name="file">上传的文件</param>
        /// <param name="fileName">文件名</param>
        /// <param name="saveTo">保存路径</param>
        /// <param name="wPath">水印图片路径</param>
        /// <param name="transparence">透明度</param>
        /// <param name="angle">旋转角度</param>
        /// <param name="align">位置</param>
        /// <param name="maxWidth">宽度</param>
        /// <param name="maxHeight">高度</param>
        /// <param name="minWidth">缩略图宽度</param>
        /// <param name="minHeight">缩略图高度</param>
        /// <param name="orginal">是否生成缩略图</param>
        public void SaveWaterMarkImageByPic(HttpPostedFile file, string fileName, string saveTo, string wPath, int angle, ImageWaterMark.ImageAlign align, int maxWidth, int maxHeight, int minWidth, int minHeight, bool orginal)
        {
            string pt = saveTo + fileName + "_temp" + Path.GetExtension(file.FileName);
            System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream);
            img.Save(pt);
            img.Dispose();
            file.InputStream.Close();

            this.SaveWaterMarkImagePath = saveTo + fileName + Path.GetExtension(file.FileName);
            this.SourceImagePath = pt;
            this.MiniatureImagePath = saveTo + "S_" + fileName + Path.GetExtension(file.FileName);
            this.MiniatureImageWidth = minWidth;
            this.MiniatureImageHeight = minHeight;
            this.ImageZipHeight = maxHeight;
            this.ImageZipWidth = maxWidth;
            this.WaterMarkImagePath = wPath;
            this.WaterMarkAlign = align;
            this.ConverImageEffect = ImageWaterMark.ConvertEffect.None;
            this.WaterMarkAngle = angle;

            this.GetWaterMarkImage();
            if (orginal)
            {
                this.GetToMiniatureImage();
            }
        }

        /// <summary>
        /// 获取字体形状
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public TextCSS GetTextCSS(string text)
        {
            switch (text)
            {
                case "Bold":
                    return TextCSS.Bold;
                case "Underline":
                    return TextCSS.Underline;
                case "Italic":
                    return TextCSS.Italic;
                case "Strikeout":
                    return TextCSS.Strikeout;
                default:
                    return TextCSS.Bold;
            }
        }

        /// <summary>
        /// 获取水印位置
        /// </summary>
        /// <param name="align"></param>
        /// <returns></returns>
        public ImageAlign GetImageAlign(int align)
        {
            switch (align)
            {
                case 1:
                    return ImageAlign.LeftTop;
                case 2:
                    return ImageAlign.CenterTop;
                case 3:
                    return ImageAlign.RightTop;
                case 4:
                    return ImageAlign.CenterLeft;
                case 5:
                    return ImageAlign.Center;
                case 6:
                    return ImageAlign.CenterRight;
                case 7:
                    return ImageAlign.LeftBottom;
                case 8:
                    return ImageAlign.CenterBottom;
                case 9:
                    return ImageAlign.RightBottom;
                default:
                    return ImageAlign.RightBottom;
            }
        }
    }
}
