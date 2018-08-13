using DataTemplateDemo.Templates;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace DataTemplateDemo.Selectors
{
    public class PageDotIndicatorSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            //return new DataTemplate(typeof(PageDotIndicatorTemplate));
            //return this.SelectDataTemplate(item, container);
            return this.SelectTemplate(item, container);
        }
    }
}