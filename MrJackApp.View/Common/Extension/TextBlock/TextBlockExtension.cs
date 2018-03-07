using System.Windows;
using System.Windows.Data;

namespace MrJackApp.View.Common.Extension.TextBlock
{
    public static class TextBlockExtension
    {
        public static bool GetNotifyOnTargetUpdatedText(DependencyObject obj)
        {
            return (bool)obj.GetValue(NotifyOnTargetUpdatedTextProperty);
        }

        public static void SetNotifyOnTargetUpdatedText(DependencyObject obj, bool value)
        {
            obj.SetValue(NotifyOnTargetUpdatedTextProperty, value);
        }

        public static readonly DependencyProperty NotifyOnTargetUpdatedTextProperty =
            DependencyProperty.RegisterAttached("NotifyOnTargetUpdatedText", typeof(bool), typeof(TextBlockExtension), new PropertyMetadata(false, NotifyOnTargetUpdatedTextChangedCallback));

        private static void NotifyOnTargetUpdatedTextChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBlock = d as System.Windows.Controls.TextBlock;
            if (textBlock == null)
                return;

            var bindingExpression = textBlock.GetBindingExpression(System.Windows.Controls.TextBlock.TextProperty);
            var binding = bindingExpression.ParentBinding;
            var newBinding = new Binding() { Source = binding.Source, Path = binding.Path, NotifyOnTargetUpdated = (bool)e.NewValue };
            textBlock.SetBinding(System.Windows.Controls.TextBlock.TextProperty, newBinding);
        }
    }
}
