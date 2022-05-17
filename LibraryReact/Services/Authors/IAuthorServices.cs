using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LibraryReact.Models;

namespace LibraryReact.Services
{
    public interface IAuthorServices
    {
        Task<IEnumerable<Authors>> Getauthor();
        Task<Authors> GetauthorById(string authorobj);
        Task<Authors> UpdateAuthor(Authors authorobj);
        Task<Authors> CreateAuthor(Authors authorobj);
        Task<Authors> DeleteAuthor(string authorobj);

    }
}