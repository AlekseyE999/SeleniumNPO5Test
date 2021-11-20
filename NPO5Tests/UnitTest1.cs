using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace NPO5Tests
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("c:/WebDriver/bin/");
            driver.Navigate().GoToUrl("https://97minsk.schools.by");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void nonValidEmail()
        {
            var LinkFeedback = driver.FindElement(By.XPath("//a[text()='Обратная связь']"));
            LinkFeedback.Click();
            string nonValidEmail = "Неверный формат e-mail.";
            var recipient = driver.FindElement(By.XPath("//input[@name='addressee']"));
            recipient.SendKeys("Директору");
            Thread.Sleep(1000);
            var UserName = driver.FindElement(By.XPath("//input[@name='user_name']"));
            UserName.SendKeys("Алексей Едунов");
            Thread.Sleep(1000);
            var UserAdress = driver.FindElement(By.XPath("//input[@name='user_contacts']"));
            UserAdress.SendKeys("Адресс");
            Thread.Sleep(1000);
            var UserEmail = driver.FindElement(By.XPath("//input[@name='user_email']"));
            UserEmail.SendKeys("NON_VALID_EMAIL");
            Thread.Sleep(1000);
            var Aim = driver.FindElement(By.XPath("//textarea[@name='text']"));
            Aim.SendKeys("Цель сообщения");
            Thread.Sleep(1000);
            var Captcha = driver.FindElement(By.XPath("//input[@name='captcha_1']"));
            Captcha.SendKeys("captcha");
            Thread.Sleep(1000);
            string pageSource = driver.PageSource;
            var Send = driver.FindElement(By.XPath("//input[@value='Отправить']"));
            Send.Click();
            bool TestComplete = pageSource.Contains(nonValidEmail);
            Assert.IsTrue(TestComplete);
            Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}