using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LibraryReact.Models;
using LibraryReact.Repositories;

namespace LibraryReact.Services
{
    public interface IPublisherServices
    {
        Task<IEnumerable<Publishers>> Getpublisher();
        Task<Publishers> GetpublisherById(string publisherobj);
        Task<Publishers> Updatepublisher(Publishers publisherobj);
        Task<Publishers> Createpublisher(Publishers publisherobj);
        Task<Publishers> Deletepublisher(string publisherobj);

    }
}