using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ProductionPaintDayDailyBll
    {
        private readonly Dao.ProductionPaintDayDailyDao dal=null;
        public ProductionPaintDayDailyBll ( )
        {
            dal = new Dao . ProductionPaintDayDailyDao ( );
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string columns )
        {
            return dal . GetDataTableOnly ( columns );
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Delete ( List<string> strList )
        {
            return dal . Delete ( strList );
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableQuery ( string strWhere )
        {
            return dal . GetDataTableQuery ( strWhere );
        }


        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="workShop"></param>
        /// <param name="dateTime"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string workShop ,string dateTime ,string person )
        {
            return dal . GetDataTablePrintOne ( workShop ,dateTime ,person );
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="workShop"></param>
        /// <param name="dateTime"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintTwo ( string workShop ,string dateTime ,string person )
        {
            return dal . GetDataTablePrintTwo ( workShop ,dateTime ,person );
        }

        /// <summary>
        /// 获取报工人
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableDWPerson ( )
        {
            return dal . GetDataTableDWPerson ( );
        }

    }
}
