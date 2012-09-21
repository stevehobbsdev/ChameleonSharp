using System;
using System.Collections.Generic;
using System.Html;
using jQueryApi;
using elkvadi.ChameleonSharp.Core;
using System.Collections;
using elkvadi.ChameleonSharp.Ui;
using System.Serialization;

namespace GmailWidgetTest
{
    public static class Index
    {
        private static long REFRESH_TIMESPAN = 60000 * 5;

        private static Object current_account = null;
        private static int last_update_call = -1;
        private static jQueryObject _root;

        static Index()
        {
            jQuery.OnDocumentReady(delegate()
            {
                _root = jQuery.Select("#chameleon-widget");
                WidgetOptions widget = new WidgetOptions();
                widget.OnLoad = delegate()
                {
                    LoadFeed();
                };

                widget.OnScrollTop = delegate()
                {
                    if (current_account != null && Chameleon.Connected())
                    {
                        UpdateFeedIfWithinTimespan();
                        StartPolling();
                    }
                };

                widget.OnScrollElsewhere = delegate()
                {
                    StopPolling();
                };

                widget.OnLayoutModeStart = delegate()
                {
                    if (current_account != null)
                    {
                        StopPolling();
                    }
                    else
                    {
                        if (Chameleon.Connected())
                        {
                            DisplayNoFeedMessage();
                        }
                        else
                        {
                            DisplayOfflineMessage();
                        }
                    }
                };

                widget.OnLayoutModeComplete = delegate()
                {
                    if (current_account != null)
                    {
                        StartPolling();
                        UpdateFeedIfWithinTimespan();
                    }
                    else
                    {
                        if (Chameleon.Connected())
                        {
                            DisplayNoFeedMessage();
                        }
                        else
                        {
                            DisplayOfflineMessage();
                        }

                    }
                };

                widget.OnConnectionAvailableChanged = delegate(bool available)
                {
                    if (available)
                    {
                        if (current_account != null)
                        {
                            LoadEmailFeed();
                        }
                        else
                        {
                            LoadFeed();
                        }
                    }
                    else
                    {
                        StopPolling();
                        if (current_account == null) 
                            DisplayOfflineMessage();
                    }
                };

                widget.OnConfigure = delegate()
                {
                    StopPolling();
                    LaunchSettings(null);
                };

                widget.OnTitleBar = delegate()
                {
                    LaunchMail(null);
                };

                widget.OnRefresh = delegate()
                {
                    if (current_account != null)
                    {
                        LoadEmailFeed();
                    }
                };

                Chameleon.Widget(widget);
            });
        }

        private static void UpdateFeedIfWithinTimespan()
        {
            if (current_account != null)
            {
                if (last_update_call != -1)
                {
                    int now = Date.Now.GetDate();
                    if (now > (last_update_call + 60000))
                    {
                        LoadEmailFeed();
                    }
                }
            }
        }

        private static void LoadFeed()
        {
            //current_account=null;
            StopPolling();
            if (!LoadFeedForSelectedAccount())
            {
                if (!LoadDefaultFeed())
                {
                    if (Chameleon.Connected())
                    {
                        DisplayNoFeedMessage();
                        Chameleon.Initialize();
                    }
                    else
                    {
                        DisplayOfflineMessage();
                        Chameleon.Initialize();
                    }

                }
            }
        }

        private static bool LoadDefaultFeed()
        {
            bool r = false;

            Object shared_data = Chameleon.GetSharedData();
            if (shared_data == null)
                shared_data = new Dictionary();

            if (Type.GetField(shared_data, "accounts") == null)
                Type.SetField(shared_data, "accounts", new List<Object>());

            Object account = null;
            if (((List<Object>)Type.GetField(shared_data, "accounts")).Count > 0)
            {
                account = ((List<Object>)Type.GetField(shared_data, "accounts"))[0];
                if (current_account == null || Type.GetField(account, "secret") != Type.GetField(current_account, "secret"))
                {
                    current_account = account;
                    LoadEmailFeed();
                }
                r = true;
            }

            return r;
        }

        private static bool LoadFeedForSelectedAccount()
        {
            bool r = false;
            Object data = Chameleon.GetSharedData();
            if (data != null && Type.GetField(data, "account_to_load") != null)
            {
                Object shared_data = Chameleon.GetSharedData();
                if (shared_data == null)
                    shared_data = new object();

                if (Type.GetField(shared_data, "accounts") == null)
                    Type.SetField(shared_data, "accounts", new List<Object>());

                Object account = null;
                for (int i = 0; i < ((List<Object>)Type.GetField(shared_data, "accounts")).Count; i++)
                {
                    if ((string)Type.GetField(((List<Object>)Type.GetField(shared_data, "accounts"))[i], "email") == (string)Type.GetField(data, "account_to_load"))
                    {
                        account = ((List<Object>)Type.GetField(shared_data, "accounts"))[i];
                        r = true;
                        break;
                    }
                }

                if (account != null && (current_account == null || Type.GetField(account, "secret") != Type.GetField(current_account, "secret")))
                {
                    current_account = account;
                    LoadEmailFeed();
                }

            }
            return r;
        }

        private static void DisplayNoFeedMessage()
        {
            ConfigureHtmlOptions options = new ConfigureHtmlOptions();
            options.Title = "Register Your Account";

            Chameleon.Invalidate();
            if (Chameleon.IsInLayoutMode())
            {
                options.Caption = "Tap the gear in the top right to register your Gmail Account and display unread messages from your inbox in this widget.";
                options.NoIcon = true;
                _root.Plugin<ChameleonObject>().ChameleonWidgetConfigureHTML(options);
                _root.Plugin<ChameleonObject>().ChameleonInvalidate();
            }
            else
            {
                options.Caption = "Tap here to register your Gmail Account and display unread messages from your inbox in this widget.";
                _root.Plugin<ChameleonObject>().ChameleonWidgetConfigureHTML(options);
                _root.Plugin<ChameleonObject>().ChameleonInvalidate();
            }
        }

        private static void DisplayNoUnreadMessagesMessages()
        {
            Chameleon.Invalidate();
            HtmlMessageOptions options = new HtmlMessageOptions();
            options.Icon = "images/inbox_ninja.png";
            options.Title = "No un-read email";
            options.Caption = "Guess you're an inbox ninja.";
            _root.Plugin<ChameleonObject>().ChameleonWidgetMessageHTML(options);
            _root.Plugin<ChameleonObject>().ChameleonInvalidate();
        }

        private static void DisplayOfflineMessage()
        {
            Chameleon.Invalidate();
            _root.Plugin<ChameleonObject>().ChameleonWidgetNeedWiFiHTML();
            _root.Plugin<ChameleonObject>().ChameleonInvalidate();
        }

        private static void DisplayError(string message)
        {
            _root.Html(message);
        }

        private static void ClearContent()
        {
            _root.Html("");
        }

        private static void LaunchSettings(jQueryEvent e)
        {
            if (e != null)
                e.PreventDefault();

            PromptHtmlOptions options = new PromptHtmlOptions();
            options.Url = "settings.html";
            options.Result = delegate(bool success, Dictionary data)
            {
                if (success)
                {
                    LoadFeed();
                }
            };
            Chameleon.PromptHTML(options);

        }

        private static void DrawMessages(List<Object> messages)
        {
            string str = "";
            if (messages != null && messages.Count > 0)
            {
                foreach (Object message in messages)
                {
                    str += GetEmailHTMLFromEntry(message);
                }
            }
            _root.Html(str);

            Chameleon.Invalidate();
            _root.Plugin<ChameleonObject>().ChameleonInvalidate();

            PrimeMailLinks();
            Chameleon.Initialize();
        }

        private static string GetEmailHTMLFromEntry(Object message)
        {
            string r = "";

            string time_since_string = (string)Type.InvokeMethod(Chameleon.ChameleonInstance, "timesince", Type.GetField(message, "created"));

            r += "<div class='email-listing' id='" + Type.GetField(message, "id") + "'>";
            r += "<img src='images/gmail_unread_email.png' class='unread-email-icon' />";

            if (Type.GetField(message, "url") != null)
                r += "<a href='" + Type.GetField(message, "url") + "' class='email-listing-title-link'>";

            r += "<p class='email-listing-title'>" + Type.GetField(message, "title") + "</p>";
            if (Type.GetField(message, "url") != null)
                r += "</a>";

            r += "<p class='email-listing-from'>" + Type.GetField(message, "author_email") + "</p>";
            r += "<p class='email-listing-created'>" + time_since_string + "</p>";
            r += "<p class='email-listing-summary'>" + Type.GetField(message, "summary") + "</p>";

            r += "</div>";

            return r;

        }

        private static void StartPolling()
        {
            PollingOptions pOptions = new PollingOptions();
            pOptions.id = "feed_refresh";
            pOptions.action = "start";
            pOptions.interval = REFRESH_TIMESPAN;
            pOptions.callback = LoadEmailFeed;

            Type.InvokeMethod(Chameleon.ChameleonInstance, "poll", pOptions);
        }

        private static void StopPolling()
        {
            Dictionary options = new Dictionary(
                "id", "feed_refresh",
                "action", "stop"
            );
            Type.InvokeMethod(Chameleon.ChameleonInstance, "poll", options);
        }

        private static void PrimeMailLinks()
        {
            jQuery.Select(".email-listing-title-link").Die("click", LaunchMail).Live("click", LaunchMail);
        }

        private static void LaunchMail(jQueryEvent e)
	    {
		    if(e != null)
                e.PreventDefault();
		
		    string url ="";
		    if(e != null && e.CurrentTarget != null)
                url = e.CurrentTarget.ToString();
		
            ComponentOptions cOptions = new ComponentOptions();
            cOptions.Package = "com.google.android.gm";
            cOptions.Name = "com.google.android.gm.ConversationListActivityGmail";
		    							
		    if(Chameleon.ComponentExists(cOptions) || (url == null || url == ""))
            {
                IntentOptions iOptions = new IntentOptions();
                iOptions.Component = cOptions;
                iOptions.Action = "android.intent.action.MAIN";
			    Chameleon.Intent(iOptions);
											
		    }
            else
            {
                IntentOptions iOptions = new IntentOptions();
                iOptions.Action = "android.intent.action.VIEW";
                iOptions.DataUrl = url;
			    Chameleon.Intent(iOptions);
		    }
		
	    }

        private static void LoadEmailFeed()
	    {
		    if(current_account != null)
            {
			    Object inst_data = Chameleon.GetData();
			    if(inst_data == null)
                    inst_data = new Dictionary();
		
                TitleOptions tOptions = new TitleOptions();
                tOptions.Text = "UNREAD MESSAGES: " + ((string)Type.GetField(current_account, "email")).ToUpperCase();
		 	    Chameleon.SetTitle(tOptions);
		 	
		 	    if(Chameleon.Connected())
                {
			 	    last_update_call = Date.Now.GetDate();
				    Dictionary qdata = new Dictionary();
				    qdata["token"] = Type.GetField(current_account, "token");
				    qdata["secret"] = Type.GetField(current_account, "secret");
	
                    LoadingOptions lOptions = new LoadingOptions();
                    lOptions.ShowLoader = true;
				    Chameleon.ShowLoading(lOptions);

                    jQueryAjaxOptions ajaxOptions = new jQueryAjaxOptions();
                    ajaxOptions.Url = "services/getmail.php";
                    ajaxOptions.Data = Json.Stringify(qdata);
                    ajaxOptions.DataType = "xml";
                    ajaxOptions.Timeout = 5000;
                    ajaxOptions.Success = delegate(object data, string textStatus, jQueryXmlHttpRequest request)
                    {
                        lOptions.ShowLoader = false;
                        Chameleon.ShowLoading(lOptions);
                        ClearContent();
                        List<Object> messages = new List<object>();

                        jQueryObject context = jQuery.FromObject(data);
                        context.Find("feed > entry").Each(delegate(int index, Element element)
						{	
						    Object message = new object();
						    Type.SetField(message, "id", jQuery.This.Find("id").GetText());
                            Type.SetField(message, "title", jQuery.This.Find("title").GetText());
                            Type.SetField(message, "author_email", jQuery.This.Find("author > email").GetText());
						    Type.SetField(message, "url", jQuery.This.Find("url").GetText());
                            Type.SetField(message, "created", jQuery.This.Find("issued").GetText());
						    Type.SetField(message, "summary", jQuery.This.Find("summary").GetText());
						    					    
						    messages.Add(message);
						});
	
                        if(messages.Count > 0)
                        {
						    DrawMessages(messages);
						  	Chameleon.SaveLocalData("cached_messages", messages); 		
						}
                        else
                        {
						  	ClearContent();
						  	DisplayNoUnreadMessagesMessages();
						  	Chameleon.Initialize();	  
						}
						 
						StartPolling();
                    };
                    ajaxOptions.Error = delegate(jQueryXmlHttpRequest req, string txtStatus, Exception error)
                    {
                        lOptions.ShowLoader = false;
                        Chameleon.ShowLoading(lOptions);
                        StartPolling();
                    };

				    jQuery.Ajax(ajaxOptions);
			    }
                else
                {
				    List<Object> local_data = (List<Object>)Chameleon.GetLocalData("cached_messages");
				    if(local_data != null)
                    {
					    DrawMessages(local_data);
				    }
                    else
                    {
					    DisplayOfflineMessage();
				    }
			    }

		    }
            else
            {
			    StopPolling();
		    }
	    }

    }
}
