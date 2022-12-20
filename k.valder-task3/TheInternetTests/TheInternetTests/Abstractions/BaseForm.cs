using TheInternetTests.Logs;

namespace TheInternetTests.Abstractions
{
    public class BaseForm
    {
        private BaseElement element;
        private string name;

        public BaseForm(BaseElement element, string name)
        {
            this.element = element;
            this.name = name;
        }

        public bool IsDisplayd()
        {
            Logger.Info("Check display " + name);
            return element.IsDisplayed();
        }
    }
}
