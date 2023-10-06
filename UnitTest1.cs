using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;
using OpenQA.Selenium.Interactions;
using System;

namespace TestProject1
{
    public class UkrNetLoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public UkrNetLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        IWebElement loginInput => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("body > div > div > main > div._25Ti7VOS > form > div._3c6HWgJy > div > label > input")));
        IWebElement passwordInput => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("body > div > div > main > div._25Ti7VOS > form > div:nth-child(2) > div > label > input")));
        //IWebElement continueButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("body > div > div > main > div._25Ti7VOS > form > button")));ublic IWebElement LoginButton => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#app-root > form > div._3upfBFYx._1XeqbOeu > button"))); // Use ElementToBeClickable here

        public void Login(string email, string password)
        {
            Actions actions = new Actions(driver);
            loginInput.SendKeys(email);
            passwordInput.SendKeys(password);
            actions.SendKeys(passwordInput, Keys.Enter).Build().Perform();
            //LoginButton.Click();

        }

    }

    public class GMXAcceptPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
    

        public void GMXLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }


    }

    public class GMXLoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public GMXLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        //IWebElement logInButton => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#login-button")));

        

        IWebElement loginInput => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("body > div > div > main > div._25Ti7VOS > form > div._3c6HWgJy > div > label > input")));
        IWebElement passwordInput => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("body > div > div > main > div._25Ti7VOS > form > div:nth-child(2) > div > label > input")));
        //IWebElement continueButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("body > div > div > main > div._25Ti7VOS > form > button")));ublic IWebElement LoginButton => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#app-root > form > div._3upfBFYx._1XeqbOeu > button"))); // Use ElementToBeClickable here

        public void Login(string email, string password)
        {
            Actions actions = new Actions(driver);
            //logInButton.Click();
            loginInput.SendKeys(email);
            passwordInput.SendKeys(password);
            actions.SendKeys(passwordInput, Keys.Enter).Build().Perform();
            //LoginButton.Click();

        }

    }

    public class WebTests
        { 
            IWebDriver driver;
            WebDriverWait wait;
            

            [SetUp]
            public void Setup()
            {
                driver = new ChromeDriver();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            }
                        
            [Test]
            public void TestUkrNet2()
            {
                driver.Navigate().GoToUrl("https://accounts.ukr.net/login?client_id=9GLooZH9KjbBlWnuLkVX");

                UkrNetLoginPage ukrNetLoginPage = new UkrNetLoginPage(driver);

                ukrNetLoginPage.Login("webdrivertest4646", "webdrivertest464");

                wait.Until(driver => driver.Url.Contains("desktop"));

                Assert.IsTrue(driver.Url.Contains("desktop"), "Login failed!");

            }

            [Test]
            public void TestUkrNetNegativeWrongLogin()
            {
                driver.Navigate().GoToUrl("https://accounts.ukr.net/login?client_id=9GLooZH9KjbBlWnuLkVX");

                UkrNetLoginPage ukrNetLoginPage = new UkrNetLoginPage(driver);

                ukrNetLoginPage.Login("wrongLogin", "webdrivertest464");

                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //bool urlDoesNotContainDesktop = wait.Until(driver => !driver.Url.Contains("desktop"));

                // Assert: Verify that the URL does not contain "desktop"
                //Assert.IsTrue(urlDoesNotContainDesktop, "Login succeeded unexpectedly!");

                //IWebElement errorMessageElement = wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div/div/main/div[1]/form/p/text()[1]")));

                //Assert.IsNotNull(errorMessageElement, "Exact link not found.");

                //WebDriverWait wait = new WebDriverWait (driver, TimeSpan.FromSeconds(30));

                wait.Until(driver => driver.Url.Contains("accounts"));
                                
                Assert.IsTrue(driver.Url.Contains("accounts"), "Login failed!");

            }

            [Test]
            public void TestUkrNetNegativeWrongPassword()
            {
                driver.Navigate().GoToUrl("https://accounts.ukr.net/login?client_id=9GLooZH9KjbBlWnuLkVX");

                UkrNetLoginPage ukrNetLoginPage = new UkrNetLoginPage(driver);

                ukrNetLoginPage.Login("webdrivertest4646", "wrongPassword");

                wait.Until(driver => driver.Url.Contains("accounts"));

                Assert.IsTrue(driver.Url.Contains("accounts"), "Login failed!");

            }

            [Test]
            public void EmailSending()
            {
                driver.Navigate().GoToUrl("https://accounts.ukr.net/login?client_id=9GLooZH9KjbBlWnuLkVX");

                UkrNetLoginPage ukrNetLoginPage = new UkrNetLoginPage(driver);

                ukrNetLoginPage.Login("webdrivertest4646", "webdrivertest464");

                IWebElement button = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#content > aside > button")));

                button.Click();

                IWebElement receiver = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#screens > div > div.screen__content > section.sendmsg__form > div:nth-child(1) > div.sendmsg__form-label-field.auto.cropped.ui-sortable > input.input")));

                receiver.SendKeys("andriilevshakov@gmx.com");

                //IWebElement emailBody = driver.FindElement(By.Id("tinymce"));

                //emailBody.SendKeys("Andreas");

                Actions action = new Actions(driver);

                action.SendKeys(receiver, Keys.Tab).Build().Perform();

                action.SendKeys(receiver, Keys.Tab).Build().Perform();

                action.SendKeys(Keys.Tab).Build().Perform();

                action.SendKeys("Andreas").Build().Perform();

                action.SendKeys(Keys.Tab).Build().Perform();

                action.SendKeys(Keys.Enter).Build().Perform();

                IWebElement conf = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#screens > div > div.sendmsg__ads.show.ready > div.sendmsg__ads-sending > div.sendmsg__ads-ready")));

                //Console.ReadLine();

                //Console.WriteLine("done");

                Assert.IsTrue(conf.Displayed, "The button is not displayed on the page.");
            }

        [Test]
        public void TestGMX()
        {
            driver.Navigate().GoToUrl("https://www.gmx.com/#.1730814-header-navlogin2-1");

            Thread.Sleep(5000);

            Actions action = new Actions(driver);

            action.SendKeys(Keys.Tab).Build().Perform();

            action.SendKeys(Keys.Tab).Build().Perform();

            action.SendKeys(Keys.Tab).Build().Perform();

            action.SendKeys(Keys.Enter).Build().Perform();

            IWebElement emailField = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#login-email")));

            emailField.SendKeys("andriilevshakov@gmx.com");

            action.SendKeys(Keys.Tab).Build().Perform();

            action.SendKeys("levshakov23").Build().Perform();

            action.SendKeys(Keys.Enter).Build().Perform();

            IWebElement emailPage = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#actions-menu-primary > a:nth-child(2) > svg")));

            emailPage.Click();

            Thread.Sleep(5000);

            //driver.SwitchTo().Frame(4);

            IWebElement unreadEmailPage = driver.FindElement(By.CssSelector("#id6b > td.last > div.container-relative > div.name"));

            unreadEmailPage.Click();


            Console.ReadLine();

            //wait.Until(driver => driver.Url.Contains("navigator"));

            //Assert.IsTrue(driver.Url.Contains("navigator"), "Login failed!");

        }

        [Test]
        public void TestGMX2()
        {
            driver.Navigate().GoToUrl("https://navigator-bs.gmx.com/home?sid=6a6da4ad211cf0ec777f500eacd4e983c880c57b5f1b9999038598b42a92e008c4f6838da3596bae48c2deb0b1db8749");

            Console.ReadLine();
        }


            [TearDown]
            public void Teardown()
            {
                driver.Dispose();
            }
        }






    }

