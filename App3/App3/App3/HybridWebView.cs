using System;
using Xamarin.Forms;

namespace App3
{
    public class HybridWebView : WebView
    {
        Action<string> action;

        public static readonly BindableProperty ContentProperty = BindableProperty.Create(
            propertyName: "Content",
            returnType: typeof(string),
            declaringType: typeof(HybridWebView),
            defaultValue: default(string));

        public string Content
        {
            get { return (string)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public void RegisterAction(Action<string> callback)
        {
            action = callback;
        }

        public void Cleanup()
        {
            action = null;
        }

        public void InvokeAction(string data)
        {
            if (action == null || data == null)
            {
                return;
            }
            action.Invoke(data);
        }
        
       
    }
}
