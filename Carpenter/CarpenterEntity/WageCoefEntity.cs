using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace CarpenterEntity
{
    public class WageCoefEntity
    {
        private int _idx;
        private string _wac001;
        private string _wac002;
        private int? _wac003;
        private string _wac004;
        private string _wac005;
        private decimal? _wac006;
        private decimal? _wac007;
        private string _wac008;
        private decimal? _wac009;
        private string _wac010;
        
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
        /// 设备编号
        /// </summary>
        public string WAC001
        {
            set
            {
                _wac001 = value;
            }
            get
            {
                return _wac001;
            }
        }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string WAC002
        {
            set
            {
                _wac002 = value;
            }
            get
            {
                return _wac002;
            }
        }
        /// <summary>
        /// 工资系数分组
        /// </summary>
        public int? WAC003
        {
            set
            {
                _wac003 = value;
            }
            get
            {
                return _wac003;
            }
        }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string WAC004
        {
            set
            {
                _wac004 = value;
            }
            get
            {
                return _wac004;
            }
        }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string WAC005
        {
            set
            {
                _wac005 = value;
            }
            get
            {
                return _wac005;
            }
        }
        /// <summary>
        /// 工资系数
        /// </summary>
        public decimal? WAC006
        {
            set
            {
                _wac006 = value;
            }
            get
            {
                return _wac006;
            }
        }
        /// <summary>
        /// 当月组别工资(汇总)
        /// </summary>
        public decimal? WAC007
        {
            set
            {
                _wac007 = value;
            }
            get
            {
                return _wac007;
            }
        }
        /// <summary>
        /// 年月
        /// </summary>
        public string WAC008
        {
            set
            {
                _wac008 = value;
            }
            get
            {
                return _wac008;
            }
        }
        /// <summary>
        /// 总工资
        /// </summary>
        public decimal? WAC009
        {
            set
            {
                _wac009 = value;
            }
            get
            {
                return _wac009;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string WAC010
        {
            set
            {
                _wac010 = value;
            }
            get
            {
                return _wac010;
            }
        }

    }
}
