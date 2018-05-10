using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
{
    /// <summary>
    /// Custom Interface that will be used in the Configure method in Startup.cs
    /// </summary>
    public interface IGreeter
    {
        string GetMessageOfTheDay();
    }

    public class Greeter : IGreeter
    {
        private IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetMessageOfTheDay()
        {
            return _configuration["Greeting"];
        }
    }
}