using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.IO;

public partial class Admin_Ajax_RegistExport : AjaxPageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int sid = 0;
        if( !int.TryParse( QS( "sid" ), out sid ) )
        {
            RenderString( "error:站点不存在！" );
        }
        AW_Site_bean site = new AW_Site_dao().funcGetSiteInfo( sid );
        if( site == null )
        {
            ShowError( "error:站点不存在！" );
        }
        string excelName = DL_helper.funcGetTicks().ToString();
        string path = SaveExcel( excelName, sid );
        RenderString( path );
    }

    protected string SaveExcel( string excelName, int sid )
    {
        if( !Directory.Exists( Server.MapPath( "/Files/Regist/" ) ) )
        {
            Directory.CreateDirectory( Server.MapPath( "/Files/Regist/" ) );
        }
        List<AW_Regist_bean> list = new AW_Regist_dao().funcGetRegistList( sid );

        int celleCount = 28; //列数
        int rowCount = list.Count;  //行数

        string excelPath = Server.MapPath( "/Files/Regist/" ) + excelName + ".xls";

        StreamWriter writer = new StreamWriter( excelPath, false );
        writer.WriteLine( "<?xml     version=\"1.0\"?>" );
        writer.WriteLine( "<?mso-application     progid=\"Excel.Sheet\"?>" );
        writer.WriteLine( "<Workbook     xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"" );
        writer.WriteLine( "     xmlns:o=\"urn:schemas-microsoft-com:office:office\"" );
        writer.WriteLine( "     xmlns:x=\"urn:schemas-microsoft-com:office:excel\"" );
        writer.WriteLine( "     xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"" );
        writer.WriteLine( "     xmlns:html=\"http://www.w3.org/TR/REC-html40\">" );
        writer.WriteLine( "     <DocumentProperties     xmlns=\"urn:schemas-microsoft-com:office:office\">" );
        writer.WriteLine( "         <Author>Automated     Report     Generator     Example</Author>" );
        writer.WriteLine( string.Format( "         <Created>{0}T{1}Z</Created>", DateTime.Now.ToString( "yyyy-mm-dd" ), DateTime.Now.ToString( "HH:MM:SS" ) ) );
        writer.WriteLine( "         <Company>Your     Company     Here</Company>" );
        writer.WriteLine( "         <Version>11.6408</Version>" );
        writer.WriteLine( "     </DocumentProperties>" );
        writer.WriteLine( "     <ExcelWorkbook     xmlns=\"urn:schemas-microsoft-com:office:excel\">" );
        writer.WriteLine( "         <WindowHeight>8955</WindowHeight>" );
        writer.WriteLine( "         <WindowWidth>11355</WindowWidth>" );
        writer.WriteLine( "         <WindowTopX>480</WindowTopX>" );
        writer.WriteLine( "         <WindowTopY>15</WindowTopY>" );
        writer.WriteLine( "         <ProtectStructure>False</ProtectStructure>" );
        writer.WriteLine( "         <ProtectWindows>False</ProtectWindows>" );
        writer.WriteLine( "     </ExcelWorkbook>" );
        writer.WriteLine( "     <Styles>" );
        writer.WriteLine( "         <Style     ss:ID=\"Default\"     ss:Name=\"Normal\">" );
        writer.WriteLine( "             <Alignment     ss:Vertical=\"Bottom\"/>" );
        writer.WriteLine( "             <Borders/>" );
        writer.WriteLine( "             <Font/>" );
        writer.WriteLine( "             <Interior/>" );
        writer.WriteLine( "             <Protection/>" );
        writer.WriteLine( "         </Style>" );
        writer.WriteLine( "         <Style     ss:ID=\"s21\">" );
        writer.WriteLine( "             <Alignment     ss:Vertical=\"Bottom\"     ss:WrapText=\"1\"/>" );
        writer.WriteLine( "         </Style>" );
        writer.WriteLine( "     </Styles>" );
        writer.WriteLine( "     <Worksheet     ss:Name=\"Sheet1\">" );
        writer.WriteLine( string.Format( "         <Table     ss:ExpandedColumnCount=\"{0}\"     ss:ExpandedRowCount=\"{1}\"     x:FullColumns=\"1\"", celleCount, rowCount + 1 ) );
        writer.WriteLine( "             x:FullRows=\"1\">" );

        writer.WriteLine( "<Row>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">卡号</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">姓</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">名</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">称谓</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">电话</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">传真</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">手机</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">电子邮箱</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">职务</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">单位</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">单位网址</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">部门</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">城市</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">地址</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">邮编</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">阁下主要的业务类别是</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">黑色家电</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">白色家电</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">小家电</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">厨房及浴室家电</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">家电配件</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">服务及刊物</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">阁下主要的工作职能</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">阁下参观的目的</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">阁下是否参与决策贵司的购买/推荐产品权?</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">如果是，阁下的采购预算大概为?</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">阁下获知“顺德家电展”的渠道?</Data></Cell>" );
        writer.Write( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">阁下是否对我们的论坛和会议感兴趣？</Data></Cell>" );
        writer.WriteLine( "</Row>" );

        foreach( AW_Regist_bean bean in list )
        {
            writer.WriteLine( "<Row>" );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", 83000000 + bean.fdRegiID ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.fdRegiSurname ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.fdRegiName ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.Appellation ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.fdRegiPhone ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.fdRegiFax ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.fdRegiMobile ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.fdRegiEmail ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.fdRegiPosition ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.fdRegiCompany ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.fdRegiWebSite ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.PositionType ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.Country ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.fdRegiAddress ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.fdRegiPost ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.Business ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.Target1 ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.Target2 ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.Target3 ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.Target4 ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.Target5 ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.Target6 ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.Function ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.Purpose ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.Decision ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.Budget ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.From ) );
            writer.Write( string.Format( "<Cell     ss:StyleID=\"Default\"><Data     ss:Type=\"String\">{0}</Data></Cell>", bean.Interest ) );
            writer.WriteLine( "</Row>" );
        }

        writer.WriteLine( "         </Table>" );
        writer.WriteLine( "         <WorksheetOptions     xmlns=\"urn:schemas-microsoft-com:office:excel\">" );
        writer.WriteLine( "             <Selected/>" );
        writer.WriteLine( "             <Panes>" );
        writer.WriteLine( "                 <Pane>" );
        writer.WriteLine( "                     <Number>3</Number>" );
        writer.WriteLine( "                     <ActiveRow>1</ActiveRow>" );
        writer.WriteLine( "                 </Pane>" );
        writer.WriteLine( "             </Panes>" );
        writer.WriteLine( "             <ProtectObjects>False</ProtectObjects>" );
        writer.WriteLine( "             <ProtectScenarios>False</ProtectScenarios>" );
        writer.WriteLine( "         </WorksheetOptions>" );
        writer.WriteLine( "     </Worksheet>" );
        writer.WriteLine( "     <Worksheet     ss:Name=\"Sheet2\">" );
        writer.WriteLine( "         <WorksheetOptions     xmlns=\"urn:schemas-microsoft-com:office:excel\">" );
        writer.WriteLine( "             <ProtectObjects>False</ProtectObjects>" );
        writer.WriteLine( "             <ProtectScenarios>False</ProtectScenarios>" );
        writer.WriteLine( "         </WorksheetOptions>" );
        writer.WriteLine( "     </Worksheet>" );
        writer.WriteLine( "     <Worksheet     ss:Name=\"Sheet3\">" );
        writer.WriteLine( "         <WorksheetOptions     xmlns=\"urn:schemas-microsoft-com:office:excel\">" );
        writer.WriteLine( "             <ProtectObjects>False</ProtectObjects>" );
        writer.WriteLine( "             <ProtectScenarios>False</ProtectScenarios>" );
        writer.WriteLine( "         </WorksheetOptions>" );
        writer.WriteLine( "     </Worksheet>" );
        writer.WriteLine( "</Workbook>" );
        writer.Close();

        return string.Format( "/Files/Regist/{0}.xls", excelName );
    }
}
