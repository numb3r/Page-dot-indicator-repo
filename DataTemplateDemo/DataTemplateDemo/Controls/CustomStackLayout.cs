using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace DataTemplateDemo.Controls
{
    public class CustomStackLayout : StackLayout
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource),
            typeof(IEnumerable<object>), typeof(CustomStackLayout), (object) null, BindingMode.OneWay,
            (BindableProperty.ValidateValueDelegate) null, (BindableProperty.BindingPropertyChangedDelegate) null,
            (BindableProperty.BindingPropertyChangingDelegate) null, (BindableProperty.CoerceValueDelegate) null,
            (BindableProperty.CreateDefaultValueDelegate) null);

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate),
            typeof(DataTemplate), typeof(CustomStackLayout), (object) null, BindingMode.OneWay,
            (BindableProperty.ValidateValueDelegate) null, (BindableProperty.BindingPropertyChangedDelegate) null,
            (BindableProperty.BindingPropertyChangingDelegate) null, (BindableProperty.CoerceValueDelegate) null,
            (BindableProperty.CreateDefaultValueDelegate) null);

        public static readonly BindableProperty ItemSelectedProperty =
            BindableProperty.Create(nameof(ItemSelected), typeof(ICommand), typeof(CustomStackLayout));

        public IEnumerable<object> ItemsSource
        {
            get => (IEnumerable<object>) this.GetValue(ItemsSourceProperty);
            set => this.SetValue(ItemsSourceProperty, (object) value);
        }

        public DataTemplate ItemTemplate
        {
            get => (DataTemplate) this.GetValue(ItemTemplateProperty);
            set => this.SetValue(ItemTemplateProperty, (object) value);
        }

        public ICommand ItemSelected
        {
            get => (ICommand) this.GetValue(ItemSelectedProperty);
            set => this.SetValue(ItemSelectedProperty, (object) value);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            CreateStack();
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            if (propertyName == ItemsSourceProperty.PropertyName)
                CreateStack();
            base.OnPropertyChanged(propertyName);
        }

        private void CreateStack()
        {
            this.Children.Clear();
            if (ItemsSource == null || ItemsSource.Count<object>() == 0 || ItemsSource.First<object>() == null)
                return;
            CreateCells();
        }

        private void CreateCells()
        {
            foreach (var obj in ItemsSource)
            {
                var test = obj as CustomStackLayout;
                this.Children.Add(CreateCellView(obj));
            }
        }

        private View CreateCellView(object item)
        {
            View content;
            BindableObject bindableObject = (BindableObject) (content = (View) ItemTemplate.CreateContent());
            if (bindableObject == null)
                return content;
            bindableObject.BindingContext = item;

            content.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = ItemSelected,
                CommandParameter = item
            });

            return content;
        }
    }
}