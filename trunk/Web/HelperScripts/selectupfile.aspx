<%@ Page language="c#" %>
<script runat="server">


private string DefaultImageFolder;  // 默认的起始文件夹

private void Page_Load(object sender, System.EventArgs e) {

try
{
			if(Session["UserName"].ToString()!=String.Empty)
			{
	DefaultImageFolder = Session["UserName"].ToString();
	}
	else
	{
				Response.Redirect("~/Login.aspx?ReturnUrl=" + Request.Path);
				return;
			}
			}
			catch
			{
				Response.Redirect("~/Login.aspx?ReturnUrl=" + Request.Path);
				return;
			}

	string isframe = "" + Request["frame"];
	if (isframe != "") {
		MainPage.Visible = true;
		iframePanel.Visible = false;
	
		string rif = "" + Request["rif"];
		string cif = "" + Request["cif"];	

		if (cif != "" && rif != "") {
			RootImagesFolder.Value = rif;
			CurrentImagesFolder.Value = cif;
		} else {
			RootImagesFolder.Value = DefaultImageFolder;
			CurrentImagesFolder.Value = DefaultImageFolder;	
		}


		if (!IsPostBack) {
			DisplayImages();
		}
	} else {
		
	}
}

private string[] ReturnFilesArray() {
	if (CurrentImagesFolder.Value != "") {
		try {
			string AppPath = HttpContext.Current.Request.PhysicalApplicationPath;
			string ImageFolderPath = AppPath + CurrentImagesFolder.Value;
			string[] FilesArray = System.IO.Directory.GetFiles(ImageFolderPath,"*");
			return FilesArray;
			
			
		} catch {
		
			return null;
		}
	} else {
		return null;
	}

}

private string[] ReturnDirectoriesArray() {
	if (CurrentImagesFolder.Value != "") {
		try {
			string AppPath = HttpContext.Current.Request.PhysicalApplicationPath;
			string CurrentFolderPath = AppPath + CurrentImagesFolder.Value;
			string[] DirectoriesArray = System.IO.Directory.GetDirectories(CurrentFolderPath,"*");
			return DirectoriesArray ;
		} catch {
			return null;
		}
	} else {
		return null;
	}
}

public void DisplayImages() {
	string[] FilesArray = ReturnFilesArray();
	string[] DirectoriesArray = ReturnDirectoriesArray();
	string AppPath = HttpContext.Current.Request.PhysicalApplicationPath;
	string AppUrl;
	
	//Get the application's URL
	if (Request.ApplicationPath == "/")
		AppUrl = Request.ApplicationPath;
	else
		AppUrl = Request.ApplicationPath + "/";
	
	GalleryPanel.Controls.Clear();
	if ( (FilesArray == null || FilesArray.Length == 0) && (DirectoriesArray == null || DirectoriesArray.Length == 0) ) {
		gallerymessage.Text = ": " + RootImagesFolder.Value;
	} else {
		string ImageFileName = "";
		string ImageFileLocation = "";

		int thumbWidth = 94;
		int thumbHeight = 94;
		
		if (CurrentImagesFolder.Value != RootImagesFolder.Value) {

			System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
			myHtmlImage.Src = AppUrl + "Admin/Resources/images/folder.up.gif";
			myHtmlImage.Attributes["unselectable"]="on"; 
			myHtmlImage.Attributes["align"]="absmiddle"; 
			myHtmlImage.Attributes["vspace"]="36"; 

			string ParentFolder = CurrentImagesFolder.Value.Substring(0,CurrentImagesFolder.Value.LastIndexOf("\\"));

			System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();					
			myImageHolder.CssClass = "imageholder";
			myImageHolder.Attributes["unselectable"]="on"; 
			myImageHolder.Attributes["onclick"]="divClick(this,'');";  
			myImageHolder.Attributes["ondblclick"]="gotoFolder('" + RootImagesFolder.Value + "','" + ParentFolder.Replace("\\","\\\\") + "');";  
			myImageHolder.Controls.Add(myHtmlImage);

			System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
			myMainHolder.CssClass = "imagespacer";
			myMainHolder.Controls.Add(myImageHolder);

			System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
			myTitleHolder.CssClass = "titleHolder";
			myTitleHolder.Controls.Add(new LiteralControl("向上"));
			myMainHolder.Controls.Add(myTitleHolder);

			GalleryPanel.Controls.Add(myMainHolder);		
			
		}
		
		foreach (string _Directory in DirectoriesArray) {
			
			try {
				string DirectoryName = _Directory.ToString();
				

				System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
				myHtmlImage.Src = AppUrl + "Admin/Resources/images/folder.big.gif";
				myHtmlImage.Attributes["unselectable"]="on"; 
				myHtmlImage.Attributes["align"]="absmiddle"; 
				myHtmlImage.Attributes["vspace"]="29"; 

				System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();					
				myImageHolder.CssClass = "imageholder";
				myImageHolder.Attributes["unselectable"]="on"; 
				myImageHolder.Attributes["onclick"]="divClick(this);";  
				myImageHolder.Attributes["ondblclick"]="gotoFolder('" + RootImagesFolder.Value + "','" + DirectoryName.Replace(AppPath,"").Replace("\\","\\\\") + "');";  
				myImageHolder.Controls.Add(myHtmlImage);

				System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
				myMainHolder.CssClass = "imagespacer";
				myMainHolder.Controls.Add(myImageHolder);

				System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
				myTitleHolder.CssClass = "titleHolder";
				myTitleHolder.Controls.Add(new LiteralControl(DirectoryName.Replace(AppPath + CurrentImagesFolder.Value + "\\","")));
				myMainHolder.Controls.Add(myTitleHolder);

				GalleryPanel.Controls.Add(myMainHolder);		
			} catch {
				// nothing for error
			}
		}
		
		foreach (string ImageFile in FilesArray) {

			try {

				ImageFileName = ImageFile.ToString();
				ImageFileName = ImageFileName.Substring(ImageFileName.LastIndexOf("\\")+1);
				ImageFileLocation = AppUrl;
				ImageFileLocation = ImageFileLocation.Substring(ImageFileLocation.LastIndexOf("\\")+1);
				//galleryfilelocation += "/";
				ImageFileLocation += CurrentImagesFolder.Value;
				ImageFileLocation += "/";
				ImageFileLocation += ImageFileName;
				System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
				myHtmlImage.Src = ImageFileLocation;
				System.Drawing.Image myImage = System.Drawing.Image.FromFile(ImageFile.ToString());
				myHtmlImage.Attributes["unselectable"]="on";  
				//myHtmlImage.border=0;

				// landscape image
				if (myImage.Width > myImage.Height) {
					if (myImage.Width > thumbWidth) {
						myHtmlImage.Width = thumbWidth;
						myHtmlImage.Height = Convert.ToInt32(myImage.Height * thumbWidth/myImage.Width);						
					} else {
						myHtmlImage.Width = myImage.Width;
						myHtmlImage.Height = myImage.Height;
					}
				// portrait image
				} else {
					if (myImage.Height > thumbHeight) {
						myHtmlImage.Height = thumbHeight;
						myHtmlImage.Width = Convert.ToInt32(myImage.Width * thumbHeight/myImage.Height);
					} else {
						myHtmlImage.Width = myImage.Width;
						myHtmlImage.Height = myImage.Height;
					}
				}
				
				if (myHtmlImage.Height < thumbHeight) {
					myHtmlImage.Attributes["vspace"] = Convert.ToInt32((thumbHeight/2)-(myHtmlImage.Height/2)).ToString(); 
				}


				System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();					
				myImageHolder.CssClass = "imageholder";
				myImageHolder.Attributes["onclick"]="divClick(this,'" + ImageFileName + "');";  
				myImageHolder.Attributes["ondblclick"]="javascript:window.returnValue='" + ImageFileLocation.Replace("\\","/") + "';window.close();";  
				myImageHolder.Controls.Add(myHtmlImage);

				System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
				myMainHolder.CssClass = "imagespacer";
				myMainHolder.Controls.Add(myImageHolder);

				System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
				myTitleHolder.CssClass = "titleHolder";
				myTitleHolder.Controls.Add(new LiteralControl(ImageFileName + "<BR>" + myImage.Width.ToString() + "x" + myImage.Height.ToString()));
				myMainHolder.Controls.Add(myTitleHolder);

				//GalleryPanel.Controls.Add(myImage);
				GalleryPanel.Controls.Add(myMainHolder);
				
				myImage.Dispose();
			} catch {

			}
		}
		gallerymessage.Text = "";
	}
}
</script>
<asp:panel id="MainPage" runat="server" visible="false">
<!doctype html public "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
<HEAD>
<META HTTP-EQUIV="Expires" CONTENT="0">
<title>插入图片</title>
<style>

body {
	margin: 0px 0px 0px 0px;
	padding: 0px 0px 0px 0px;
	background: #ffffff; 
	width: 100%;
	overflow:hidden;
	border: 0;
}

body,tr,td {
	color: #000000;
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 10pt;
}

div.imagespacer {
	width: 120;
	height: 126;
	text-align: center;			
	float: left;
	font: 10pt verdana;
	margin: 5px;
	overflow: hidden;
}
div.imageholder {
	margin: 0px;
	padding: 0px;
	border: 1 solid #CCCCCC;
	width: 100;
	height: 100;
}

div.titleholder {
	font-family: ms sans serif, arial;
	font-size: 8pt;
	width: 100;
	text-overflow: ellipsis;
	overflow: hidden;
	white-space: nowrap;			
}		

</style>


<script language="javascript">
lastDiv = null;
function divClick(theDiv,filename) {
	if (lastDiv) {
		lastDiv.style.border = "1 solid #CCCCCC";
	}
	lastDiv = theDiv;
	theDiv.style.border = "2 solid #316AC5";

}
function gotoFolder(rootfolder,newfolder) {
	window.navigate("SelectUpFile.aspx?frame=1&rif=" + rootfolder + "&cif=" + newfolder);
}		
function returnImage(imagename) {
	window.opener.document.form1.url.value = arr;
	window.parent.close();	
}		
</script>		
</HEAD>
<body>
<table width=100% height=100% cellpadding=0 cellspacing=0 border=0>

<FORM  runat="server">

<tr><td>
	<div id="galleryarea" style="width=100%; height:100%; overflow: auto;">
		<asp:label id="gallerymessage" runat="server"></asp:label>
		<asp:panel id="GalleryPanel" runat="server"></asp:panel>
	</div>
</td></tr>
<tr><td height=16 style="padding-left:10px;border-top: 1 solid #999999; background-color:#99ccff;">
	<input type="hidden" id="RootImagesFolder" Value="images" runat="server" />
	<input type="hidden" id="CurrentImagesFolder" Value="images" runat="server" />
</td></tr>
</form>
</table>
</body>
</HTML>
</asp:panel>
<asp:panel id="iframePanel" runat="server" >
<html> 
<head><title>插入图片</title></head>
<style>
body {
	margin: 0px 0px 0px 0px;
	padding: 0px 0px 0px 0px;
	background: #ffffff;
	overflow:hidden;
}
</style>
<body>
	<iframe style="width:100%;height:100%;border:0;" border=0 frameborder=0 src="SelectUpFile.aspx?frame=1&<%=Request.QueryString%>"></iframe>
</body>
</html>
</asp:panel>
