using System;
using System . Data;


namespace CarpenterBll . Bll
{
    public class ProductScheduleBll
    {
        private readonly Dao.ProductScheduleDao _dao=null;
        private readonly Dao.ProductionStockPlanDay_Dao _plan_dao=null;
        private readonly Dao.PlanAssembleDayDailyDao dayDaily=null;

        public ProductScheduleBll ( )
        {
            _dao = new Dao . ProductScheduleDao ( );
            _plan_dao = new Dao . ProductionStockPlanDay_Dao ( );
            dayDaily = new Dao . PlanAssembleDayDailyDao ( );
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
        /// 获取备料所有日计划
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable getTableBLPlan ( string weekEnds ,string productNum )
        {
            return _dao . getTableBLPlan ( weekEnds ,productNum );
        }

        /// <summary>
        /// 获取备料所有报工记录
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable getTableBLBG ( string weekEnds ,string productNum )
        {
            return _dao . getTableBLBG ( weekEnds ,productNum );
        }

        /// <summary>
        /// 获取机加工所有日计划
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable getTableJPlan ( string weekEnds ,string productNum )
        {
            return _dao . getTableJPlan ( weekEnds ,productNum );
        }

        /// <summary>
        /// 获取备料所有报工记录
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable getTableJBG ( string weekEnds ,string productNum )
        {
            return _dao . getTableJBG ( weekEnds ,productNum );
        }


        /// <summary>
        /// 获取备料日计划明细
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableBL ( string weekEnds ,string productNum,string workShop )
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
        public DataTable GetDataTableJ ( string weekEnds ,string productNum ,string workShop)
        {
            return _plan_dao . GetDataTableJ ( weekEnds ,productNum ,workShop );
        }
        
        /// <summary>
        /// 获取组装日计划明细
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableZ ( string weekEnds ,string productNum )
        {
            return _plan_dao . GetDataTableZ ( weekEnds ,productNum );
        }

        /// <summary>
        /// 获取组装日计划报工
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableZBG ( string weekEnds ,string productNum )
        {
            return _plan_dao . GetDataTableZBG ( weekEnds ,productNum );
        }


        /// <summary>
        /// 获取油漆日计划明细
        /// </summary>
        /// <param name="workShopSection"></param>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string weekEnds ,string productNum )
        {
            return _plan_dao . GetDataTable ( weekEnds ,productNum );
        }

        /// <summary>
        /// 获取油漆日计划报工记录
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePaintBG ( string weekEnds ,string productNum )
        {
            return _plan_dao . GetDataTablePaintBG ( weekEnds ,productNum );
        }

        /// <summary>
        /// 查询字段值
        /// </summary>
        /// <param name="coloumn"></param>
        /// <returns></returns>
        public DataTable GetOnly ( string coloumn )
        {
            return _dao . GetOnly ( coloumn );
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
        /// 是否已经存在计划
        /// </summary>
        /// <returns></returns>
        public bool Exists ( string part ,string proNum )
        {
            return _dao . Exists ( part ,proNum );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool Delete ( DataRow row )
        {
            return _dao . Delete ( row );
        }


        /// <summary>
        /// 编辑加急日期
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditDate ( CarpenterEntity . ProductScheduleEntity model )
        {
            return _dao . EditDate ( model );
        }

    }
}
