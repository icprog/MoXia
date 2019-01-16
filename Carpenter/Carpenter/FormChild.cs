using System;
using System . Data;

namespace Carpenter
{
    public partial class FormChild :FormBase
    {
        public FormChild ( )
        {
            InitializeComponent ( );

           Power ( );
        }

        private void FormChild_Load ( object sender ,EventArgs e )
        {
            toolState ( );
        }

        /*
        void Power ( )
        {
            CarpenterBll . Bll . MainBll _bll = new CarpenterBll . Bll . MainBll ( );
            DataTable dt = _bll . GetDataTableBtnPower ( UserLogin . userNum ,UserLogin . programName );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string btnPow = string . Empty;
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    btnPow = dt . Rows [ 0 ] [ "POW004" ] . ToString ( );
                    if ( string . IsNullOrEmpty ( btnPow ) )
                        toolStrip1 . Items . Remove ( toolQuery );
                    else if ( btnPow == "False" )
                        toolStrip1 . Items . Remove ( toolQuery );
                    btnPow = dt . Rows [ 0 ] [ "POW005" ] . ToString ( );
                    if ( string . IsNullOrEmpty ( btnPow ) )
                        toolStrip1 . Items . Remove ( toolAdd );
                    else if ( btnPow == "False" )
                        toolStrip1 . Items . Remove ( toolAdd );
                    btnPow = dt . Rows [ 0 ] [ "POW006" ] . ToString ( );
                    if ( string . IsNullOrEmpty ( btnPow ) )
                        toolStrip1 . Items . Remove ( toolDelete );
                    else if ( btnPow == "False" )
                        toolStrip1 . Items . Remove ( toolDelete );
                    btnPow = dt . Rows [ 0 ] [ "POW007" ] . ToString ( );
                    if ( string . IsNullOrEmpty ( btnPow ) )
                        toolStrip1 . Items . Remove ( toolEdit );
                    else if ( btnPow == "False" )
                        toolStrip1 . Items . Remove ( toolEdit );
                    btnPow = dt . Rows [ 0 ] [ "POW008" ] . ToString ( );
                    if ( string . IsNullOrEmpty ( btnPow ) )
                        toolStrip1 . Items . Remove ( toolReview );
                    else if ( btnPow == "False" )
                        toolStrip1 . Items . Remove ( toolReview );
                    btnPow = dt . Rows [ 0 ] [ "POW009" ] . ToString ( );
                    if ( string . IsNullOrEmpty ( btnPow ) )
                        toolStrip1 . Items . Remove ( toolExamin );
                    else if ( btnPow == "False" )
                        toolStrip1 . Items . Remove ( toolExamin );
                    btnPow = dt . Rows [ 0 ] [ "POW010" ] . ToString ( );
                    if ( string . IsNullOrEmpty ( btnPow ) )
                        toolStrip1 . Items . Remove ( toolSave );
                    else if ( btnPow == "False" )
                        toolStrip1 . Items . Remove ( toolSave );
                    btnPow = dt . Rows [ 0 ] [ "POW011" ] . ToString ( );
                    if ( string . IsNullOrEmpty ( btnPow ) )
                        toolStrip1 . Items . Remove ( toolCanecl );
                    else if ( btnPow == "False" )
                        toolStrip1 . Items . Remove ( toolCanecl );
                    btnPow = dt . Rows [ 0 ] [ "POW012" ] . ToString ( );
                    if ( string . IsNullOrEmpty ( btnPow ) )
                        toolStrip1 . Items . Remove ( toolCancellation );
                    else if ( btnPow == "False" )
                        toolStrip1 . Items . Remove ( toolCancellation );
                }
            }
            else if ( UserLogin . userNum != "00001" )
            {
                toolStrip1 . Visible = false;

                //foreach ( ToolStripButton btn in toolStrip1 . Items )
                //{
                //    if ( btn . GetType ( ) == typeof ( ToolStripButton ) )
                //    {
                //        ToolStripButton toolBtn = btn as ToolStripButton;
                //        toolStrip1 . Items . Remove ( toolBtn );
                //    }
                //}
            }
        }
        */

        void Power ( )
        {
            CarpenterBll . Bll . MainBll _bll = new CarpenterBll . Bll . MainBll ( );
            DataTable dt = _bll . GetDataTableBtnPower ( UserLogin . userNum ,UserLogin . programName );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string btnPow = string . Empty;
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    if ( barTool . LinksPersistInfo . Count > toolCanecl . Id && barTool . LinksPersistInfo [ toolCanecl . Id ] . Item . Name == "toolCancel" )
                    {
                        btnPow = dt . Rows [ 0 ] [ "POW011" ] . ToString ( );
                        if ( string . IsNullOrEmpty ( btnPow ) )
                            barTool . LinksPersistInfo . RemoveAt ( toolCanecl . Id );
                        else if ( btnPow == "False" )
                            barTool . LinksPersistInfo . RemoveAt ( toolCanecl . Id );
                    }
                    if ( barTool . LinksPersistInfo . Count > toolSave . Id && barTool . LinksPersistInfo [ toolSave . Id ] . Item . Name == "toolSave" )
                    {
                        btnPow = dt . Rows [ 0 ] [ "POW010" ] . ToString ( );
                        if ( string . IsNullOrEmpty ( btnPow ) )
                            barTool . LinksPersistInfo . RemoveAt ( toolSave . Id );
                        else if ( btnPow == "False" )
                            barTool . LinksPersistInfo . RemoveAt ( toolSave . Id );
                    }
                    if ( barTool . LinksPersistInfo . Count > toolExport . Id && barTool . LinksPersistInfo [ toolExport . Id ] . Item . Name == "toolExport" )
                    {
                        btnPow = dt . Rows [ 0 ] [ "POW017" ] . ToString ( );
                        if ( string . IsNullOrEmpty ( btnPow ) )
                            barTool . LinksPersistInfo . RemoveAt ( toolExport . Id );
                        else if ( btnPow == "False" )
                            barTool . LinksPersistInfo . RemoveAt ( toolExport . Id );
                    }
                    if ( barTool . LinksPersistInfo . Count > toolPrint . Id && barTool . LinksPersistInfo [ toolPrint . Id ] . Item . Name == "toolPrint" )
                    {
                        btnPow = dt . Rows [ 0 ] [ "POW016" ] . ToString ( );
                        if ( string . IsNullOrEmpty ( btnPow ) )
                            barTool . LinksPersistInfo . RemoveAt ( toolPrint . Id );
                        else if ( btnPow == "False" )
                            barTool . LinksPersistInfo . RemoveAt ( toolPrint . Id );
                    }
                    if ( barTool . LinksPersistInfo . Count > toolCancellation . Id && barTool . LinksPersistInfo [ toolCancellation . Id ] . Item . Name == "toolCancellation" )
                    {
                        btnPow = dt . Rows [ 0 ] [ "POW012" ] . ToString ( );
                        if ( string . IsNullOrEmpty ( btnPow ) )
                            barTool . LinksPersistInfo . RemoveAt ( toolCancellation . Id );
                        else if ( btnPow == "False" )
                            barTool . LinksPersistInfo . RemoveAt ( toolCancellation . Id );
                    }
                    if ( barTool . LinksPersistInfo . Count > toolExamin . Id && barTool . LinksPersistInfo [ toolExamin . Id ] . Item . Name == "toolExamin" )
                    {
                        btnPow = dt . Rows [ 0 ] [ "POW009" ] . ToString ( );
                        if ( string . IsNullOrEmpty ( btnPow ) )
                            barTool . LinksPersistInfo . RemoveAt ( toolExamin . Id );
                        else if ( btnPow == "False" )
                            barTool . LinksPersistInfo . RemoveAt ( toolExamin . Id );
                    }
                    if ( barTool . LinksPersistInfo . Count > toolReview . Id && barTool . LinksPersistInfo [ toolReview . Id ] . Item . Name == "toolReview" )
                    {
                        btnPow = dt . Rows [ 0 ] [ "POW008" ] . ToString ( );
                        if ( string . IsNullOrEmpty ( btnPow ) )
                            barTool . LinksPersistInfo . RemoveAt ( toolReview . Id );
                        else if ( btnPow == "False" )
                            barTool . LinksPersistInfo . RemoveAt ( toolReview . Id );
                    }
                    if ( barTool . LinksPersistInfo . Count > toolDelete . Id && barTool . LinksPersistInfo [ toolDelete . Id ] . Item . Name == "toolDelete" )
                    {
                        btnPow = dt . Rows [ 0 ] [ "POW006" ] . ToString ( );
                        if ( string . IsNullOrEmpty ( btnPow ) )
                            barTool . LinksPersistInfo . RemoveAt ( toolDelete . Id );
                        else if ( btnPow == "False" )
                            barTool . LinksPersistInfo . RemoveAt ( toolDelete . Id );
                    }
                    if ( barTool . LinksPersistInfo . Count > toolEdit . Id && barTool . LinksPersistInfo [ toolEdit . Id ] . Item . Name == "toolEdit" )
                    {
                        btnPow = dt . Rows [ 0 ] [ "POW007" ] . ToString ( );
                        if ( string . IsNullOrEmpty ( btnPow ) )
                            barTool . LinksPersistInfo . RemoveAt ( toolEdit . Id );
                        else if ( btnPow == "False" )
                            barTool . LinksPersistInfo . RemoveAt ( toolEdit . Id );
                    }
                    if ( barTool . LinksPersistInfo . Count > toolAdd . Id && barTool . LinksPersistInfo [ toolAdd . Id ] . Item . Name == "toolAdd" )
                    {
                        btnPow = dt . Rows [ 0 ] [ "POW005" ] . ToString ( );
                        if ( string . IsNullOrEmpty ( btnPow ) )
                            barTool . LinksPersistInfo . RemoveAt ( toolAdd . Id );
                        else if ( btnPow == "False" )
                            barTool . LinksPersistInfo . RemoveAt ( toolAdd . Id );
                    }
                    if ( barTool . LinksPersistInfo . Count > toolQuery . Id && barTool . LinksPersistInfo [ toolQuery . Id ] . Item . Name == "toolCancel" )
                    {
                        btnPow = dt . Rows [ 0 ] [ "POW004" ] . ToString ( );
                        if ( string . IsNullOrEmpty ( btnPow ) )
                            barTool . LinksPersistInfo . RemoveAt ( toolQuery . Id );
                        else if ( btnPow == "False" )
                            barTool . LinksPersistInfo . RemoveAt ( toolQuery . Id );
                    }
                }
            }
            else if ( UserLogin . userNum != "00001" )
            {
                barTool . Visible = false;

                //foreach ( ToolStripButton btn in toolStrip1 . Items )
                //{
                //    if ( btn . GetType ( ) == typeof ( ToolStripButton ) )
                //    {
                //        ToolStripButton toolBtn = btn as ToolStripButton;
                //        toolStrip1 . Items . Remove ( toolBtn );
                //    }
                //}
            }
        }

        protected void toolState ( )
        {
            toolQuery . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolAdd . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolCanecl . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolReview . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
        }

        protected virtual int Query ( )
        {
            return 0;
        }
        protected void QueryTool ( )
        {
            toolQuery . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolAdd . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolCanecl . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolReview . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;

            if ( toolCancellation . Caption . Equals ( "反注销" ) )
            {
                //Concell1 . Show ( );
                toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolReview . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            }
            if ( toolExamin . Caption . Equals ( "反审核" ) )
            {
                toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolReview . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }

        }
        private void toolQuery_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            CarpenterBll . UserInformation . TypeOfOper = "查询";
            Query ( );
        }

        protected virtual int Add (  )
        {
            return 0;
        }
        private void toolAdd_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            CarpenterBll . UserInformation . TypeOfOper = "新增";
            Add ( );
        }
        protected void addTool ( )
        {
            toolAdd . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolQuery . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolCanecl . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolReview . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
        }


        protected virtual int Edit ( )
        {
            return 0;
        }
        private void toolEdit_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            CarpenterBll . UserInformation . TypeOfOper = "编辑";
            Edit ( );
        }
        protected void editTool ( )
        {
            toolAdd . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolQuery . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolCanecl . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolReview . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
        }

        protected virtual int Delete ( )
        {
           
            return 0;
        }
        protected void deleteTool ( )
        {
            toolQuery . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolAdd . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolCanecl . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolReview . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
        }
        private void toolDelete_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            CarpenterBll . UserInformation . TypeOfOper = "删除";
            Delete ( );
        }

        protected virtual int Review ( )
        {
            
            return 0;
        }
        private void toolReview_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            CarpenterBll . UserInformation . TypeOfOper = "送审";
            Review ( );
        }
        protected void Review ( string oddNum ,string programId)
        {
            FormReview from = new FormReview ( UserLogin . programName ,oddNum );
            from . ShowDialog ( );
        }

        protected virtual int Examine ( )
        {
           
            return 0;
        }
        private void toolExamin_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            CarpenterBll . UserInformation . TypeOfOper = "审核";
            Examine ( );
        }
        protected void examineTool ( string state )
        {
            toolQuery . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolAdd . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            
            if ( state . Equals ( "审核" ) )
            {
                toolExamin . Caption = "反审核";
                //Concell1 . Show ( );           
                toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolCanecl . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolReview . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
            else
            {
                toolExamin . Caption = "审核";
                //Concell1 . Hide ( );
                toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolCanecl . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolReview . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            }
        }

        protected virtual int Save ( )
        {
            
            return 0;
        }
        private void toolSave_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            CarpenterBll . UserInformation . TypeOfOper = "保存";
            Save ( );
        }
        protected void saveTool ( )
        {
            toolQuery . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolAdd . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolCancellation . Caption = "注销";
            toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolCanecl . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolExamin . Caption = "审核";
            toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolReview . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
        }

        protected virtual int Cancel ( )
        {
          
            return 0;
        }
        private void toolCanecl_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            CarpenterBll . UserInformation . TypeOfOper = "取消";
            Cancel ( );
        }
        protected void cancelTool ( string  state)
        {
            if ( state . Equals ( "add" ) )
            {
                toolAdd . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolQuery . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolCanecl . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolReview . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            }
            else if ( state . Equals ( "edit" ) )
            {
                toolAdd . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolQuery . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolCanecl . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolReview . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            }
        }

        protected void cancelltionTool ( string stateOfCancell )
        {
            toolQuery . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolAdd . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            if ( stateOfCancell . Equals ( "注销" ) )
            {
                toolCancellation . Caption = "反注销";
                //Concell1 . Show ( );           
                toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolCanecl . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolReview . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            }
            else
            {
                toolCancellation . Caption = "注销";
                //Concell1 . Hide ( );
                toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolCanecl . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolExamin . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolReview . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            }
        }
        protected virtual int Cancellation ( )
        {
            
            return 0;
        }
        private void toolCancellation_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            CarpenterBll . UserInformation . TypeOfOper = "注销";
            Cancellation ( );
        }

        protected virtual int Print ( )
        {
           
            return 0;
        }
        private void toolPrint_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            CarpenterBll . UserInformation . TypeOfOper = "打印";
            Print ( );
        }

        protected virtual int Export ( )
        {
            
            return 0;
        }
        private void toolExport_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            CarpenterBll . UserInformation . TypeOfOper = "导出";
            Export ( );
        }


    }
}
