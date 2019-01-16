using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ProductDailyWorkBll
    {
        private readonly Dao.ProductDailyWorkDao dal=null;
        public ProductDailyWorkBll ( )
        {
            dal = new Dao . ProductDailyWorkDao ( );
        }

        /// <summary>
        /// 获取设备信息
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable equExists ( string num )
        {
            return dal . equExists ( num );
        }

        /// <summary>
        /// 获取设备对应工艺信息
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetArt ( string num )
        {
            return dal . GetArt ( num );
        }


        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable perExists ( string num )
        {
            return dal . perExists ( num );
        }

        /// <summary>
        /// 获取传票信息
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable cpExists ( string num  ,string equNum ,string process )
        {
            return dal . cpExists ( num ,equNum ,process );
        }

        /// <summary>
        /// 是否开工或完工闭合
        /// </summary>
        /// <returns></returns>
        public string ExistsSign ( CarpenterEntity . ProductDailyWorkEntity _model ,DataTable table )
        {
            return dal . ExistsSign ( _model ,table );
        }



        /// <summary>
        /// 是否可以开工
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public int ExistsSignStart ( CarpenterEntity . ProductDailyWorkEntity _model ,DataTable table )
        {
            return dal . ExistsSignStart ( _model ,table );
        }

        /// <summary>
        /// 保存记录
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Save ( CarpenterEntity . ProductDailyWorkEntity _model ,DataTable table )
        {
            return dal . Save ( _model ,table );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            return dal . GetDataTableOnly ( );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            return dal . Delete ( idx );
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
        /// 获取开工和完工不配对的异常数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWarnTitle ( )
        {
            return dal . GetDataTableWarnTitle ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo ( string strWhere )
        {
            return dal . GetDataTableTwo ( strWhere );
        }

        /// <summary>
        /// 获取零件数量
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public decimal numOfPart ( string code )
        {
            return dal . numOfPart ( code );
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Examin ( List<string> strList )
        {
            return dal . Examin ( strList );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Cancella ( List<string> strList )
        {
            return dal . Cancella ( strList );
        }

        /// <summary>
        /// 编辑记工数量
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table )
        {
            return dal . Edit ( table );
        }

        /// <summary>
        /// 获取设备备注
        /// </summary>
        /// <param name="equimentNum"></param>
        /// <returns></returns>
        public DataTable tableRemark ( string equimentNum )
        {
            return dal . tableRemark ( equimentNum );
        }

        /// <summary>
        /// 获取区间标准
        /// </summary>
        /// <param name="equimentNum"></param>
        /// <param name="artName"></param>
        /// <returns></returns>
        public DataTable tableSpace ( string equimentNum ,string artName )
        {
            return dal . tableSpace ( equimentNum ,artName );
        }

        /// <summary>
        /// 获取工资类型
        /// </summary>
        /// <param name="equimentNum"></param>
        /// <returns></returns>
        public DataTable tableSalary ( string equimentNum )
        {
            return dal . tableSalary ( equimentNum );
        }

        /// <summary>
        /// 是否强制完工
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool isOver ( CarpenterEntity . ProductDailyWorkEntity _model )
        {
            return dal . isOver ( _model );
        }

        /// <summary>
        /// 同零件和工艺是否订单数量等于记工数量，若等则提示已报工完成
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool isOverForSave ( CarpenterEntity . ProductDailyWorkEntity _model )
        {
            return dal . isOverForSave ( _model );
        }

        /// <summary>
        /// 同传票编号和工艺已经记工的数量是多少
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public decimal getOverNum ( CarpenterEntity . ProductDailyWorkEntity _model )
        {
            return dal . getOverNum ( _model );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getPrintTable ( string strWhere )
        {
            return dal . getPrintTable ( strWhere );
        }


        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getPrintUser ( string strWhere )
        {
            return dal . getPrintUser ( strWhere );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . ProductDailyWorkEntity model )
        {
            return dal . Edit ( model );
        }

        /// <summary>
        /// 获取没有同时扫描完工的人员信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tableUser"></param>
        /// <returns></returns>
        public Dictionary<string ,string> isOver ( CarpenterEntity . ProductDailyWorkEntity model ,DataTable tableUser )
        {
            return dal . isOver ( model ,tableUser );
        }

        /// <summary>
        /// 编辑工艺信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool editArt ( CarpenterEntity . ProductDailyWorkPREEntity model )
        {
            return dal . editArt ( model );
        }

        /// <summary>
        /// 获取工艺信息根据设备
        /// </summary>
        /// <param name="equCode"></param>
        /// <returns></returns>
        public DataTable getTableForArt ( string equCode )
        {
            return dal . getTableForArt ( equCode );
        }

        }
}
