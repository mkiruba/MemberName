using MemberName.Frontend;

namespace MemberName.AddinAdapter
{
    public class AddinAdapter
    {
        public void ShowMemberDialog()
        {
            MemberControl memberControl = new MemberControl();
            var result = memberControl.ShowDialog();
        }
    }
}
