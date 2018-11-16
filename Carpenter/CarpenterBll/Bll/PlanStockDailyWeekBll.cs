using System . Collections . Generic;
using System . Data;

namespace CarpenterBll . Bll
{
    public class PlanStockDailyWeekBll
    {
        private readonly Dao.PlanStockDailyWeekDao dal=new Dao.PlanStockDailyWeekDao();

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string columns )
        {
            return dal . GetDataTableOnly ( columns );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            return dal . GetDataTable ( strWhere );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string year ,string week ,string userName )
        {
            return dal . GetDataTablePrintOne (  year , week , userName );
        }

        public DataTable GetDataTablePrintOne ( string date ,string userName )
        {
            return dal . GetDataTablePrintOne ( date ,userName );
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

        public DataTable GetDataTablePrintTwo ( string date ,string userName )
        {
            return dal . GetDataTablePrintTwo ( date ,userName );
        }

        /// <summary>
        /// 是否是同产品属性
        /// </summary>
        /// <param name="inList"></param>
        /// <returns>0:表示没有数据,按计划报工 1:表示全部是常规,按计划报工  2:表示没有常规,按非计划报工 3:表示有常规和非常规,不让报工  4:表示都是非常规,按非计划报工</returns>
        public int ExistsProductAttr ( List<string> inList )
        {
            return dal . ExistsProductAttr ( inList );
        }

        /// <summary>
        /// 获取周计划报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanWeek ( List<string> inList )
        {
            return dal . GetDataTablePlanWeek ( inList );
        }

        /// <summary>
        /// 获取非常规产品报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanWeekOther ( List<string> inList )
        {
            return dal . GetDataTablePlanWeekOther ( inList );
        }

        /// <summary>
        /// 预排报工  先减掉周计划正式排产的产品
        /// </summary>
        /// <param name="idxLi"></param>
        /// <returns></returns>
        public List<string> idxList ( List<string> idxLi )
        {
            return dal . idxList ( idxLi );
        }

        /// <summary>
        /// 获取周计划预排报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanWeekDaily ( List<string> inList )
        {
            return dal . GetDataTablePlanWeekDaily ( inList );
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
        /// 获取周次
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableWeek ( string year )
        {
            return dal . GetDataTableWeek ( year );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePerson ( )
        {
            return dal . GetDataTablePerson ( );
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

        /// <summary>
        /// 获取报工人
        /// </summary>
        /// <returns></returns>
        public DataTable getTableForName ( )
        {
            return dal . getTableForName ( );
        }

    }
}
