
using System . Data;
using System . Text;

namespace CarpenterBll . Bll
{
    public class OPIBll
    {
        private readonly Dao.OPIDao _dao=new Dao.OPIDao();

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOne ( )
        {
            return _dao . GetDataTableOne ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string fileName )
        {
            return _dao . GetDataTableOnly ( fileName );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            return _dao . GetDataTable ( strWhere );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            return _dao . Delete ( idx );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Cancellation ( int idx ,bool state )
        {
            return _dao . Cancellation ( idx ,state );
        }

        /// <summary>
        /// 是否存在此品号
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public bool Exists ( string productNum )
        {
            return _dao . Exists ( productNum );
        }


        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( CarpenterEntity . OPIEntity _model )
        {
            return _dao . Add ( _model );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . OPIEntity _model )
        {
            return _dao . Edit ( _model );
        }

        /// <summary>
        /// 获取品号
        /// </summary>
        /// <returns></returns>
        public string GetNum ( )
        {
            return _dao . GetNum ( );
        }

        /// <summary>
        /// 是否在BOM清单或开料周计划中存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exists ( int idx )
        {
            return _dao . Exists ( idx );
        }

    }
}
