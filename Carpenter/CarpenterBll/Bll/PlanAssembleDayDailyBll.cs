using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class PlanAssembleDayDailyBll
    {
        private readonly Dao.PlanAssembleDayDailyDao dal=null;
        public PlanAssembleDayDailyBll ( )
        {
            dal = new Dao . PlanAssembleDayDailyDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string columnName )
        {
            return dal . GetDataTableOnly ( columnName );
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
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableDWPerson ( )
        {
            return dal . GetDataTableDWPerson ( );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="workShop"></param>
        /// <param name="dateTime"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string workShop ,string dateTime ,string person )
        {
            return dal . GetDataTablePrintOne ( workShop ,dateTime ,person );
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="workShop"></param>
        /// <param name="dateTime"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string workShop ,string dateTime ,string person )
        {
            return dal . GetDataTablePrintTwo ( workShop ,dateTime ,person );
        }


        /// <summary>
        /// 获取日计划报工记录
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTableDaily ( List<string> inList )
        {
            return dal . GetDataTableDaily ( inList );
        }

        /// <summary>
        /// 获取日计划报工记录  非常规
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTableDailyOnley ( List<string> inList )
        {
            return dal . GetDataTableDailyOnley ( inList );
        }

        /// <summary>
        /// 获取日计划预排报工记录
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTableDailyPlan ( List<string> inList )
        {
            return dal . GetDataTableDailyPlan ( inList );
        }

    }
}
