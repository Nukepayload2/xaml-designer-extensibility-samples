using System.Windows.Controls;
using System.ComponentModel;
using System;
using System.Windows;

namespace CustomControlLibrary.WpfCore
{
    public class CustomButton : Button
    {
        public CustomButton()
        {
            // The GetIsInDesignMode check and the following design-time 
            // code are optional and shown only for demonstration.
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                Content = "Design mode active";
            }
        }

        // Adding a Date property to CustomButton to provide sample code for PropertyValueEditor
        public static readonly DependencyProperty DateProperty = DependencyProperty.Register(
            "Date",
            typeof(DateTime),
            typeof(CustomButton),
            new PropertyMetadata(DateTime.MinValue, OnDateChanged));

        public DateTime Date
        {
            get
            {
                return (DateTime)this.GetValue(DateProperty);
            }

            set
            {
                this.SetValue(DateProperty, value);
            }
        }

        private static void OnDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomButton presenter = d as CustomButton;
            presenter.Date = (DateTime)e.NewValue;
        }
    }
}