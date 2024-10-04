using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        string applicationPath = @"C:\Tools\AddressBook\AddressBook.exe";

        private GroupHelper groupHelper;
        private AutoItX3 aux;

        public ApplicationManager() 
        {
            aux = new AutoItX3();
            aux.Run(applicationPath, "", aux.SW_SHOW);
            aux.WinWait(WINTITLE);
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE, "", 10);

            groupHelper = new GroupHelper(this);
        }

        
        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public GroupHelper Groups 
        {
            get
            {
                return groupHelper;
            }
        }

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }
    }
}
