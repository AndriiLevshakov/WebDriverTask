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
        }

    }    

    public class GMXLoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public GMXLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        IWebElement loginInput => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("body > div > div > main > div._25Ti7VOS > form > div._3c6HWgJy > div > label > input")));
        IWebElement passwordInput => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("body > div > div > main > div._25Ti7VOS > form > div:nth-child(2) > div > label > input")));

        public void Login(string email, string password)
        {
            Actions actions = new Actions(driver);
            
            loginInput.SendKeys(email);
            passwordInput.SendKeys(password);
            actions.SendKeys(passwordInput, Keys.Enter).Build().Perform();
        }
    }

    public class WebTests
        { 
            IWebDriver driver;
            WebDriverWait wait;

        string newNickName = "Andrii Levshakov2";            

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
            public void EmailSendingFromUkrNet()
            {
                driver.Navigate().GoToUrl("https://accounts.ukr.net/login?client_id=9GLooZH9KjbBlWnuLkVX");

                UkrNetLoginPage ukrNetLoginPage = new UkrNetLoginPage(driver);

                ukrNetLoginPage.Login("webdrivertest4646", "webdrivertest464");

                IWebElement button = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#content > aside > button")));

                button.Click();

                IWebElement receiver = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#screens > div > div.screen__content > section.sendmsg__form > div:nth-child(1) > div.sendmsg__form-label-field.auto.cropped.ui-sortable > input.input")));

                receiver.SendKeys("andriilevshakov@gmx.com");
                
                Actions action = new Actions(driver);

                action.SendKeys(receiver, Keys.Tab).Build().Perform();

                action.SendKeys(receiver, Keys.Tab).Build().Perform();

                action.SendKeys(Keys.Tab).Build().Perform();

            Thread.Sleep(2000);

            action.SendKeys("Andreas").Build().Perform();

                action.SendKeys(Keys.Tab).Build().Perform();

                action.SendKeys(Keys.Enter).Build().Perform();

                IWebElement conf = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#screens > div > div.sendmsg__ads.show.ready > div.sendmsg__ads-sending > div.sendmsg__ads-ready")));
                            
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

            driver.SwitchTo().Frame("mail");

            IWebElement unreadEmailPage = driver.FindElement(By.XPath("//tr[@class='new'][contains(@title, Levshakov)][1]"));

            unreadEmailPage.Click();

            Thread.Sleep(5000);

            driver.SwitchTo().Frame("mail-detail");

            IWebElement emailText = driver.FindElement(By.XPath("//body"));

            string emailTextString = emailText.Text;

            if (emailTextString == "Andreas")
            {                
                driver.SwitchTo().ParentFrame();

                IWebElement respondField = wait.Until(ExpectedConditions.ElementExists(By.XPath("//textarea")));

                respondField.SendKeys(newNickName);

                IWebElement sendRespondButton = driver.FindElement(By.XPath("//button[@id='send']"));

                sendRespondButton.Click();
            }
            else
            {
                throw new Exception("Email Text is not correct");
            }

            IWebElement conf = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class, 'success')]")));

            Assert.IsTrue(conf.Displayed, "Login failed!");
        }

        [Test]
        public void TestChangeNickName()
        {
            Actions action = new Actions(driver);

            driver.Navigate().GoToUrl("https://accounts.ukr.net/login?client_id=9GLooZH9KjbBlWnuLkVX");

            UkrNetLoginPage ukrNetLoginPage = new UkrNetLoginPage(driver);

            ukrNetLoginPage.Login("webdrivertest4646", "webdrivertest464");

            Thread.Sleep(5000);
            
            driver.Navigate().GoToUrl("https://mail.ukr.net/desktop#settings/account");

            IWebElement nickNameField = wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@name='name']")));

            nickNameField.Clear();

            nickNameField.SendKeys("Andrii Levshakov2");

            Thread.Sleep(2000);

            action.SendKeys(Keys.Enter).Build().Perform();

            Thread.Sleep(2000);

            driver.Navigate().GoToUrl("https://mail.ukr.net/desktop#settings/account");

            Thread.Sleep(2000);

            IWebElement nickNameField2 = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@value='Andrii Levshakov2']")));

            Assert.IsTrue(nickNameField2.Displayed);
        }


            [TearDown]
            public void Teardown()
            {
            /*
            Actions action = new Actions(driver);

            driver.Navigate().GoToUrl("https://accounts.ukr.net/login?client_id=9GLooZH9KjbBlWnuLkVX");

            UkrNetLoginPage ukrNetLoginPage = new UkrNetLoginPage(driver);

            ukrNetLoginPage.Login("webdrivertest4646", "webdrivertest464");

            Thread.Sleep(5000);

            driver.Navigate().GoToUrl("https://mail.ukr.net/desktop#settings/account");

            IWebElement nickNameField = wait.Until(ExpectedConditions.ElementExists(By.XPath("//input [@name='name']")));

            nickNameField.Clear();

            nickNameField.SendKeys("Andrii Levshakov");

            Thread.Sleep(2000);

            //IWebElement saveButton = driver.FindElement(By.XPath("//button[@type='submit']"));

            action.SendKeys(Keys.Enter).Build().Perform();
            */

            driver.Dispose();
            }
        }






    }

