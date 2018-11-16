using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace CarpenterEntity
{
    public class PaintBaseAndProductEntity
    {
        private int _idx;
        private string _pba001;
        private string _pba002;
        private string _pba003;
        private decimal? _pba004;
        private string _pba005;
        private string _pba006;
        
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
        /// 品号
        /// </summary>
        public string PBA001
        {
            set
            {
                _pba001 = value;
            }
            get
            {
                return _pba001;
            }
        }
        /// <summary>
        /// 品名
        /// </summary>
        public string PBA002
        {
            set
            {
                _pba002 = value;
            }
            get
            {
                return _pba002;
            }
        }
        /// <summary>
        /// 油漆名称
        /// </summary>
        public string PBA003
        {
            set
            {
                _pba003 = value;
            }
            get
            {
                return _pba003;
            }
        }
        /// <summary>
        /// 油漆平方
        /// </summary>
        public decimal? PBA004
        {
            set
            {
                _pba004 = value;
            }
            get
            {
                return _pba004;
            }
        }
        /// <summary>
        /// 系列
        /// </summary>
        public string PBA005
        {
            set
            {
                _pba005 = value;
            }
            get
            {
                return _pba005;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBA006
        {
            set
            {
                _pba006 = value;
            }
            get
            {
                return _pba006;
            }
        }
    }
}
