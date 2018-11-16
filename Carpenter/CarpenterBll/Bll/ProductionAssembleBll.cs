using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ProductionAssembleBll
    {
        private readonly Dao.ProductionAssembleDao dal=null;
        private readonly Dao. PlanAssembleWeek_Dao _week_dao=null;
        private readonly Dao.PlanAssembleWeekDailyDao weekDaily=null;
        private readonly Dao.PlanAssembleDay_Dao _day_dao=null;
        private readonly Dao.PlanAssembleDayDailyDao dayDaily=null;
        private readonly Dao.AssembleWorkOrderDao orderDao=null;

        public ProductionAssembleBll ( )
        {
            dal = new Dao . ProductionAssembleDao ( );
            _week_dao = new Dao . PlanAssembleWeek_Dao ( );
            weekDaily = new Dao . PlanAssembleWeekDailyDao ( );
            _day_dao = new Dao . PlanAssembleDay_Dao ( );
            dayDaily = new Dao . PlanAssembleDayDailyDao ( );
            orderDao = new Dao . AssembleWorkOrderDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetTableView ( string strWhere )
        {
            return dal . GetTableView ( strWhere );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Save ( DataTable table )
        {
            return dal . Save ( table );
        }


        /// <summary>
        /// 获取数据列
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public DataTable GetOnly ( string columns )
        {
            return dal . GetOnly ( columns );
        }

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <returns></returns>
        public DataTable GetColor ( )
        {
            return dal . GetColor ( );
        }

        /// <summary>
        /// 获取派工信息
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        public DataTable GetTableOrder ( string weekEnds ,string productName )
        {
            return dal . GetTableOrder ( weekEnds ,productName );
        }


        /// <summary>
        /// 本年是否有此周次
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <returns></returns>
        public int Exists_Machine ( string weekEnds ,bool planCheck ,List<string> strList )
        {
            return _week_dao . Exists_Machine ( weekEnds ,planCheck ,strList );
        }

        /// <summary>
        /// 生成组装周计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Add_BL_Machine ( CarpenterEntity . PlanAssembleWeekPLAEntity _model ,List<string> strList ,bool planCheck )
        {
            return _week_dao . Add_BL_Machine ( _model ,strList ,planCheck );
        }

        /// <summary>
        /// 覆盖组装周计划  但不删除之前的内容
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Edit_BL_Machine ( CarpenterEntity . PlanAssembleWeekPLAEntity _model ,List<string> strList ,bool planCheck )
        {
            return _week_dao . Edit_BL_Machine ( _model ,strList ,planCheck );
        }

        /// <summary>
        /// 获取周计划报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanWeekJ ( List<string> inList )
        {
            return weekDaily . GetDataTablePlanWeekJ ( inList );

        }

        /// <summary>
        /// 获取周计划预排报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanWeekDailyJ ( List<string> inList )
        {
            return weekDaily . GetDataTablePlanWeekDailyJ ( inList );
        }

        /// <summary>
        /// 周计划组装报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ZDailyWeek ( DataTable table ,bool state )
        {
            return weekDaily . ZDailyWeek ( table ,state );
        }

        /// <summary>
        /// 是否存在生产组装日计划   相同的工段和计划日期
        /// </summary>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public int Exists_Day_Assemeble ( string workShop ,DateTime dt ,List<string> intList ,bool planCheck )
        {
            return _day_dao . Exists_Day_Assemeble ( workShop ,dt ,intList ,planCheck );
        }

        /// <summary>
        /// 生成组装日计划覆盖
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns>1:无此单号  2:选择产品不允许重复生成  3:生成成功  4:生成失败</returns>
        public int Esit_J_Day ( CarpenterEntity . PlanAssembleDayPLDEntity _model ,List<string> strList ,bool planScheduling )
        {
            return _day_dao . Esit_J_Day ( _model ,strList ,planScheduling );
        }

        /// <summary>
        /// 生成组装日计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Add_J_Day ( CarpenterEntity . PlanAssembleDayPLDEntity _model ,List<string> strList ,bool planScheduling )
        {
            return _day_dao . Add_J_Day ( _model ,strList ,planScheduling );
        }

        /// <summary>
        /// 获取报工清单
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( List<string> inList )
        {
            return dayDaily . GetDataTable ( inList );
        }

        /// <summary>
        /// 获取计划报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlan ( List<string> inList )
        {
            return dayDaily . GetDataTablePlan ( inList );
        }

        /// <summary>
        /// 组装报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        //public bool ZDailyWork ( DataTable table  ,bool plan )
        //{
        //    return dayDaily . ZDailyWork ( table  ,plan );
        //}

        /// <summary>
        /// 获取组装日计划明细
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableZ ( string weekEnds ,string productNum )
        {
            return dayDaily . GetDataTableZ ( weekEnds ,productNum );
        }

        /// <summary>
        /// 获取组装日计划报工信息
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableZB ( string weekEnds ,string productNum )
        {
            return dayDaily . GetDataTableZB ( weekEnds ,productNum );
        }

        /// <summary>
        /// 获取派工单数据
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public List<string> GetStrList ( List<string> strList )
        {
            return orderDao . GetStrList ( strList );
        }

        /// <summary>
        /// 组装报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="plan"></param>
        /// <returns></returns>
        public bool ZDayDailyWork ( DataTable table ,bool plan )
        {
            return dayDaily . ZDayDailyWork ( table ,plan );
        }

        /// <summary>
        /// 是否存在组装周计划
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsZW ( List<string> idxList )
        {
            return dal . ExistsZW ( idxList );
        }

        /// <summary>
        /// 是否存在组装日计划
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsZD ( List<string> idxList )
        {
            return dal . ExistsZD ( idxList );
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool Delete ( List<string> idxList )
        {
            return dal . Delete ( idxList );
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

    }

}
