using System;
using System.Collections.Generic;
using System.Html;
using jQueryApi;
using elkvadi.ChameleonSharp.Core;
using System.Collections;

namespace Tests
{
    public static class Main
    {
        static Main()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQueryObject _root = jQuery.Select("#chameleon-widget");
                WidgetOptions wop = new WidgetOptions();
                wop.OnLoad = delegate()
                {
                    _root.Append("<div>widget loaded...</div>");
                };

                wop.OnCreate = delegate()
                {
                    _root.Append("<div>widget created...</div>");
                };

                wop.OnResume = delegate()
                {
                    _root.Append("<div>widget resumed...</div>");
                };

                wop.OnPause = delegate()
                {
                    _root.Append("<div>widget paused...</div>");
                };

                wop.OnLayout = delegate()
                {
                    _root.Append("<div>widget size changed...</div>");
                };

                wop.OnScrollTop = delegate()
                {
                    _root.Append("<div>widget scrolled to top...</div>");
                };

                wop.OnScrollElsewhere = delegate()
                {
                    _root.Append("<div>widget scrolled...</div>");
                };

                wop.OnLayoutModeStart = delegate()
                {
                    _root.Append("<div>widget layout mode started...</div>");
                };

                wop.OnLayoutModeComplete = delegate()
                {
                    _root.Append("<div>widget layout mode complete...</div>");
                };

                wop.OnConnectionAvailableChanged = delegate(bool available)
                {
                    _root.Append("<div>widget connection status changed to " + available + " ...</div>");
                };

                wop.OnConfigure = delegate()
                {
                    _root.Append("<div>widget entered configure mode...</div>");
                };

                wop.OnTitleBar = delegate()
                {
                    _root.Append("<div>widget title clicked...</div>");

                    PromptHtmlOptions options = new PromptHtmlOptions();
                    options.Url = "settings.html";
                    options.Height = 200;
                    options.Width = 300;
                    options.Result = delegate(bool success, Dictionary data)
                    {
                        _root.Append("result from window " + success);
                    };
                    Chameleon.PromptHTML(options);
                };

                wop.OnRefresh = delegate()
                {
                    _root.Html("<div>widget refreshed...</div>");
                    _root.Append("<div>connection status: " + Chameleon.Connected() + "</div>");
                    _root.Append("<div>layout mode status: " + Chameleon.IsInLayoutMode() + "</div>");
                    LoadingOptions firstLoadOptions = new LoadingOptions();
                    firstLoadOptions.ShowLoader = true;
                    Chameleon.ShowLoading(firstLoadOptions);

                    Window.SetTimeout(delegate()
                    {
                        LoadingOptions lo = new LoadingOptions();
                        lo.ShowLoader = false;
                        Chameleon.ShowLoading(lo);
                    }, 2000);
                };

                wop.NotChameleon = delegate()
                {
                    _root.Append("<div>widget loaded outside of Chameleon...</div>");
                };

                Chameleon.Widget(wop);
            });
        }
    }
}
