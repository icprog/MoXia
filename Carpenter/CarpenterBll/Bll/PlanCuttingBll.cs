
using System;
using System . Collections . Generic;
using System . Data;

namespace CarpenterBll . Bll
{
    public class PlanCuttingBll
    {
        private readonly Dao.PlanCuttingDao _dao=new Dao.PlanCuttingDao();

        private readonly Dao.BomWorkPlanDao _daoBom=new Dao.BomWorkPlanDao();

        /// <summary>
        /// 替换直径符号等
        /// </summary>
        /// <returns></returns>
        public string editOther ( )
        {
            return _daoBom . editOther ( );
        }

        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <returns></returns>
        public DataTable GetDataTableOPI ( string weekEnds )
        {
            return _dao . GetDataTableOPI ( weekEnds );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableProduct ( string productNum )
        {
            return _dao . GetDataTableProduct ( productNum );
        }

        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableProduct ( )
        {
            return _dao . GetDataTableProduct ( );
        }

        /// <summary>
        /// 获取单头数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableQueryOne ( string strWhere )
        {
            return _dao . GetDataTableQueryOne ( strWhere );
        }

        /// <summary>
        /// 获取单身数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableQueryTwo ( string strWhere )
        {
            return _dao . GetDataTableQueryTwo ( strWhere );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="batchNum"></param>
        /// <returns></returns>
        public bool Delete ( string batchNum )
        {
            return _dao . Delete ( batchNum );
        }


        /// <summary>
        /// 进度跟踪表是否存在
        /// </summary>
        /// <param name="batchNum"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public bool ExistsPRS ( string batchNum ,string pinNum )
        {
            return _dao . ExistsPRS ( batchNum ,pinNum );
        }
        public bool ExistsPRS ( string batchNum   )
        {
            return _dao . ExistsPRS ( batchNum  );
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="barchNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Concell ( string barchNum ,bool state )
        {
            return _dao . Concell ( barchNum ,state );
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="barchNum"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Examine ( string barchNum ,bool state,DataTable tableQuery ,DateTime dtOne,string userName,string programName ,string  userNum)
        {
            return _dao . Examine ( barchNum ,state ,tableQuery ,dtOne ,userName ,programName ,userNum );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="batchNum"></param>
        /// <returns></returns>
        public bool Exists ( string batchNum )
        {
            return _dao . Exists ( batchNum );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_modelCut"></param>
        /// <param name="tableQuery"></param>
        /// <returns></returns>
        public bool Add ( CarpenterEntity . PlanCutCUTEntity _modelCut ,DataTable tableQuery )
        {
            return _dao . Add ( _modelCut ,tableQuery );
        }

        /// <summary>
        /// 获取id
        /// </summary>
        /// <param name="batchNum"></param>
        /// <returns></returns>
        public int id ( string batchNum )
        {
            return _dao . id ( batchNum );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="batchNum"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exists ( string batchNum ,int idx )
        {
            return _dao . Exists ( batchNum ,idx );
        }

        /// <summary>
        /// 编辑记录
        /// </summary>
        /// <param name="_modelCut"></param>
        /// <param name="tableQuery"></param>
        /// <returns></returns>
        public bool Edit ( CarpenterEntity . PlanCutCUTEntity _modelCut ,DataTable tableQuery )
        {
            return _dao . Edit ( _modelCut ,tableQuery );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable printOne ( string oddNum )
        {
            return _dao . printOne ( oddNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable printTwo ( string oddNum )
        {
            return _dao . printTwo ( oddNum );
        }

        /// <summary>
        /// generate the code from 
        /// </summary>
        /// <param name="strList"></param>
        /// <param name="weekEnds"></param>
        /// <returns></returns>
        public bool GenerateCodeAndPrint ( List<string> strList ,string weekEnds )
        {
            return _dao . GenerateCodeAndPrint ( strList ,weekEnds );
        }

        /// <summary>
        /// 获取清单列表
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string weekEnds ,string productNum )
        {
            return _daoBom . getPrintOne ( weekEnds ,productNum );
        }

        /// <summary>
        /// 获取清单列表
        /// </summary>
        /// <param name="productNum"></param>
        /// <returns></returns>
        public DataTable getPrintTwo ( string productNum )
        {
            return _daoBom . getPrintTwo ( productNum );
        }

        /// <summary>
        /// 获取打印传票的数据列表
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="idxStr"></param>
        /// <returns></returns>
        public DataTable printOne ( string weekEnds ,List<string> proList )
        {
            return _dao . printOne ( weekEnds ,proList );
        }

        /// <summary>
        /// 获取清单打印列表
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="typeOfPro"></param>
        /// <param name="typeOfWork"></param>
        /// <returns></returns>
        public DataTable getOrderTable ( string weekEnds ,string typeOfPro ,string typeOfWork ,string proNum )
        {
            return _dao . getOrderTable ( weekEnds ,typeOfPro ,typeOfWork ,proNum );
        }



        /// <summary>
        /// 获取板材清单打印列表
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="typeOfPro"></param>
        /// <param name="typeOfWork"></param>
        /// <returns></returns>
        public DataTable getOrderTable ( string weekEnds ,string typeOfPro ,string proNum )
        {
            return _dao . getOrderTable ( weekEnds ,typeOfPro ,proNum );
        }

        /// <summary>
        /// 获取产品类别
        /// </summary>
        /// <returns></returns>
        public List<string> getTypeOfPro ( )
        {
            return _dao . getTypeOfPro ( );
        }


        /// <summary>
        /// 获取封边清单打印列表
        /// </summary>
        /// <param name="weekEnds"></param>
        /// <param name="typeOfPro"></param>
        /// <returns></returns>
        public DataTable getPartFB ( string weekEnds ,string typeOfPro ,string proNum )
        {
            return _dao . getPartFB ( weekEnds ,typeOfPro ,proNum );
        }

    }
}
