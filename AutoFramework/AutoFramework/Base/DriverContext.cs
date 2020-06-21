using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AutoFramework.Base
{
    public class DriverContext
    {
        public readonly ParallelConfig _parellelConfig;

        public DriverContext(ParallelConfig parellelConfig)
        {
            _parellelConfig = parellelConfig;
        }


        public void GoToUrl(string url)
        {
            _parellelConfig.Driver.Url = url;
        }
    }
}
