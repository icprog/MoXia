using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace Carpenter
{
    public class ThreadManager
    {
        public AnnouncementRemindThread AnnouncementThread = null;
        public event EventHandler<AnnouncementRemindEventArgs > UIAnnouncementCallBackEvent = null;

        protected void StartAnnouncementThread ( )
        {
            if ( AnnouncementThread != null )
                AnnouncementThread . Stop ( );
            AnnouncementThread = new AnnouncementRemindThread ( );
            AnnouncementThread . UICallBackEvent += UIAnnouncementCallBackEvent;
            AnnouncementThread . Start ( );
        }

        protected void StopAnnouncementThread ( )
        {
            if ( AnnouncementThread != null )
            {
                AnnouncementThread . UICallBackEvent -= UIAnnouncementCallBackEvent;
                AnnouncementThread . Stop ( );
            }
        }

        public void StartThread ( )
        {
            StartAnnouncementThread ( );
        }

        public void StopThread ( )
        {
            StopAnnouncementThread ( );
        }

    }
}
