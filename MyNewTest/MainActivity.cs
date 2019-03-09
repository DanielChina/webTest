using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace MyNewTest
{
    class MainActivity
    { 
        private  int currentCase =1;
        static void Main(string[] args)
        {
        }
        [SetUp]
        public void Initialize()
        {
            Container.UI= new ChromeDriver();
        }
        [Test]
        public void Execute()
        {
            //login and check my cart
            switch(currentCase)
            {
                case 1:
                    TestCase.Login(Container.UI, false);
                    break;
                case 2:
                    TestCase.LoginAndCheckCart(Container.UI);
                    break;
                case 3:
                    TestCase.BoundaryTestCase(Container.UI);
                    break;
                case 4:
                    TestCase.TestAndSaveResult(Container.UI);
                    break;
                default:
                    return;
            }
                        
        }
        [TearDown]
        public void Cleanup()
        {
            Container.UI.Close();
        }
    }
}
