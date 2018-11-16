using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace CarpenterBll . Bll
{
    public class AssembleWorkOrderBll
    {
        private readonly Dao.AssembleWorkOrderDao dal=null;
        private readonly Dao.PlanAssembleDayDailyDao dayDaily=null;
        public AssembleWorkOrderBll ( )
        {
            dal = new Dao . AssembleWorkOrderDao ( );
            dayDaily = new Dao . PlanAssembleDayDailyDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable tableViewTwo ( string oddNum )
        {
            return dal . tableViewTwo ( oddNum );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public CarpenterEntity . AssembleWorkOrderAWOEntity GetList ( string oddNum )
        {
            return dal . GetList ( oddNum );
        }

        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <returns></returns>
        public DataTable table ( )
        {
            return dal . table ( );
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            return dal . Delete ( oddNum );
        }

        /// <summary>
        /// 获取剩余数量
        /// </summary>
        /// <param name="week"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public int GetNum ( string week ,string productNum,string oddNum )
        {
            return dal . GetNum ( week ,productNum ,oddNum );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_awo"></param>
        /// <param name="strList"></param>
        /// <param name="getHash"></param>
        /// <returns></returns>
        public bool Save ( Hashtable hsTable,DataTable tableView )
        {
            return dal . Save ( hsTable ,tableView );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetTableQueryPerson ( )
        {
            return dal . GetTableQueryPerson ( );
        }

        /// <summary>
        /// 获取剩余数量
        /// </summary>
        /// <param name="week"></param>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public DataTable proNum ( List<string> strIdx )
        {
            return dal . proNum ( strIdx );
        }

        /// <summary>
        /// 获取剩余数量
        /// </summary>
        /// <param name="week"></param>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public int proNum ( string week ,string proNum ,string oddNum )
        {
            return dal . proNum ( week ,proNum ,oddNum );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_awo"></param>
        /// <param name="tableOne"></param>
        /// <param name="tableTwo"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . AssembleWorkOrderAWOEntity _awo  ,DataTable tableTwo )
        {
            return dal . Edit ( _awo  ,tableTwo );
        }


        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="programName"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examine ( string oddNum ,string programName ,bool state )
        {
            return dal . Examine ( oddNum ,programName ,state );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Cancellation ( string oddNum ,bool state )
        {
            return dal . Cancellation ( oddNum ,state );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable printOne ( string oddNum  )
        {
            return dal . printOne ( oddNum  );
        }

        public DataTable printTwo ( string oddNum )
        {
            return dal . printTwo ( oddNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable printTwo ( string oddNum,List<string> strList )
        {
            return dal . printTwo ( oddNum ,strList );
        }

        /// <summary>
        /// 获取报工列表
        /// </summary>
        /// <param name="week"></param>
        /// <param name="produceNum"></param>
        /// <returns></returns>
        public DataTable tableOne ( string week ,string produceNum )
        {
            return dal . tableOne ( week ,produceNum );
        }

        /// <summary>
        /// 组装报工
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ZDailyWork ( DataTable table ,bool plan ,Hashtable hasTable ,DateTime dt )
        {
            return dayDaily . ZDailyWork ( table ,plan ,hasTable ,dt );
        }

    }
}
