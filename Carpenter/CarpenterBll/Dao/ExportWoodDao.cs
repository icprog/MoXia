using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;

namespace CarpenterBll . Dao
{
    public class ExportWoodDao
    {
        /// <summary>
        /// save data to moxwob
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Save ( DataTable table )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            string proName = string . Empty, nameOne = string . Empty, nameTwo = string . Empty, nameTre = string . Empty, nameFor = string . Empty, nameFiv = string . Empty, nameSix = string . Empty, nameSev = string . Empty;
            //int column = 0;

            CarpenterEntity . WoodBaseEntity _model = new CarpenterEntity . WoodBaseEntity ( );
            List<string> strList = new List<string> ( );

            proName = table . Rows [ 0 ] [ 0 ] . ToString ( );
            if ( proName . Equals ( "产品名称" ) )
            {
                strList . Clear ( );
                nameOne = table . Rows [ 0 ] [ 1 ] . ToString ( ) . Trim ( );
                nameTwo = table . Rows [ 0 ] [ 2 ] . ToString ( ) . Trim ( );
                nameTre = table . Rows [ 0 ] [ 3 ] . ToString ( ) . Trim ( );
                nameFor = table . Rows [ 0 ] [ 4 ] . ToString ( ) . Trim ( );
                nameFiv = table . Rows [ 0 ] [ 5 ] . ToString ( ) . Trim ( );
                nameSix = table . Rows [ 0 ] [ 6 ] . ToString ( ) . Trim ( );
                strList . Add ( nameOne );
                strList . Add ( nameTwo );
                strList . Add ( nameTre );
                strList . Add ( nameFor );
                strList . Add ( nameFiv );
                strList . Add ( nameSix );
            }


                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    for ( int j = 0 ; j < table . Columns . Count ; j++ )
                    {
                        _model = new CarpenterEntity . WoodBaseEntity ( );
                        _model . WOB002 = table . Rows [ i ] [ 0 ] . ToString ( );
                        if ( !_model . WOB002 . Contains ( "产品名称" ) && !string . IsNullOrEmpty ( _model . WOB002 ) )
                        {
                            _model . WOB002 = table . Rows [ i ] [ j ] . ToString ( );
                            getProNum ( _model );
                            if ( !string . IsNullOrEmpty ( _model . WOB001 ) )
                            {
                                foreach ( string s in strList )
                                {
                                    _model . WOB006 = string . Empty;
                                    _model . WOB004 = s;
                                    if ( s . Equals ( table . Rows [ 0 ] [ 1 ] . ToString ( ) ) )
                                    {
                                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ 1 ] . ToString ( ) ) )
                                            _model . WOB005 = null;
                                        else
                                            _model . WOB005 = Math . Round ( Convert . ToDecimal ( table . Rows [ i ] [ 1 ] . ToString ( ) ) ,4 );
                                    }
                                    else if ( s . Equals ( table . Rows [ 0 ] [ 2 ] . ToString ( ) ) )
                                    {
                                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ 2 ] . ToString ( ) ) )
                                            _model . WOB005 = null;
                                        else
                                            _model . WOB005 = Math . Round ( Convert . ToDecimal ( table . Rows [ i ] [ 2 ] . ToString ( ) ) ,4 );
                                    }
                                    else if ( s . Equals ( table . Rows [ 0 ] [ 3 ] . ToString ( ) ) )
                                    {
                                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ 3 ] . ToString ( ) ) )
                                            _model . WOB005 = null;
                                        else
                                            _model . WOB005 = Math . Round ( Convert . ToDecimal ( table . Rows [ i ] [ 3 ] . ToString ( ) ) ,4 );
                                    }
                                    else if ( s . Equals ( table . Rows [ 0 ] [ 4 ] . ToString ( ) ) )
                                    {
                                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ 4 ] . ToString ( ) ) )
                                            _model . WOB005 = null;
                                        else
                                            _model . WOB005 = Math . Round ( Convert . ToDecimal ( table . Rows [ i ] [ 4 ] . ToString ( ) ) ,4 );
                                    }
                                    else if ( s . Equals ( table . Rows [ 0 ] [ 5 ] . ToString ( ) ) )
                                    {
                                        string str = table . Rows [ i ] [ 5 ] . ToString ( );
                                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ 5 ] . ToString ( ) ) )
                                            _model . WOB005 = null;
                                        else
                                            _model . WOB005 = Math . Round ( Convert . ToDecimal ( table . Rows [ i ] [ 5 ] . ToString ( ) ) ,4 );
                                    }
                                    else if ( s . Equals ( table . Rows [ 0 ] [ 6 ] . ToString ( ) ) )
                                    {
                                        if ( string . IsNullOrEmpty ( table . Rows [ i ] [ 6 ] . ToString ( ) ) )
                                            _model . WOB005 = null;
                                        else
                                            _model . WOB005 = Math . Round ( Convert . ToDecimal ( table . Rows [ i ] [ 6 ] . ToString ( ) ) ,4 );
                                    }
                                    if ( _model . WOB005 != null && _model . WOB005 > 0 )
                                        add_wob ( SQLString ,strSql ,_model );
                                }
                            }
                        }
                    }
                }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        /// <summary>
        /// obtain the name of pro from the pro list
        /// </summary>
        /// <param name="proName"></param>
        /// <returns></returns>
        void getProNum ( CarpenterEntity . WoodBaseEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT OPI001,OPI003 FROM MOXOPI WHERE OPI002='{0}' AND OPI008='在产'" ,_model . WOB002 );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                _model . WOB001 = dt . Rows [ 0 ] [ "OPI001" ] . ToString ( );
                _model . WOB003 = dt . Rows [ 0 ] [ "OPI003" ] . ToString ( );
            }
        }

        void add_wob ( Hashtable SQLString,StringBuilder strSql,CarpenterEntity.WoodBaseEntity model )
        {
            if ( !string . IsNullOrEmpty ( model . WOB001 ) )
            {
                strSql = new StringBuilder ( );
                strSql . Append ( "INSERT INTO MOXWOB (" );
                strSql . Append ( "WOB001,WOB002,WOB003,WOB004,WOB005,WOB006) " );
                strSql . Append ( "VALUES (" );
                strSql . Append ( "@WOB001,@WOB002,@WOB003,@WOB004,@WOB005,@WOB006) " );
                SqlParameter [ ] parameter = {
                new SqlParameter("@WOB001",SqlDbType.NVarChar,50),
                new SqlParameter("@WOB002",SqlDbType.NVarChar,50),
                new SqlParameter("@WOB003",SqlDbType.NVarChar,50),
                new SqlParameter("@WOB004",SqlDbType.NVarChar,50),
                new SqlParameter("@WOB005",SqlDbType.Decimal,7),
                new SqlParameter("@WOB006",SqlDbType.NVarChar,100)
                };
                parameter [ 0 ] . Value = model . WOB001;
                parameter [ 1 ] . Value = model . WOB002;
                parameter [ 2 ] . Value = model . WOB003;
                parameter [ 3 ] . Value = model . WOB004;
                parameter [ 4 ] . Value = model . WOB005;
                parameter [ 5 ] . Value = model . WOB006;
                SQLString . Add ( strSql ,parameter );
            }
        }

    }
}


/*
 * 打印datatable
   private void PrintTable()
        {
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = ucMutiTableHeader1.bandedGridView1.GridControl;
            link.Landscape = true;
            link.PaperKind = System.Drawing.Printing.PaperKind.A3;
            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            /nk.CreateMarginalFooterArea += new CreateAreaEventHandler(link_CreateMarginalFooterArea);
            link.Margins.Top = 60;
            link.Margins.Bottom = 50;
            link.Margins.Left = 30;
            link.Margins.Right = 30;
            link.CreateDocument();
            link.ShowPreview();
            //ucMutiTableHeader1.bandedGridView1.OptionsPrint.AutoWidth = false;
        }
     */
