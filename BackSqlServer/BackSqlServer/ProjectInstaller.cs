using System;
using System . Collections;
using System . Collections . Generic;
using System . ComponentModel;
using System . Configuration . Install;
using System . Linq;
using System . Threading . Tasks;

namespace BackSqlServer
{
    [RunInstaller ( true )]
    public partial class AAA :System . Configuration . Install . Installer
    {
        public AAA ( )
        {
            InitializeComponent ( );
        }
    }
}
