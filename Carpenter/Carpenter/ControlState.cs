

using System . Windows . Forms;

namespace Carpenter
{
    public class ControlState
    {
        public static void ControlEnable ( Control con )
        {
            foreach ( Control cn in con.Controls )
            {
                if ( cn . GetType ( ) == typeof ( TextBox ) )
                {
                    TextBox box = cn as TextBox;
                    box . Enabled = true;
                    continue;
                }
                if ( cn . GetType ( ) == typeof ( ComboBox ) )
                {
                    ComboBox box = cn as ComboBox;
                    box . Enabled = true;
                    continue;
                }
                if ( cn . GetType ( ) == typeof ( RichTextBox ) )
                {
                    RichTextBox box = cn as RichTextBox;
                    box . Enabled = true;
                    continue;
                }
                if ( cn . GetType ( ) == typeof ( Button ) )
                {
                    Button box = cn as Button;
                    box . Enabled = true;
                    continue;
                }
                if ( cn . GetType ( ) == typeof ( DateTimePicker ) )
                {
                    DateTimePicker dtp = cn as DateTimePicker;
                    dtp . Enabled = true;
                    continue;
                }
                if ( cn . GetType ( ) == typeof ( DevExpress . XtraEditors . MemoEdit ) )
                {
                    DevExpress . XtraEditors . MemoEdit box = cn as DevExpress . XtraEditors . MemoEdit;
                    box . Enabled = true;
                    continue;
                }
            }
        }
        public static void ControlUnEnable ( Control con )
        {
            foreach ( Control cn in con . Controls )
            {
                if ( cn . GetType ( ) == typeof ( TextBox ) )
                {
                    TextBox box = cn as TextBox;
                    box . Enabled = false;
                    continue;
                }
                if ( cn . GetType ( ) == typeof ( ComboBox ) )
                {
                    ComboBox box = cn as ComboBox;
                    box . Enabled = false;
                    continue;
                }
                if ( cn . GetType ( ) == typeof ( RichTextBox ) )
                {
                    RichTextBox box = cn as RichTextBox;
                    box . Enabled = false;
                    continue;
                }
                if ( cn . GetType ( ) == typeof ( Button ) )
                {
                    Button box = cn as Button;
                    box . Enabled = false;
                    continue;
                }
                if ( cn . GetType ( ) == typeof ( DevExpress.XtraEditors.MemoEdit ) )
                {
                    DevExpress . XtraEditors . MemoEdit box = cn as DevExpress . XtraEditors . MemoEdit;
                    box . Enabled = false;
                    continue;
                }
            }
        }
        public static void ControlClear ( Control con )
        {
            foreach ( Control cn in con . Controls )
            {
                if ( cn . GetType ( ) == typeof ( TextBox ) )
                {
                    TextBox box = cn as TextBox;
                    box . Text = string . Empty;
                    continue;
                }
                if ( cn . GetType ( ) == typeof ( ComboBox ) )
                {
                    ComboBox box = cn as ComboBox;
                    box . Text = string . Empty;
                    continue;
                }
                if ( cn . GetType ( ) == typeof (DevExpress.XtraEditors.MemoEdit  ) )
                {
                    DevExpress . XtraEditors . MemoEdit box = cn as DevExpress . XtraEditors . MemoEdit;
                    box . Text = string . Empty;
                    continue;
                }
            }
        }
    }
}
