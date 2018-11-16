using StudentMgr;
using System;
using System . Collections . Generic;
using System . Data;
using System . Drawing;
using System . Text;

namespace CarpenterBll
{
    public static class UserInformation
    {
        private static string _userName;
        /// <summary>
        /// 登录者
        /// </summary>
        public static string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }

        private static string _programName;
        /// <summary>
        /// 程序
        /// </summary>
        public static string ProgramName
        {
            get
            {
                return _programName;
            }
            set
            {
                _programName = value;
            }
        }

        private static string _typeOfOper;
        /// <summary>
        /// 操作类型
        /// </summary>
        public static string TypeOfOper
        {
            get
            {
                return _typeOfOper;
            }
            set
            {
                _typeOfOper = value;
            }
        }

        public static DateTime dt ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GETDATE() t " );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) ) )
                    return DateTime . Now;
                else
                    return Convert . ToDateTime ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) );
            }
            else
                return DateTime . Now;
        }

        private static List<string> _strList;

        public static List<string> StrList
        {
            get
            {
                return _strList;
            }

            set
            {
                _strList = value;
            }
        }

        /// <summary>
        /// 组装日计划报工，未派工组装产品
        /// </summary>
        private static List<string> _zPai;

        public static List<string> ZPai
        {
            get
            {
                return _zPai;
            }

            set
            {
                _zPai = value;
            }
        }

        private static Color _feedColor;
        /// <summary>
        /// 获取系统皮肤颜色
        /// </summary>
        public static Color FeedColor 
        {
            get
            {
                return _feedColor;
            }
            set
            {
                _feedColor = value;
            }
        }



    }
}
