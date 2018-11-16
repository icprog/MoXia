using System . Collections . Generic;
using System . Data;
using System . Text;

namespace CarpenterBll . Bll
{
    public class EquipmentBll
    {
        private readonly Dao.EquipmentDao _dao=new Dao.EquipmentDao();

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            return _dao . GetDataTable ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="EQU001"></param>
        /// <returns></returns>
        public DataTable GetDataTableV ( string EQU001 )
        {
            return _dao . GetDataTableV ( EQU001 );
        }

        /// <summary>
        /// 获取设备编号
        /// </summary>
        /// <returns></returns>
        public string GetNum ( )
        {
            return _dao . GetNum ( );
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
        /// 获取工艺信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableArt ( )
        {
            return _dao . GetDataTableArt ( );

        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_modelOne"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Add ( CarpenterEntity . EquimentEntity _modelOne ,DataTable table )
        {
            return _dao . Add ( _modelOne ,table ); 
        }


        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_modelOne"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . EquimentEntity _modelOne ,DataTable table ,List<int> idxList)
        {
            return _dao . Edit ( _modelOne ,table ,idxList );
        }

        /// <summary>
        /// 是否注销
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Cancel ( int idx ,bool state )
        {
            return _dao . Cancel ( idx ,state );
        }

        /// <summary>
        /// 获取工作中心
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWork ( )
        {
            return _dao . GetDataTableWork ( );
        }

        /// <summary>
        /// 是否存在此设备编码
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Exists ( string oddNum )
        {
            return _dao . Exists ( oddNum );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool getIdxCount ( string oddNum )
        {
            return _dao . getIdxCount ( oddNum );
        }


        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="intList"></param>
        /// <returns></returns>
        public DataTable PrintOne ( List<int> intList )
        {
            return _dao . PrintOne ( intList );
        }

        }
}
