using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
namespace NguyenNhatLoc_TH4
{
    [TestFixture]
    public class Class1
    {
        private IWebDriver driver;
        private string baseURL;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://automationpractice.com";
        }
        [TearDown]
        public void TearDownTest()
        {
            driver.Quit();
        }
        [Test]
        public void TClogin01()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("nhatloc200@gmail.com");
            driver.FindElement(By.Id("passwd")).Click();
            driver.FindElement(By.Id("passwd")).Clear();
            driver.FindElement(By.Id("passwd")).SendKeys("123abc");
            driver.FindElement(By.Id("SubmitLogin")).Click();
            Assert.AreEqual("Lộc Nguyễn", driver.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a/span")).Text);
        }
        [Test]
        public void TC_Register_01()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();

            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.AreEqual("Invalid email address.", driver.FindElement(By.XPath("//*[@id='create_account_error']/ol/li")).Text);
        }
        [Test]
        public void TC_Register_02()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();

            driver.FindElement(By.Id("email_create")).SendKeys("nhatloc22@gmail.com");

            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.AreEqual("An account using this email address has already been registered. Please enter a valid password or request a new one.", driver.FindElement(By.XPath("//*[@id='create_account_error']/ol/li")).Text);
        }
        [Test]
        public void TC_Register_04()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("nhatloc22@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Loc");
            driver.FindElement(By.Id("passwd")).SendKeys("19072000");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("address2")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("city")).SendKeys("TDM");
            driver.FindElement(By.Id("id_state")).SendKeys("Texas");
            driver.FindElement(By.Id("postcode")).SendKeys("00000");
            driver.FindElement(By.Id("id_country")).SendKeys("United States");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone")).SendKeys("0978364572");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0978364572");
            driver.FindElement(By.Id("alias")).SendKeys("BinhDuong");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();

            Assert.AreEqual("firstname is required.", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        [Test]
        public void TC_Register_05()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("nhatloc22@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("");
            driver.FindElement(By.Id("passwd")).SendKeys("19072000");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("address2")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("city")).SendKeys("TDM");
            driver.FindElement(By.Id("id_state")).SendKeys("Texas");
            driver.FindElement(By.Id("postcode")).SendKeys("00000");
            driver.FindElement(By.Id("id_country")).SendKeys("United States");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone")).SendKeys("0978364572");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0978364572");
            driver.FindElement(By.Id("alias")).SendKeys("BinhDuong");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();

            Assert.AreEqual("lastname is required.", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        [Test]
        public void TC_Register_06()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("nhatloc22@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Nhat Loc");
            driver.FindElement(By.Id("passwd")).SendKeys("");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("address2")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("city")).SendKeys("TDM");
            driver.FindElement(By.Id("id_state")).SendKeys("Texas");
            driver.FindElement(By.Id("postcode")).SendKeys("00000");
            driver.FindElement(By.Id("id_country")).SendKeys("United States");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone")).SendKeys("0978364572");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0978364572");
            driver.FindElement(By.Id("alias")).SendKeys("BinhDuong");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();

            Assert.AreEqual("passwd is required.", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        [Test]
        public void TC_Register_07()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("nhatloc22@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Nhat Loc");
            driver.FindElement(By.Id("passwd")).SendKeys("2005");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("address2")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("city")).SendKeys("TDM");
            driver.FindElement(By.Id("id_state")).SendKeys("Texas");
            driver.FindElement(By.Id("postcode")).SendKeys("00000");
            driver.FindElement(By.Id("id_country")).SendKeys("United States");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone")).SendKeys("0978364572");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0978364572");
            driver.FindElement(By.Id("alias")).SendKeys("BinhDuong");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();

            Assert.AreEqual("passwd is invalid.", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        [Test]
        public void TC_Register_08()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("nhatloc22@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Nhat Loc");
            driver.FindElement(By.Id("passwd")).SendKeys("19072000");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("");
            driver.FindElement(By.Id("address2")).SendKeys("");
            driver.FindElement(By.Id("city")).SendKeys("TDM");
            driver.FindElement(By.Id("id_state")).SendKeys("Texas");
            driver.FindElement(By.Id("postcode")).SendKeys("00000");
            driver.FindElement(By.Id("id_country")).SendKeys("United States");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone")).SendKeys("0978364572");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0978364572");
            driver.FindElement(By.Id("alias")).SendKeys("BinhDuong");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();

            Assert.AreEqual("address1 is required.", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        [Test]
        public void TC_Register_09()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("nhatloc22@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Nhat Loc");
            driver.FindElement(By.Id("passwd")).SendKeys("19072000");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("address2")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("city")).SendKeys("");
            driver.FindElement(By.Id("id_state")).SendKeys("Texas");
            driver.FindElement(By.Id("postcode")).SendKeys("00000");
            driver.FindElement(By.Id("id_country")).SendKeys("United States");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone")).SendKeys("0978364572");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0978364572");
            driver.FindElement(By.Id("alias")).SendKeys("BinhDuong");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();

            Assert.AreEqual("city is required.", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        [Test]
        public void TC_Regiter_10()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("nhatloc22@gmail.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Nhat Loc");
            driver.FindElement(By.Id("passwd")).SendKeys("19072000");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("address2")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("city")).SendKeys("TDM");
            driver.FindElement(By.Id("id_state")).SendKeys("Texas");
            driver.FindElement(By.Id("postcode")).SendKeys("00000");
            driver.FindElement(By.Id("id_country")).SendKeys("United States");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone")).SendKeys("0978364572");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0978364572");
            driver.FindElement(By.Id("alias")).SendKeys("BinhDuong");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.AreEqual("This country requires you to choose a State.", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        [Test]
        public void TC_Register_11()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("1924801030024@student.tdmu.edu.vn");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Nhat Loc");
            driver.FindElement(By.Id("passwd")).SendKeys("19072000");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("address2")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("city")).SendKeys("TDM");
            driver.FindElement(By.Id("id_state")).SendKeys("Texas");
            driver.FindElement(By.Id("postcode")).SendKeys("00000");
            driver.FindElement(By.Id("id_country")).SendKeys("-");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone")).SendKeys("0978364572");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0978364572");
            driver.FindElement(By.Id("alias")).SendKeys("BinhDuong");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.AreEqual("id_country is required. Country cannot be loaded with address->id_country. Country is invalid", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
        [Test]
        public void TC_Register_12()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
            driver.FindElement(By.LinkText("Sign in")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("1924801030024@student.tdmu.edu.vn");
            driver.FindElement(By.Id("SubmitCreate")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Nguyen");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Nhat Loc");
            driver.FindElement(By.Id("passwd")).SendKeys("19072000");
            driver.FindElement(By.Id("days")).FindElement(By.XPath("//*[@id='days']/option[4]")).Click();
            driver.FindElement(By.Id("months")).FindElement(By.XPath("//*[@id='months']/option[4]")).Click();
            driver.FindElement(By.Id("years")).FindElement(By.XPath("//*[@id='years']/option[4]")).Click();
            driver.FindElement(By.Id("company")).SendKeys("N/A");
            driver.FindElement(By.Id("address1")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("address2")).SendKeys("BinhDuong");
            driver.FindElement(By.Id("city")).SendKeys("TDM");
            driver.FindElement(By.Id("id_state")).SendKeys("Texas");
            driver.FindElement(By.Id("postcode")).SendKeys("");
            driver.FindElement(By.Id("id_country")).SendKeys("United States");
            driver.FindElement(By.Id("other")).SendKeys("N/A");
            driver.FindElement(By.Id("phone")).SendKeys("0978364572");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("0978364572");
            driver.FindElement(By.Id("alias")).SendKeys("BinhDuong");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.FindElement(By.XPath("//*[@id='submitAccount']/span")).Click();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.AreEqual("The Zip/Postal code you've entered is invalid. It must follow this format: 00000", driver.FindElement(By.XPath("//*[@id='center_column']/div/ol/li")).Text);
        }
    }
}
