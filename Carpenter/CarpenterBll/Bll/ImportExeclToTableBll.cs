using System . Data;

namespace CarpenterBll . Bll
{
    public class ImportExeclToTableBll
    {
        private readonly Dao.ImportExeclToTableDao dal=null;

        public ImportExeclToTableBll ( )
        {
            dal = new Dao . ImportExeclToTableDao ( );
        }

        /// <summary>
        /// 导入数据到库
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public int Add ( DataTable table )
        {
            return dal . Add ( table );
        }

        /// <summary>
        /// 保存图片到指定文件夹下面
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="savePath"></param>
        /// <returns></returns>
        public bool ExeclToImage ( string filePath ,string savePath ,DataTable table ,string Version )
        {
            return dal . ExeclToImage ( filePath ,savePath ,table ,Version );
        }


        /// <summary>
        /// 导入清单
        /// </summary>
        /// <param name="table"></param>
        /// <returns>1：清单上面的产品不存在于产品信息  2：部分零件没有规格 3：正常</returns>
        public int ExeclToOrder ( DataTable table )
        {
            return dal . ExeclToOrder ( table );
        }

    }
}
