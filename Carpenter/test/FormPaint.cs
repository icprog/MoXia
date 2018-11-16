﻿
using DevExpress . XtraSplashScreen;
using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Drawing . Drawing2D;
using System . Linq;
using System . Text;
using System . Windows . Forms;

namespace test
{
    public partial class FormPaint :Form
    {
        public FormPaint ( )
        {
            InitializeComponent ( );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rectangle">表示矩形的大小和位置的数组</param>
        /// <param name="ga">画笔</param>
        /// <param name="_radius">圆的角度</param>
        /// <param name="cusp">是否画尖角</param>
        /// <param name="biginColor">渐变色的起始</param>
        /// <param name="endColor">渐变色的结束颜色</param>
        private void Draw ( Rectangle rectangle ,Graphics ga ,int _radius ,bool cusp ,Color biginColor ,Color endColor )
        {
            int span = 2;
            ga . SmoothingMode = System . Drawing . Drawing2D . SmoothingMode . AntiAlias;
            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush ( rectangle ,biginColor ,endColor ,LinearGradientMode . Vertical );
            //画尖角
            if ( cusp )
            {
                span = 10;
                PointF p1 = new PointF ( rectangle . Width - 12 ,rectangle . Y + 10 );
                PointF p2 = new PointF ( rectangle . Width - 12 ,rectangle . Y + 30 );
                PointF p3 = new PointF ( rectangle . Width ,rectangle . Y + 20 );
                PointF [ ] ptsArray = new PointF [ ] { p1 ,p2 ,p3 };
                ga . FillPolygon ( myLinearGradientBrush ,ptsArray );
            }
            //填充
            ga . FillPath ( myLinearGradientBrush ,DrawRoundRect ( rectangle . X ,rectangle . Y ,rectangle . Width - span ,rectangle . Height - 1 ,_radius ) );
        }

        private static GraphicsPath DrawRoundRect ( int x ,int y ,int with ,int heigh ,int radius )
        {
            //四边圆角
            GraphicsPath g = new GraphicsPath ( );
            g . AddArc ( x ,y ,radius ,radius ,180 ,90 );
            g . AddArc ( with - radius ,y ,radius ,radius ,270 ,90 );
            g . AddArc ( with - radius ,heigh - radius ,radius ,radius ,0 ,90 );
            g . AddArc ( x ,heigh - radius ,radius ,radius ,90 ,90 );
            g . CloseAllFigures ( );
            return g;
        }

        private void button1_Paint ( object sender ,PaintEventArgs e )
        {
            Draw ( e . ClipRectangle ,e . Graphics ,18 ,false ,Color . FromArgb ( 0 ,122 ,204 ) ,Color . FromArgb ( 8 ,39 ,57 ) );
            base . OnPaint ( e );
            Graphics g = e . Graphics;
            g . DrawString ( "其实我是个按钮" ,new Font ( "微软雅黑" ,9 ,FontStyle . Regular ) ,new SolidBrush ( Color . White ) ,new PointF ( 10 ,10 ) );
        }

        private void button1_Click ( object sender ,EventArgs e )
        {
            MessageBox . Show ( button1 . Text );
        }
    }
}
