using MyAspNetCoreApp.Models;
using System.Collections.Generic;

namespace MyAspNetCoreApp.Responses
{
    public class SearchContactsResponse
    {
        public List<Contact> Contacts { get; set; }
        public int TotalCount { get; set; }

        public SearchContactsResponse()
        {
            Contacts = new List<Contact>();
        }
    }
}