using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemberName.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberName.Service.Tests
{
    [TestClass()]
    public class GetMembersTests
    {
        [TestMethod()]
        public void GetMembersAsyncTest()
        {
            GetMembers getMembers = new GetMembers();
            getMembers.GetMembersAsync();
            
        }
    }
}