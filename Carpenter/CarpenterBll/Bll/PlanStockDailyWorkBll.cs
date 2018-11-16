using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class PlanStockDailyWorkBll
    {
        private readonly Dao.PlanStockDailyWorkDao _dao=new Dao.PlanStockDailyWorkDao();

        /// <summary>
        /// 获取需要查询的内容
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string item )
        {
            return _dao . GetDataTableOnly ( item );
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( string strWhere )
        {
            return _dao . GetDataTableQuery ( strWhere );
        }

        /// <summary>
        /// 获取报工清单
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( List<string> inList,string work )
        {
            return _dao . GetDataTable ( inList ,work );
        }

        /// <summary>
        /// 获取报工清单  非常规
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOther ( List<string> inList ,string work )
        {
            return _dao . GetDataTableOther ( inList ,work );
        }

        /// <summary>
        /// 获取计划报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlan ( List<string> inList ,string work )
        {
            return _dao . GetDataTablePlan ( inList ,work );
        }

        /// <summary>
        /// 获取报工人
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableDWPerson ( )
        {
            return _dao . GetDataTableDWPerson ( );
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="workShop"></param>
        /// <param name="dateTime"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string workShop ,string dateTime ,string person )
        {
            return _dao . GetDataTablePrintOne ( workShop ,dateTime ,person );
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
            return _dao . GetDataTablePrintTwo ( workShop ,dateTime ,person );
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Delete ( List<string> strList )
        {
            return _dao . Delete ( strList );
        }

    }
}
