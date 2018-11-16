

using System . Drawing;

namespace Carpenter . Query
{
    public partial class FormPictureEnlarge :FormBase
    {
        public FormPictureEnlarge (string text ,Image image)
        {
            InitializeComponent ( );

            this . Text = text;
            this . pictureBox1 . Image = image;
        }
    }
}
