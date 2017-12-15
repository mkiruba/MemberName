using System.Runtime.InteropServices;

namespace MemberName.AddinAdapter
{
    [ComVisible(true)]
    public interface IAddInAdapter
    {
        void ShowMemberDialog();
    }
}
