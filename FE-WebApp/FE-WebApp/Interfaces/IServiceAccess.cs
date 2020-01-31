using System.Threading.Tasks;

namespace FE_WebApp.Interfaces
{
    public interface IServiceAccess
    {
        /// <summary>
        /// Post the data to an API
        /// </summary>
        /// <typeparam name="T">Type of Response Object that is expected</typeparam>
        /// <typeparam name="M">Type Request Object that needs to be posted</typeparam>
        /// <param name="url">URL for the API where data needs to be posted</param>
        /// <param name="request">Request object that needs to be posted</param>
        /// <returns>Task of type of expected response</returns>
        Task<T> PostAsync<T, M>(string url, M request);
    }
}
