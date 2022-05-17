using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LibraryReact.Models;
using LibraryReact.Repositories;

namespace LibraryReact.Services
{
    public interface IMemberServices
    {
        Task<IEnumerable<Members>> Getmember();
        Task<Members> GetmemberById(string memberobj);
        Task<Members> Updatemember(Members memberobj);
        Task<Members> Createmember(Members memberobj);
        Task<Members> Deletemember(string memberobj);

    }
}