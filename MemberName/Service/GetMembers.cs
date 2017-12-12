using System;
using System.Net.Http;
using System.Diagnostics;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MemberName.Service
{
    public class GetMembers
    {
        string uri = "http://data.parliament.uk/membersdataplatform/services/mnis/members/query/House=Commons%7CIsEligible=true/";
        public void GetMembersAsync()
        {
            try
            {
                Task<string> task;
                using (var client = new HttpClient())
                {
                    var result = client.GetAsync(uri).Result;
                    result.EnsureSuccessStatusCode();
                    task = result.Content.ReadAsStringAsync();                    
                }
                task.Wait();
                try
                {
                    var xDocument = XDocument.Parse(task.Result);
                    LoadMembers(xDocument);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                    throw;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                throw;
            }                    
        }

        private void LoadMembers(XDocument xDocument)
        {
            List<MemberNameBO> members = new List<MemberNameBO>();
            foreach (var member in xDocument.Descendants("Member"))
            {
                members.Add(new MemberNameBO
                {
                    MemberName = member.Element("DisplayAs").Value,
                    Constituency = member.Element("MemberFrom").Value,
                    Party = member.Element("Party").Value,
                });
            }
        }
    }
}
