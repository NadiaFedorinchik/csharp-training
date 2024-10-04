using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class Helperbase
    {
        protected string WINTITLE = "Free Address Book";
        protected AutoItX3 aux;
        protected ApplicationManager manager;

        public Helperbase(ApplicationManager manager)
        {
            this.manager = manager;
            WINTITLE = ApplicationManager.WINTITLE;
            this.aux = manager.Aux;
        }
    }
}