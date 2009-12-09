using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

using Admin.Framework;

using Common.Agent;
using Common.Common;

using Studio.Array;
using Studio.Web;

public partial class SlideEidt : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        this.img1.ImageUrl = "/shopdata/noimage.jpg";
        this.img2.ImageUrl = "/shopdata/noimage.jpg";
        this.img3.ImageUrl = "/shopdata/noimage.jpg";
        this.img4.ImageUrl = "/shopdata/noimage.jpg";
        this.img5.ImageUrl = "/shopdata/noimage.jpg";

    }

    protected override void OnPreRender(EventArgs e)
    {
        using ( SlideAgent sa = new SlideAgent() )
        {

            ArrayList slidelist = sa.GetSlideList();

            if ( slidelist.Count > 0 )
            {
                this.img1.ImageUrl = ShopInfo.DataPath + "/Slide/" + ( (Slide)slidelist[0] ).SlideFile;
                this.hf1.Value = ( (Slide)slidelist[0] ).SlideFile;
                this.txt1.Text = ( (Slide)slidelist[0] ).SlideLink;
                this.txts1.Text = ( (Slide)slidelist[0] ).Sort.ToString();
            }


            if ( slidelist.Count > 1 )
            {
                this.img2.ImageUrl = ShopInfo.DataPath + "/Slide/" + ( (Slide)slidelist[1] ).SlideFile;
                this.hf2.Value = ( (Slide)slidelist[1] ).SlideFile;
                this.txt2.Text = ( (Slide)slidelist[1] ).SlideLink;
                this.txts2.Text = ( (Slide)slidelist[1] ).Sort.ToString();
            }


            if ( slidelist.Count > 2 )
            {
                this.img3.ImageUrl = ShopInfo.DataPath + "/Slide/" + ( (Slide)slidelist[2] ).SlideFile;
                this.hf3.Value = ( (Slide)slidelist[2] ).SlideFile;
                this.txt3.Text = ( (Slide)slidelist[2] ).SlideLink;
                this.txts3.Text = ( (Slide)slidelist[2] ).Sort.ToString();
            }


            if ( slidelist.Count > 3 )
            {
                this.img4.ImageUrl = ShopInfo.DataPath + "/Slide/" + ( (Slide)slidelist[3] ).SlideFile;
                this.hf4.Value = ( (Slide)slidelist[3] ).SlideFile;
                this.txt4.Text = ( (Slide)slidelist[3] ).SlideLink;
                this.txts4.Text = ( (Slide)slidelist[3] ).Sort.ToString();
            }


            if ( slidelist.Count > 4 )
            {
                this.img5.ImageUrl = ShopInfo.DataPath + "/Slide/" + ( (Slide)slidelist[4] ).SlideFile;
                this.hf5.Value = ( (Slide)slidelist[4] ).SlideFile;
                this.txt5.Text = ( (Slide)slidelist[4] ).SlideLink;
                this.txts5.Text = ( (Slide)slidelist[4] ).Sort.ToString();
            }

        }
    }
    protected void btnSave_Click(object sender , EventArgs e)
    {
        ObjectList slist = new ObjectList();

        Slide s = this.SavaSlide( fud1 , txt1 , hf1 , txts1 , "slide1.jpg" );
        if ( s != null ) slist.Add( s );

        s = this.SavaSlide( fud2 , txt2 , hf2 , txts2 , "slide2.jpg" );
        if ( s != null ) slist.Add( s );

        s = this.SavaSlide( fud3 , txt3 , hf3 , txts3 , "slide3.jpg" );
        if ( s != null ) slist.Add( s );

        s = this.SavaSlide( fud4 , txt4 , hf4 , txts4 , "slide4.jpg" );
        if ( s != null ) slist.Add( s );

        s = this.SavaSlide( fud5 , txt5 , hf5 , txts5 , "slide5.jpg" );
        if ( s != null ) slist.Add( s );

        slist.Sort();


        using ( SlideAgent sa = new SlideAgent() )
        {
            if ( sa.SlideEdit( slist ) > 0 )
            {
                this.AddLog( EventID.Update , "修改幻灯片" , "修改幻灯片" );

                WebAgent.SuccAndGo( "保存成功" , "/Admin/SlideEidt.aspx" );
            }
        }

    }

    /// <summary>
    /// 上传图片
    /// </summary>
    /// <param name="fp"></param>
    /// <param name="t"></param>
    /// <param name="ts"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public Slide SavaSlide(FileUpload fp , TextBox t , HiddenField f , TextBox ts , string fileName)
    {
        Slide s = new Slide();

        int maxSize = 1024 * 1024 * 2;

        if ( fp.HasFile )
        {
            HttpPostedFile file = fp.PostedFile;

            if ( file.FileName.ToString().Substring( file.FileName.ToString().IndexOf( '.' ) , 4 ).ToLower().Equals( ".bmp" ) )
            {
                WebAgent.FailAndGo( "当前不支持bmp格式图片." );
            }

            string folder = Server.MapPath( ShopInfo.DataPath ) + "\\Slide";
            if ( !Directory.Exists( folder ) )
            {
                Directory.CreateDirectory( folder );
            }

            string url = "/" + fileName;
            fileName = folder + "\\" + fileName ;

            if ( file.ContentLength > maxSize )
            {
                WebAgent.FailAndGo( "图片太大，当前允许2M." );
            }

            file.SaveAs( fileName );

            file.InputStream.Close();

            s.SlideFile = url;

        }
        else
        {
            if ( f.Value == null || f.Value == "" ) return null;
            else
            {
                s.SlideFile = f.Value;

            }
        }

        int st = 0;
        s.SlideLink = t.Text;
        s.Sort = int.Parse( ts.Text == "" ? st.ToString() : ts.Text );
        return s;

    }
}
