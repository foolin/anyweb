using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Studio.Web;
using Studio.Array;
using System.Drawing.Imaging;

namespace Studio.Web
{
    /// <summary>
    /// 给图片加水印
    /// 实例:
    /// ImageCover cover = new ImageCover();
    /// cover.CoverPath = "C:\\a.gif";
    /// cover.CoverImage("C:\\source.gif");//原图和目标图片一致的情况下
    /// cover.CoverImage("C:\\source.gif","C:\\desc.gif");//原图和目标图片不同的情况下
    /// </summary>
    public class ImageCover
    {
        private string _coverPath;
        /// <summary>
        /// 水印图片路径
        /// </summary>
        public string CoverPath
        {
            set 
            { 
                _coverPath = value;
                _image = System.Drawing.Image.FromFile(_coverPath);
                _widthCover = _image.Width;
                _heightCover = _image.Height;
                _image.Dispose();
            }
            get { return _coverPath; }
        }

        private CoverPosition _position = CoverPosition.RightBottom;
        /// <summary>
        /// 水印图片位置
        /// </summary>
        public CoverPosition Position
        {
            set { _position = value; }
            get { return _position; }
        }

        private System.Drawing.Image _bitmap;//bmp图片
        private Graphics _graphics;//画板
        private System.Drawing.Image _image;//图片
        private int _widthCover; //
        private int _heightCover;

        /// <summary>
        /// 根据文件名获取图片格式
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        ImageFormat GetImageFormat(string path)
        {
            switch (Path.GetExtension(path).ToLower())
            {
                case ".jpg":
                    return ImageFormat.Jpeg;
                case ".gif":
                    return ImageFormat.Gif;
                case ".png":
                    return ImageFormat.Png;
                case ".bmp":
                    return ImageFormat.Bmp;
                default:
                    return ImageFormat.Jpeg;
            }
        }

        /// <summary>
        /// 给图片加水印(原图和目标图片一致的情况下)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public bool CoverImage(string source)
        {
            string saveTo = source + ".temp";
            bool result = this.CoverImage(source, saveTo);
            if (!result)
                return false;
            File.Delete(source);
            File.Move(saveTo, source);
            return true;
        }

        /// <summary>
        /// 给图片加水印
        /// </summary>
        /// <param name="source"></param>
        /// <param name="saveTo"></param>
        /// <returns></returns>
        public bool CoverImage(string source, string saveTo)
        {
            //文件不存在,退出
            if (!File.Exists(source))
                return false;

            //读取原图片
            _image = System.Drawing.Image.FromFile(source);
            int width = _image.Width;
            int height = _image.Height;

            //如果图片多帧，不加
            FrameDimension fd = new FrameDimension(_image.FrameDimensionsList[0]);
            if (_image.GetFrameCount(fd) > 1)
            {
                _image.Dispose();
                return false;
            }

            //如果图片的高度不到水印的3倍，或者宽度比水印小，不加
            if (width < _widthCover || _heightCover * 3 > height)
            {
                _image.Dispose();
                return false;
            }

            //将原图写入画板中
            _bitmap = new Bitmap(width, height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.InterpolationMode = InterpolationMode.High;
            _graphics.SmoothingMode = SmoothingMode.HighQuality;
            _graphics.Clear(Color.White);
            _graphics.DrawImage(_image, 0, 0, width, height);
            _image.Dispose();

            //读取水印文件
            _image = System.Drawing.Image.FromFile(_coverPath);

            //计算水印位置
            int left = width - _image.Width;
            int top = height - _image.Height;
            switch(_position)
            {
                case CoverPosition.LeftTop:
                    left = 0;
                    top = 0;
                    break;
                case CoverPosition.RightTop:
                    left = width - _image.Width;
                    top = 0;
                    break;
                case CoverPosition.LeftBottom:
                    left = 0;
                    top = height -  _image.Height;
                    break;
                case CoverPosition.RightBottom:
                    left = width - _image.Width;
                    top = height - _image.Height;
                    break;
            }

            //将水印写入画板
            _graphics.DrawImage(_image, left, top, _image.Width, _image.Height);
            _bitmap.Save(saveTo, GetImageFormat(source));
            _image.Dispose();
            _graphics.Dispose();
            _bitmap.Dispose();

            return true;
        }
    }

    public enum CoverPosition : int
    {
        LeftTop = 1,
        RightTop = 2,
        LeftBottom = 3,
        RightBottom = 4
    }
}
