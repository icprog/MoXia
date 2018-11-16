using System;
using System . Data;
using System . Reflection;
using System . Threading;

namespace Carpenter
{
    public partial class FormRemind :FormBase
    {
        public FormRemind ( )
        {
            InitializeComponent ( );

           Utility . GridViewMoHuSelect . SetFilter ( gridView1 );          
        }


        public delegate void gridControlDelegate ( DataTable da );

        
        private void FormRemind_Load ( object sender ,System . EventArgs e )
        {
            Thread thread = new Thread ( new ThreadStart ( readQuery ) );
            thread . Start ( );
        }
        
        void readQuery ( )
        {
            try
            {
                Thread . Sleep ( 2000 );
                gridControlDelegate gD = new gridControlDelegate ( setValue );
                CarpenterBll . Bll . RemindBll _bll = new CarpenterBll . Bll . RemindBll ( );
                DataTable tableQuery = _bll . GetQuery ( UserLogin . userNum );
                BeginInvoke ( gD ,new object [ ] { tableQuery } );
            }
            catch ( Exception ex )
            {
                Utility . LogHelper . WriteLog ( ex . StackTrace );
            }
        }

        void setValue ( DataTable da )
        {
            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            gridControl1 . DataSource = da;
        }

    }
}
