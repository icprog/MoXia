using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class PayrollReportBll
    {
        readonly private Dao.PayrollReportDao _dal=null;
        public PayrollReportBll ( )
        {
            _dal = new Dao . PayrollReportDao ( );
        }

        /// <summary>
        /// get data from database to view 
        /// </summary>
        /// <param name="yearAndMonth"></param>
        /// <returns></returns>
        public DataTable getTableQuery ( string yearAndMonth )
        {
            return _dal . getTableQuery ( yearAndMonth );
        }

        /// <summary>
        /// 生成工资
        /// </summary>
        /// <param name="yearAndMonth"></param>
        /// <returns>-1 没有工资  1成功  2失败</returns>
        public int Read ( string yearAndMonth )
        {
            return _dal . Read ( yearAndMonth );
        }

        }
}
