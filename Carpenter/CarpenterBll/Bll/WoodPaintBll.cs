
using System . Data;


namespace CarpenterBll . Bll
{
    public class WoodPaintBll
    {
        private readonly Dao.WoodPaintDao _dao=new Dao.WoodPaintDao();

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfProduct ( string str )
        {
            return _dao . GetDataTableOfProduct ( str );
        }

        /// <summary>
        /// 获取油漆BOM表内容
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfPaint ( )
        {
            return _dao . GetDataTableOfPaint ( );
        }

        /// <summary>
        /// 获取木材数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfWood ( string strWhere )
        {
            return _dao . GetDataTableOfWood ( strWhere );
        }

        /// <summary>
        /// 获取油漆数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTablePaint ( string strWhere )
        {
            return _dao . GetDataTablePaint ( strWhere );
        }

        /// <summary>
        /// 获取油漆耗材表数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOne ( string strWhere )
        {
            return _dao . GetDataTableOne ( strWhere );
        }

        /// <summary>
        /// 删除一条信息
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string tableName )
        {
            return _dao . Delete ( idx ,tableName );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Cancellation ( int idx ,string tableName ,string columnName ,bool bol)
        {
            return _dao . Cancellation ( idx ,tableName ,columnName ,bol );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="keyName">主键名</param>
        /// <param name="keyPrimary">主键值</param>
        /// <returns></returns>
        public bool Exists ( string tableName ,string keyName ,string keyPrimary )
        {
            return _dao . Exists ( tableName ,keyName ,keyPrimary );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int AddWood ( CarpenterEntity . WOODEntity _model )
        {
            return _dao . AddWood ( _model );
        }

        /// <summary>
        /// 编辑木材BOM
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool EditWood ( CarpenterEntity . WOODEntity _model )
        {
            return _dao . EditWood ( _model );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int AddPaint ( CarpenterEntity . PAITEntity _model )
        {
            return _dao . AddPaint ( _model );
        }

        /// <summary>
        /// 编辑油漆BOM
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool EditPaint ( CarpenterEntity . PAITEntity _model )
        {
            return _dao . EditPaint ( _model );
        }


        /// <summary>
        /// 编辑油漆BOM
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool EditPaintWorkProcedure ( CarpenterEntity . PAIJEntity _model )
        {
            return _dao . EditPaintWorkProcedure ( _model );
        }

        /// <summary>
        /// 获取最大序号
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public string GetPaintOneNum ( string productName )
        {
            return _dao . GetPaintOneNum ( productName );
        }


        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Exists ( CarpenterEntity . PAIJEntity _model )
        {
            return _dao . Exists ( _model );
        }

        /// <summary>
        /// 增加油漆工序表
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int AddPaintWorkProcedure ( CarpenterEntity . PAIJEntity _model )
        {
            return _dao . AddPaintWorkProcedure ( _model );
        }


        /// <summary>
        /// 获取分类
        /// </summary>
        /// <param name="procudtNum"></param>
        /// <returns></returns>
        public string GetClass ( string procudtNum )
        {
            return _dao . GetClass ( procudtNum );
        }

    }
}
