using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Article_bean
	{
        private AW_Column_bean _Column;
        public AW_Column_bean Column
        {
            get { return _Column; }
            set { _Column = value; }
        }

        private List<AW_Tag_bean> _TagList = new List<AW_Tag_bean>();
        public List<AW_Tag_bean> TagList
        {
            get
            {
                return _TagList;
            }
            set
            {
                _TagList = value;
            }
        }

        private List<AW_Article_Picture_bean> _PictureList;
        public List<AW_Article_Picture_bean> PictureList
        {
            get
            {
                return _PictureList;
            }
            set
            {
                _PictureList = value;
            }
        }

        private List<AW_Article_Picture_bean> _CatWalkList;
        public List<AW_Article_Picture_bean> CatWalkList
        {
            get
            {
                return _CatWalkList;
            }
            set
            {
                _CatWalkList = value;
            }
        }

        private List<AW_Article_Picture_bean> _BackStageList;
        public List<AW_Article_Picture_bean> BackStageList
        {
            get
            {
                return _BackStageList;
            }
            set
            {
                _BackStageList = value;
            }
        }

        private List<AW_Article_Picture_bean> _CloseUpList;
        public List<AW_Article_Picture_bean> CloseUpList
        {
            get
            {
                return _CloseUpList;
            }
            set
            {
                _CloseUpList = value;
            }
        }

        private List<AW_Article_Picture_bean> _FrontRowList;
        public List<AW_Article_Picture_bean> FrontRowList
        {
            get
            {
                return _FrontRowList;
            }
            set
            {
                _FrontRowList = value;
            }
        }

        public string fdArtiCategoryName
        {
            get
            {
                switch( this.fdArtiCategory )
                {
                    case 1:
                        return "男装";
                    case 2:
                        return "高级成衣";
                    case 3:
                        return "高级定制";
                    default:
                        return "";
                }
            }
        }

        public string fdArtiCityName
        {
            get
            {
                switch( this.fdArtiCity )
                {
                    case 1:
                        return "巴黎";
                    case 2:
                        return "米兰";
                    case 3:
                        return "伦敦";
                    case 4:
                        return "纽约";
                    default:
                        return "其他";

                }
            }
        }

        public string fdArtiPath
        {
            get 
            {
                switch( fdArtiType )
                {
                    case 0:
                        return string.Format( "/a/{0}.aspx", this.fdArtiID );
                    case 1:
                        return string.Format( "/p/{0}.aspx", this.fdArtiID );
                    case 2:
                        return string.Format( "/f/{0}.aspx", this.fdArtiID );
                    default:
                        return string.Format( "/a/{0}.aspx", this.fdArtiID );
                }
            }
        }
	}
}
