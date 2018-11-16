using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Carpenter . Query
{
    public partial class FormControlOne :FormBase
    { 
        string sign=string.Empty;DataTable tableView;
        List<string> strList=new List<string>();
        Carpenter.ControlUser.workShopSectionChoise workSection;
        Carpenter.ControlUser . BLDailyWork dailyWork;
        Carpenter.ControlUser.JDailyWork jDailyWork;
        Carpenter.ControlUser.ZDailyWork zDailyWork;
        Carpenter.ControlUser.PDailyWork pDailyWork;
        Carpenter.ControlUser.ZDayDailyWork zDayDailyWork;
        
        bool plan=false;
        
        public FormControlOne ( string text ,string sign ,DataTable table ,List<string> strList)
        {
            InitializeComponent ( );
            
            this . Text = text;
            this . sign = sign;
            this . tableView = table;
            this . strList = strList;

            if ( this . Text . Contains ( "备料" ) )
            {
                workSection = new ControlUser . workShopSectionChoise ( );
                this . Controls . Add ( workSection );
                foreach ( string s in CarpenterBll . ColumnValues . bl )
                {
                    workSection . comWorkShip . Items . Add ( s );
                }
                if ( this . Text . Equals ( "备料日计划计划报工" ) )
                    plan = true;
                else
                    plan = false;
                this . ClientSize = new System . Drawing . Size ( 251 ,114 );
                this . FormBorderStyle = FormBorderStyle . FixedSingle;
                this . MaximizeBox = false;
                workSection . btnOk . Click += BtnOk_Click1;
                workSection . btnCancel . Click += BtnCancel_Click1;
            }
           else if ( this . Text . Contains ( "机加工" ) )
            {
                workSection = new ControlUser . workShopSectionChoise ( );
                this . Controls . Add ( workSection );
                foreach ( string s in CarpenterBll . ColumnValues .jjg )
                {
                    workSection . comWorkShip . Items . Add ( s );
                }
                if ( this . Text . Equals ( "机加工日计划计划报工" ) )
                    plan = true;
                else
                    plan = false;

                this . ClientSize = new System . Drawing . Size ( 251 ,114 );
                this . FormBorderStyle = FormBorderStyle . FixedSingle;
                this . MaximizeBox = false;
                workSection . btnOk . Click += BtnOk_Click1;
                workSection . btnCancel . Click += BtnCancel_Click1;
            }
            else if ( this . Text . Contains ( "组装派工" ) )
            {
                if ( this . Text . Equals ( "组装派工计划报工" ) )
                    zDailyWork = new ControlUser . ZDailyWork ( tableView ,true );
                else
                    zDailyWork = new ControlUser . ZDailyWork ( tableView ,false );

                this . Controls . Add ( zDailyWork );
                zDailyWork . Dock = DockStyle . Fill;
                zDailyWork . btnOk . Click += BtnOk_Click3;
                zDailyWork . btnCancel . Click += BtnCancel_Click1;
            }
            else if ( this . Text . Contains ( "组装报工" ) )
            {
                if ( this . Text . Equals ( "组装报工预排日计划" ) )
                    zDayDailyWork = new ControlUser . ZDayDailyWork ( true ,strList );
                else
                    zDayDailyWork = new ControlUser . ZDayDailyWork ( false ,strList );

                this . Controls . Add ( zDayDailyWork );
                zDayDailyWork . Dock = DockStyle . Fill;
                zDayDailyWork . btnOk . Click += BtnOk_Click5;
                zDayDailyWork . btnCancel . Click += BtnCancel_Click1;
            }
            else if ( this . Text . Contains ( "油漆" ) )
            {
                workSection = new ControlUser . workShopSectionChoise ( );
                this . Controls . Add ( workSection );
                foreach ( string s in CarpenterBll . ColumnValues . yq )
                {
                    workSection . comWorkShip . Items . Add ( s );
                }
                //workSection . comWorkShip . Items . Add ( "包装" );
                workSection . comWorkShip . Items . Remove ( CarpenterBll . ColumnValues . yq_rb );
                if ( this . Text . Equals ( "油漆日计划计划报工" ) )
                {
                    //workSection . comWorkShip . Items . Add ( CarpenterBll . ColumnValues . yq_bz );
                    plan = true;
                }
                else
                    plan = false;
                this . ClientSize = new System . Drawing . Size ( 251 ,114 );
                this . FormBorderStyle = FormBorderStyle . FixedSingle;
                this . MaximizeBox = false;
                workSection . btnOk . Click += BtnOk_Click1;
                workSection . btnCancel . Click += BtnCancel_Click1;
            }
        }
        
        #region ZDailyWork

        private void BtnOk_Click3 ( object sender ,EventArgs e )
        {
            bool isOk = zDailyWork . getisOk;
            if ( isOk == true )
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }

        #endregion

        #region PDailyWork

        private void BtnOk_Click4 ( object sender ,EventArgs e )
        {
            // workNum = 0,
            bool isOk = true;
            int
                dlNum = 0, dlNumSum = 0, planNum = 0;
            DataRow row;
            for ( int i = 0 ; i < pDailyWork . gridView1 . DataRowCount ; i++ )
            {
                row = pDailyWork . gridView1 . GetDataRow ( i );
                row . ClearErrors ( );
                //workNum = string . IsNullOrEmpty ( row [ "PDP025" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PDP025" ] . ToString ( ) );
                planNum = string . IsNullOrEmpty ( row [ "PWE007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PWE007" ] . ToString ( ) );
                dlNum = string . IsNullOrEmpty ( row [ "DQ" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "DQ" ] . ToString ( ) );
                dlNumSum = string . IsNullOrEmpty ( row [ "PWF007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PWF007" ] . ToString ( ) );
                //if ( workNum < dlNum + dlNumSum )
                //{
                //    row . SetColumnError ( "DQ" ,"底漆数量不允许多于生产数量" );
                //    isOk = false;
                //    break;
                //}
                if ( planNum < dlNum + dlNumSum )
                {
                    row . SetColumnError ( "DQ" ,"底漆数量不允许多于计划数量" );
                    isOk = false;
                    break;
                }
                dlNum = string . IsNullOrEmpty ( row [ "YM" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "YM" ] . ToString ( ) );
                dlNumSum = string . IsNullOrEmpty ( row [ "PWF008" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PWF008" ] . ToString ( ) );
                //if ( workNum < dlNum + dlNumSum )
                //{
                //    row . SetColumnError ( "YM" ,"油磨数量不允许多于生产数量" );
                //    isOk = false;
                //    break;
                //}
                if ( planNum < dlNum + dlNumSum )
                {
                    row . SetColumnError ( "YM" ,"油磨数量不允许多于计划数量" );
                    isOk = false;
                    break;
                }
                dlNum = string . IsNullOrEmpty ( row [ "XS" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "XS" ] . ToString ( ) );
                dlNumSum = string . IsNullOrEmpty ( row [ "PWF009" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PWF009" ] . ToString ( ) );
                //if ( workNum < dlNum + dlNumSum )
                //{
                //    row . SetColumnError ( "XS" ,"修色数量不允许多于生产数量" );
                //    isOk = false;
                //    break;
                //}
                if ( planNum < dlNum + dlNumSum )
                {
                    row . SetColumnError ( "XS" ,"修色数量不允许多于计划数量" );
                    isOk = false;
                    break;
                }
                dlNum = string . IsNullOrEmpty ( row [ "MQ" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "MQ" ] . ToString ( ) );
                dlNumSum = string . IsNullOrEmpty ( row [ "PWF010" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PWF010" ] . ToString ( ) );
                //if ( workNum < dlNum + dlNumSum )
                //{
                //    row . SetColumnError ( "MQ" ,"面漆数量不允许多于生产数量" );
                //    isOk = false;
                //    break;
                //}
                if ( planNum < dlNum + dlNumSum )
                {
                    row . SetColumnError ( "MQ" ,"面漆数量不允许多于计划数量" );
                    isOk = false;
                    break;
                }
                dlNum = string . IsNullOrEmpty ( row [ "RB" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "RB" ] . ToString ( ) );
                dlNumSum = string . IsNullOrEmpty ( row [ "PWF011" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PWF011" ] . ToString ( ) );
                //if ( workNum < dlNum + dlNumSum )
                //{
                //    row . SetColumnError ( "RB" ,"软包数量不允许多于生产数量" );
                //    isOk = false;
                //    break;
                //}
                if ( planNum < dlNum + dlNumSum )
                {
                    row . SetColumnError ( "RB" ,"软包数量不允许多于计划数量" );
                    isOk = false;
                    break;
                }
                dlNum = string . IsNullOrEmpty ( row [ "BZ" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "BZ" ] . ToString ( ) );
                dlNumSum = string . IsNullOrEmpty ( row [ "PWF016" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PWF016" ] . ToString ( ) );
                if ( planNum < dlNum + dlNumSum )
                {
                    row . SetColumnError ( "BZ" ,"包装数量不允许多于生产数量" );
                    isOk = false;
                    break;
                }
            }
            if ( isOk == true )
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }
        public DataTable getDataDailyP
        {
            get
            {
                return pDailyWork . getTable;
            }
        }
        public string getStr
        {
            get
            {
                return pDailyWork . getStr;
            }
        }

        #endregion
        
        #region workSection

        private void BtnCancel_Click1 ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }
        private void BtnOk_Click1 ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( workSection . comWorkShip . Text ) )
            {
                XtraMessageBox . Show ( "请选择报工工段" );
                return;
            }
            this . Controls . Clear ( );
            if ( this . sign . Equals ( "BLDailyWork" ) )
            {
                dailyWork = new ControlUser . BLDailyWork ( plan ,workSection . comWorkShip . Text ,strList );
                this . Controls . Add ( dailyWork );
                this . Location = new System . Drawing . Point ( 100 ,100 );
                this . ClientSize = new System . Drawing . Size ( 1237 ,460 );
                this . FormBorderStyle = FormBorderStyle . Sizable;
                this . MaximizeBox = true;
                dailyWork . Dock = System . Windows . Forms . DockStyle . Fill;
                dailyWork . btnOk . Click += BtnOk_Click;
                dailyWork . btnCancel . Click += BtnCancel_Click;
            }
            if ( this . sign . Equals ( "JDailyWork" ) )
            {
                jDailyWork = new ControlUser . JDailyWork ( plan ,workSection . comWorkShip . Text ,strList );
                this . Controls . Add ( jDailyWork );
                this . Location = new System . Drawing . Point ( 100 ,100 );
                this . ClientSize = new System . Drawing . Size ( 1237 ,460 );
                this . FormBorderStyle = FormBorderStyle . Sizable;
                this . MaximizeBox = true;
                jDailyWork . Dock = System . Windows . Forms . DockStyle . Fill;
                jDailyWork . btnOk . Click += BtnOk_Click2;
                jDailyWork . btnCancel . Click += BtnCancel_Click;
            }
            if ( this . sign . Equals ( "PDailyWork" ) )
            {
                pDailyWork = new ControlUser . PDailyWork ( plan ,workSection . comWorkShip . Text ,strList );
                this . Controls . Add ( pDailyWork );
                this . Location = new System . Drawing . Point ( 100 ,100 );
                this . ClientSize = new System . Drawing . Size ( 1237 ,460 );
                this . FormBorderStyle = FormBorderStyle . Sizable;
                this . MaximizeBox = true;
                pDailyWork . Dock = System . Windows . Forms . DockStyle . Fill;
                pDailyWork . btnOk . Click += BtnOk_Click4;
                pDailyWork . btnCancel . Click += BtnCancel_Click;
            }
        }

        #endregion

        #region JDailyWork

        private void BtnOk_Click2 ( object sender ,EventArgs e )
        {
            //workNum = 0,
            bool isOk = true;
            int 
                dlNum = 0, dlNumSum = 0,
                xbNum = 0 ;
            DataRow row;
            for ( int i = 0 ; i < jDailyWork . gridView1 . DataRowCount ; i++ )
            {
                row = jDailyWork . gridView1 . GetDataRow ( i );
                row . ClearErrors ( );
                //workNum = string . IsNullOrEmpty ( row [ "PST028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PST028" ] . ToString ( ) );
                xbNum = string . IsNullOrEmpty ( row [ "PMX007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PMX007" ] . ToString ( ) );
                dlNum = string . IsNullOrEmpty ( row [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "DL" ] . ToString ( ) );
                dlNumSum = string . IsNullOrEmpty ( row [ "PMY007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PMY007" ] . ToString ( ) );
                //if ( workNum < dlNum + dlNumSum )
                //{
                //    row . SetColumnError ( "DL" ,"加工中心数量不允许多于生产数量" );
                //    isOk = false;
                //    break;
                //}
                if ( xbNum < dlNum + dlNumSum )
                {
                    row . SetColumnError ( "DL" ,"加工中心数量不允许多于计划数量" );
                    isOk = false;
                    break;
                }
                dlNum = string . IsNullOrEmpty ( row [ "XB" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "XB" ] . ToString ( ) );
                dlNumSum = string . IsNullOrEmpty ( row [ "PMY008" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PMY008" ] . ToString ( ) );
                //if ( workNum < dlNum + dlNumSum )
                //{
                //    row . SetColumnError ( "XB" ,"开榫钻孔数量不允许多于生产数量" );
                //    isOk = false;
                //    break;
                //}
                if ( xbNum < dlNum + dlNumSum )
                {
                    row . SetColumnError ( "XB" ,"开榫钻孔数量不允许多于计划数量" );
                    isOk = false;
                    break;
                }
                dlNum = string . IsNullOrEmpty ( row [ "CJ" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "CJ" ] . ToString ( ) );
                dlNumSum = string . IsNullOrEmpty ( row [ "PMY009" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PMY009" ] . ToString ( ) );
                //if ( workNum < dlNum + dlNumSum )
                //{
                //    row . SetColumnError ( "CJ" ,"倒圆数量不允许多于生产数量" );
                //    isOk = false;
                //    break;
                //}
                if ( xbNum < dlNum + dlNumSum )
                {
                    row . SetColumnError ( "CJ" ,"倒圆数量不允许多于计划数量" );
                    isOk = false;
                    break;
                }
            }
            if ( isOk == true )
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }
        public DataTable getDataDailyJ
        {
            get
            {
                return jDailyWork . getTable;
            }
        }

        #endregion

        #region BLDailyWork

        private void BtnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }
        private void BtnOk_Click ( object sender ,EventArgs e )
        {
            // workNum = 0,
            bool isOk = true;
            int
                dlNum = 0, dlNumSum = 0,
                planNum = 0;
            DataRow row;
            for ( int i = 0 ; i < dailyWork . gridView1 . DataRowCount ; i++ )
            {
                row = dailyWork . gridView1 . GetDataRow ( i );
                row . ClearErrors ( );
                //workNum = string . IsNullOrEmpty ( row [ "PST028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PST028" ] . ToString ( ) );
                planNum = string . IsNullOrEmpty ( row [ "PSX007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PSX007" ] . ToString ( ) );
                dlNum = string . IsNullOrEmpty ( row [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "DL" ] . ToString ( ) );
                dlNumSum = string . IsNullOrEmpty ( row [ "PDW007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PDW007" ] . ToString ( ) );
                //if ( workNum < dlNum + dlNumSum )
                //{
                //    row . SetColumnError ( "DL" ,"断料数量不允许多于生产数量" );
                //    isOk = false;
                //    break;
                //}
                if ( planNum < dlNum + dlNumSum )
                {
                    row . SetColumnError ( "DL" ,"断料数量不允许多于计划数量" );
                    isOk = false;
                    break;
                }
                dlNum = string . IsNullOrEmpty ( row [ "XB" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "XB" ] . ToString ( ) );
                dlNumSum = string . IsNullOrEmpty ( row [ "PDW008" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PDW008" ] . ToString ( ) );
                //if ( workNum < dlNum + dlNumSum )
                //{
                //    row . SetColumnError ( "XB" ,"修边数量不允许多于生产数量" );
                //    isOk = false;
                //    break;
                //}
                if ( planNum < dlNum + dlNumSum )
                {
                    row . SetColumnError ( "XB" ,"修边数量不允许多于计划数量" );
                    isOk = false;
                    break;
                }
                dlNum = string . IsNullOrEmpty ( row [ "CJ" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "CJ" ] . ToString ( ) );
                dlNumSum = string . IsNullOrEmpty ( row [ "PDW009" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PDW009" ] . ToString ( ) );
                //if ( workNum < dlNum + dlNumSum )
                //{
                //    row . SetColumnError ( "CJ" ,"齿接数量不允许多于生产数量" );
                //    isOk = false;
                //    break;
                //}
                if ( planNum < dlNum + dlNumSum )
                {
                    row . SetColumnError ( "CJ" ,"齿接数量不允许多于计划数量" );
                    isOk = false;
                    break;
                }
                dlNum = string . IsNullOrEmpty ( row [ "PB" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PB" ] . ToString ( ) );
                dlNumSum = string . IsNullOrEmpty ( row [ "PDW010" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PDW010" ] . ToString ( ) );
                //if ( workNum < dlNum + dlNumSum )
                //{
                //    row . SetColumnError ( "PB" ,"拼板数量不允许多于生产数量" );
                //    isOk = false;
                //    break;
                //}
                if ( planNum < dlNum + dlNumSum )
                {
                    row . SetColumnError ( "PB" ,"拼板数量不允许多于计划数量" );
                    isOk = false;
                    break;
                }
                dlNum = string . IsNullOrEmpty ( row [ "PC" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PC" ] . ToString ( ) );
                dlNumSum = string . IsNullOrEmpty ( row [ "PDW011" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PDW011" ] . ToString ( ) );
                //if ( workNum < dlNum + dlNumSum )
                //{
                //    row . SetColumnError ( "PC" ,"刨床数量不允许多于生产数量" );
                //    isOk = false;
                //    break;
                //}
                if ( planNum < dlNum + dlNumSum )
                {
                    row . SetColumnError ( "PC" ,"刨床数量不允许多于计划数量" );
                    isOk = false;
                    break;
                }
            }
            if ( isOk == true )
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }
        public DataTable getDataDailyBL
        {
            get
            {
                return dailyWork . getTable;
            }
        }

        #endregion

        #region zDayDailyWork

        private void BtnOk_Click5 ( object sender ,EventArgs e )
        {
            bool isOk = true;
            int 
               dlNum = 0, dlNumSum = 0,
               planNum = 0;
            DataRow row;
            for ( int i = 0 ; i < zDayDailyWork . gridView1 . DataRowCount ; i++ )
            {
                row = zDayDailyWork . gridView1 . GetDataRow ( i );
                planNum = string . IsNullOrEmpty ( row [ "PLE007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PLE007" ] . ToString ( ) );
                dlNum = string . IsNullOrEmpty ( row [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "DL" ] . ToString ( ) );
                dlNumSum = string . IsNullOrEmpty ( row [ "PLF007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PLF007" ] . ToString ( ) );
                if ( planNum < dlNum + dlNumSum )
                {
                    row . SetColumnError ( "DL" ,"组装数量不允许多于计划数量" );
                    isOk = false;
                    break;
                }
            }

            if ( isOk == true )
                this . DialogResult = System . Windows . Forms . DialogResult . OK;

        }
        public DataTable getDataDayDailyZ
        {
            get
            {
                return zDayDailyWork . getTable;
            }
        }

        #endregion

    }
}
