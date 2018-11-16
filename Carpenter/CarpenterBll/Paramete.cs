using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace CarpenterBll
{
    public class Paramete
    {
        private string _key;
        private string _name;
        private string _value;
        private int _num;


        public string Key
        {
            get
            {
                return _key;
            }

            set
            {
                _key = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
            }
        }

        public int Num
        {
            get
            {
                return _num;
            }

            set
            {
                _num = value;
            }
        }

    }
}

