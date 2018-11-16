using System;
using System . Data;
using System . Threading;

namespace Carpenter
{
    public class AnnouncementRemindThread
    {
        public event EventHandler<AnnouncementRemindEventArgs> UICallBackEvent=null;

        /// <summary>
        /// 线程停止标识
        /// </summary>
        protected bool _flag=false;

        /// <summary>
        /// 检测周期
        /// </summary>
        private int _period=60*1000;

        /// <summary>
        /// 线程
        /// </summary>
        protected Thread _runThread=null;

        public AnnouncementRemindThread ( )
        {
        }

        /// <summary>
        /// 启动线程
        /// </summary>
        public void Start ( )
        {
            _runThread = new Thread ( Run );
            _runThread . IsBackground = true;
            _flag = true;
            _runThread . Start ( );
        }

        /// <summary>
        /// 
        /// </summary>
        protected void Run ( )
        {
            long startTemp = 0;
            long endTemp = 0;

            startTemp = DateTime . Now . Ticks;
            while ( _flag )
            {
                //线程休眠5分钟  只要不关闭线程  线程就会一直执行
                Thread . Sleep ( 6000 * 5 );
                endTemp = DateTime . Now . Ticks;
                TimeSpan tSp = new TimeSpan ( endTemp - startTemp );
                if ( tSp . TotalMilliseconds < _period )
                {
                    continue;
                }
                UserLogin . table = getTable ( );
                OnUICallBackEvent ( UserLogin . table );
                startTemp = DateTime . Now . Ticks;
            }
        }

        /// <summary>
        /// 获取最新消息
        /// </summary>
        /// <returns></returns>
        protected DataTable getTable ( )
        {
            try
            {
                CarpenterBll . Bll . MaintainTransmitBll _bll = new CarpenterBll . Bll . MaintainTransmitBll ( );
                DataTable table = _bll . getTableOfView ( UserLogin . userNum );
                if ( table != null && table . Rows . Count > 0 )
                    return table;
                else
                    return null;
            }
            catch ( Exception ex )
            {
                Utility . LogHelper . WriteException ( ex );
                return null;
            }
        }

        /// <summary>
        /// 停止运行
        /// </summary>
        public void Stop ( )
        {
            if ( _runThread != null )
            {
                _flag = false;
            }
        }

        /// <summary>
        /// 获取消息后回调UI
        /// </summary>
        /// <param name="table"></param>
        protected void OnUICallBackEvent ( DataTable table )
        {
            try
            {
                if ( UICallBackEvent != null )
                {
                    UICallBackEvent ( this ,new AnnouncementRemindEventArgs ( table ) );
                }
            }
            catch ( Exception ex )
            {
                Utility . LogHelper . WriteException ( ex );
            }
        }

    }

    public class AnnouncementRemindEventArgs :EventArgs
    {
        private DataTable _table;
        public DataTable Table
        {
            get
            {
                return _table;
            }
            set
            {
                _table = value;
            }
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        /// <param name="table"></param>
        public AnnouncementRemindEventArgs ( DataTable table )
        {
            _table = table;
        }

    }

}

