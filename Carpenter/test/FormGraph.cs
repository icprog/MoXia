using System;
using System . Drawing;
using System . Windows . Forms;

namespace test
{
    public partial class FormGraph :Form
    {
        public FormGraph ( )
        {
            InitializeComponent ( );
        }

        private void FormGraph_Load ( object sender ,EventArgs e )
        {
            gra ( splitContainerControl1 );
            gra ( pictureBox1 );
        }

        private void FormGraph_Paint ( object sender ,PaintEventArgs e )
        {
            //Graphics gp = e . Graphics;
            //画填充圆
            //SolidBrush s = new SolidBrush ( Color . Red );
            //画空心圆
            //Pen pen = new Pen ( Color . Red ,3 );           
            //gp . DrawEllipse ( pen ,50 ,50 ,90 ,60 );
            //Font myFont = new Font ( "宋体" ,20 ,FontStyle .Bold );
            //Brush bush = new SolidBrush ( Color . Red );
            //gp . DrawString ( "审核" ,myFont ,bush ,60 ,65 );
        }

        void gra ( DevExpress . XtraEditors . SplitContainerControl sp )
        {
            sp . Panel1 . Paint += ( s ,e ) =>
              {
                  Graphics gp = e . Graphics;
                  //画填充圆
                  //SolidBrush s = new SolidBrush ( Color . Red );
                  //画空心圆
                  Pen pen = new Pen ( Color . Red ,3 );
                  gp . DrawEllipse ( pen ,50 ,50 ,90 ,60 );
                  Font myFont = new Font ( "宋体" ,20 ,FontStyle . Bold );
                  Brush bush = new SolidBrush ( Color . Red );
                  gp . DrawString ( "审核" ,myFont ,bush ,60 ,65 );
              };
        }

        void gra ( PictureBox sp )
        {
            sp . Paint += ( s ,e ) =>
            {
                Graphics gp = e . Graphics;
                //画填充圆
                //SolidBrush s = new SolidBrush ( Color . Red );
                //画空心圆
                Pen pen = new Pen ( Color . Red ,3 );
                gp . DrawEllipse ( pen ,50 ,50 ,90 ,60 );
                Font myFont = new Font ( "宋体" ,20 ,FontStyle . Bold );
                Brush bush = new SolidBrush ( Color . Red );
                gp . DrawString ( "审核" ,myFont ,bush ,60 ,65 );
            };
        }


    }
}
