using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LibraryReact.Models;
using LibraryReact.Repositories;

namespace LibraryReact.Services
{
    public interface IIssueBookServices
    {
        Task<IEnumerable<IssueBooks>> Getibook();
        Task<IssueBooks> GetibookById(int ibookobj);
        Task<IssueBooks> Updateibook(IssueBooks ibookobj);
        Task<IssueBooks> Createibook(IssueBooks ibookobj);
        Task<IssueBooks> Deleteibook(int ibookobj);

    }
}