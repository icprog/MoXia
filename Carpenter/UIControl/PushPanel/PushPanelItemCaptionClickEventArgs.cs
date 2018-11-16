using System;

namespace UILibrary.PushPanel
{
    /* ���ߣ�Starts_2000
     * ���ڣ�2010-08-10
     * ��վ��http://www.csharpwin.com CS ����Ա֮����
     * ��������ʹ�û��޸����´��룬���뱣����Ȩ��Ϣ��
     * ������鿴 CS����Ա֮����ԴЭ�飨http://www.csharpwin.com/csol.html����
     */
    public delegate void PushPanelItemCaptionClickEventHandler(
        object sender,
        PushPanelItemCaptionClickEventArgs e);

    public class PushPanelItemCaptionClickEventArgs : EventArgs
    {
        private PushPanelItem _item;

        public PushPanelItemCaptionClickEventArgs()
            : base()
        {
        }

        public PushPanelItemCaptionClickEventArgs(PushPanelItem item)
            : this()
        {
            _item = item;
        }

        public PushPanelItem Item
        {
            get { return _item; }
            set { _item = value; }
        }
    }
}
