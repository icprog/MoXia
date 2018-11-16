using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ExportWoodBll
    {
        readonly private Dao.ExportWoodDao _dal=null;
        public ExportWoodBll ( )
        {
            _dal = new Dao . ExportWoodDao ( );
        }

        /// <summary>
        /// save data to moxwob
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Save ( DataTable table )
        {
            return _dal . Save ( table );
        }
    }
}
