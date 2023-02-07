using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3
{
    public partial class MainPage : ContentPage
    {
        private HybridWebView hybridWebView;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LearningPageViewModel();

            ((LearningPageViewModel)BindingContext).TextChanged += TextChanged;
            hybridWebView = new HybridWebView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = ((LearningPageViewModel)BindingContext).ArticleHtmlFormat,
            };
            hybridWebView.RegisterAction(data => DisplayAlert("Alert", "Hello " + data, "OK"));
            slHybridView.Children.Clear();
            slHybridView.Children.Add(hybridWebView);

        }
        private void TextChanged(object sender, EventArgs e)
        {
                var hybridWebView = new HybridWebView()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Content = ((LearningPageViewModel)BindingContext).ArticleHtmlFormat,
                };
                hybridWebView.RegisterAction(data => { ((LearningPageViewModel)BindingContext).ShowCorrectAction(data); });
                slHybridView.Children.Clear();
                slHybridView.Children.Add(hybridWebView);

        }
    }
}