using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class PlanMachinDayDailyWorkBll
    {
        private readonly Dao.PlanMachinDayDailyWorkDao dal=null;
        public PlanMachinDayDailyWorkBll ( )
        {
            dal = new Dao . PlanMachinDayDailyWorkDao ( );
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
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableView ( string strWhere )
        {
            return dal . GetDataTableView ( strWhere );
        }

        /// <summary>
        /// 获取报工清单
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( List<string> inList ,string work )
        {
            return dal . GetDataTable ( inList ,work );
        }

        /// <summary>
        /// 获取报工清单  非常规
        /// </summary>
        /// <param name="inList"></param>
        /// <param name="work"></param>
        /// <returns></returns>
        public DataTable GetDataTableOther ( List<string> inList ,string work )
        {
            return dal . GetDataTableOther ( inList ,work );
        }

        /// <summary>
        /// 获取计划报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlan ( List<string> inList,string work )
        {
            return dal . GetDataTablePlan ( inList ,work );
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
        /// 删除
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Delete ( List<string> strList )
        {
            return dal . Delete ( strList );
        }

    }
}
