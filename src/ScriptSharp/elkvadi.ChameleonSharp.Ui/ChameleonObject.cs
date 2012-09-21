using jQueryApi;
using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Ui
{
    [Imported]
    [IgnoreNamespace]
    public class ChameleonObject : jQueryObject
    {
        /// <summary>
        /// One of the only ways we have found that will force an HTML element to redraw properly in an Android WebView set to 
        /// have a transparent background. 
        /// Use this in tandem with chameleon.invalidate().
        /// </summary>
        public void ChameleonInvalidate()
        {
            return;
        }

        /// <summary>
        /// Draws a visual message to display to the end user that is consistent with Chameleon.
        /// </summary>
        [ScriptName("chameleonWidgetMessageHTML")]
        public void ChameleonWidgetMessageHTML(ClickableHtmlOptions options)
        {
            return;
        }

        /// <summary>
        /// Draws a visual message to display to the end user that is consistent with Chameleon.
        /// </summary>
        /// <param name="options"></param>
        [ScriptName("chameleonWidgetErrorHTML")]
        public void ChameleonWidgetErrorHTML(ClickableHtmlOptions options)
        {
            return;
        }

        /// <summary>
        /// Draws a standard message on the Widget usually used when no content exists
        /// </summary>
        [ScriptName("chameleonWidgetConfigureHTML")]
        public void ChameleonWidgetConfigureHTML(ConfigureHtmlOptions options)
        {
            return;
        }

        /// <summary>
        /// Displays a standard message on the widget telling the user that this widget needs wifi
        /// </summary>
        [ScriptName("chameleonWidgetNeedWiFiHTML")]
        public void ChameleonWidgetNeedWiFiHTML(HtmlMessageOptions options)
        {
            return;
        }

        /// <summary>
        /// Forces all links that are a child of this element to be proxied to an external browser rather than loading in the widget.
        /// </summary>
        public void ChameleonProxyAllLinks()
        {
            return;
        }
    }
}
