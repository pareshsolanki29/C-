using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace automateWebURL
{
    class Program
    {
        public static object ExpectedConditions { get; private set; }

        static void Main(string[] args)
        {
            var url = "http://hpa.services/automation-challenge";
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.GetType());


            IWebElement element = driver.FindElement(By.Id("Box1"));

            element.Click();

            IAlert alert = driver.SwitchTo().Alert();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            Thread.Sleep(1000);
            alert.Accept();
            IWebElement element1 = driver.FindElement(By.Id("Box3"));
            element1.Equals(driver.SwitchTo().ActiveElement());

            element1.SendKeys(Keys.Tab);
            Thread.Sleep(1000);
            alert.Accept();
            IWebElement optNo = driver.FindElement(By.Id("optionVal"));
            var selOption = optNo.GetAttribute("innerHTML");

            Console.WriteLine(selOption);
            foreach (var item in driver.FindElements(By.XPath("//input[contains(@name,'option')]")))
            {

                //Console.WriteLine(item.GetAttribute("value"));
                if (item.GetAttribute("value") == selOption)
                {

                    item.Click();
                    Thread.Sleep(1000);
                    alert.Accept();
                }
            }


            IWebElement box4 = driver.FindElement(By.Id("selectionVal"));
            var box4Text = box4.GetAttribute("innerHTML");


            foreach (var seldrop in box4.FindElements(By.XPath("//option")))
            {
                Console.WriteLine(seldrop);
                if (seldrop.GetAttribute("value") == box4Text)
                {
                    seldrop.Click();
                    Thread.Sleep(1000);
                    alert.Accept();

                }
            }




            IWebElement tableForm = driver.FindElement(By.Id("FormTable"));
            IList<IWebElement> TableRows = tableForm.FindElements(By.TagName("td")).ToList();
            IWebElement buttonSave = driver.FindElement(By.TagName("button"));
            Console.WriteLine(buttonSave.GetAttribute("innerHTML"));

            for (int i = 0; i <= TableRows.Count - 2; i++)
            {
                IWebElement inputText = TableRows[i].FindElement(By.CssSelector("input"));
                var ele = inputText.GetAttribute("placeholder").ToString();

                inputText.SendKeys(ele);
                Console.WriteLine(inputText.GetAttribute("innerHTML"));
            }


            buttonSave.Click();
            alert.Accept();

            IWebElement formResult = driver.FindElement(By.Id("formResult"));
            var formCode = formResult.GetAttribute("innerHTML").ToString();
            Console.WriteLine(formCode);
            var lineNum = driver.FindElement(By.Id("lineNum")).GetAttribute("innerHTML");
            Console.WriteLine(lineNum);
            IWebElement tableView = driver.FindElement(By.Id("inputTable"));
            IWebElement table1 = driver.FindElement(By.CssSelector("#inputTable > tbody > tr:nth-child(" + lineNum + ") > td:nth-child(2) > input"));

            Console.WriteLine(table1.GetAttribute("value"));
            table1.Click();
            table1.Clear();
            table1.SendKeys(formCode);

            IWebElement footer = driver.FindElement(By.ClassName("Footer"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(footer);
            IWebElement box7 = driver.FindElement(By.Id("Box7"));
            box7.Click();

            alert.Accept();


            box7.Click();

            Thread.Sleep(5000);
            driver.SwitchTo().Alert().Accept();
            
            driver.FindElement(By.Id("BoxParagraph8")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.Id("BoxParagraph9")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().Alert().Accept();

            driver.FindElement(By.Id("BoxParagraph10")).Click();
            Thread.Sleep(5000);
            driver.SwitchTo().Alert().Accept();

        }
    }
}