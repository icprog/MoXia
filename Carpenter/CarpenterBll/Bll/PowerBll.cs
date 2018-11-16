using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class PowerBll
    {
        private readonly Dao.PowerDao _dao=new Dao.PowerDao();

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetPerson ( )
        {
            return _dao . GetPerson ( );
        }

        /// <summary>
        /// 获取程序信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetProgram ( )
        {
            return _dao . GetProgram ( );
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
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( CarpenterEntity . PowerEntity _model )
        {
            return _dao . Add ( _model );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . PowerEntity _model )
        {
            return _dao . Edit ( _model );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Exsits ( CarpenterEntity . PowerEntity _model )
        {
            return _dao . Exsits ( _model );
        }


        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int EditIdx ( CarpenterEntity . PowerEntity _model )
        {
            return _dao . EditIdx ( _model );
        }

    }
}
