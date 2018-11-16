using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

namespace CarpenterBll . Bll
{
    public class DepartMentBll
    {
        private readonly Dao.DepartMentDao _dao=new Dao.DepartMentDao();
        
        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( int pid )
        {
            return _dao . GetDataTable ( pid );
        }

        /// <summary>
        /// 获取部门编号
        /// </summary>
        /// <returns></returns>
        public string GetStr ( )
        {
            return _dao . GetStr ( );
        }

        /// <summary>
        /// 删除具有相同编号和名称的部门
        /// </summary>
        /// <param name="nameOfDe"></param>
        /// <returns></returns>
        public bool Exists ( )
        {
            return _dao . Exists ( );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete ( string id )
        {
            return _dao . Delete ( id );
        }

        /// <summary>
        /// 注销记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Examine ( int id ,string state )
        {
            return _dao . Examine ( id ,state );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Save ( CarpenterEntity . DepartMentEntity _model )
        {
            return _dao . Save ( _model );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . DepartMentEntity _model )
        {
            return _dao . Edit ( _model );
        }

        /// <summary>
        /// 获取pid
        /// </summary>
        /// <param name="DEP001"></param>
        /// <returns></returns>
        public string GetDEP003 ( string DEP001 )
        {
            return _dao . GetDEP003 ( DEP001 );
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            return _dao . GetDataTable ( );
        }

        /// <summary>
        /// 获取是否工作中心
        /// </summary>
        /// <param name="numOfDepart"></param>
        /// <returns></returns>
        public bool signOfJob ( string numOfDepart )
        {
            return _dao . signOfJob ( numOfDepart );
        }

    }
}
