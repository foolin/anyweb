using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Studio.Web;
using System.Configuration;

public partial class getpdf : System.Web.UI.Page
{
    private Bitmap Image;
    private string FileName;
    private string Url;
    private int Width;
    private int Height;
    private List<pdfImage> list = new List<pdfImage>();

    protected void Page_Load(object sender, EventArgs e)
    {
        string articleID = Request.QueryString["id"] + "";
        string pdfPath = "";    //PDF路径

        if (string.IsNullOrEmpty(articleID) || !WebAgent.IsInt32(articleID))
        {
            WebAgent.AlertAndBack("文章不存在！");
        }
        pdfPath = pdfPath = string.Format("/Pdf/{0}.pdf", articleID);

        if (File.Exists(Server.MapPath(pdfPath)))
        {
            Response.Redirect(pdfPath);
        }

        GenerateBitmap(articleID, string.Format("{0}/renderarticle.aspx?id={1}", ConfigurationManager.AppSettings["Host"], articleID), -1, -1);
        if (list.Count > 0)
        {
            createPdf(pdfPath);
        }

        Response.Redirect(pdfPath);
    }

    /// <summary>
    /// 创建pdf
    /// </summary>
    /// <param name="pdfPath"></param>
    /// <param name="imgPath"></param>
    protected void createPdf(string pdfPath)
    {
        Document document = new Document();
        PdfWriter.GetInstance(document, new FileStream(Server.MapPath(pdfPath), FileMode.Create));
        document.Open();
        foreach (pdfImage pimage in list) 
        {
            if (File.Exists(Server.MapPath(pimage.imagePath)))
            {
                iTextSharp.text.Image jpeg = iTextSharp.text.Image.GetInstance(Server.MapPath(pimage.imagePath));
                jpeg.ScaleAbsolute(520, 520 * pimage.imageHeight / pimage.imageWidth);
                document.Add(jpeg);
                File.Delete(Server.MapPath(pimage.imagePath));
            }
        }       
        document.Close();
    }

    public void GenerateBitmap(string FileName, string Url, int Width, int Height)
    {
        this.Url = Url;
        this.FileName = FileName;
        this.Width = Width;
        this.Height = Height;
        Thread TempThread = new Thread(new ThreadStart(CreateBrowser));
        TempThread.SetApartmentState(ApartmentState.STA);
        TempThread.Start();
        TempThread.Join();
    }

    private void CreateBrowser()
    {
        WebBrowser Browser = new WebBrowser();
        Browser.ScrollBarsEnabled = false;
        Browser.Navigate(Url);
        Browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(Browser_DocumentCompleted);
        while (Browser.ReadyState != WebBrowserReadyState.Complete)
            System.Windows.Forms.Application.DoEvents();
        Browser.Dispose();
    }

    void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        WebBrowser Browser = (WebBrowser)sender;
        Browser.ScriptErrorsSuppressed = false;
        Browser.ScrollBarsEnabled = false;
        
        if (Width == -1)
        {
            Browser.Width = Browser.Document.Body.ScrollRectangle.Width;
            Width = Browser.Document.Body.ScrollRectangle.Width;
        }
        else
        {
            Browser.Width = Width;
        }
        if (Height == -1)
        {
            Browser.Height = Browser.Document.Body.ScrollRectangle.Height;
            Height = Browser.Document.Body.ScrollRectangle.Height;
        }
        else
        {
            Browser.Height = Height;
        }       

        Browser.BringToFront();

        int minPoint = 0;   //起始坐标
        int pageHeight = 1200;  //pdf页面高度
        int imageHeight = Browser.Height > pageHeight ? pageHeight : Browser.Height;    //生成图片高度
        int docHeight = Browser.Height; //页面总高度
        int pageNo = 1; //图片编号

        while (docHeight > 0)
        {
            Browser.ClientSize = new Size(Browser.Width, imageHeight);  //设置工作区高度和宽度
            Browser.Document.Window.ScrollTo(new Point(0, minPoint));   //滚动滚动条
            Image = new Bitmap(Browser.Width, imageHeight); //定义图片
            Browser.DrawToBitmap(Image, new System.Drawing.Rectangle(0, 0, Browser.Width, imageHeight));    //初始化图片
            Image.Save(Server.MapPath(string.Format("/pdf/{0}_{1}.jpg", FileName, pageNo)), ImageFormat.Bmp);   //保存图片

            //将图片信息加入列表
            pdfImage pimage = new pdfImage();   
            pimage.imagePath = string.Format("/pdf/{0}_{1}.jpg", FileName, pageNo);
            pimage.imageWidth = Browser.Width;
            pimage.imageHeight = imageHeight;
            list.Add(pimage);

            minPoint += pageHeight; //移到下一个坐标
            docHeight -= pageHeight;    //未生成图片的总高度
            imageHeight = docHeight > pageHeight ? pageHeight : docHeight;  //下一张图片的高度
            pageNo++;
        }
    }

    /// <summary>
    /// 图片信息
    /// </summary>
    public class pdfImage
    {
        private string _imagePath;
        public string imagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }

        private int _imageWidth;
        public int imageWidth
        {
            get { return _imageWidth; }
            set { _imageWidth = value; }
        }

        private int _imageHeight;
        public int imageHeight
        {
            get { return _imageHeight; }
            set { _imageHeight = value; }
        }
    }
}
