using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LibraryReact.Models;
using LibraryReact.Repositories;

namespace LibraryReact.Services
{
    public interface IBookServices
    {
        Task<IEnumerable<Books>> Getbook();
        Task<Books> GetbookById(string bookobj);
        Task<Books> Updatebook(Books bookobj);
        Task<Books> Createbook(Books bookobj);
        Task<Books> Deletebook(string bookobj);

    }
}