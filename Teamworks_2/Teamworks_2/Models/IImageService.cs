using System;
using System.Threading.Tasks;

namespace Teamworks_2.Models
{
    public interface IImageService
    {
        Task<string> PickImageAsync();
    }
}
