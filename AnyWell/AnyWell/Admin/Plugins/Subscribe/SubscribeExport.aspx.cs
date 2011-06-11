using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Net;
using System.IO;
using Studio.Web;
public partial class Admin_Plugins_Subscribe_SubscribeExport : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string excelName = DL_helper.funcGetTicks().ToString();
        string path = SaveExcel(excelName);
        if (string.IsNullOrEmpty(path))
        {
            Response.Write("<script type=text/javascript>parent.exportSubscribeFail();</script>");
        }
        else
        {
            Response.Write("<script type=text/javascript>parent.exportSubscribeOK();</script>");
            Response.End();
        }
    }

    protected string SaveExcel(string excelName)  //文件名
    {
        if (!Directory.Exists(Server.MapPath("/Files/Subscribe/")))
        {
            Directory.CreateDirectory(Server.MapPath("/Files/Subscribe/"));
        }
        List<AW_Subscribe_bean> list = new AW_Subscribe_dao().funcGetSubscribeList(QS("ids").Trim());

        int celleCount = 5; //列数
        int rowCount = list.Count;  //行数

        string excelPath = Server.MapPath("/Files/Subscribe/") + excelName + ".xls";

        StreamWriter writer = new StreamWriter(excelPath, false);
        writer.WriteLine("<?xml     version=\"1.0\"?>");
        writer.WriteLine("<?mso-application     progid=\"Excel.Sheet\"?>");
        writer.WriteLine("<Workbook     xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
        writer.WriteLine("     xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
        writer.WriteLine("     xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
        writer.WriteLine("     xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"");
        writer.WriteLine("     xmlns:html=\"http://www.w3.org/TR/REC-html40\">");
        writer.WriteLine("     <DocumentProperties     xmlns=\"urn:schemas-microsoft-com:office:office\">");
        writer.WriteLine("         <Author>Automated     Report     Generator     Example</Author>");
        writer.WriteLine(string.Format("         <Created>{0}T{1}Z</Created>", DateTime.Now.ToString("yyyy-mm-dd"), DateTime.Now.ToString("HH:MM:SS")));
        writer.WriteLine("         <Company>Your     Company     Here</Company>");
        writer.WriteLine("         <Version>11.6408</Version>");
        writer.WriteLine("     </DocumentProperties>");
        writer.WriteLine("     <ExcelWorkbook     xmlns=\"urn:schemas-microsoft-com:office:excel\">");
        writer.WriteLine("         <WindowHeight>8955</WindowHeight>");
        writer.WriteLine("         <WindowWidth>11355</WindowWidth>");
        writer.WriteLine("         <WindowTopX>480</WindowTopX>");
        writer.WriteLine("         <WindowTopY>15</WindowTopY>");
        writer.WriteLine("         <ProtectStructure>False</ProtectStructure>");
        writer.WriteLine("         <ProtectWindows>False</ProtectWindows>");
        writer.WriteLine("     </ExcelWorkbook>");
        writer.WriteLine("     <Styles>");
        writer.WriteLine("         <Style     ss:ID=\"Default\"     ss:Name=\"Normal\">");
        writer.WriteLine("             <Alignment     ss:Vertical=\"Bottom\"/>");
        writer.WriteLine("             <Borders/>");
        writer.WriteLine("             <Font/>");
        writer.WriteLine("             <Interior/>");
        writer.WriteLine("             <Protection/>");
        writer.WriteLine("         </Style>");
        writer.WriteLine("         <Style     ss:ID=\"s21\">");
        writer.WriteLine("             <Alignment     ss:Vertical=\"Bottom\"     ss:WrapText=\"1\"/>");
        writer.WriteLine("         </Style>");
        writer.WriteLine("     </Styles>");
        writer.WriteLine("     <Worksheet     ss:Name=\"Sheet1\">");
        writer.WriteLine(string.Format("         <Table     ss:ExpandedColumnCount=\"{0}\"     ss:ExpandedRowCount=\"{1}\"     x:FullColumns=\"1\"", celleCount, rowCount + 1));
        writer.WriteLine("             x:FullRows=\"1\">");

        writer.WriteLine("<Row>");
        writer.Write("<Cell     ss:StyleID=\"s21\"><Data     ss:Type=\"String\">序号</Data></Cell>");
        writer.Write("<Cell     ss:StyleID=\"s21\"><Data     ss:Type=\"String\">公司名称</Data></Cell>");
        writer.Write("<Cell     ss:StyleID=\"s21\"><Data     ss:Type=\"String\">姓氏</Data></Cell>");
        writer.Write("<Cell     ss:StyleID=\"s21\"><Data     ss:Type=\"String\">名称</Data></Cell>");
        writer.Write("<Cell     ss:StyleID=\"s21\"><Data     ss:Type=\"String\">电子邮件</Data></Cell>");
        writer.WriteLine("</Row>");

        int rowNum = 1;//序号

        foreach (AW_Subscribe_bean bean in list)
        {
            writer.WriteLine("<Row>");
            writer.Write(string.Format("<Cell     ss:StyleID=\"s21\"><Data     ss:Type=\"String\">{0}</Data></Cell>", rowNum));
            writer.Write(string.Format("<Cell     ss:StyleID=\"s21\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.fdSubsCompany));
            writer.Write(string.Format("<Cell     ss:StyleID=\"s21\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.fdSubsSurname));
            writer.Write(string.Format("<Cell     ss:StyleID=\"s21\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.fdSubsName));
            writer.Write(string.Format("<Cell     ss:StyleID=\"s21\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.fdSubsEmail));
            writer.WriteLine("</Row>");
            rowNum++;
        }

        writer.WriteLine("         </Table>");
        writer.WriteLine("         <WorksheetOptions     xmlns=\"urn:schemas-microsoft-com:office:excel\">");
        writer.WriteLine("             <Selected/>");
        writer.WriteLine("             <Panes>");
        writer.WriteLine("                 <Pane>");
        writer.WriteLine("                     <Number>3</Number>");
        writer.WriteLine("                     <ActiveRow>1</ActiveRow>");
        writer.WriteLine("                 </Pane>");
        writer.WriteLine("             </Panes>");
        writer.WriteLine("             <ProtectObjects>False</ProtectObjects>");
        writer.WriteLine("             <ProtectScenarios>False</ProtectScenarios>");
        writer.WriteLine("         </WorksheetOptions>");
        writer.WriteLine("     </Worksheet>");
        writer.WriteLine("     <Worksheet     ss:Name=\"Sheet2\">");
        writer.WriteLine("         <WorksheetOptions     xmlns=\"urn:schemas-microsoft-com:office:excel\">");
        writer.WriteLine("             <ProtectObjects>False</ProtectObjects>");
        writer.WriteLine("             <ProtectScenarios>False</ProtectScenarios>");
        writer.WriteLine("         </WorksheetOptions>");
        writer.WriteLine("     </Worksheet>");
        writer.WriteLine("     <Worksheet     ss:Name=\"Sheet3\">");
        writer.WriteLine("         <WorksheetOptions     xmlns=\"urn:schemas-microsoft-com:office:excel\">");
        writer.WriteLine("             <ProtectObjects>False</ProtectObjects>");
        writer.WriteLine("             <ProtectScenarios>False</ProtectScenarios>");
        writer.WriteLine("         </WorksheetOptions>");
        writer.WriteLine("     </Worksheet>");
        writer.WriteLine("</Workbook>");
        writer.Close();

        return excelPath;
    }
}
