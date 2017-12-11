using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Diagnostics;

namespace MemberName.Service
{
    public class GetMembers
    {
        string uri = "http://data.parliament.uk/membersdataplatform/services/mnis/members/query/House=Commons%7CIsEligible=true/";
        public async void GetMembersAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(uri);

                var result = response.Content;
                // return URI of the created resource.
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                throw;
            }
           
           
        }
    }
}
