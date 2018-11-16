using System . Threading;
using System . Windows . Forms;

namespace Carpenter
{
    public static class CrossThreadCalls
    {
        /// <summary>
        /// 跨线程访问控件 在控件上执行委托
        /// </summary>
        /// <param name="ctl">控件</param>
        /// <param name="del">执行的委托</param>
        public static void CrossThreadCall ( this Control ctl ,ThreadStart del )
        {
            if ( del == null )
                return;
            if ( ctl . InvokeRequired )
                ctl . Invoke ( del ,null );
            else
                del ( );
        }
    }
}

