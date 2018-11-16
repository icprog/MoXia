using System;
using System . Data;

namespace Carpenter . Query
{
    public partial class FormWeekDailyWork :FormBase
    {
        Carpenter.ControlUser.BLDailyWeek week=null;
        Carpenter.ControlUser.JDailyWeek jWeek=null;
        Carpenter.ControlUser.ZDailyWeek zWeek=null;
        Carpenter.ControlUser.PDailyWeek pWeek=null;
        DataTable tableOne; DataRow row; bool result = true; int sums = 0, num = 0, numY = 0;
        
        public FormWeekDailyWork ( string text ,DataTable tableOne )
        {
            InitializeComponent ( );

            this . Text = text;
            this . tableOne = tableOne;

            if ( this . Text . Contains ( "备料" ) )
            {
                week = new ControlUser . BLDailyWeek ( tableOne );
                this . Controls . Add ( week );
                week . Dock = System . Windows . Forms . DockStyle . Fill;
                week . btnOk . Click += BtnOk_Click;
                week . btnCancel . Click += BtnCancel_Click;
            }

            else if ( this . Text . Contains ( "机加工" ) )
            {
                jWeek = new ControlUser . JDailyWeek ( tableOne );
                this . Controls . Add ( jWeek );
                jWeek . Dock = System . Windows . Forms . DockStyle . Fill;
                jWeek . btnOk . Click += BtnOk_Click1;
            }

            else if ( this . Text . Contains ( "组装" ) )
            {
                zWeek = new ControlUser . ZDailyWeek ( tableOne );
                this . Controls . Add ( zWeek );
                zWeek . Dock = System . Windows . Forms . DockStyle . Fill;
                zWeek . btnOk . Click += BtnOk_Click2;
            }

            else if ( this . Text . Contains ( "油漆" ) )
            {
                pWeek = new ControlUser . PDailyWeek ( tableOne );
                this . Controls . Add ( pWeek );
                pWeek . Dock = System . Windows . Forms . DockStyle . Fill;
                pWeek . btnOk . Click += BtnOk_Click3;
            }

        }

        #region 油漆
        private void BtnOk_Click3 ( object sender ,EventArgs e )
        {
            result = true;
            for ( int i = 0 ; i < pWeek . gridView1 . DataRowCount ; i++ )
            {
                row = pWeek . gridView1 . GetDataRow ( i );
                row . ClearErrors ( );
                if ( row != null )
                {
                    sums = string . IsNullOrEmpty ( row [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "DL" ] . ToString ( ) );
                    num = string . IsNullOrEmpty ( row [ "PWI007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PWI007" ] . ToString ( ) );
                    numY = string . IsNullOrEmpty ( row [ "PDP025" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PDP025" ] . ToString ( ) );
                    if ( num + sums > numY )
                    {
                        row . SetColumnError ( "DL" ,"报工数量+累计报工数量多于生产数量" );
                        result = false;
                        break;
                    }
                }
            }

            if ( result == true )
            {
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
            }
        }
        public DataTable GetTableP
        {
            get
            {
                return pWeek . getTable;
            }
        }
        #endregion

        #region 组装
        private void BtnOk_Click2 ( object sender ,EventArgs e )
        {
            result = true;
            for ( int i = 0 ; i < zWeek . gridView1 . DataRowCount ; i++ )
            {
                row = zWeek . gridView1 . GetDataRow ( i );
                row . ClearErrors ( );
                if ( row != null )
                {
                    sums = string . IsNullOrEmpty ( row [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "DL" ] . ToString ( ) );
                    num = string . IsNullOrEmpty ( row [ "PLC007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PLC007" ] . ToString ( ) );
                    numY = string . IsNullOrEmpty ( row [ "PAS016" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PAS016" ] . ToString ( ) );
                    if ( num + sums > numY )
                    {
                        row . SetColumnError ( "DL" ,"报工数量+累计报工数量多于生产数量" );
                        result = false;
                        break;
                    }
                }
            }

            if ( result == true )
            {
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
            }
        }
        public DataTable GetTableZ
        {
            get
            {
                return zWeek . getTable;
            }
        }
        #endregion

        #region 机加工
        private void BtnOk_Click1 ( object sender ,EventArgs e )
        {
            result = true;
            for ( int i = 0 ; i < jWeek . gridView1 . DataRowCount ; i++ )
            {
                row = jWeek . gridView1 . GetDataRow ( i );
                row . ClearErrors ( );
                if ( row != null )
                {
                    sums = string . IsNullOrEmpty ( row [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "DL" ] . ToString ( ) );
                    num = string . IsNullOrEmpty ( row [ "PME007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PME007" ] . ToString ( ) );
                    numY = string . IsNullOrEmpty ( row [ "PST028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PST028" ] . ToString ( ) );
                    if ( num + sums > numY )
                    {
                        row . SetColumnError ( "DL" ,"报工数量+累计报工数量多于生产数量" );
                        result = false;
                        break;
                    }
                }
            }

            if ( result == true )
            {
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
            }
        }
        public DataTable GetTableJ
        {
            get
            {
                return jWeek . getTable;
            }
        }
        #endregion

        #region 备料
        private void BtnCancel_Click ( object sender ,System . EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }
        private void BtnOk_Click ( object sender ,System . EventArgs e )
        {
            result = true;     
            for ( int i = 0 ; i < week . gridView1 . DataRowCount ; i++ )
            {
                row = week . gridView1 . GetDataRow ( i );
                row . ClearErrors ( );
                if ( row != null )
                {
                    sums = string . IsNullOrEmpty ( row [ "DL" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "DL" ] . ToString ( ) );
                    num = string . IsNullOrEmpty ( row [ "PDK007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PDK007" ] . ToString ( ) );
                    numY = string . IsNullOrEmpty ( row [ "PST028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "PST028" ] . ToString ( ) );
                    if ( num + sums>numY )
                    {
                        row . SetColumnError ( "DL" ,"报工数量+累计报工数量多于生产数量" );
                        result = false;
                        break;
                    }
                }
            }

            if ( result == true )
            {
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
            }

        }
        public DataTable GetTable
        {
            get
            {
                return week . getTable;
            }
        }

        #endregion

    }
}