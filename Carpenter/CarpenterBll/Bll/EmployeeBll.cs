using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class EmployeeBll
    {
        private readonly Dao.EmployeeDao _dao=new Dao.EmployeeDao();
        
        /// <summary>
        /// 获取人员编号
        /// </summary>
        /// <returns></returns>
        public string GetNum ( )
        {
            return _dao . GetNum ( );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete ( int id )
        {
            return _dao . Delete ( id );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Exists ( string num )
        {
            return _dao . Exists ( num );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( CarpenterEntity . EmployeeEntity _model )
        {
            return _dao . Add ( _model );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . EmployeeEntity _model )
        {
            return _dao . Edit ( _model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableAll ( )
        {
            return _dao . GetDataTableAll ( );
        }

        /// <summary>
        /// 编辑注销状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public bool Cancel ( int id ,bool sign )
        {
            return _dao . Cancel ( id ,sign );
        }

        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="userNum"></param>
        /// <param name="pwdMD5"></param>
        /// <returns></returns>
        public bool yesOrNoLogin ( string userName ,string pwdMD5 )
        {
            return _dao . yesOrNoLogin ( userName ,pwdMD5 );
        }

        /// <summary>
        /// 获取密码
        /// </summary>
        /// <param name="usernum"></param>
        /// <returns></returns>
        public string GetUserNum ( string username )
        {
            return _dao . GetUserNum ( username );
        }

        /// <summary>
        /// 更改密码
        /// </summary>
        /// <param name="numOfPerson"></param>
        /// <param name="pw"></param>
        /// <returns></returns>
        public bool EditPw ( string numOfPerson ,string pw )
        {
            return _dao . EditPw ( numOfPerson ,pw );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="intList"></param>
        /// <returns></returns>
        public DataTable printOne ( List<int> intList )
        {
            return _dao . printOne ( intList );
        }

    }
}
