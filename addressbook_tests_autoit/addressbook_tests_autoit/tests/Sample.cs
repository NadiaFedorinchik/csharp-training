using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    [TestClass]
    public class ApplicationLaunchTests
    {
        private AutoItX3 autoit = new AutoItX3();

        [TestMethod]
        public void LaunchApplication()
        {
            // Замените "C:\Path\To\Your\Application.exe" на фактический путь к вашему приложению
            string applicationPath = @"C:\Tools\FreeAddressBookPortable\AddressBook.exe";

            // Запускаем приложение
            autoit.Run(applicationPath);

            // Ждем, пока окно приложения появится
            autoit.WinWaitActive("Title вашего приложения");

            // Дополнительные проверки (например, проверка наличия элементов интерфейса)
            //bool isWindowActive = autoit.WinActive("Title вашего приложения");
            //Assert.IsTrue(isWindowActive, "Приложение не было запущено успешно");
        }
    }
}