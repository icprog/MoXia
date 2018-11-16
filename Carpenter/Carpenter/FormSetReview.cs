using DevExpress . XtraEditors;
using System . Data;
using System . Reflection;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormSetReview :FormChild
    {
        CarpenterBll.Bll.SetReviewBll _bll=new CarpenterBll.Bll.SetReviewBll();
        CarpenterEntity.SetReviewEntity _model=new CarpenterEntity.SetReviewEntity();
        string nameOfPerson=string.Empty,nameOfProgram=string.Empty; int num =0;

        public FormSetReview ( )
        {
            InitializeComponent ( );
            
            Utility . GridViewMoHuSelect . SetFilter ( gridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolCanecl ,toolSave ,toolExport ,toolPrint ,toolCancellation ,toolExamin ,toolReview } );
        }

        #region Main
        protected override int Query ( )
        {
            DataTable tableQuery = _bll . GetDataTable ( );
            gridControl1 . DataSource = tableQuery;
            QueryTool ( );

            return 0;
        }
        protected override int Add ( )
        {
            Carpenter . Query . SetReviewEdit form = new Carpenter . Query . SetReviewEdit ( "新增" ,_model ,nameOfPerson ,nameOfProgram );
            DialogResult result = form . ShowDialog ( );
            if ( result == System . Windows . Forms . DialogResult . OK )
            {
                Query ( );
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
            eidt ( );

            return 0;
        }
        protected override int Delete ( )
        {
            if ( _model . idx < 1 )
            {
                XtraMessageBox . Show ( "请选择需要删除的内容" );
                return 0;
            }
            if ( XtraMessageBox . Show ( "确定删除选中内容?" ,"删除?" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                return 0;
            bool result = _bll . Delete ( _model . idx );
            if ( result == true )
            {
                XtraMessageBox . Show ( "成功删除" );
                Query ( );
            }
            else
                XtraMessageBox . Show ( "删除失败,请重试" );

            return 0;
        }
        #endregion

        #region Event
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            num = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                DataRow row = gridView1 . GetDataRow ( num );
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : int . Parse ( row [ "idx" ] . ToString ( ) );
                _model . SRE002 = row [ "SRE002" ] . ToString ( );
                _model . SRE003 = row [ "SRE003" ] . ToString ( );
                _model . SRE004 = row [ "SRE004" ] . ToString ( );
                nameOfPerson= row [ "EMP002" ] . ToString ( );
                nameOfProgram = row [ "FOR001" ] . ToString ( );
            }
        }

        private void gridView1_DoubleClick ( object sender ,System . EventArgs e )
        {
            num = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                eidt ( );
            }
        }
        #endregion

        #region Method
        void eidt ( )
        {
            Carpenter . Query . SetReviewEdit form = new Carpenter . Query . SetReviewEdit ( "编辑" ,_model ,nameOfPerson ,nameOfProgram );
            DialogResult result = form . ShowDialog ( );
            if ( result == System . Windows . Forms . DialogResult . OK )
            {
                Query ( );
            }
        }
        #endregion

    }
}


/*
 WITH CET AS (
SELECT SRE004,SRE002 FROM MOXSRE WHERE SRE003='00007' AND SRE004!='0'
)
,CFT AS (
SELECT A.SRE002,A.SRE004 FROM MOXSRE A LEFT JOIN CET B ON A.SRE002=B.SRE002
GROUP BY A.SRE002,A.SRE004,B.SRE004 
HAVING A.SRE004<B.SRE004
)
,CHT AS (
SELECT SRE002,MAX(SRE004) SRE004 FROM CFT GROUP BY SRE002
),CJT AS(
--得到最新的送审消息
SELECT MAX(REV004) REV004,REV001 FROM MOXREV WHERE REV005='送审' GROUP BY REV001 
),CKT AS (
--得到最新送审消息的人员和程序信息
SELECT REV003,B.REV001 FROM MOXREV A INNER JOIN CJT B ON A.REV001=B.REV001 AND A.REV004=B.REV004
),CGT AS (
SELECT SRE004,SRE003,REV001 FROM MOXSRE A INNER JOIN CKT B ON A.SRE002=B.REV001 AND A.SRE003=B.REV003
)
,CLT AS (
SELECT A.SRE002,A.SRE004,B.SRE003 FROM CHT A INNER JOIN CGT B ON A.SRE002=B.REV001 AND A.SRE004=B.SRE004
),
CST AS(
--得到最新的送审消息
SELECT MAX(REV004) REV004,REV001 FROM MOXREV WHERE REV005='驳回' GROUP BY REV001 
)
SELECT A.* FROM MOXREV A INNER JOIN CLT B ON A.REV001=B.SRE002 AND A.REV003=B.SRE003
UNION ALL
SELECT A.* FROM MOXREV A LEFT JOIN CJT B ON A.REV001=B.REV001 AND A.REV004=B.REV004 WHERE REV005='驳回' AND REV003='00007'
     */
