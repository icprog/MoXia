using System;
using System . ServiceProcess;
using System . Configuration;

namespace BackSqlServer
{
    public partial class BCSQL :ServiceBase
    {
        public BCSQL ( )
        {
            InitializeComponent ( );

            System . Timers . Timer timer = new System . Timers . Timer ( );
            timer . Elapsed += new System . Timers . ElapsedEventHandler ( TimeEvent );

            string t = ConfigurationManager . ConnectionStrings [ "time" ] . ConnectionString;
            timer . Interval = int . Parse ( t );////每1秒1000*60*60*24 = 一天执行一次  
            timer . Enabled = true;
        }

        //定时执行事件
        private void TimeEvent ( object sender ,System . Timers . ElapsedEventArgs e )
        {
            string nowDate = DateTime . Now . ToString ( "HH" );//得到小时
            Utility . LogHelper . WriteLog ( "\n检索时间：" + nowDate + " " + DateTime . Now . ToString ( "mm" ) );
            string str = null;
            //每天凌晨2点对数据库进行备份操作
            if ( nowDate == "23" )
            {
                //从配置文件中得到需要备份的数据库
                string DB = ConfigurationManager . ConnectionStrings [ "DB" ] . ConnectionString;
                string [ ] arr = DB . Split ( ';' );

                //遍历进行备份操作
                for ( int i = 0 ; i < arr . Length ; i++ )
                {
                    Utility . LogHelper . WriteLog ( "\n当前时间：" + DateTime . Now . ToString ( "yyyy-MM-dd hh-mm-ss" ) + "\n" );
                    Utility . LogHelper . WriteLog ( "\n开始备份数据库：" + "\n" );
                    str = DbBackup . Backuping ( arr [ i ] );
                    Utility . LogHelper . WriteLog ( "\n备份数据库：" + str + "\n" );
                }
            }
        }

        //启动服务
        protected override void OnStart ( string [ ] args )
        {
            Utility . LogHelper . WriteLog ( "当前时间：" + DateTime . Now );
            Utility . LogHelper . WriteLog ( "客户端数据同步服务：【服务启动】" );
        }

        //停止服务
        protected override void OnStop ( )
        {
            Utility . LogHelper . WriteLog ( "当前时间：" + DateTime . Now );
            Utility . LogHelper . WriteLog ( "客户端数据同步服务：【服务停止】" );
        }

        //关闭计算机
        protected override void OnShutdown ( )
        {
            Utility . LogHelper . WriteLog ( "当前时间：" + DateTime . Now );
            Utility . LogHelper . WriteLog ( "客户端数据同步服务：【计算机关闭】" );
        }

    }
}
