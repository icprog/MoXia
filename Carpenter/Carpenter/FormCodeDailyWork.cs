using DevExpress . XtraEditors;
using FastReport . Data;
using System;
using System . Collections . Generic;
using System . Data;
using System . Drawing;
using System . Reflection;
using System . Runtime . InteropServices;
using System . Threading;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormCodeDailyWork :FormBase
    {
        Thread thread; SynchronizationContext m_SyncContext = null;
        DataTable tableView,table; int len=0;/*decimal*/ /*jgNum=0M*//*;*/
        CarpenterBll.Bll.ProductDailyWorkBll _bll=null;
        CarpenterEntity.ProductDailyWorkEntity _model=null;
        TextBox str=new TextBox(); bool isOk =false;
        bool btnClick=false;
        
        public FormCodeDailyWork ( )
        {
            InitializeComponent ( );
            
            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            _bll = new CarpenterBll . Bll . ProductDailyWorkBll ( );
            _model = new CarpenterEntity . ProductDailyWorkEntity ( );

            //获取UI线程同步上下文
            m_SyncContext = SynchronizationContext . Current;
            tableView = new DataTable ( );
            tableView . Columns . Add ( "PRD004" ,typeof ( System . String ) );
            tableView . Columns . Add ( "PRD005" ,typeof ( System . String ) );
            tableView . Columns . Add ( "DEP002" ,typeof ( System . String ) );
            tableView . Columns . Add ( "De" ,typeof ( System . String ) );
            gridControl1 . DataSource = tableView;
            //this . txtCode . Focus ( );
            //this . txtCode . ScrollToCaret ( );
            txtCode . Select ( );
            keyBoard . Visible = false;

            keyBoard . btnOne . Click += BtnOne_Click;
            keyBoard . btnTwo . Click += BtnTwo_Click;
            keyBoard . btnTre . Click += BtnTre_Click;
            keyBoard . btnFor . Click += BtnFor_Click;
            keyBoard . btnFiv . Click += BtnFiv_Click;
            keyBoard . btnSix . Click += BtnSix_Click;
            keyBoard . btnSev . Click += BtnSev_Click;
            keyBoard . btnEgi . Click += BtnEgi_Click;
            keyBoard . btnNin . Click += BtnNin_Click;
            keyBoard . btnZ . Click += BtnZ_Click;
            keyBoard . btnDel . Click += BtnDel_Click;
            keyBoard . btnEx . Click += BtnEx_Click;
            keyBoard . btnDi . Click += BtnDi_Click;
            keyBoard . btnC . Click += BtnC_Click;

            //确保控件在最上面
            keyBoard . BringToFront ( );
        }
        
        private void FormCodeDailyWork_Load ( object sender ,System . EventArgs e )
        {
            this . MouseDown += new System . Windows . Forms . MouseEventHandler ( Form_MouseDown );
            this . MouseMove += new System . Windows . Forms . MouseEventHandler ( Form_MouseMove );
            this . MouseUp += new System . Windows . Forms . MouseEventHandler ( Form_MouseUp );
            
            this . thread = new Thread ( new ThreadStart ( this . ThreadProcSafePost ) );
            this . thread . Start ( );
        }
        
        #region FormEvent
        Point mouseOff;//鼠标移动位置变量  
        bool leftFlag;//标签是否为左键  
        private void Form_MouseDown ( object sender ,MouseEventArgs e )
        {
            if ( e . Button == MouseButtons . Left )
            {
                mouseOff = new Point ( -e . X ,-e . Y ); //得到变量的值  
                leftFlag = true;                  //点击左键按下时标注为true;  
            }
        }
        private void Form_MouseMove ( object sender ,MouseEventArgs e )
        {
            if ( leftFlag )
            {
                Point mouseSet = Control . MousePosition;
                mouseSet . Offset ( mouseOff . X ,mouseOff . Y );  //设置移动后的位置  
                //( ( ( /*System.Windows.Forms.PictureBox*/ ) sender ).Parent ).Location = mouseSet;
                this . Location = mouseSet;
            }
        }
        private void Form_MouseUp ( object sender ,MouseEventArgs e )
        {
            if ( leftFlag )
            {
                leftFlag = false;//释放鼠标后标注为false;  
            }
        }

        private void panel1_MouseDown ( object sender ,MouseEventArgs e )
        {
            if ( e . Button == MouseButtons . Left )
            {
                mouseOff = new Point ( -e . X ,-e . Y ); //得到变量的值  
                leftFlag = true;                  //点击左键按下时标注为true;  
            }
        }
        private void panel1_MouseUp ( object sender ,MouseEventArgs e )
        {
            if ( leftFlag )
            {
                leftFlag = false;//释放鼠标后标注为false;  
            }
        }
        private void panel1_MouseMove ( object sender ,MouseEventArgs e )
        {
            if ( leftFlag )
            {
                Point mouseSet = Control . MousePosition;
                mouseSet . Offset ( mouseOff . X ,mouseOff . Y );  //设置移动后的位置  
                //( ( ( /*System.Windows.Forms.PictureBox*/ ) sender ).Parent ).Location = mouseSet;
                this . Location = mouseSet;
            }
        }

        [DllImport ( "user32.dll" )]
        public static extern bool ReleaseCapture ( );
        [DllImport ( "user32.dll" )]
        public static extern bool SendMessage ( IntPtr hwnd ,int wMsg ,int wParam ,int lParam );
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        #endregion

        #region Event
        //Cancel
        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . Close ( );
        }
        //Save
        private void btnSave_Click ( object sender ,EventArgs e )
        {
            btnClick = false;
            if ( getValue ( ) == false )
                return;
            
            isOk = _bll . Save ( _model ,tableView );
            if ( isOk )
            {
                XtraMessageBox . Show ( "保存成功" );
                _model . PRD025 = 0;
                _model . PRD024 = string . Empty;
                _model . PRD026 = string . Empty;
            }
            else
                XtraMessageBox . Show ( "保存失败" );
        }
        //强制完工
        private void btnSaveOver_Click ( object sender ,EventArgs e )
        {
            //TODO:强制完工的规格和记工数量如果和最初的一致是否保存？
            //TODO:应该带出规格就可以，记工数量自己填写，只要有内容就保存
            //TODO:强制完工是否需要开工扫描

            btnClick = true;
            if ( getValue ( ) == false )
                return;

            if ( _model . PRD037 > 0 || _model . PRD039 > 0 || _model . PRD041 > 0 )
            {
                _model . PRD035 = true;
                isOk = _bll . Save ( _model ,tableView );
                if ( isOk )
                {
                    XtraMessageBox . Show ( "保存成功" );
                    _model . PRD025 = 0;
                    _model . PRD024 = string . Empty;
                    _model . PRD026 = string . Empty;
                }
                else
                    XtraMessageBox . Show ( "保存失败" );
            }
            else
                XtraMessageBox . Show ( "强制完工必须满足其中一个记工数量大于0" );
        }
        //Reset
        private void btnReset_Click ( object sender ,EventArgs e )
        {
            weekNum . Text = partName . Text = proNum . Text = labNumProduct . Text = proName . Text = cp . Text = proSpice . Text = Num . Text = txtSpe1 . Text = txtSpe2 . Text = txtSpe3 . Text = txtNum1 . Text = txtNum2 . Text = txtNum3 . Text = string . Empty;
            rabClose . Checked = rabOpen . Checked = false;
            txtTime . Text = "1";
        }
        //ResetAll
        private void button1_Click ( object sender ,EventArgs e )
        {
            txtCode . Text = EquName . Text = equNum . Text = cmbArt . Text = weekNum . Text = proName . Text = proNum . Text = proSpice . Text = partName . Text = Num . Text = remark . Text = cp . Text = txtNum1 . Text = txtNum2 . Text = txtNum3 . Text =txtSpe1.Text=txtSpe2.Text=txtSpe3.Text= string . Empty;
            rabClose . Checked = rabOpen . Checked = false;
            cmbArt . DataSource = null;
            lupSpace . Properties . DataSource = null;
            txtTime . Text = string . Empty;
            labNumProduct . Text = string . Empty;
            cmdRemark . Text = string . Empty;
            cmbSalary . Items . Clear ( );
            cmbSalary . Text = string . Empty;
            tableView . Rows . Clear ( );
            gridControl1 . RefreshDataSource ( );
        }
        //Equpment
        private void labEqu_Click ( object sender ,EventArgs e )
        {
            //if ( string . IsNullOrEmpty ( txtCode . Text ) )
            //{
            //    XtraMessageBox . Show ( "请扫描设备" );
            //    return;
            //}
            
        }
        //person
        private void labPer_Click ( object sender ,EventArgs e )
        {
            //if ( string . IsNullOrEmpty ( txtCode . Text ) )
            //{
            //    XtraMessageBox . Show ( "请扫描人员" );
            //    return;
            //}
           
        }
        //cp
        private void labCp_Click ( object sender ,EventArgs e )
        {
           
            
        }
        //DELETE PERSON
        private void gridView1_RowCellClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowCellClickEventArgs e )
        {
            int num = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
            {
                if ( e . Column . Name == "De" )
                {
                    tableView . Rows . RemoveAt ( num );
                    gridControl1 . RefreshDataSource ( );
                }
            }
        }
        //Code
        private void txtCode_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e . KeyChar == 13 )
            {
                if ( string . IsNullOrEmpty ( txtCode . Text ) )
                {
                    XtraMessageBox . Show ( "请扫描传票" );
                    return;
                }
                len = txtCode . Text . Length;
                if ( len > 6 )
                {
                    if ( string . IsNullOrEmpty ( equNum . Text ) )
                    {
                        XtraMessageBox . Show ( "请先扫描设备" );
                        return;
                    }
                    if ( string . IsNullOrEmpty ( cmbArt . Text ) )
                    {
                        XtraMessageBox . Show ( "请选择设备工艺" );
                        return;
                    }
                    cpC ( );
                }
                else if ( len == 6 )
                {
                    Equpment ( );
                }
                else if ( len < 6 )
                {
                    person ( );
                }
            }
        }
        private void cp_TextChanged ( object sender ,EventArgs e )
        {
            if ( cp . Text . Length == 12 )
            {
                Num . Text = _bll . numOfPart ( cp . Text ) . ToString ( );
                Num . Tag = Num . Text;
                _model . PRD012 = Convert . ToDecimal ( Num . Text );
            }
        }
        private void cmbArt_TextChanged ( object sender ,EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( cmbArt . Text ) )
            {
                _model . PRD032 = cmbArt . SelectedValue . ToString ( );

                lupSpace . Properties . DataSource = _bll . tableSpace ( equNum . Text ,cmbArt . Text );
                lupSpace . Properties . DisplayMember = "idx";
                lupSpace . Properties . ValueMember = "idx";

                cmbSalary . Items . Clear ( );
                DataTable salaryOfArt = _bll . tableSalary ( _model . PRD032 );
                if ( salaryOfArt != null && salaryOfArt . Rows . Count > 0 )
                {
                    _model . PRD033 = salaryOfArt . Rows [ 0 ] [ "ART011" ] . ToString ( );
                    if ( !string . IsNullOrEmpty ( _model . PRD033 ) )
                    {
                        string [ ] salaryType = _model . PRD033 . Split ( ',' );
                        foreach ( string s in salaryType )
                        {
                            cmbSalary . Items . Add ( s . Trim ( ) );
                        }
                        cmbSalary . Text = salaryType [ 0 ];
                    }
                }
            }
        }
        private void lupSpace_EditValueChanged ( object sender ,EventArgs e )
        {
            LookUpEdit edit = sender as LookUpEdit;
            if ( edit . EditValue != null )
            {
                object o = edit . Properties . GetDataSourceRowByKeyValue ( edit . EditValue );
                if ( o is DataRowView )
                {
                    DataRowView v = o as DataRowView;
                    _model . PRD024 = v . Row [ "ARU002" ] . ToString ( );
                    _model . PRD025 = string . IsNullOrEmpty ( v . Row [ "ARU005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( v . Row [ "ARU005" ] . ToString ( ) );
                    _model . PRD026 = v . Row [ "ARU006" ] . ToString ( );
                }
            }
        }
        #endregion

        #region Click
        private void Num_MouseClick ( object sender ,MouseEventArgs e )
        {
            str = Num;
            if ( keyBoard . Visible )
            {
                if ( keyBoard . Location . X == labelControl7 . Location . X - 19 )
                    keyBoard . Visible = false;
                else
                    keyBoard . Location = new Point ( labelControl7 . Location . X - 19 ,labelControl7 . Location . Y - 266 );
            }
            else
            {
                keyBoard . Visible = true;
                keyBoard . Location = new Point ( labelControl7 . Location . X - 19 ,labelControl7 . Location . Y - 266 );
            }
        }
        private void txtCode_MouseClick ( object sender ,MouseEventArgs e )
        {
            str = txtCode;
            if ( keyBoard . Visible )
            {
                if ( keyBoard . Location . X == labelControl17 . Location . X - 19 )
                    keyBoard . Visible = false;
                else
                    keyBoard . Location = new Point ( labelControl17 . Location . X - 19 ,labelControl17 . Location . Y + 20 );
            }
            else
            {
                keyBoard . Visible = true;
                keyBoard . Location = new Point ( labelControl17 . Location . X - 19 ,labelControl17 . Location . Y + 20 );
            }
        }
        private void txtTime_MouseClick ( object sender ,MouseEventArgs e )
        {
            str = txtTime;
            if ( keyBoard . Visible )
            {
                if ( keyBoard . Location . X == labelControl10 . Location . X )
                    keyBoard . Visible = false;
                else
                    keyBoard . Location = new Point ( labelControl10 . Location . X ,labelControl10 . Location . Y + 20 );
            }
            else
            {
                keyBoard . Visible = true;
                keyBoard . Location = new Point ( labelControl10 . Location . X ,labelControl10 . Location . Y + 20 );
            }
        }
        private void txtSpe1_MouseClick ( object sender ,MouseEventArgs e )
        {
            str = txtSpe1;
            if ( keyBoard . Visible )
            {
                if ( keyBoard . Location . X == labelControl21 . Location . X )
                    keyBoard . Visible = false;
                else
                    keyBoard . Location = new Point ( labelControl21 . Location . X ,labelControl21 . Location . Y - 266 );
            }
            else
            {
                keyBoard . Visible = true;
                keyBoard . Location = new Point ( labelControl21 . Location . X ,labelControl21 . Location . Y - 266 );
            }
        }
        private void txtNum1_MouseClick ( object sender ,MouseEventArgs e )
        {
            str = txtNum1;
            if ( keyBoard . Visible )
            {
                if ( keyBoard . Location . X == labelControl23 . Location . X )
                    keyBoard . Visible = false;
                else
                    keyBoard . Location = new Point ( labelControl23 . Location . X ,labelControl23 . Location . Y - 266 );
            }
            else
            {
                keyBoard . Visible = true;
                keyBoard . Location = new Point ( labelControl23 . Location . X ,labelControl23 . Location . Y - 266 );
            }
        }
        private void txtSpe2_MouseClick ( object sender ,MouseEventArgs e )
        {
            str = txtSpe2;
            if ( keyBoard . Visible )
            {
                if ( keyBoard . Location . X == labelControl24 . Location . X )
                    keyBoard . Visible = false;
                else
                    keyBoard . Location = new Point ( labelControl24 . Location . X ,labelControl24 . Location . Y - 266 );
            }
            else
            {
                keyBoard . Visible = true;
                keyBoard . Location = new Point ( labelControl24 . Location . X ,labelControl24 . Location . Y - 266 );
            }
        }
        private void txtNum2_MouseClick ( object sender ,MouseEventArgs e )
        {
            str = txtNum2;
            if ( keyBoard . Visible )
            {
                if ( keyBoard . Location . X == labelControl18 . Location . X )
                    keyBoard . Visible = false;
                else
                    keyBoard . Location = new Point ( labelControl18 . Location . X ,labelControl18 . Location . Y - 266 );
            }
            else
            {
                keyBoard . Visible = true;
                keyBoard . Location = new Point ( labelControl18 . Location . X ,labelControl18 . Location . Y - 266 );
            }
        }
        private void txtSpe3_MouseClick ( object sender ,MouseEventArgs e )
        {
            str = txtSpe3;
            if ( keyBoard . Visible )
            {
                if ( keyBoard . Location . X == labelControl26 . Location . X )
                    keyBoard . Visible = false;
                else
                    keyBoard . Location = new Point ( labelControl26 . Location . X ,labelControl26 . Location . Y - 266 );
            }
            else
            {
                keyBoard . Visible = true;
                keyBoard . Location = new Point ( labelControl26 . Location . X ,labelControl26 . Location . Y - 266 );
            }
        }
        private void txtNum3_MouseClick ( object sender ,MouseEventArgs e )
        {
            str = txtNum3;
            if ( keyBoard . Visible )
            {
                if ( keyBoard . Location . X == labelControl25 . Location . X )
                    keyBoard . Visible = false;
                else
                    keyBoard . Location = new Point ( labelControl25 . Location . X ,labelControl25 . Location . Y - 266 );
            }
            else
            {
                keyBoard . Visible = true;
                keyBoard . Location = new Point ( labelControl25 . Location . X ,labelControl25 . Location . Y - 266 );
            }
        }
        private void BtnEx_Click ( object sender ,EventArgs e )
        {
            keyBoard . Visible = false;
        }
        private void BtnDel_Click ( object sender ,EventArgs e )
        {
            if ( str . Text . Length > 0 )
            {
                str . Text = str . Text . Substring ( 0 ,str . Text . Length - 1 );
                str . SelectionStart = str . Text . Length;
            }
        }
        private void BtnZ_Click ( object sender ,EventArgs e )
        {
            str . Text = str . Text + "0";
        }
        private void BtnNin_Click ( object sender ,EventArgs e )
        {
            str . Text = str . Text + "9";
        }
        private void BtnEgi_Click ( object sender ,EventArgs e )
        {
            str . Text = str . Text + "8";
        }
        private void BtnSev_Click ( object sender ,EventArgs e )
        {
            str . Text = str . Text + "7";
        }
        private void BtnSix_Click ( object sender ,EventArgs e )
        {
            str . Text = str . Text + "6";
        }
        private void BtnFiv_Click ( object sender ,EventArgs e )
        {
            str . Text = str . Text + "5";
        }
        private void BtnFor_Click ( object sender ,EventArgs e )
        {
            str . Text = str . Text + "4";
        }
        private void BtnTwo_Click ( object sender ,EventArgs e )
        {
            str . Text = str . Text + "2";
        }
        private void BtnTre_Click ( object sender ,EventArgs e )
        {
            str . Text = str . Text + "3";
        }
        private void BtnOne_Click ( object sender ,EventArgs e )
        {
            str . Text = str . Text + "1";
        }
        private void BtnC_Click ( object sender ,EventArgs e )
        {
            str . Text = str . Text + "*";
        }
        private void BtnDi_Click ( object sender ,EventArgs e )
        {
            str . Text = str . Text + ".";
        }
        #endregion

        #region ThreadMethod
        //第二步：定义线程的主体方法
        /// <summary>
        /// 线程的主体方法
        /// </summary>
        private void ThreadProcSafePost ( )
        {
            while ( true )
            {
                Thread . Sleep ( 1000 );
                //...执行线程任务


                if ( this . dtpTime . Text == string . Empty )
                    //在线程中更新UI（通过UI线程同步上下文m_SyncContext）
                    m_SyncContext . Post ( SetTextSafePost ,CarpenterBll . UserInformation . dt ( ) . ToString ( ) );
                else
                    m_SyncContext . Post ( SetTextSafePost ,CarpenterBll . UserInformation . dt ( ) . ToString ( ) );

                //...执行线程其他任务
            }
        }
        //第三步：定义更新UI控件的方法
        /// <summary>
        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetTextSafePost ( object text )
        {
            if ( this . dtpTime . Text == string . Empty )
                this . dtpTime . Text = text . ToString ( );
            else
                this . dtpTime . Text = Convert . ToDateTime ( dtpTime . Text ) . AddMilliseconds ( 1000 ) . ToString ( );
        }
        #endregion

        #region Other Method
        bool getValue ( )
        {
            if ( string . IsNullOrEmpty ( equNum . Text ) )
            {
                XtraMessageBox . Show ( "请扫描设备" );
                return false;
            }
            if ( string . IsNullOrEmpty ( cp . Text ) )
            {
                XtraMessageBox . Show ( "请扫描传票" );
                return false;
            }
            if ( rabClose . Checked == false && rabOpen . Checked == false )
            {
                XtraMessageBox . Show ( "请选择开工或完工" );
                return false;
            }
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );
            if ( tableView == null || tableView . Rows . Count < 1 )
            {
                XtraMessageBox . Show ( "请扫描人员" );
                return false;
            }

            if ( rabClose . Checked == true )
            {
                decimal num = 0;
                if ( btnClick == false )
                {
                    if ( string . IsNullOrEmpty ( Num . Text ) && string . IsNullOrEmpty ( txtNum1 . Text ) && string . IsNullOrEmpty ( txtNum2 . Text ) && string . IsNullOrEmpty ( txtNum3 . Text ) )
                    {
                        XtraMessageBox . Show ( "请填写记工数量" );
                        return false;
                    }
                    if ( decimal . TryParse ( Num . Text ,out num ) == false )
                    {
                        XtraMessageBox . Show ( "数量请填写数字" );
                        return false;
                    }
                    if ( decimal . TryParse ( txtNum1 . Text ,out num ) == false )
                    {
                        XtraMessageBox . Show ( "数量请填写数字" );
                        return false;
                    }
                    if ( decimal . TryParse ( txtNum2 . Text ,out num ) == false )
                    {
                        XtraMessageBox . Show ( "数量请填写数字" );
                        return false;
                    }
                    if ( decimal . TryParse ( txtNum3 . Text ,out num ) == false )
                    {
                        XtraMessageBox . Show ( "数量请填写数字" );
                        return false;
                    }
                    if ( Convert . ToDecimal ( Num . Text ) <= 0 && Convert . ToDecimal ( txtNum1 . Text ) <= 0 && Convert . ToDecimal ( txtNum2 . Text ) <= 0 && Convert . ToDecimal ( txtNum3 . Text ) <= 0 )
                    {
                        XtraMessageBox . Show ( "记工数量必须大于0" );
                        return false;
                    }
                }
                else if ( btnClick )
                {
                    if ( !string . IsNullOrEmpty ( Num . Text ) && decimal . TryParse ( Num . Text ,out num ) == false )
                    {
                        XtraMessageBox . Show ( "数量请填写数字" );
                        return false;
                    }
                    if ( !string . IsNullOrEmpty ( txtNum1 . Text ) && decimal . TryParse ( txtNum1 . Text ,out num ) == false )
                    {
                        XtraMessageBox . Show ( "数量请填写数字" );
                        return false;
                    }
                    if ( !string . IsNullOrEmpty ( txtNum2 . Text ) && decimal . TryParse ( txtNum2 . Text ,out num ) == false )
                    {
                        XtraMessageBox . Show ( "数量请填写数字" );
                        return false;
                    }
                    if ( !string . IsNullOrEmpty ( txtNum3 . Text ) && decimal . TryParse ( txtNum3 . Text ,out num ) == false )
                    {
                        XtraMessageBox . Show ( "数量请填写数字" );
                        return false;
                    }
                }
            }

            if ( string . IsNullOrEmpty ( labNumProduct . Text ) )
            {
                XtraMessageBox . Show ( "请填写产品数量" );
                return false;
            }
            if ( Convert . ToInt32 ( labNumProduct . Text ) < 1 )
            {
                XtraMessageBox . Show ( "产品数量必须大于0" );
                return false;
            }

            string check = string . Empty;
            if ( string . IsNullOrEmpty ( cmbSalary . Text ) )
            {
                if ( cmbSalary . Items . Count < 1 )
                {
                    _model . PRD032 = cmbArt . SelectedValue . ToString ( );
                    cmbSalary . Items . Clear ( );
                    DataTable salaryOfArt = _bll . tableSalary ( _model . PRD032 );
                    if ( salaryOfArt != null && salaryOfArt . Rows . Count > 0 )
                    {
                        if ( XtraMessageBox . Show ( "工艺：" + cmbArt . Text + "有工资类型,是否选择?" ,"提示" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
                        {
                            check = "1";
                            _model . PRD033 = salaryOfArt . Rows [ 0 ] [ "ART011" ] . ToString ( );
                            if ( !string . IsNullOrEmpty ( _model . PRD033 ) )
                            {
                                string [ ] salaryType = _model . PRD033 . Split ( ',' );
                                foreach ( string s in salaryType )
                                {
                                    cmbSalary . Items . Add ( s . Trim ( ) );
                                }
                                cmbSalary . Text = salaryType [ 0 ];
                            }
                        }
                    }
                }
            }

            if ( check == "1" && string . IsNullOrEmpty ( cmbSalary . Text ) )
            {
                XtraMessageBox . Show ( "请选择工资类型" );
                return false;
            }


            _model . PRD001 = equNum . Text;
            _model . PRD002 = EquName . Text;
            _model . PRD003 = cmbArt . Text;
            _model . PRD006 = cp . Text;
            _model . PRD007 = weekNum . Text;
            _model . PRD008 = proNum . Text;
            _model . PRD009 = proName . Text;
            _model . PRD034 = proSpice . Text;
            _model . PRD011 = partName . Text;
            _model . PRD010 = partName . Tag . ToString ( );
            _model . PRD042 = string . IsNullOrEmpty ( labNumProduct . Text ) == true ? 0 : Convert . ToInt32 ( labNumProduct . Text );

            _model . PRD014 = rabOpen . Checked == true ? true : false;
            _model . PRD016 = remark . Text;
            decimal dLen = 0;
            if ( !string . IsNullOrEmpty ( Num . Text ) && decimal . TryParse ( Num . Text ,out dLen ) == false )
            {
                XtraMessageBox . Show ( "记工数量应为数字" );
                return false;
            }
            _model . PRD019 = dLen;
            _model . PRD020 = false;
            _model . PRD022 = cmdRemark . Text;
            len = 0;
            if ( !string . IsNullOrEmpty ( txtTime . Text ) && int . TryParse ( txtTime . Text ,out len ) == false )
            {
                XtraMessageBox . Show ( "加工次数应为数字" );
                return false;
            }
            if ( len < 1 )
            {
                XtraMessageBox . Show ( "加工次数至少为1" );
                return false;
            }
            _model . PRD023 = len;
            _model . PRD033 = cmbSalary . Text;
            _model . PRD035 = false;
            _model . PRD036 = txtSpe1 . Text;
            dLen = 0;
            if ( !string . IsNullOrEmpty ( txtNum1 . Text ) && decimal . TryParse ( txtNum1 . Text ,out dLen ) == false )
            {
                XtraMessageBox . Show ( "记工数量应为数字" );
                return false;
            }
            _model . PRD037 = dLen;
            if ( dLen <= 0 )
                _model . PRD036 = string . Empty;
            _model . PRD038 = txtSpe2 . Text;
            dLen = 0;
            if ( !string . IsNullOrEmpty ( txtNum2 . Text ) && decimal . TryParse ( txtNum2 . Text ,out dLen ) == false )
            {
                XtraMessageBox . Show ( "记工数量应为数字" );
                return false;
            }
            _model . PRD039 = dLen;
            if ( dLen <= 0 )
                _model . PRD038 = string . Empty;
            _model . PRD040 = txtSpe3 . Text;
            dLen = 0;
            if ( !string . IsNullOrEmpty ( txtNum3 . Text ) && decimal . TryParse ( txtNum3 . Text ,out dLen ) == false )
            {
                XtraMessageBox . Show ( "记工数量应为数字" );
                return false;
            }
            _model . PRD041 = dLen;
            if ( dLen <= 0 )
                _model . PRD040 = string . Empty;
            dLen = 0;
            if ( !string . IsNullOrEmpty ( Num . Tag . ToString ( ) ) && decimal . TryParse ( Num . Tag . ToString ( ) ,out dLen ) == false )
            {
                XtraMessageBox . Show ( "记工数量应为数字" );
                return false;
            }
            _model . PRD012 = dLen;

            if ( _model . PRD019 > _model . PRD012 )
            {
                XtraMessageBox . Show ( "记工数量多于零件数量,请更正" );
                return false;
            }

            //是否有开工记录
            _model . PRD005 = _bll . ExistsSign ( _model ,tableView );
            if ( !string . IsNullOrEmpty ( _model . PRD005 ) )
            {
                if ( _model . PRD014 )
                {
                    XtraMessageBox . Show ( "姓名:" + _model . PRD005 + "\r\n" + "设备:" + _model . PRD002 + "\r\n" + "工艺:" + _model . PRD003 + "\r\n" + "传票:" + _model . PRD006 + "\r\n" + "未完工,不可重复开工" );
                    return false;
                }
                if ( _model . PRD014 == false )
                {
                    XtraMessageBox . Show ( "姓名:" + _model . PRD005 + "\r\n" + "设备:" + _model . PRD002 + "\r\n" + "工艺:" + _model . PRD003 + "\r\n" + "传票:" + _model . PRD006 + "\r\n" + "未开工,不可完工" );
                    return false;
                }
            }

            //完工操作
            if ( _model . PRD014 == false )
            {
                //同组人员是否同时完工
                Dictionary<string ,string> userList = _bll . isOver ( _model ,tableView );
                if ( userList != null && userList . Count > 0 )
                {
                    foreach ( string str in userList . Keys )
                    {
                        XtraMessageBox . Show ( "人员编号:" + str + "\n\r人员姓名:" + userList [ str ] + "\n\r同时开工,请同时完工" );
                        return false;
                    }
                }
            }

            if ( _bll . isOver ( _model ) )
            {
                if ( XtraMessageBox . Show ( "传票：" + _model . PRD006 + "\r\n工艺：" + _model . PRD003 + "\r\n已经强制完工,是否继续记工？" ,"报工提示" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
                    return true;
                else
                    return false;
            }

            if ( _bll . isOverForSave ( _model ) )
            {
                if ( XtraMessageBox . Show ( "传票：" + _model . PRD006 + "\r\n工艺：" + _model . PRD003 + "\r\n订单数量已报工完成,是否继续报工？" ,"报工提示" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
                    return true;
                else
                    return false;
            }

            if ( _model . PRD019 > 0 )
            {
                dLen = _bll . getOverNum ( _model );
                if ( _model . PRD012 - dLen < _model . PRD019 )
                {
                    XtraMessageBox . Show ( "传票：" + _model . PRD006 + "\r\n工艺：" + _model . PRD003 + "\r\n已经记工" + dLen + ",记工数量多余剩余零件数量,请编辑其它记工数量" );
                    return false;
                }
            }

            return true;
        }
        void Equpment ( )
        {
            table = _bll . equExists ( txtCode . Text );
            if ( table != null && table . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( table . Rows [ 0 ] [ "EQU001" ] . ToString ( ) ) )
                {
                    XtraMessageBox . Show ( "不存在编号:" + txtCode . Text + "的设备,请核实" );
                    return;
                }
                txtCode . Text = string . Empty;
                EquName . Text = table . Rows [ 0 ] [ "EQU002" ] . ToString ( );
                equNum . Text = table . Rows [ 0 ] [ "EQU001" ] . ToString ( );
                DataTable dt = _bll . GetArt ( equNum . Text );
                DataRow row = dt . NewRow ( );
                row [ "EQV003" ] = string . Empty;
                row [ "EQV002" ] = string . Empty;
                dt . Rows . InsertAt ( row ,0 );
                cmbArt . DataSource = dt;
                cmbArt . DisplayMember = "EQV003";
                cmbArt . ValueMember = "EQV002";
                if ( dt != null && dt . Rows . Count > 1 )
                    cmbArt . Text = dt . Rows [ 1 ] [ "EQV003" ] . ToString ( );
                cmdRemark . DataSource = _bll . tableRemark ( equNum . Text );
                cmdRemark . DisplayMember = "EQU010";
                txtTime . Text = "1";
            }
            else
                XtraMessageBox . Show ( "不存在编号:" + txtCode . Text + "的设备,请核实" );
        }
        void person ( )
        {
            table = _bll . perExists ( txtCode . Text );
            if ( table != null && table . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( table . Rows [ 0 ] [ "EMP001" ] . ToString ( ) ) )
                {
                    XtraMessageBox . Show ( "不存在编号:" + txtCode . Text + "的人员,请核实" );
                    return;
                }
                txtCode . Text = String . Empty;
                string perName = table . Rows [ 0 ] [ "EMP002" ] . ToString ( );
                string perNum = table . Rows [ 0 ] [ "EMP001" ] . ToString ( );
                string partNum = table . Rows [ 0 ] [ "DEP002" ] . ToString ( );

                if ( tableView != null && tableView . Rows . Count > 0 )
                {
                    if ( tableView . Select ( "PRD005='" + perNum + "'" ) . Length < 1 )
                        tableView . Rows . Add ( perNum ,perName ,partNum ,"" );
                }
                else if ( tableView == null )
                {
                    tableView . Columns . Add ( "PRD004" ,typeof ( System . String ) );
                    tableView . Columns . Add ( "PRD005" ,typeof ( System . String ) );
                    tableView . Columns . Add ( "DEP002" ,typeof ( System . String ) );
                    tableView . Columns . Add ( "De" ,typeof ( System . String ) );
                    tableView . Rows . Add ( perNum ,perName ,partNum ,"" );
                    gridControl1 . DataSource = tableView;
                }
                else
                {
                    tableView . Rows . Add ( perNum ,perName ,partNum ,"" );
                    gridControl1 . DataSource = tableView;
                }
            }
            else
                XtraMessageBox . Show ( "不存在编号:" + txtCode . Text + "的人员,请核实" );
        }
        void cpC ( )
        {
            table = _bll . cpExists ( txtCode . Text ,equNum . Text ,cmbArt . Text );
            if ( table != null && table . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( table . Rows [ 0 ] [ "WPC005" ] . ToString ( ) ) )
                {
                    XtraMessageBox . Show ( "不存在编号:" + txtCode . Text + "的传票,请核实" );
                    return;
                }
                txtCode . Text = string . Empty;
                weekNum . Text = table . Rows [ 0 ] [ "WPC001" ] . ToString ( );
                proName . Text = table . Rows [ 0 ] [ "WOQ008" ] . ToString ( );
                proNum . Text = table . Rows [ 0 ] [ "WPC002" ] . ToString ( );
                partName . Text = table . Rows [ 0 ] [ "WPC004" ] . ToString ( );
                proSpice . Text = txtSpe1 . Text = txtSpe2 . Text = txtSpe3 . Text = table . Rows [ 0 ] [ "WOR" ] . ToString ( );
                partName . Tag = table . Rows [ 0 ] [ "WOQ009" ] . ToString ( );
                cp . Text = table . Rows [ 0 ] [ "WPC005" ] . ToString ( );
                labNumProduct . Text = table . Rows [ 0 ] [ "CUU003" ] . ToString ( );
                txtNum1 . Text = txtNum2 . Text = txtNum3 . Text = 0 . ToString ( );
            }
            else
                XtraMessageBox . Show ( "不存在编号:" + txtCode . Text + "的传票,请核实" );
        }
        #endregion

    }
}






