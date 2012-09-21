using jQueryApi;
using System;
using System.Collections.Generic;
using elkvadi.ChameleonSharp.Core;
using System.Collections;

namespace GmailWidgetTest
{
    public static class Settings
    {
        static Settings()
        {
            jQuery.OnDocumentReady(delegate()
            {
                string stoken = "";
	            jQuery.Select("#accounts_select").Hide();
	
	            PopulateAccounts();

                jQuery.Select("#add-account-button").Click(delegate(jQueryEvent e)
                {
                    OAuthOptions oOptions = new OAuthOptions();
                    oOptions.Version = "1.0";
					oOptions.CallbackUrl = "http://chameleon.teknision.com/widgets/callback.html";
                    oOptions.ConsumerSecret = "QzKS7+8VgPDpIVzhJcdH0oOPPUUslucHG1Pf4h0slaQ=";
                    oOptions.OnResult = delegate(bool success, Dictionary data)
                    {
                        Dictionary account = new Dictionary;
						account["token"] = data["access_token"];
						account["secret"] = data["access_secret"];
						account["email"] = "unknown";
						GetUsernameForAccount(account);
                    };

                    OAuthUrlOptions requestOptions = new OAuthUrlOptions();
                    requestOptions.Url = "https://www.google.com/accounts/OAuthGetRequestToken";
                    requestOptions.Args = new Dictionary("scope", "https://mail.google.com/mail/feed/atom");

                    OAuthUrlOptions authorizeOptions = new OAuthUrlOptions();
                    authorizeOptions.Url = "https://www.google.com/accounts/OAuthAuthorizeToken";
                    authorizeOptions.Args = new Dictionary("btmpl", "mobile");

                    OAuthUrlOptions accessOptions = new OAuthUrlOptions();
                    accessOptions.Url = "https://www.google.com/accounts/OAuthGetAccessToken";
                    
                    oOptions.Request = requestOptions;
                    oOptions.Authorize = authorizeOptions;
                    oOptions.Access = accessOptions;

                    Chameleon.PromptOauth(oOptions);
            	});

            });
        }

        private static void PopulateAccounts(Object account_to_select)
	    {
		    Object shared_data = Chameleon.GetSharedData();
		    if(shared_data == null)
                shared_data = new object();

		    if(Type.GetField(shared_data, "accounts") == null)
                Type.SetField(shared_data, "accounts", new List<Object>);

		    List<Object> options = new List<Object>();
		    if(((List<Object>)Type.GetField(shared_data, "accounts")).Count > 0)
            {
			    jQuery.Select("#accounts_select").Show();
			
                foreach(Object account in ((List<Object>)Type.GetField(shared_data, "accounts")))
                {
                    Dictionary listing = new Dictionary();
				    listing["name"] = ((string)Type.GetField(account, "email")).ToUpperCase();
				    listing["value"] = Type.GetField(account, "email");
				    options.Add(listing);
                }			
			    
                Dictionary sOptions = new Dictionary(
                    "title", "Select An Account",
                    "list", options);

                Type.InvokeMethod(jQuery.Select("#accounts_select"), "chameleonSelectList", sOptions);
			
			    if(account_to_select != null)
                {
                    sOptions = new Dictionary("selectedValue", account_to_select);
                    Type.InvokeMethod(jQuery.Select("#accounts_select"), "chameleonSelectList", sOptions);
			    }
		    }
		
	    }


    }
}
