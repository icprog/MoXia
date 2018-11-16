using DevExpress . XtraEditors;
using System;
using System . Data;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormDepartMent :FormChild
    {
        public FormDepartMent ( )
        {
            InitializeComponent ( );

            ToolBarContain . ToolbarsC ( barTool ,new DevExpress . XtraBars . BarButtonItem [ ] { toolExport ,toolPrint ,toolCancellation ,toolExamin ,toolReview  } );

            splitContainerControl1 . Panel1 . Enabled = true;
            splitContainerControl1 . Panel2 . Enabled = false;
        }
        
        string state=string.Empty;
        
        #region Main
        protected override int Query ( )
        {
            CarpenterBll . Bll . DepartMentBll _bll = new CarpenterBll . Bll . DepartMentBll ( );
            _bll . Exists ( );

            if ( treeView1 . Nodes . Count > 0 )
                treeView1 . Nodes . Clear ( );
            setTreeView ( treeView1 ,0 );
            this . treeView1 . ExpandAll ( );

            QueryTool ( );

            splitContainerControl1 . Panel1 . Enabled = true;
            splitContainerControl1 . Panel2 . Enabled = false;
            treeView1 . Enabled = true;

            return 0;
        }
        protected override int Add ( )
        {
            if ( treeView1 . SelectedNode == null )
            {
                XtraMessageBox . Show ( "请选择父节点" );
                return 0;
            }
            splitContainerControl1 . Panel1 . Enabled = true;
            splitContainerControl1 . Panel2 . Enabled = true;
            texName . Text = string . Empty;

            addTool ( );
            
            NumOfPerson ( );
            texNum . Enabled = false;
            treeView1 . Enabled = false;
            state = "add";

            return 0;
        }
        protected override int Edit ( )
        {
            if ( treeView1 . SelectedNode == null )
            {
                XtraMessageBox . Show ( "请选择节点" );
                return 0;
            }


            editTool ( );

            splitContainerControl1 . Panel1 . Enabled = false;
            splitContainerControl1 . Panel2 . Enabled = true;
            treeView1 . Enabled = false;
            state = "edit";

            return 0;
        }
        protected override int Delete ( )
        {
            if ( treeView1 . SelectedNode == null )
            {
                XtraMessageBox . Show ( "请选择节点" );
                return 0;
            }
            if ( texNum . Text . Equals ( "0001" ) )
            {
                XtraMessageBox . Show ( "公司不允许删除" );
                return 0;
            }
            if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
            {
                CarpenterBll . Bll . DepartMentBll _bll = new CarpenterBll . Bll . DepartMentBll ( );
                bool result = _bll . Delete (  texNum . Text  );
                if ( result == true )
                {
                    //XtraMessageBox . Show ( "删除成功" );

                    Query ( );
                }
                else
                    XtraMessageBox . Show ( "删除失败,请重试" );
            }

            return 0;
        }
        protected override int Examine ( )
        {
            errorProvider1 . Clear ( );
            if ( string . IsNullOrEmpty ( texNum . Tag . ToString ( ) ) )
            {
                errorProvider1 . SetError ( texNum ,"请重新选择部门" );
                return 0;
            }

            CarpenterBll . Bll . DepartMentBll _bll = new CarpenterBll . Bll . DepartMentBll ( );

            bool result = false;
            if ( toolCancellation . Caption .Equals( "注销" ))
                result = _bll . Examine ( Convert . ToInt32 ( texNum . Tag . ToString ( ) ) ,"F" );
            else
                result = _bll . Examine ( Convert . ToInt32 ( texNum . Tag . ToString ( ) ) ,"T" );
            if ( result == true )
            {
                XtraMessageBox . Show ( "已" + toolCancellation . Caption + "" );
                toolQuery . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolAdd . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolCancellation . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
                if ( toolCancellation . Caption == "注销" )
                    toolCancellation . Caption = "反注销";
                else
                    toolCancellation . Caption = "注销";
                toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolCanecl . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            }
            else
                XtraMessageBox . Show ( "" + toolCancellation . Caption + "失败,请重试" );


            return 0;
        }
        protected override int Save ( )
        {
            if ( string . IsNullOrEmpty ( texNum . Tag . ToString ( ) ) )
            {
                XtraMessageBox . Show ( "请选择节点" );
                return 0;
            }
            errorProvider1 . Clear ( );
            bool isOk = true;
            if ( string . IsNullOrEmpty ( texNum . Text ) )
            {
                errorProvider1 . SetError ( texNum ,"部门编号不能为空" );
                isOk = false;
            }
            if ( string . IsNullOrEmpty ( texName . Text ) )
            {
                errorProvider1 . SetError ( texName ,"部门名称不能为空" );
                isOk = false;
            }
            if ( isOk == false )
                return 0;

            CarpenterBll . Bll . DepartMentBll _bll = new CarpenterBll . Bll . DepartMentBll ( );
            CarpenterEntity . DepartMentEntity _model = new CarpenterEntity . DepartMentEntity ( );
            
            _model . DEP001 = texNum . Text . ToString ( );
            _model . DEP002 = texName . Text;
            _model . DEP003 = Convert . ToInt32 ( texNum . Tag );
            _model . DEP004 = checkJob . Checked == true ? true : false;
            if ( state .Equals( "add" ) )
            {
                NumOfPerson ( );
                _model . IDX = _bll . Save ( _model );
                if ( _model . IDX > 0 )
                {
                    //XtraMessageBox . Show ( "保存成功" );
                    texNum . Tag = _model . IDX . ToString ( );

                    splitContainerControl1 . Panel1 . Enabled = true;
                    splitContainerControl1 . Panel2 . Enabled = false;
                    treeView1 . Enabled = true;

                    Query ( );

                    //saveTool ( );
                }
                else
                    XtraMessageBox . Show ( "保存失败,请重试" );
            }
            else if ( state .Equals( "edit") )
            {
                //bool result =_bll.
                bool result = _bll . Edit ( _model );
                if ( result == true )
                {
                    splitContainerControl1 . Panel1 . Enabled = true;
                    splitContainerControl1 . Panel2 . Enabled = false;
                    treeView1 . Enabled = true;

                    Query ( );

                    //saveTool ( );
                }
                else
                    XtraMessageBox . Show ( "编辑失败,请重试" );
            }

           

            return 0;
        }
        protected override int Cancel ( )
        {
            if ( state . Equals ( "add" ) )
            {
                splitContainerControl1 . Panel2 . Enabled = false;
                splitContainerControl1 . Panel1 . Enabled = true;
                treeView1 . Enabled = true;
                texNum . Text = string . Empty;
                texNum . Tag = string . Empty;
            }
            else if ( state . Equals ( "edit" ) )
            {
                splitContainerControl1 . Panel2 . Enabled = false;
                splitContainerControl1 . Panel1 . Enabled = true;
                treeView1 . Enabled = true;
            }

            cancelTool ( state );

            return 0;
        }
        #endregion

        #region Method
        //生成部门编号
        void NumOfPerson ( )
        {
            CarpenterBll . Bll . DepartMentBll _bll = new CarpenterBll . Bll . DepartMentBll ( );
            CarpenterEntity . DepartMentEntity _list = new CarpenterEntity . DepartMentEntity ( );
            _list . DEP001 = _bll . GetStr ( );
            if ( string . IsNullOrEmpty ( _list . DEP001 ) )
                _list . DEP001 = "0001";
            else
            {
                if ( Convert . ToInt32 ( _list . DEP001 ) < 9 )
                    _list . DEP001 = "000" + ( Convert . ToInt32 ( _list . DEP001 ) + 1 ) . ToString ( );
                else if ( Convert . ToInt32 ( _list . DEP001 ) >= 9 && Convert . ToInt32 ( _list . DEP001 ) < 99 )
                    _list . DEP001 = "00" + ( Convert . ToInt32 ( _list . DEP001 ) + 1 ) . ToString ( );
                else if ( Convert . ToInt32 ( _list . DEP001 ) >= 99 && Convert . ToInt32 ( _list . DEP001 ) < 999 )
                    _list . DEP001 = "0" + ( Convert . ToInt32 ( _list . DEP001 ) + 1 ) . ToString ( );
                else
                    _list . DEP001 = ( Convert . ToInt32 ( _list . DEP001 ) + 1 ) . ToString ( );
            }
            texNum . Text = _list . DEP001;
        }
        //添加节点  调用的时候parentId以0值开始 setTreeView(treeView1, 0);
        void setTreeView ( TreeView tr ,int pid )
        {
            CarpenterBll . Bll . DepartMentBll _bll = new CarpenterBll . Bll . DepartMentBll ( );
            DataTable tableQuery = _bll . GetDataTable ( pid );
            if ( tableQuery != null && tableQuery . Rows . Count > 0 )
            {
                int pId = -1;
                foreach ( DataRow row in tableQuery . Rows )
                {
                    TreeNode node = new TreeNode ( );
                    node . Text = row [ "DEP002" ] . ToString ( );
                    node . Tag = Convert . ToInt32 ( row [ "DEP001" ] . ToString ( ) );
                    pId = ( int ) row [ "DEP003" ];
                    if ( pId == 0 )
                    {
                        treeView1 . Nodes . Add ( node );
                    }
                    else
                    {
                        RefreshChildNode ( treeView1 ,node ,pId );
                    }
                    //查找以node为父节点的子节点
                    setTreeView ( treeView1 ,( int ) node . Tag );
                }
            }
        }
        //处理根节点的子节点
        void RefreshChildNode ( TreeView tr ,TreeNode treeNode ,int pid )
        {
            foreach ( TreeNode node in tr.Nodes )
            {
                if ( ( int ) node . Tag == pid )
                {
                    node . Nodes . Add ( treeNode );
                    return;
                }
                else if ( node . Nodes . Count > 0 )
                {
                    FindChildNode ( node ,treeNode ,pid );
                }
            }
        }
        //处理根节点的子节点的子节点
        void FindChildNode ( TreeNode tNode ,TreeNode treeNode ,int pid )
        {
            foreach ( TreeNode node in tNode . Nodes )
            {
                if ( ( int ) node . Tag == pid )
                {
                    node . Nodes . Add ( treeNode );
                    return;
                }
                else if(node.Nodes.Count>0)
                {
                    FindChildNode ( node ,treeNode ,pid );
                }
            }
        }
        #endregion

        #region Event
        private void treeView1_NodeMouseClick ( object sender ,TreeNodeMouseClickEventArgs e )
        {
            if ( !string . IsNullOrEmpty ( e . Node . Tag . ToString ( ) ) )
            {
                texNum . Text = e . Node . Tag . ToString ( );
                texNum . Text = texNum . Text . PadLeft ( 4 ,'0' );
                //if ( Convert . ToInt32 ( e . Node . Tag . ToString ( ) ) < 9 )
                //    texNum . Text = "000" + e . Node . Tag . ToString ( );
                //else if ( Convert . ToInt32 ( e . Node . Tag . ToString ( ) ) >= 9 && Convert . ToInt32 ( e . Node . Tag . ToString ( ) ) < 99 )
                //    texNum . Text = "00" + e . Node . Tag . ToString ( );
                //else if ( Convert . ToInt32 ( e . Node . Tag . ToString ( ) ) >= 99 && Convert . ToInt32 ( e . Node . Tag . ToString ( ) ) < 999 )
                //    texNum . Text = "0" + e . Node . Tag . ToString ( );
                //if ( Convert . ToInt32 ( e . Node . Tag . ToString ( ) ) >= 999 )
                //    texNum . Text = e . Node . Tag . ToString ( );
            }
            else
                texNum . Text = e . Node . Tag . ToString ( );
            texName . Text = e . Node . Text;

            texNum . Tag = Convert . ToInt32 ( texNum . Text ) . ToString ( );
            signOfJob ( );
        }
        void signOfJob ( )
        {
            CarpenterBll . Bll . DepartMentBll _bll = new CarpenterBll . Bll . DepartMentBll ( );
            checkJob . Checked = _bll . signOfJob ( texNum . Text ) == true ? true : false;
        }
        #endregion

    }
}
