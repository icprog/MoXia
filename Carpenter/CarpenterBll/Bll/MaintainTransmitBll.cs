using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class MaintainTransmitBll
    {
        private readonly Dao.MaintainTransmitDao _dao=new Dao.MaintainTransmitDao();

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere ,string userNum)
        {
            return _dao . GetDataTable ( strWhere , userNum );
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable getTableOfView ( string userNum )
        {
            return _dao . getTableOfView ( userNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="mts001"></param>
        /// <returns></returns>
        public DataTable GetDataTableOne ( string mts001 )
        {
            return _dao . GetDataTableOne ( mts001 );
        }

        /// <summary>
        /// 获取联系单编号
        /// </summary>
        /// <returns></returns>
        public string contact ( )
        {
            return _dao . contact ( );
        }

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime getTime ( )
        {
            return _dao . getTime ( );
        }

        /// <summary>
        /// 增加记录
        /// </summary>
        /// <param name="_MTE"></param>
        /// <param name="_MTS"></param>
        /// <returns></returns>
        public bool Add ( CarpenterEntity . MaintainTransmitMTREntity _MTE ,CarpenterEntity . MaintainTransmitMTSEntity _MTS )
        {
            return _dao . Add ( _MTE ,_MTS );
        }

        /// <summary>
        /// 编辑结束标记
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public bool Edit ( string contact ,string sign )
        {
            return _dao . Edit ( contact ,sign );
        }


        /// <summary>
        /// 工作联系单
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfGZ (string userNum )
        {
            return _dao . GetDataTableOfGZ ( userNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public DataTable printOne ( string contact )
        {
            return _dao . printOne ( contact );
        }


        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable printTwo ( string strWhere )
        {
            return _dao . printTwo ( strWhere );
        }

    }
}
