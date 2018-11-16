using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ProgramControlBll
    {
        private readonly Dao.ProgramControlDao _dao=new Dao.ProgramControlDao();


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            return _dao . GetDataTable ( );
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
        public int Add ( CarpenterEntity . ProgramControlEntity _model )
        {
            return _dao . Add ( _model );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . ProgramControlEntity _model )
        {
            return _dao . Edit ( _model );
        }

    }
}
