using dotnet.webapi.Controllers;
using Microsoft.Extensions.Logging;

namespace dotnet.webapi.nunit
{
    [TestFixture]
    public class WeatherForecastControllerTests(ILogger<WeatherForecastController> logger)
    {
        private readonly ILogger<WeatherForecastController> _logger = logger;
        private WeatherForecastController _weatherForecastController;

        [SetUp]
        public void Setup()
        {
            _weatherForecastController = new WeatherForecastController(_logger);
        }

        [Test]
        public void Test1()
        {
            var result = _weatherForecastController.Get(5);

            if (result.Count() == 5)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
