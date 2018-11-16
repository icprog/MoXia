using System . Data;

namespace CarpenterBll . Bll
{
    public class MainBll
    {
        private readonly Dao.MainDao _dao=new Dao.MainDao();

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePower ( string userNum )
        {
            return _dao . GetDataTablePower ( userNum );
        }

        /// <summary>
        /// 获取按钮级权限
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableBtnPower ( string userNum ,string programNum )
        {
            return _dao . GetDataTableBtnPower ( userNum ,programNum );
        }
    }
}
