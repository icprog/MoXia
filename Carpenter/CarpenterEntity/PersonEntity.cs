using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

namespace CarpenterEntity
{
    public class PersonEntity
    {
        public PersonEntity ( )
        {
        }

        #region Model
        private int _id;
        private string _username;
        private string _password;
        private string _realname;
        private string _ename;
        private string _sex="男";
        private string _email;
        private string _phone;
        private string _telephone;
        private int _age=30;
        private string _department;
        private DateTime  _entrytime=DateTime.Now ;
        private string _roletype;
        private string _roledate;
        private DateTime  _createtime=DateTime .Now ;
        private string _createman;
        private DateTime  _modifytime=DateTime .Now ;
        private string _modifyman;
        private int _isdelete=0;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int id
        {
            set
            {
                _id = value;
            }
            get
            {
                return _id;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string username
        {
            set
            {
                _username = value;
            }
            get
            {
                return _username;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string password
        {
            set
            {
                _password = value;
            }
            get
            {
                return _password;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string realname
        {
            set
            {
                _realname = value;
            }
            get
            {
                return _realname;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ename
        {
            set
            {
                _ename = value;
            }
            get
            {
                return _ename;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sex
        {
            set
            {
                _sex = value;
            }
            get
            {
                return _sex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string email
        {
            set
            {
                _email = value;
            }
            get
            {
                return _email;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set
            {
                _phone = value;
            }
            get
            {
                return _phone;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string telephone
        {
            set
            {
                _telephone = value;
            }
            get
            {
                return _telephone;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int age
        {
            set
            {
                _age = value;
            }
            get
            {
                return _age;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string department
        {
            set
            {
                _department = value;
            }
            get
            {
                return _department;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime entrytime
        {
            set
            {
                _entrytime = value;
            }
            get
            {
                return _entrytime;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string roletype
        {
            set
            {
                _roletype = value;
            }
            get
            {
                return _roletype;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string roledate
        {
            set
            {
                _roledate = value;
            }
            get
            {
                return _roledate;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime createtime
        {
            set
            {
                _createtime = value;
            }
            get
            {
                return _createtime;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string createman
        {
            set
            {
                _createman = value;
            }
            get
            {
                return _createman;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime modifytime
        {
            set
            {
                _modifytime = value;
            }
            get
            {
                return _modifytime;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string modifyman
        {
            set
            {
                _modifyman = value;
            }
            get
            {
                return _modifyman;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isdelete
        {
            set
            {
                _isdelete = value;
            }
            get
            {
                return _isdelete;
            }
        }
        #endregion Model

    }
}
