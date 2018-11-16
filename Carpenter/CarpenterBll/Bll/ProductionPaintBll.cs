using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ProductionPaintBll
    {
        private readonly Dao.ProductionPaintDao dal=null;
        private readonly Dao.ProductionPaintWeek_Dao _week_dal=null;
        private readonly Dao.ProductionPaintWeekDailyDao _weekDaily=null;
        private readonly Dao.ProductionPaint_DayDao _day_dal=null;
        private readonly Dao.ProductionPaintDayDailyDao _dayDaily=null;

        public ProductionPaintBll ( )
        {
            dal = new Dao . ProductionPaintDao ( );
            _week_dal = new Dao . ProductionPaintWeek_Dao ( );
            _weekDaily = new Dao . ProductionPaintWeekDailyDao ( );
            _day_dal = new Dao . ProductionPaint_DayDao ( );
            _dayDaily = new Dao . ProductionPaintDayDailyDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableView ( string strWhere )
        {
            return dal . GetDataTableView ( strWhere );
        }

        ///// <summary>
        ///// 保存数据
        ///// </summary>
        ///// <param name="tableView"></param>
        ///// <returns></returns>
        //public bool Save ( DataTable tableView )
        //{
        //    return dal . Save ( tableView );
        //}


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
        /// 本年是否有此周次
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <returns></returns>
        public int Exists ( string weekEnds ,bool planCheck ,List<string> strList )
        {
            return _week_dal . Exists ( weekEnds ,planCheck ,strList );
        }

        /// <summary>
        /// 生成油漆周计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Add_BL ( CarpenterEntity . ProductionPaintWeekPWGEntity _model ,List<string> strList ,bool planCheck )
        {
            return _week_dal . Add_BL ( _model ,strList ,planCheck );
        }

        /// <summary>
        /// 覆盖油漆周计划  但不删除之前的内容
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Edit_BL ( CarpenterEntity . ProductionPaintWeekPWGEntity _model ,List<string> strList ,bool planCheck )
        {
            return _week_dal . Edit_BL ( _model ,strList ,planCheck );
        }

        /// <summary>
        /// 获取周计划报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanWeekJ ( List<string> inList )
        {
            return _weekDaily . GetDataTablePlanWeekJ ( inList );

        }

        /// <summary>
        /// 获取周计划预排报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlanWeekDailyJ ( List<string> inList )
        {
            return _weekDaily . GetDataTablePlanWeekDailyJ ( inList );
        }

        /// <summary>
        /// 周计划组装报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool PDailyWeek ( DataTable table ,bool state )
        {
            return _weekDaily . PDailyWeek ( table ,state );
        }

        /// <summary>
        /// 是否存在生产油漆日计划   相同的工段和计划日期
        /// </summary>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public int Exists_Day ( string workShop ,DateTime dt ,List<string> intList ,bool planCheck )
        {
            return _day_dal . Exists_Day ( workShop ,dt ,intList ,planCheck );
        }

        /// <summary>
        /// 生成油漆日计划
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Add_BL_Day ( CarpenterEntity . ProductionPaintDayPWDEntity _model ,List<string> strList ,bool planScheduling )
        {
            return _day_dal . Add_BL_Day ( _model ,strList ,planScheduling );
        }

        /// <summary>
        /// 生成油漆日计划覆盖
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="strList"></param>
        /// <returns>1:无此单号  2:选择产品不允许重复生成  3:生成成功  4:生成失败</returns>
        public int Esit_BL_Day ( CarpenterEntity . ProductionPaintDayPWDEntity _model ,List<string> strList ,bool planScheduling )
        {
            return _day_dal . Esit_BL_Day ( _model ,strList ,planScheduling );
        }

        /// <summary>
        /// 获取报工清单
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( List<string> inList,string work )
        {
            return _dayDaily . GetDataTable ( inList ,work );
        }



        /// <summary>
        /// 获取包装报工清单
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableBZ ( List<string> inList )
        {
            return _dayDaily . GetDataTableBZ ( inList );
        }


        /// <summary>
        /// 获取报工清单 非常规产品
        /// </summary>
        /// <param name="inList"></param>
        /// <param name="work"></param>
        /// <returns></returns>
        public DataTable GetDataTableOther ( List<string> inList ,string work )
        {
            return _dayDaily . GetDataTableOther ( inList ,work );
        }

        /// <summary>
        /// 获取计划报工清单
        /// </summary>
        /// <param name="inList"></param>
        /// <returns></returns>
        public DataTable GetDataTablePlan ( List<string> inList,string work )
        {
            return _dayDaily . GetDataTablePlan ( inList ,work );
        }

        /// <summary>
        /// 备料报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool BLDailyWork ( DataTable table ,bool plan ,string work )
        {
            return _dayDaily . BLDailyWork ( table ,plan ,work );
        }

        /// <summary>
        /// 获取油漆日计划明细
        /// </summary>
        /// <param name="workShopSection"></param>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string weekEnds ,string productNum,string workShop )
        {
            return _day_dal . GetDataTable ( weekEnds ,productNum ,workShop );
        }

        /// <summary>
        /// 编辑白坯和软包的内容
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . ProductionPaintEntity _model )
        {
            return dal . Edit ( _model );
        }


        /// <summary>
        /// 获取油漆报工记录
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <param name="workShop"></param>
        /// <returns></returns>
        public DataTable getDataTable ( string weekEnds ,string productNum ,string workShop )
        {
            return _day_dal . getDataTable ( weekEnds ,productNum ,workShop );
        }


        /// <summary>
        /// 是否存在周计划记录
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsYW ( List<string> idxList )
        {
            return dal . ExistsYW ( idxList );
        }

        /// <summary>
        /// 是否存在日计划记录
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool ExistsYD ( List<string> idxList )
        {
            return dal . ExistsYD ( idxList );
        }


        /// <summary>
        /// 删除数据
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
