using elkvadi.ChameleonSharp.Core;
using elkvadi.ChameleonSharp.Ui;
using jQueryApi;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SwitchWidgetJs
{
    public class Test
    {
        private void Refresh()
        {
            RefreshOptions refreshOptions = new RefreshOptions();
            refreshOptions.Refresh = true;
            Chameleon.Refresh(refreshOptions);
        }

        private void Intent()
        {
            ComponentOptions componentOptions = new ComponentOptions();
            componentOptions.Package = "com.twitter.android";
            componentOptions.Name = "com.twitter.android.StartActivity";

            Chameleon.ComponentExists(componentOptions);

            IntentOptions intentOptions = new IntentOptions();
            intentOptions.Component = componentOptions;
            intentOptions.Action = "android.intent.action.MAIN";
            Chameleon.Intent(intentOptions);
        }

        private void GetWindowType()
        {
            if (Chameleon.GetType() == "widget")
                Chameleon.Close();


            if (Chameleon.GetType() == "window")
            {
                Dictionary data = new Dictionary("message", "This is an example of data you can return");
                Chameleon.Close(true, data);
            }
            
        }

        private void Loading()
        {
            LoadingOptions loadingOptions = new LoadingOptions();
            loadingOptions.ShowLoader = true;

            Chameleon.ShowLoading(loadingOptions);
        }

        private void Title()
        {
            TitleOptions titleOptions = new TitleOptions();
            titleOptions.Text = "Title";

            Chameleon.SetTitle(titleOptions);
        }

        private void PromptHtml()
        {
            PromptHtmlOptions promptOptions = new PromptHtmlOptions();
            promptOptions.Height = 300; //optional property
            promptOptions.Width = 200; //optional property
            promptOptions.Url = "settings.html";
            promptOptions.Result = delegate(bool success, Dictionary data)
            {
                //optional callback
            };
            Chameleon.PromptHTML(promptOptions);
        }

        private void SetData()
        {
            MyInstanceData data = Chameleon.GetData<MyInstanceData>();
            data.Message = "This is the data I am saving";
            Chameleon.SaveData(data);
        }

        private void LocalData()
        {
            MyLocalData localData = new MyLocalData();
            LocalDataItem dataItem = new LocalDataItem();
            dataItem.Name = "Data item 1";
            dataItem.Description = "This is data item number 1";

            localData.LocalDataItems = new List<LocalDataItem>();
            localData.LocalDataItems.Add(dataItem);

            Chameleon.SaveLocalData("dataitemlist", localData);
        }

        private void GetLocal()
        {
            MyLocalData localData = Chameleon.GetLocalData<MyLocalData>("dataitemlist");
            if (localData != null)
            {
                if (localData.LocalDataItems != null)
                {
                    string str = "";
                    foreach (LocalDataItem dataItem in localData.LocalDataItems)
                    {
                        str += string.Format("{0} : {1}\n", dataItem.Name, dataItem.Description);
                    }
                }
            }
        }

        private void SharedData()
        {
            MySharedData sharedData = Chameleon.GetSharedData<MySharedData>();
            Account account = new Account();
            account.Name = "@evadi";
            account.Description = "Some guy that makes stuff";
            sharedData.Account = account;
            Chameleon.SaveSharedData(sharedData);
        }

        private void Invalidate()
        {
            InvalidateOptions invalidateOptions = new InvalidateOptions();
            invalidateOptions.Time = 100;
            invalidateOptions.Callback = delegate()
            {
                //do something
            };

            Chameleon.Invalidate();
            jQuery.Select(".someDiv").Html("new contents").Plugin<ChameleonUiObject>().ChameleonInvalidate(invalidateOptions);
        }

        private void WidgetMessage()
        {
            ClickableHtmlOptions htmlOptions = new ClickableHtmlOptions();
            htmlOptions.Title = "Hello";
            htmlOptions.Caption = "Is it me you're looking for?";
            htmlOptions.Icon = "http://chameleonlauncher.com/widgets/common/images/chameleon_config_widget_message_icon.png";
            htmlOptions.OnClick = delegate(jQueryEvent e)
            {
                //do something
            };
            jQuery.Select("#somediv").Plugin<ChameleonUiObject>().ChameleonWidgetMessageHTML(htmlOptions);
        }

        private void Proxy()
        {
            string html = "<a href=\"http://chameleonlauncher.com\">Chameleon Launcher Home Page</a>";
            jQuery.Select("#someDiv").Html(html).Plugin<ChameleonUiObject>().ChameleonProxyAllLinks();
        }

        private void OAuth()
        {
            OAuthOptions oauthOption = new OAuthOptions();
            oauthOption.Version = "1.0";

            OAuthUrlOptions authoriseOptions = new OAuthUrlOptions();
            authoriseOptions.Url = "https://api.twitter.com/oauth/authorize";
            authoriseOptions.Args = new Dictionary("force_login", "true");
            oauthOption.Authorize = authoriseOptions;

            OAuthUrlOptions requestOptions = new OAuthUrlOptions();
            requestOptions.Url = "https://api.twitter.com/oauth/request_token";
            oauthOption.Request = requestOptions;

            OAuthUrlOptions accessOptions = new OAuthUrlOptions();
            accessOptions.Url = "https://api.twitter.com/oauth/access_token";
            oauthOption.Access = accessOptions;

            oauthOption.CallbackUrl = "http://yourcallbackurl";
            oauthOption.ConsumerKey = "chameleon_encryped_consumer_key";
            oauthOption.ConsumerSecret = "chameleon_encrypted_consumer_secret";
            oauthOption.OnResult = delegate(bool success, Dictionary data)
            {
                //do something
            };

            Chameleon.PromptOauth(oauthOption);
        }
    }
}

public class MySharedData
{
    public Account Account;
}

public class Account
{
    public string Name;
    public string Description;
}

public class MyInstanceData
{
    public string Message;
}

public class MyLocalData
{
    public List<LocalDataItem> LocalDataItems;
}

public class LocalDataItem
{
    public string Name;
    public string Description;
}