using System;
using System . Data;
using System . Drawing;
using System . Windows . Forms;

namespace Carpenter
{
    public partial class FormMain :FormBase
    {
        
        public FormMain ( )
        {
            InitializeComponent ( );

            this . Location = new Point ( -1000 ,-1000 );
           
        }

        private void FormMain_Load ( object sender ,EventArgs e )
        {
            Login ( );

            //SetImage . setImage ( pictureBox1 ,"BackGround.jpg" );
            //splitContainer1 . Panel2 . BackgroundImageLayout = ImageLayout . Stretch;
        }

        /// <summary>
        /// Login
        /// </summary>
        protected void Login ( )
        {
            this . Hide ( );
            FormLogin form = new FormLogin ( );
            this . StartPosition = FormStartPosition . WindowsDefaultBounds;
            if ( form . ShowDialog ( ) == System . Windows . Forms . DialogResult . OK )
            {
                this . Location = new Point ( 0 ,0 );
                this . WindowState = FormWindowState . Maximized;
                this . Show ( );
                this . BringToFront ( );
                this . toolLogin . Text = UserLogin . userName + "(" + UserLogin . userNum + ")";
            }
            else
                this . Close ( );

            ShowMenuByUser ( );
        }

        void ShowMenuByUser ( )
        {
            Power ( pushPanelItem1 );
            Power ( pushPanelItem2 );
            Power ( pushPanelItem3 );
        }

        void Power ( UILibrary . PushPanel . PushPanelItem pnl )
        {
            if ( UserLogin . userNum == "00001" )
                return;
            CarpenterBll . Bll . MainBll _bll = new CarpenterBll . Bll . MainBll ( );
            DataTable dt = _bll . GetDataTablePower ( UserLogin . userNum );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                foreach ( Control cn in pnl . Controls )
                {
                    if ( cn . GetType ( ) == typeof ( Label ) )
                    {
                        Label lab = cn as Label;
                        if ( !string . IsNullOrEmpty ( lab . Tag . ToString ( ) ) )
                        {
                            if ( dt . Select ( "POW003='" + lab . Tag . ToString ( ) + "'" ) . Length < 1 )
                                lab . Enabled = false;
                            else
                                lab . Enabled = true;
                        }
                        else
                            lab . Enabled = false;
                    }
                }
            }
            else
            {
                foreach ( Control cn in pnl . Controls )
                {
                    if ( cn . GetType ( ) == typeof ( Label ) )
                    {
                        Label lab = cn as Label;
                        lab . Enabled = false;
                    }
                }
            }
        }

        private void labDepment_Click ( object sender ,EventArgs e )
        {
            Form from = new FormDepartMent ( );
            UserLogin . programName = from . Name;
            from . Show ( );
        }
        private void labEmployee_Click ( object sender ,EventArgs e )
        {
            Form from = new FormEmployee ( );
            UserLogin . programName = from . Name;
            from . Show ( );
        }
        private void labPower_Click ( object sender ,EventArgs e )
        {
            Form from = new FormPower ( );
            UserLogin . programName = from . Name;
            from . Show ( );
        }
        private void labProgram_Click ( object sender ,EventArgs e )
        {
            Form from = new FormProgramControl ( );
            UserLogin . programName = from . Name;
            from . Show ( );
        }
        private void labSetReview_Click ( object sender ,EventArgs e )
        {
            Form from = new FormSetReview ( );
            UserLogin . programName = from . Name;
            from . Show ( );
        }
        private void ToolStripPwd_Click ( object sender ,EventArgs e )
        {
            Form from = new FormSetPW ( );
            from . Show ( );
        }
        private void ToolStripRemind_Click ( object sender ,EventArgs e )
        {
            Form from = new FormRemind ( );
            from . Show ( );
        }
        private void labArt_Click ( object sender ,EventArgs e )
        {
            Form from = new FormArt ( );
            from . Show ( );
        }
        private void labEquipment_Click ( object sender ,EventArgs e )
        {
            Form from = new FormEquipment ( );
            from . Show ( );
        }
        private void label1_Click ( object sender ,EventArgs e )
        {
            Form from = new FormOPI ( );
            UserLogin . programName = from . Name;
            from . Show ( );
        }
        private void label2_Click ( object sender ,EventArgs e )
        {
            Form from = new FormBomWoodPaint ( );
            UserLogin . programName = from . Name;
            from . Show ( );
        }
        private void labBomWorkPlan_Click ( object sender ,EventArgs e )
        {
            Form from = new FormBomWorkPlan ( );
            UserLogin . programName = from . Name;
            from . Show ( );
        }
        private void labPlanCutting_Click ( object sender ,EventArgs e )
        {
            Form from = new FormPlanCutting ( );
            UserLogin . programName = from . Name;
            from . Show ( );
        }
        private void labProductSchedule_Click ( object sender ,EventArgs e )
        {
            Form from = new FormProductSchedule ( );
            UserLogin . programName = from . Name;
            from . Show ( );
        }
        private void labProductionStock_Click ( object sender ,EventArgs e )
        {
            Form from = new FormProductionStock ( );
            UserLogin . programName = from . Name;
            from . Show ( );
        }
        private void labPlanStock_Click ( object sender ,EventArgs e )
        {
            Form from = new FormPlanStock ( );
            UserLogin . programName = from . Name;
            from . Show ( );
        }
        private void lalabPlanStockWork_Click ( object sender ,EventArgs e )
        {
            Form from = new FormPlanStockWork ( );
            UserLogin . programName = from . Name;
            from . Show ( );
        }
        private void labPlanStockDailyWork_Click ( object sender ,EventArgs e )
        {
            Form from = new FormPlanStockDailyWork ( );
            UserLogin . programName = from . Name;
            from . Show ( );
        }
        private void ToolClose_Click ( object sender ,EventArgs e )
        {
            this . Close ( );
            this . Dispose ( );
        }

        private void ToolRstart_Click ( object sender ,EventArgs e )
        {
            Application . Restart ( );
        }

    }
}
