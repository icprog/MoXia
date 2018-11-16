using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class PlanAssembleWeekDailyBll
    {
        private readonly Dao.PlanAssembleWeekDailyDao dal=null;
        public PlanAssembleWeekDailyBll ( )
        {
            dal = new Dao . PlanAssembleWeekDailyDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public DataTable GetOnly ( string columnName )
        {
            return dal . GetOnly ( columnName );
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Delete ( List<string> strList )
        {
            return dal.Delete ( strList );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableView ( string strWhere )
        {
            return dal . GetDataTableView ( strWhere );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string year ,string week ,string userName )
        {
            return dal . GetDataTablePrintOne ( year ,week ,userName );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string year ,string week ,string userName )
        {
            return dal . GetDataTablePrintTwo ( year ,week ,userName );
        }

        /// <summary>
        /// 获取年
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableYear ( )
        {
            return dal . GetDataTableYear ( );
        }

        /// <summary>
        /// 获取操作者
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePerson ( )
        {
            return dal . GetDataTablePerson ( );
        }

        /// <summary>
        /// 获取周次
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableWeek ( string year )
        {
            return dal . GetDataTableWeek ( year );
        }

    }
}
