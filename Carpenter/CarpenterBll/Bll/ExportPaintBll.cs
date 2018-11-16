using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class ExportPaintBll
    {
        readonly private Dao.ExportPaintDao _dal=null;
        public ExportPaintBll ( )
        {
            _dal = new Dao . ExportPaintDao ( );
        }

        /// <summary>
        /// save paint base data to database
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool SavePaintBase ( DataTable table )
        {
            return _dal . SavePaintBase ( table );
        }

    }
}
