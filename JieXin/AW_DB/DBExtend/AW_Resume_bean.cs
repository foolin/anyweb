using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Resume_bean
	{
        private List<AW_Education_bean> _educationList;
        /// <summary>
        /// 教育经历
        /// </summary>
        public List<AW_Education_bean> EducationList
        {
            get
            {
                return _educationList;
            }
            set
            {
                _educationList = value;
            }
        }

        private List<AW_Rewards_bean> _rewardList;
        /// <summary>
        /// 奖励
        /// </summary>
        public List<AW_Rewards_bean> RewardList
        {
            get
            {
                return _rewardList;
            }
            set
            {
                _rewardList = value;
            }
        }

        private List<AW_Position_bean> _positionList;
        /// <summary>
        /// 职务
        /// </summary>
        public List<AW_Position_bean> PositionList
        {
            get
            {
                return _positionList;
            }
            set
            {
                _positionList = value;
            }
        }

        private List<AW_Work_bean> _workList;
        /// <summary>
        /// 工作经验
        /// </summary>
        public List<AW_Work_bean> WorkList
        {
            get
            {
                return _workList;
            }
            set
            {
                _workList = value;
            }
        }

        private List<AW_Language_bean> _languageList;
        /// <summary>
        /// 语言能力
        /// </summary>
        public List<AW_Language_bean> LanguageList
        {
            get
            {
                return _languageList;
            }
            set
            {
                _languageList = value;
            }
        }

        private List<AW_Cert_bean> _certList;
        /// <summary>
        /// 证书
        /// </summary>
        public List<AW_Cert_bean> CertList
        {
            get
            {
                return _certList;
            }
            set
            {
                _certList = value;
            }
        }

        private List<AW_Awards_bean> _awardList;
        /// <summary>
        /// 奖项
        /// </summary>
        public List<AW_Awards_bean> AwardList
        {
            get
            {
                return _awardList;
            }
            set
            {
                _awardList = value;
            }
        }

        private List<AW_Skills_bean> _skillList;
        /// <summary>
        /// 技能
        /// </summary>
        public List<AW_Skills_bean> SkillList
        {
            get
            {
                return _skillList;
            }
            set
            {
                _skillList = value;
            }
        }
	}
}
