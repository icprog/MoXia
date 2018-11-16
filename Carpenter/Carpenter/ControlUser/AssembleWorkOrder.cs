namespace Carpenter . ControlUser
{
    public partial class AssembleWorkOrder :DevExpress . XtraEditors . XtraUserControl
    {
        public AssembleWorkOrder ( )
        {
            InitializeComponent ( );
        }

        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
    }
}
