using NUnit.Framework;

namespace Northwind.Data.Services.Tests.ServicesTests
{
    [SetUpFixture]
    public class SetUpFixtureClass
    {
        private TestAppHost _appHost = null;

        [SetUp]
	    public void RunBeforeAnyTests()
	    {
            _appHost = new TestAppHost();
            _appHost.Init();
            _appHost.Start(Config.ServiceStackBaseUri);
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            if (_appHost != null)
            {
                _appHost.Stop();
                _appHost.Dispose();
            }
        }
    }
}
