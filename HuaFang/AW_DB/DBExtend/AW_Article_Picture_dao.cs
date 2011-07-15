using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Article_Picture_dao
	{
        /// <summary>
        /// 获取文章图片
        /// </summary>
        /// <param name="article"></param>
        public void funcInitArticlePic( AW_Article_bean article )
        {
            if( article.fdArtiType == 0 )
            {
                return;
            }
            this.propWhere = "fdArPiArtiID=" + article.fdArtiID;
            this.propOrder = "ORDER BY fdArPiSort ASC";
            List<AW_Article_Picture_bean> list = this.funcGetList();
            article.PictureList = new List<AW_Article_Picture_bean>();
            article.CatWalkList = new List<AW_Article_Picture_bean>();
            article.BackStageList = new List<AW_Article_Picture_bean>();
            article.CloseUpList = new List<AW_Article_Picture_bean>();
            article.FrontRowList = new List<AW_Article_Picture_bean>();
            foreach( AW_Article_Picture_bean bean in list )
            {
                switch( bean.fdArPiType )
                {
                    case 0:
                        article.PictureList.Add( bean );
                        break;
                    case 1:
                        article.CatWalkList.Add( bean );
                        break;
                    case 2:
                        article.BackStageList.Add( bean );
                        break;
                    case 3:
                        article.CloseUpList.Add( bean );
                        break;
                    case 4:
                        article.FrontRowList.Add( bean );
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 删除文章图片
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="pictureIDs"></param>
        public void funcDeletePictureNoExists( int articleId, string pictureIDs )
        {
            this.funcExecute( String.Format( "DELETE AW_Article_Picture WHERE fdArPiArtiID={0} AND fdArPiID NOT IN ({1})", articleId, pictureIDs ) );
        }
	}
}
