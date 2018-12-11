using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class PaintBaseAndProductBll
    {
        private readonly Dao.PaintBaseAndProductDao dal=null;
        public PaintBaseAndProductBll ( )
        {
            dal = new Dao . PaintBaseAndProductDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return dal . getTableView ( strWhere );
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Delete ( List<string> idxList )
        {
            return dal . Delete ( idxList );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public bool Save ( DataTable tableView )
        {
            return dal . Save ( tableView );
        }

        /// <summary>
        /// 获取产品
        /// </summary>
        /// <returns></returns>
        public DataTable getTablePro ( )
        {
            return dal . getTablePro ( );
        }

        /// <summary>
        /// 获取此系列的
        /// </summary>
        /// <param name="xl"></param>
        /// <returns></returns>
        public DataTable getColumns ( string xl )
        {
            return dal . getColumns ( xl );
        }

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool SaveTable ( DataTable table )
        {
            return dal . SaveTable ( table );
        }

        }
}
