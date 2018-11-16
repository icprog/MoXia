using CarpenterBll;
using DevExpress . XtraEditors;
using System;
using System . Collections . Generic;
using System . Data;
using System . Drawing;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormMaintainTransmit :FormBase
    {
        CarpenterEntity.MaintainTransmitMTREntity _MTE=new CarpenterEntity.MaintainTransmitMTREntity();
        CarpenterEntity.MaintainTransmitMTSEntity _MTS=new CarpenterEntity.MaintainTransmitMTSEntity();
        CarpenterBll.Bll.MaintainTransmitBll _bll=new CarpenterBll.Bll.MaintainTransmitBll();
        string strWhere = "1=1";

        public FormMaintainTransmit ( )
        {
            InitializeComponent ( );
            
            Utility . GridViewMoHuSelect . SetFilter ( gridView2 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            comType . Properties .DataSource = _bll . GetDataTableOfGZ ( UserLogin . userNum );
            comType .Properties. DisplayMember = "STR002";
            comType .Properties. ValueMember = "STR001";

            if ( UserLogin . table == null || UserLogin . table . Rows . Count < 1 )
                return;
            gridControl2 . DataSource = UserLogin . table;
        }
        
        //检索
        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            query ( );
        }

        void query ( )
        {
            if ( string . IsNullOrEmpty ( comOverOnt . Text ) )
            {
                XtraMessageBox . Show ( "请选择结束标记" );
                return;
            }

            strWhere = "1=1";
            getStrwhere ( );

            CarpenterBll . Bll . MaintainTransmitBll _bll = new CarpenterBll . Bll . MaintainTransmitBll ( );

            DataTable table = _bll . GetDataTable ( strWhere ,UserLogin . userNum );
            gridControl2 . DataSource = table;
        }

        //导出Execl
        private void btnExportOne_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comOverOnt . Text ) )
            {
                XtraMessageBox . Show ( "请选择结束标记" );
                return;
            }

            strWhere = "1=1";
            getStrwhere ( );
            DataTable dt = _bll . printTwo ( strWhere );
            dt . TableName = "Maintain";
            Export ( new DataTable [ ] { dt } ,"工作联系单列表.frx" );
        }

        void getStrwhere ( )
        {
            string dtStart = dtpStart . Text;
            string dtEnd = dtpEnd . Text;
            _MTE . MTR002 = comOverOnt . Text;

            if ( !string . IsNullOrEmpty ( dtStart ) )
                strWhere = strWhere + " AND MTR009>='" + dtStart + "'";
            if ( !string . IsNullOrEmpty ( dtEnd ) )
                strWhere = strWhere + " AND MTR009<='" + dtEnd + "'";
            if ( !string . IsNullOrEmpty ( _MTE . MTR002 ) )
                strWhere = strWhere + " AND MTR002='" + _MTE . MTR002 + "'";
        }

        private void gridView2_DoubleClick ( object sender ,EventArgs e )
        {
            int num = gridView2 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView2 . RowCount - 1 )
            {
                DataRow row = gridView2 . GetDataRow ( num );
                _MTE . MTR001 = row [ "MTR001" ] . ToString ( );
                _MTE . MTR002 = row [ "MTR002" ] . ToString ( );
                _MTE . MTR003 = string . IsNullOrEmpty ( row [ "MTR003" ] . ToString ( ) ) == true ? _bll . getTime ( ) : Convert . ToDateTime ( row [ "MTR003" ] . ToString ( ) );
                _MTE . MTR004 = string . IsNullOrEmpty ( row [ "MTR004" ] . ToString ( ) ) == true ? _bll . getTime ( ) : Convert . ToDateTime ( row [ "MTR004" ] . ToString ( ) );
                _MTE . MTR005 = row [ "MTR005" ] . ToString ( );
                _MTE . MTR006 = row [ "MTR006" ] . ToString ( );
                _MTE . MTR007 = row [ "MTR007" ] . ToString ( );
                _MTE . MTR008 = row [ "MTR008" ] . ToString ( );
                _MTE . MTR009 = string . IsNullOrEmpty ( row [ "MTR009" ] . ToString ( ) ) == true ? _bll . getTime ( ) : Convert . ToDateTime ( row [ "MTR009" ] . ToString ( ) );
                _MTE . MTR010 = row [ "MTR010" ] . ToString ( );
                _MTE . MTR011 = row [ "MTR011" ] . ToString ( );
                assignMent ( _MTE );
            }
        }
        void assignMent ( CarpenterEntity . MaintainTransmitMTREntity _MTE )
        {
            comOverTwo . Text = _MTE . MTR002;
            if ( comOverTwo . Text . Equals ( "已结束" ) )
            {
                btnOver . Enabled = false;
                UnEnable ( );
            }
            else
            {
                btnOver . Enabled = true;
                Enable ( );
            }
            texNumOfC . Text = _MTE . MTR001;
            texStart . Text = _MTE . MTR003 . ToString ( "yyyy-MM-dd" );
            texTime . Text = _MTE . MTR004 . ToString ( "hh:mm:ss" );
            texPerson . Text = _MTE . MTR005 + " " + _MTE . MTR006;
            comType . Text = _MTE . MTR008;
            texPersonCir . Text = _MTE . MTR010;
            texSketch . Text = _MTE . MTR011;

            richContent . Text = string . Empty;
            DataTable da = _bll . GetDataTableOne ( _MTE . MTR001 );
            if ( da != null && da . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    richContent . Text = richContent . Text  + da . Rows [ i ] [ "MTS" ] . ToString ( ) . Trim ( ) + "\r\n";
                }
            }
            else
                richContent . Text = string . Empty;
        }

        //添加联系内容
        private void btnCon_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( texSketch . Text ) )
            {
                XtraMessageBox . Show ( "请填写项目简述" );
                return;
            }

            Carpenter . Query . FormControl from = new Query . FormControl ( "联系内容" ,"FormContact" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                _MTS . MTS002 = UserLogin . userName;
                _MTS . MTS003 = from . getContact;
                _MTS . MTS004 = _bll . getTime ( );
                if ( getValue ( ) == false )
                    return;
                bool isOk = _bll . Add ( _MTE ,_MTS );
                if ( isOk == false )
                {
                    XtraMessageBox . Show ( "联系内容添加失败,请重新添加" );
                    return;
                }
                else
                {
                    richContent . Text = string . Empty;
                    DataTable da = _bll . GetDataTableOne ( texNumOfC . Text );
                    if ( da != null && da . Rows . Count > 0 )
                    {
                        for ( int i = 0 ; i < da . Rows . Count ; i++ )
                        {
                            richContent . Text = richContent . Text + da . Rows [ i ] [ "MTS" ] . ToString ( ) . Trim ( ) + "\r\n";
                        }
                    }
                    else
                        richContent . Text = string . Empty;
                }
            }
        }

        bool getValue ( )
        {
            bool result = true;

            _MTE . MTR001 = _MTS . MTS001 = texNumOfC . Text;
            if ( string . IsNullOrEmpty ( comOverTwo . Text ) )
            {
                XtraMessageBox . Show ( "请选择结束标记" );
                return false;
            }
            _MTE . MTR002 = comOverTwo . Text;
            if ( string . IsNullOrEmpty ( texStart . Text ) )
            {
                XtraMessageBox . Show ( "开单日期不可为空" );
                return false;
            }
            _MTE . MTR003 = string . IsNullOrEmpty ( texStart . Text ) == true ? _bll . getTime ( ) : Convert . ToDateTime ( texStart . Text );
            if ( string . IsNullOrEmpty ( texTime . Text ) )
            {
                XtraMessageBox . Show ( "开单时间不可为空" );
                return false;
            }
            _MTE . MTR004 = string . IsNullOrEmpty ( texTime . Text ) == true ? _bll . getTime ( ) : Convert . ToDateTime ( texTime . Text );
            string [ ] str = texPerson . Text . Trim ( ) . Split ( ' ' );
            if ( string . IsNullOrEmpty ( str [ 0 ] . ToString ( ) ) || string . IsNullOrEmpty ( str [ 1 ] . ToString ( ) ) )
            {
                XtraMessageBox . Show ( "开单联系人不可为空" );
                return false;
            }
            _MTE . MTR005 = str [ 0 ];
            _MTE . MTR006 = str [ 1 ];
            if ( string . IsNullOrEmpty ( comType . Text ) )
            {
                XtraMessageBox . Show ( "请选择单据类别" );
                return false;
            }
            _MTE . MTR008 = comType . Text;
            _MTE . MTR007 = comType . EditValue . ToString ( );
            if ( string . IsNullOrEmpty ( texPersonCir . Text ) )
            {
                XtraMessageBox . Show ( "请选择流转人员" );
                return false;
            }
            _MTE . MTR010 = texPersonCir . Text;
            if ( string . IsNullOrEmpty ( texSketch . Text ) )
            {
                XtraMessageBox . Show ( "请选择填写项目简述" );
                return false;
            }
            _MTE . MTR011 = texSketch . Text;

            return result;
        }
        //新建
        private void btnAdd_Click ( object sender ,EventArgs e )
        {
            clear ( );
            Enable ( );
            comOverTwo . Text = "未结束";
            texNumOfC . Text = _bll . contact ( );
            DateTime dt = _bll . getTime ( );
            texStart . Text = dt . ToString ( "yyyy-MM-dd" );
            texTime . Text = dt . ToString ( "hh:mm:ss" );
            texPerson . Text = UserLogin . userNum + " " + UserLogin . userName;
        }        
        //结束
        private void btnOver_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( texPerson . Text ) )
            {
                XtraMessageBox . Show ( "开单联系人不可为空" );
                return;
            }
            if ( !texPerson . Text . Contains ( UserLogin . userNum ) )
                return;
            bool isOk = _bll . Edit ( texNumOfC . Text ,"已结束" );
            if ( isOk == false )
                XtraMessageBox . Show ( "结束失败,请重试" );
            else
            {
                query ( );
                btnOver . Enabled = false;
                comOverTwo . Text = "已结束";
                btnCon . Enabled = false;
                UnEnable ( );
            }
        }
        //打印
        private void btnPrint_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( texNumOfC . Text ) )
            {
                XtraMessageBox . Show ( "请选择需要打印的单据" );
                return;
            }
            

            DataTable dt = _bll . printOne ( texNumOfC . Text );
            dt . TableName = "Maintain";
            Print ( new DataTable [ ] { dt } ,"工作联系单.frx" );
        }
        //导出Execl
        private void btnExportTwo_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( texNumOfC . Text ) )
            {
                XtraMessageBox . Show ( "请选择需要打印的单据" );
                return;
            }


            DataTable dt = _bll . printOne ( texNumOfC . Text );
            dt . TableName = "Maintain";
            Export ( new DataTable [ ] { dt } ,"工作联系单.frx" );
        }
        //流转人员
        private void texPersonCir_DoubleClick ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( texPerson . Text ) )
            {
                XtraMessageBox . Show ( "开单联系人不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( comType . Text ) )
            {
                XtraMessageBox . Show ( "单据类别不可为空" );
                return;
            }

            if ( !texPerson . Text . Contains ( UserLogin . userNum ) )
                return;
            if ( !string . IsNullOrEmpty ( richContent . Text ) )
                return;

            Carpenter . Query . FormControl from = new Query . FormControl ( "工作联系单流转人员选择" ,"FormMaintainTransmit" );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                List<CarpenterBll . Paramete> table = new List<CarpenterBll . Paramete> ( );
                table = from . getMainHas;
                if ( table . Count < 1 )
                {
                    XtraMessageBox . Show ( "请选择流转人员" );
                    return;
                }

                string str = string . Empty;

                foreach ( Paramete item in table )
                {
                    if ( str == string . Empty )
                        str = item . Key + " " + item . Value;
                    else
                        str = str + " | " + item . Key + " " + item . Value;
                }

                texPersonCir . Text = str;
            }
        }

        /// <summary>
        /// 设置窗口显示位置(右下角)
        /// </summary>
        public void SetPosition ( )
        {
            Point p = new Point ( Screen . PrimaryScreen . WorkingArea . Width - this . Width - 5 ,Screen . PrimaryScreen . WorkingArea . Height - this . Height );
            this . PointToScreen ( p );
            this . Location = p;
        }

        void clear ( )
        {
            comOverTwo . Text = texNumOfC . Text = texStart . Text = texTime . Text = texPerson . Text = comType . Text = texPersonCir . Text = texSketch . Text = richContent . Text = string . Empty;
        }
        void UnEnable ( )
        {
            comOverTwo . Enabled = texNumOfC . Enabled = texStart . Enabled = texTime . Enabled = texPerson . Enabled = comType . Enabled = texPersonCir . Enabled = texSketch . Enabled = richContent . Enabled = btnCon.Enabled= false;
        }
        void Enable ( )
        {
            comOverTwo . Enabled = texNumOfC . Enabled = texStart . Enabled = texTime . Enabled = texPerson . Enabled = comType . Enabled = texPersonCir . Enabled = texSketch . Enabled = richContent . Enabled = btnCon . Enabled = true;
        }

    }
}
