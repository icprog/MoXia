using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace CarpenterEntity
{
    public class OutPutValueEntity
    {
        private int _idx;
        private int? _opv001;
        private int? _opv002;
        private int? _opv003;
        private decimal? _opv004;
        private decimal? _opv005;
        private decimal? _opv006;
        private decimal? _opv007;
        private decimal? _opv008;
        private decimal? _opv009;
        private decimal? _opv010;
        private decimal? _opv011;
        private int? _opvtest;

        /// <summary>
        /// 
        /// </summary>
        public int idx
        {
            set
            {
                _idx = value;
            }
            get
            {
                return _idx;
            }
        }
        /// <summary>
        /// 年
        /// </summary>
        public int? OPV001
        {
            set
            {
                _opv001 = value;
            }
            get
            {
                return _opv001;
            }
        }
        /// <summary>
        /// 月
        /// </summary>
        public int? OPV002
        {
            set
            {
                _opv002 = value;
            }
            get
            {
                return _opv002;
            }
        }
        /// <summary>
        /// 日
        /// </summary>
        public int? OPV003
        {
            set
            {
                _opv003 = value;
            }
            get
            {
                return _opv003;
            }
        }
        /// <summary>
        /// 备料
        /// </summary>
        public decimal? OPV004
        {
            set
            {
                _opv004 = value;
            }
            get
            {
                return _opv004;
            }
        }
        /// <summary>
        /// 机加工
        /// </summary>
        public decimal? OPV005
        {
            set
            {
                _opv005 = value;
            }
            get
            {
                return _opv005;
            }
        }
        /// <summary>
        /// 组装
        /// </summary>
        public decimal? OPV006
        {
            set
            {
                _opv006 = value;
            }
            get
            {
                return _opv006;
            }
        }
        /// <summary>
        /// 底漆
        /// </summary>
        public decimal? OPV007
        {
            set
            {
                _opv007 = value;
            }
            get
            {
                return _opv007;
            }
        }
        /// <summary>
        /// 油墨
        /// </summary>
        public decimal? OPV008
        {
            set
            {
                _opv008 = value;
            }
            get
            {
                return _opv008;
            }
        }
        /// <summary>
        /// 面漆
        /// </summary>
        public decimal? OPV009
        {
            set
            {
                _opv009 = value;
            }
            get
            {
                return _opv009;
            }
        }
        /// <summary>
        /// 包装
        /// </summary>
        public decimal? OPV010
        {
            set
            {
                _opv010 = value;
            }
            get
            {
                return _opv010;
            }
        }
        /// <summary>
        /// 断料
        /// </summary>
        public decimal? OPV011
        {
            set
            {
                _opv011 = value;
            }
            get
            {
                return _opv011;
            }
        }

        /// <summary>
        /// 测试
        /// </summary>
        public int? Opvtest
        {
            get
            {
                return _opvtest;
            }

            set
            {
                _opvtest = value;
            }
        }
    }
}
