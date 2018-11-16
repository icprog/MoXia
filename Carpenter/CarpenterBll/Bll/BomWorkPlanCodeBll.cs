using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class BomWorkPlanCodeBll
    {
        private readonly Dao.BomWorkPlanCodeDao dal=null;
        private readonly Dao.BomWorkPlanDao _dao=null;

        public BomWorkPlanCodeBll ( )
        {
            dal = new Dao . BomWorkPlanCodeDao ( );
            _dao = new Dao . BomWorkPlanDao ( );
        }

        /// <summary>
        /// 获取批号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWeekend ( )
        {
            return dal . GetDataTableWeekend ( );
        }

        /// <summary>
        /// 获取品名  品号 BOM清单
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePorductNum ( )
        {
            return dal . GetDataTablePorductNum ( );
        }

        /// <summary>
        /// 获取零件名称  零件编号  BOM清单
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePartNum ( )
        {
            return dal . GetDataTablePartNum ( );
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
        /// 删除数据
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            return dal . Delete ( idx );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="idxList"></param>
        /// <param name="weekEnds"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( List<int> idxList ,string weekEnds ,string productNum)
        {
            return _dao . GetDataTablePrint ( idxList ,weekEnds ,productNum );
        }

        /// <summary>
        /// 获取打印传票的数据列表
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="idxStr"></param>
        /// <returns></returns>
        public DataTable printOne ( List<string> idxList )
        {
            return _dao . printOne ( idxList );
        }

        /// <summary>
        /// 获取打印传票的数据列表
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="idxStr"></param>
        /// <returns></returns>
        public DataTable printOne ( string weekEnds ,List<string> proList )
        {
            return _dao . printOne ( weekEnds ,proList );
        }

        /// <summary>
        /// 获取条码
        /// </summary>
        /// <returns></returns>
        public string getCodeNum ( )
        {
            return dal . getCodeNum ( );
        }

        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        public DataTable getProductInfo ( )
        {
            return dal . getProductInfo ( );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Save ( CarpenterEntity . BomWorkPlanCodeEntity _model )
        {
            return dal . Save ( _model );
        }

    }
}
