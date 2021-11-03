using OpenQA.Selenium;
using System;
using System.IO;

namespace TesteBase2.Objetos
{
    public class Print
    {
        IWebDriver _driver;

        public Print(IWebDriver driver)
        {
            _driver = driver;
        }
        public void Screenshot(string directory)
        {
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            byte[] imagebytes = Convert.FromBase64String(screenshot.ToString());
            using (BinaryWriter bw = new BinaryWriter(new FileStream(directory, FileMode.Append, FileAccess.Write)))
            {
                bw.Write(imagebytes);
                bw.Close();
            }
        }
    }
}
