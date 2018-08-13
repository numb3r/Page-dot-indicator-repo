using Xamarin.Forms;

namespace DataTemplateDemo.Models
{
    public class Sheet : BindableObject
    {
        private bool _isCurrent;

        public bool IsCurrent
        {
            get => _isCurrent;
            set
            {
                if (_isCurrent != value)
                {
                    _isCurrent = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}