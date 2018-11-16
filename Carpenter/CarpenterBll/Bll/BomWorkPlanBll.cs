
using System . Collections . Generic;
using System . Data;

namespace CarpenterBll . Bll
{
    public class BomWorkPlanBll
    {
        private readonly Dao.BomWorkPlanDao _dao=new Dao.BomWorkPlanDao();

        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableProduct ( )
        {
            return _dao . GetDataTableProduct ( );
        }


        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePerson ( )
        {
            return _dao . GetDataTablePerson ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePro ( )
        {
            return _dao . GetDataTablePro ( );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public bool Delete ( string productNum )
        {
            return _dao . Delete ( productNum );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="productNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Cancellation ( string productNum ,bool state )
        {
            return _dao . Cancellation ( productNum ,state );
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="productNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examine ( string productNum ,bool state )
        {
            return _dao . Examine ( productNum ,state );
        }

        /// <summary>
        /// 获取单头数据列表
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOne ( string productNum )
        {
            return _dao . GetDataTableOne ( productNum );
        }

        /// <summary>
        /// 获取单身数据列表
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo ( string productNum )
        {
            return _dao . GetDataTableTwo ( productNum );
        }

        /// <summary>
        /// 增加一单记录
        /// </summary>
        /// <param name="tableQuery"></param>
        /// <param name="_modelOne"></param>
        /// <returns></returns>
        public bool Add ( DataTable tableQuery ,CarpenterEntity . BomWorkPlanWOQEntity _modelOne )
        {
            return _dao . Add ( tableQuery ,_modelOne );
        }

        /// <summary>
        /// 编辑一单记录
        /// </summary>
        /// <param name="tableQuery"></param>
        /// <param name="_modelOne"></param>
        /// <param name="tableQueryOne"></param>
        /// <returns></returns>
        public bool Edit ( DataTable tableQuery ,CarpenterEntity . BomWorkPlanWOQEntity _modelOne ,List<string> idxList )
        {
            return _dao . Edit ( tableQuery ,_modelOne ,idxList );
        }

        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( )
        {
            return _dao . GetDataTableQuery ( );
        }

        /// <summary>
        /// 获取产品其它信息
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableProduct ( string productNum )
        {
            return _dao . GetDataTableProduct ( productNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOPI ( )
        {
            return _dao . GetDataTableOPI ( );
        }

        /// <summary>
        /// 获取批号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWeek ( string productNum )
        {
            return _dao . GetDataTableWeek ( productNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="idxList"></param>
        /// <param name="weekEnds"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( List<int> idxList ,string weekEnds,string productNum )
        {
            return _dao . GetDataTablePrint ( idxList ,weekEnds ,productNum );
        }


        /// <summary>
        /// 获取清单列表
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string weekEnds ,string productNum )
        {
            return _dao . getPrintOne ( weekEnds ,productNum );
        }

        /// <summary>
        /// 获取清单列表
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable getPrintTwo ( string productNum )
        {
            return _dao . getPrintTwo ( productNum );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="weekEnd"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public bool Exists_WeekProduct ( string weekEnd ,string productNum )
        {
            return _dao . Exists_WeekProduct ( weekEnd ,productNum );
        }

        /// <summary>
        /// 是否存在品号
        /// </summary>
        /// <param name="pinNum"></param>
        /// <returns></returns>
        public bool Exists ( string pinNum )
        {
            return _dao . Exists ( pinNum );
        }
    }
}
