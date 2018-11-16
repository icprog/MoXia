using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Linq;
using System . Text;

namespace CarpenterBll
{
    public static class ColumnValues
    {
        #region BOM清单  作业类型
        /// <summary>
        /// 抽屉
        /// </summary>
        public static string ct="抽斗";
        /// <summary>
        /// 实木
        /// </summary>
        public static string sm="实木";
        /// <summary>
        /// 拼板
        /// </summary>
        public static string pb="拼板";
        /// <summary>
        /// 包拼
        /// </summary>
        public static string bp="包拼";
        /// <summary>
        /// 实木包拼
        /// </summary>
        public static string smbp="实木包拼";
        /// <summary>
        /// 板材
        /// </summary>
        public static string bc="板材";
        /// <summary>
        /// 包芯
        /// </summary>
        public static string bx="包芯";
        /// <summary>
        /// 其它
        /// </summary>
        public static string qt="其他";
        /// <summary>
        /// BOM清单  作业类型
        /// </summary>
        public static string[] strWorkType=new string[] {sm,pb,bp,bc,bx,ct,qt,smbp};
        #endregion

        #region 工艺信息  工资类型
        /// <summary>
        /// 立方
        /// </summary>
        public  static string cube="立方";
        /// <summary>
        /// 长宽平方
        /// </summary>
        public  static string lwSquare="长宽平方";
        /// <summary>
        /// 长厚平方
        /// </summary>
        public static string lhSquare="长厚平方";
        /// <summary>
        /// 两面平方
        /// </summary>
        public static string lwlhSquare="两面平方";
        /// <summary>
        /// 长度
        /// </summary>
        public static string lenth="长度";
        /// <summary>
        /// 件数
        /// </summary>
        public static string pieceNum="件数";
        /// <summary>
        /// 次数
        /// </summary>
        public static string timeNum="次数";
        /// <summary>
        /// 长+长+宽
        /// </summary>
        public static string twoLenAndWith="长+长+宽";
        /// <summary>
        /// 长+宽+宽
        /// </summary>
        public static string lenAndTwoWith="长+宽+宽";
        /// <summary>
        /// 长+宽
        /// </summary>
        public static string lenAndWith="长+宽";
        /// <summary>
        /// 周长
        /// </summary>
        public static string twoLenAndTwoWith="(长+宽)*2";
        /// <summary>
        /// 工艺信息  工资类型
        /// </summary>
        public static string[] artSaType=new string[] {cube,lwSquare,lhSquare,lwlhSquare,lenth,pieceNum,timeNum,twoLenAndWith,lenAndTwoWith,lenAndWith,twoLenAndTwoWith};
        #endregion

        #region 工艺信息  区间标准
        /// <summary>
        /// 标准
        /// </summary>
        public static string space_standard="标准";
        /// <summary>
        /// 非标
        /// </summary>
        public static string space_nonstandard="非标";
        /// <summary>
        /// 工艺信息  区间标准
        /// </summary>
        public static string[] artSpaceType=new string[] { space_standard ,space_nonstandard};
        #endregion

        #region 备料工段
        /// <summary>
        /// 断料
        /// </summary>
        public static string bl_dl="断料";
        /// <summary>
        /// 修边
        /// </summary>
        public static string bl_xb="修边";
        /// <summary>
        /// 齿接
        /// </summary>
        public static string bl_cj="齿接";
        /// <summary>
        /// 拼板
        /// </summary>
        public static string bl_pb="拼板";
        /// <summary>
        /// 刨床
        /// </summary>
        public static string bl_pc="刨床";
        /// <summary>
        /// 备料工段
        /// </summary>
        public static string[] bl=new string[] { bl_dl ,bl_xb ,bl_cj,bl_pb ,bl_pc };
        #endregion

        #region 机加工工段
        /// <summary>
        /// 加工中心
        /// </summary>
        public static string jjg_jgzx="加工中心";
        /// <summary>
        /// 开榫钻孔
        /// </summary>
        public static string jjg_kszk="开榫钻孔";
        /// <summary>
        /// 倒圆
        /// </summary>
        public static string jjg_dy="倒圆";
        /// <summary>
        /// 机加工工段
        /// </summary>
        public static string[] jjg=new string[] {jjg_jgzx,jjg_kszk,jjg_dy};
        #endregion

        #region 油漆工段
        /// <summary>
        /// 底漆
        /// </summary>
        public static string yq_dq="底漆";
        /// <summary>
        /// 油磨
        /// </summary>
        public static string yq_ym="油磨";
        /// <summary>
        /// 修色
        /// </summary>
        public static string yq_xs="修色";
        /// <summary>
        /// 面漆
        /// </summary>
        public static string yq_mq="面漆";
        /// <summary>
        /// 软包
        /// </summary>
        public static string yq_rb="软包";
        /// <summary>
        /// 包装
        /// </summary>
        public static string yq_bz="包装";
        /// <summary>
        /// 油漆工段
        /// </summary>
        public static string[] yq=new string[] { yq_dq ,yq_ym,yq_xs ,yq_mq,yq_rb,yq_bz };
        #endregion

        //产品属性  常规或其他  
        //产品报工：常规按计划报工、其它按非计划报工
        public static string pro_cg=string.Empty;

    }
}
