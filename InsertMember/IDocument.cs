using System.Runtime.InteropServices;

namespace InsertMember
{
    [ComVisible(true)]
    public interface IDocument
    {
        string ShowMemberDialog();
    }
}
