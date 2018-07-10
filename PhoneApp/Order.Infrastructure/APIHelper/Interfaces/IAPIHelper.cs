using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.APIHelper
{
    public interface IAPIHelper
    {
        string URL { get; set; }
        Task<T> Post<T>(string endPoint, object data);

    }
}
