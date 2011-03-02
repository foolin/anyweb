<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Uploader.ascx.cs" Inherits="Admin_Control_Uploader" %>
<object data="data:application/x-silverlight-2," type="application/x-silverlight-2"
    width="500" height="300">
    <param name="source" value="/ClientBin/FileUpload.xap" />
    <param name="background" value="white" />
    <param name="minRuntimeVersion" value="2.0.31005.0" />
    <param name="autoUpgrade" value="true" />
    <param name="initParams" value="UploadPage=/Admin/FileUpload.ashx,Filter=Images (*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp)|*.jpg;*.gif;*.png;*.jpg;*.jpeg;*.bmp,FilePath=<%=FilePath %>,JavascriptReturnFunction=<%=JavascriptReturnFunction %>,Multiselect=<%=Multiselect %>,MaxNumberToUpload=<%=MaxNumberToUpload %>,UploadChunkSize=102400" />
    <a href="http://go.microsoft.com/fwlink/?LinkID=124807" style="text-decoration: none;">
        <img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight"
            style="border-style: none" />
    </a>
</object>
<iframe style='visibility: hidden; height: 0; width: 0; border: 0px'></iframe>
