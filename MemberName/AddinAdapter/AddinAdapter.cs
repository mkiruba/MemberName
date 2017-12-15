using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MemberName.Frontend;

namespace MemberName.AddinAdapter
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class AddinAdapter : IAddInAdapter
    {
        public void ShowMemberDialog()
        {
            MemberControl memberControl = new MemberControl();
            var result = memberControl.ShowDialog();
        }
    }
}
