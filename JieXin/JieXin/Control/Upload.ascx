<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Upload.ascx.cs" Inherits="Control_Upload" %>
<div id="UploadPic" class="choArea">
    <div class="top">
        <i class="iTit">上传照片</i> <span class="topRight white"><a onclick="closeWindow('UploadPic')"
            href="javascript:void(0);">
            <img height="15" width="15" src="/images/icon_close.gif"></a> </span>
    </div>
    <div class="con gray">
        <table style="width: 100%; text-align: center;">
            <tr>
                <td>
                    <br />
                    <span style="color: Red; display: none" id="results"></span>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    上传路径：<input type="file" id="filePhoto" name="filePhoto" />
                    <input type="button" value="上传" onclick="uploadPhoto()" />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    照片尺寸90*110px,大小不能超过300k
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
        <span class="blank5px"></span>
    </div>
    <div class="btm">
    </div>
</div>

