using System;
using System . Collections . Generic;
using System . Data;

namespace CarpenterBll . Bll
{
    public class ProductionStockBll
    {
        private readonly Dao.ProductionStockDao _dao=null;
        private readonly Dao.ProductionStock_WeekDao _week_dao=null;
        private readonly Dao.ProductionStock_DayDao _day_dao=null;
        private readonly Dao.ProductionStock_DailyworkDao _daily_dao=null;
        private readonly Dao.ProductionStockPlanDay_Dao _plan_dao=null;
        private readonly Dao.PlanMachin_WeekDao _machin_dao=null;
        private readonly Dao.PlanMachin_DayDao _machin_day_dao=null;
        private readonly Dao.PlanMachine_DailyworkDao _Jdaily_dao=null;

        public ProductionStockBll ( )
        {
            _dao = new Dao . ProductionStockDao ( );
            _week_dao = new Dao . ProductionStock_WeekDao ( );
            _day_dao = new Dao . ProductionStock_DayDao ( );
            _daily_dao = new Dao . ProductionStock_DailyworkDao ( );
            _plan_dao = new Dao . ProductionStockPlanDay_Dao ( );
            _machin_dao = new Dao . PlanMachin_WeekDao ( );
            _machin_day_dao = new Dao . PlanMachin_DayDao ( );
            _Jdaily_dao = new Dao . PlanMachine_DailyworkDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            return _dao . GetDataTable ( strWhere );
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table,string name )
        {
            return _dao . Edit ( table ,name );
        }

        /// <summary>
        /// 获取数据列
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public DataTable GetOnly ( string columns )
        {
            return _dao . GetOnly ( columns );
        }

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <returns></returns>
        public DataTable GetColor ( )
        {
            return _dao . GetColor ( );
        }

        /// <summary>
        /// 本年是否有此周次
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <returns></returns>
        public int Exists ( string weekEnds ,bool planCheck ,List<string> strList )
        {
            return _week_dao . Exists (  weekEnds , planCheck , strList );
        }
        
        /// <summary>
        /// 生成备料周计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Add_BL ( CarpenterEntity . PlanStockPLSEntity _model ,List<string> strList ,string name ,bool planCheck)
        {
            return _week_dao . Add_BL ( _model ,strList ,name ,planCheck );
        }

        /// <summary>
        /// 覆盖备料周计划  但不删除之前的内容
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Edit_BL ( CarpenterEntity . PlanStockPLSEntity _model ,List<string> strList ,string name ,bool planCheck )
        {
            return _week_dao . Edit_BL ( _model ,strList ,name ,planCheck );
        }

        /// <summary>
        /// 是否存在生产备料日计划   相同的工段和计划日期
        /// </summary>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public int Exists_Day ( string workShop ,DateTime dt ,List<string> intList,bool planCheck )
        {
            return _day_dao . Exists_Day ( workShop ,dt ,intList ,planCheck);
        }

        /// <summary>
        /// 生产备料日计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Add_BL_Day ( CarpenterEntity . PlanStockWorkPSWEntity _model ,List<string> strList ,bool planScheduling )
        {
            return _day_dao . Add_BL_Day ( _model ,strList,planScheduling );
        }

        /// <summary>
        /// 生成备料日计划覆盖
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns>1:无此单号  2:选择产品不允许重复生成  3:生成成功  4:生成失败</returns>
        public int Esit_BL_Day ( CarpenterEntity . PlanStockWorkPSWEntity _model ,List<string> strList,bool planScheduling )
        {
            return _day_dao . Esit_BL_Day ( _model ,strList,planScheduling );
        }

        /// <summary>
        /// 备料报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool BLDailyWork ( DataTable table ,string userName ,bool plan)
        {
            return _daily_dao . BLDailyWork ( table ,userName ,plan);
        }

        /// <summary>
        /// 周计划备料报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool BLDailyWeek ( DataTable table ,string userName ,bool state )
        {
            return _week_dao . BLDailyWeek ( table ,userName ,state );
        }

        /// <summary>
        /// 获取备料日计划明细
        /// </summary>
        /// <param name="workShopSection"></param>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableBL ( string weekEnds ,string productNum ,string workShop)
        {
            return _plan_dao . GetDataTableBL ( weekEnds ,productNum ,workShop );
        }

        /// <summary>
        /// 获取备料报工记录
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public DataTable getDataTableBL ( string weekEnds ,string productNum ,string workShop )
        {
            return _plan_dao . getDataTableBL ( weekEnds ,productNum ,workShop );
        }

        /// <summary>
        /// 获取机加工日计划明细
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableJ ( string weekEnds ,string productNum ,string workShop )
        {
            return _plan_dao . GetDataTableJ ( weekEnds ,productNum ,workShop );
        }

        /// <summary>
        /// 获取备料报工记录
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public DataTable getDataTableJ ( string weekEnds ,string productNum ,string workShop )
        {
            return _plan_dao . getDataTableJ ( weekEnds ,productNum ,workShop );
        }

        /// <summary>
        /// 本年是否有此周次
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <returns></returns>
        public int Exists_Machine ( string weekEnds ,bool planCheck ,List<string> strList )
        {
            return _machin_dao . Exists_Machine ( weekEnds ,planCheck ,strList );
        }

        /// <summary>
        /// 覆盖机加工周计划  但不删除之前的内容
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Edit_BL_Machine ( CarpenterEntity . PlanMachinPMCEntity _model ,List<string> strList ,bool planCheck )
        {
            return _machin_dao . Edit_BL_Machine ( _model ,strList ,planCheck );
        }

        /// <summary>
        /// 生成机加工周计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Add_BL_Machine ( CarpenterEntity . PlanMachinPMCEntity _model ,List<string> strList ,bool planCheck )
        {
            return _machin_dao . Add_BL_Machine ( _model ,strList ,planCheck );
        }

        /// <summary>
        /// 周计划机加工报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool JDailyWeek ( DataTable table ,bool state )
        {
            return _machin_dao . JDailyWeek ( table ,state );
        }

        /// <summary>
        /// 是否存在生产机加工日计划   相同的工段和计划日期
        /// </summary>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public int Exists_Day_Machine ( string workShop ,DateTime dt ,List<string> intList ,bool planCheck )
        {
            return _machin_day_dao . Exists_Day_Machine ( workShop ,dt ,intList ,planCheck );
        }

        /// <summary>
        /// 生成机加工日计划覆盖
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns>1:无此单号  2:选择产品不允许重复生成  3:生成成功  4:生成失败</returns>
        public int Esit_J_Day ( CarpenterEntity . PlanMachinWorkPMWEntity _model ,List<string> strList ,bool planScheduling )
        {
            return _machin_day_dao . Esit_J_Day ( _model ,strList ,planScheduling );
        }


        /// <summary>
        /// 生成机加工日计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Add_J_Day ( CarpenterEntity . PlanMachinWorkPMWEntity _model ,List<string> strList ,bool planScheduling )
        {
            return _machin_day_dao . Add_J_Day ( _model ,strList ,planScheduling );
        }

        /// <summary>
        /// 机加工报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool JDailyWork ( DataTable table ,string userName ,bool plan )
        {
            return _Jdaily_dao . JDailyWork ( table ,userName ,plan );
        }

        /// <summary>
        /// 备料日计划是否存在记录
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsBLD ( List<string> idxList )
        {
            return _dao . ExistsBLD ( idxList );
        }

        /// <summary>
        /// 备料周计划是否存在记录
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsBLW ( List<string> idxList )
        {
            return _dao . ExistsBLW ( idxList );
        }

        /// <summary>
        /// 机加工周计划是否存在记录
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsJD ( List<string> idxList )
        {
            return _dao . ExistsJD ( idxList );
        }

        /// <summary>
        /// 机加工日计划是否存在记录
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsJW ( List<string> idxList )
        {
            return _dao . ExistsJW ( idxList );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool Delete ( List<string> idxList )
        {
            return _dao . Delete ( idxList );
        }


    }
}
