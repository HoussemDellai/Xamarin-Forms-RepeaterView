using System.Collections;
using Xamarin.Forms;

namespace Repeater.Controls
{
    public class RepeaterView : StackLayout
    {
        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(
            nameof(ItemTemplate), 
            typeof(DataTemplate), 
            typeof(RepeaterView), 
            default(DataTemplate));

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource), 
            typeof(ICollection), 
            typeof(RepeaterView), 
            null, 
            BindingMode.OneWay, 
            propertyChanged: ItemsChanged);
        
        public RepeaterView()
        {
            Spacing = 0;
        }

        public ICollection ItemsSource
        {
            get => (ICollection) GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public DataTemplate ItemTemplate
        {
            get => (DataTemplate) GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }
        
        protected virtual View ViewFor(object item)
        {
            View view = null;

            if (ItemTemplate != null)
            {
                var content = ItemTemplate.CreateContent();

                view = content is View ? content as View : ((ViewCell)content).View;

                view.BindingContext = item;
            }

            return view;
        }
        
        private static void ItemsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as RepeaterView;

            if (control == null) return;

            control.Children.Clear();

            var items = (ICollection) newValue;

            if (items == null) return;

            foreach (var item in items)
            {
                control.Children.Add(control.ViewFor(item));
            }
        }
    }
    //public class RepeaterView<T> : StackLayout where T : class
    //{
    //    public static readonly BindableProperty HeaderTemplateProperty = BindableProperty.Create(nameof(HeaderTemplate), typeof(DataTemplate), typeof(RepeaterView<T>), default(DataTemplate));

    //    public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(RepeaterView<T>), default(DataTemplate));

    //    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<T>), typeof(RepeaterView<T>), null, BindingMode.OneWay, propertyChanged: ItemsChanged);

    //    public RepeaterView()
    //    {
    //        Spacing = 0;
    //    }

    //    public IEnumerable<T> ItemsSource
    //    {
    //        get => (IEnumerable<T>)GetValue(ItemsSourceProperty);
    //        set => SetValue(ItemsSourceProperty, value);
    //    }

    //    public DataTemplate ItemTemplate
    //    {
    //        get => (DataTemplate)GetValue(ItemTemplateProperty);
    //        set => SetValue(ItemTemplateProperty, value);
    //    }

    //    public DataTemplate HeaderTemplate
    //    {
    //        get => (DataTemplate)GetValue(HeaderTemplateProperty);
    //        set => SetValue(HeaderTemplateProperty, value);
    //    }

    //    protected virtual View ViewFor(T item)
    //    {
    //        View view = null;
    //        if (ItemTemplate != null)
    //        {
    //            var content = ItemTemplate.CreateContent();
    //            view = (content is View) ? content as View : ((ViewCell)content).View;

    //            view.BindingContext = item;
    //        }

    //        return view;
    //    }

    //    protected View HeaderView()
    //    {
    //        View view = null;

    //        if (HeaderTemplate != null)
    //        {
    //            var content = HeaderTemplate.CreateContent();
    //            view = (content is View) ? content as View : ((ViewCell)content).View;
    //            view.BindingContext = BindingContext;
    //        }

    //        return view;
    //    }

    //    private static void ItemsChanged(BindableObject bindable, object oldValue, object newValue)
    //    {
    //        var control = bindable as RepeaterView<T>;

    //        if (control == null) return;

    //        control.Children.Clear();

    //        IEnumerable<T> items = (IEnumerable<T>) newValue;

    //        if (items != null && items.Any())
    //        {
    //            var header = control.HeaderView();
    //            if (header != null)
    //                control.Children.Add(header);

    //            foreach (var item in items)
    //                control.Children.Add(control.ViewFor(item));
    //        }
    //    }
    //}
}