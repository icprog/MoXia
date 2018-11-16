using FastReport;
using FastReport . Export . Xml;
using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using System . Windows . Forms;

namespace Carpenter
{
    public static class OrderPrintAndExport
    {
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="printFile"></param>
        public static  void Print ( DataTable [ ] dt ,string printFile )
        {
            DataSet ds = new DataSet ( );
            if ( dt . Length > 0 )
            {
                for ( int i = 0 ; i < dt . Length ; i++ )
                {
                    ds . Tables . Add ( dt [ i ] );
                }
            }

            if ( ds != null && ds . Tables . Count > 0 )
            {
                string file = Application . StartupPath + "\\" + printFile + "";
                Report report = new Report ( );
                report . Load ( file );
                report . RegisterData ( ds );
                report . Show ( );
            }

        }

        /// <summary>
        /// 导出Execl
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="printFile"></param>
        public static void Export ( DataTable [ ] dt ,string printFile )
        {
            DataSet ds = new DataSet ( );
            if ( dt . Length > 0 )
            {
                for ( int i = 0 ; i < dt . Length ; i++ )
                {
                    ds . Tables . Add ( dt [ i ] );
                }
            }

            if ( ds != null && ds . Tables . Count > 0 )
            {
                string file = Application . StartupPath + "\\" + printFile + "";
                Report report = new Report ( );
                report . Load ( file );
                report . RegisterData ( ds );
                report . Prepare ( );
                XMLExport exprots = new XMLExport ( );
                exprots . Export ( report );
            }
        }
    }
}
