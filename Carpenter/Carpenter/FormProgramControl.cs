using DevExpress . Utils . Paint;
using DevExpress . XtraEditors;
using System;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormProgramControl :FormChild
    {
        CarpenterBll.Bll.ProgramControlBll _bll=new CarpenterBll.Bll.ProgramControlBll();
        CarpenterEntity . ProgramControlEntity _model = new CarpenterEntity . ProgramControlEntity ( );
        
        public FormProgramControl ( )
        {
            InitializeComponent ( );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolCanecl ,toolSave ,toolCancellation ,toolExamin ,toolReview } );

            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );
            FieldInfo fi = typeof ( XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );
        }
        
        #region Main
        protected override int Query ( )
        {
            DataTable tableQuery = _bll . GetDataTable ( );
            gridControl1 . DataSource = tableQuery;

            return 0;
        }
        protected override int Add ( )
        {
            Carpenter . Query . ProgramControlEdit form = new Carpenter . Query . ProgramControlEdit ( "新增" ,_model,"add" );
            form . StartPosition = FormStartPosition . CenterScreen;
            DialogResult result = form . ShowDialog ( );
            if ( result == System . Windows . Forms . DialogResult . OK )
            {
                Query ( );
            }

            return 0;
        }
        protected override int Delete ( )
        {
            if ( _model . idx < 1 )
            {
                XtraMessageBox . Show ( "请选择需要删除的内容" );
                return 0;
            }
            if ( XtraMessageBox . Show ( "确定删除选中的内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
            {
                bool result = _bll . Delete ( _model . idx );
                if ( result == true )
                {
                    XtraMessageBox . Show ( "删除成功" );
                    Query ( );
                }
                else
                    XtraMessageBox . Show ( "删除失败,请重试" );
            }

            return 0;
        }
        protected override int Edit ( )
        {
            if ( _model . idx < 1 )
            {
                XtraMessageBox . Show ( "请选择需要编辑的内容" );
                return 0;
            }

            Carpenter . Query . ProgramControlEdit form = new Carpenter . Query . ProgramControlEdit ( "编辑" ,_model,"edit" );
            form . StartPosition = FormStartPosition . CenterScreen;
            DialogResult result = form . ShowDialog ( );
            if ( result == System . Windows . Forms . DialogResult . OK )
            {
                Query ( );
            }

            return 0;
        }
        #endregion

        #region Event
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            int num = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                _model . idx = string . IsNullOrEmpty ( gridView1 . GetDataRow ( num ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( num ) [ "idx" ] . ToString ( ) );
                _model . FOR001 = gridView1 . GetDataRow ( num ) [ "FOR001" ] . ToString ( );
                _model . FOR002 = gridView1 . GetDataRow ( num ) [ "FOR002" ] . ToString ( );
                _model . FOR003 = gridView1 . GetDataRow ( num ) [ "FOR003" ] . ToString ( );
                _model . FOR004 = gridView1 . GetDataRow ( num ) [ "FOR004" ] . ToString ( );
            }
        }
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        #endregion

    }
}
