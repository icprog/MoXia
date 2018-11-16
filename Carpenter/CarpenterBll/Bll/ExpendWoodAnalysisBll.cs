using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ExpendWoodAnalysisBll
    {
        readonly private Dao.ExpendWoodAnalysisDao _dal=null;
        public ExpendWoodAnalysisBll ( )
        {
            _dal = new Dao . ExpendWoodAnalysisDao ( );
        }

        /// <summary>
        /// get the batch num from databse 
        /// </summary>
        /// <returns></returns>
        public DataTable getTableBatchNum ( )
        {
            return _dal . getTableBatchNum ( );
        }

        /// <summary>
        /// get datatable from database to view
        /// </summary>
        /// <param name="batchNum"></param>
        /// <returns></returns>
        public DataTable getTableView ( string batchNum )
        {
            return _dal . getTableView ( batchNum );
        }

        }
}
