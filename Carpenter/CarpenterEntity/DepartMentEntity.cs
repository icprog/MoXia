using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace CarpenterEntity
{
    public class DepartMentEntity
    {
        private int _idx;
        private string _dep001;
        private string _dep002;
        private int _dep003;
        private bool _dep004;

        public int IDX
        {
            get
            {
                return _idx;
            }
            set
            {
                _idx = value;
            }
        }

        /// <summary>
        /// 部门编号
        /// </summary>
        public string DEP001
        {
            get
            {
                return _dep001;
            }
            set
            {
                _dep001 = value;
            }
        }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DEP002
        {
            get
            {
                return _dep002;
            }
            set
            {
                _dep002 = value;
            }
        }

        /// <summary>
        /// pid
        /// </summary>
        public int DEP003
        {
            get
            {
                return _dep003;
            }
            set
            {
                _dep003 = value;
            }
        }

        /// <summary>
        /// 是否工作中心
        /// </summary>
        public bool DEP004
        {
            get
            {
                return _dep004;
            }
            set
            {
                _dep004 = value;
            }
        }

    }
}
