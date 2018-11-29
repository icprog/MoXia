using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace CarpenterEntity
{
    public class ProPartArtEntity
    {
        private int idx;
        private string _ppa001;
        private string _ppa002;
        private string _ppa003;
        private string _ppa004;
        private string _ppa005;
        private string _ppa006;
        private string _ppa007;
        private string _ppa008;

        public int Idx
        {
            get
            {
                return idx;
            }

            set
            {
                idx = value;
            }
        }
        /// <summary>
        /// 品号
        /// </summary>
        public string PPA001
        {
            get
            {
                return _ppa001;
            }

            set
            {
                _ppa001 = value;
            }
        }
        /// <summary>
        /// 品名
        /// </summary>
        public string PPA002
        {
            get
            {
                return _ppa002;
            }

            set
            {
                _ppa002 = value;
            }
        }
        /// <summary>
        /// 零件编号
        /// </summary>
        public string PPA003
        {
            get
            {
                return _ppa003;
            }

            set
            {
                _ppa003 = value;
            }
        }
        /// <summary>
        /// 零件名称
        /// </summary>
        public string PPA004
        {
            get
            {
                return _ppa004;
            }

            set
            {
                _ppa004 = value;
            }
        }
        /// <summary>
        /// 工序编号
        /// </summary>
        public string PPA005
        {
            get
            {
                return _ppa005;
            }

            set
            {
                _ppa005 = value;
            }
        }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string PPA006
        {
            get
            {
                return _ppa006;
            }

            set
            {
                _ppa006 = value;
            }
        }
        /// <summary>
        /// 条码
        /// </summary>
        public string PPA007
        {
            get
            {
                return _ppa007;
            }

            set
            {
                _ppa007 = value;
            }
        }
        /// <summary>
        /// 零件规格
        /// </summary>
        public string PPA008
        {
            get
            {
                return _ppa008;
            }

            set
            {
                _ppa008 = value;
            }
        }
    }
}
