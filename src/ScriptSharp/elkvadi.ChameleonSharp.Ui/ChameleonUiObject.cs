using jQueryApi;
using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Ui
{
    [Imported]
    [IgnoreNamespace]
    public class ChameleonUiObject : jQueryObject
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

        [AlternateSignature]
        public extern void ChameleonInvalidate(InvalidateOptions options);

        /// <summary>
        /// Draws a visual message to display to the end user that is consistent with Chameleon.
        /// </summary>
        [ScriptName("chameleonWidgetMessageHTML")]
        public jQueryObject ChameleonWidgetMessageHTML(ClickableHtmlOptions options)
        {
            return null;
        }

        /// <summary>
        /// Draws a visual message to display to the end user that is consistent with Chameleon.
        /// </summary>
        /// <param name="options"></param>
        [ScriptName("chameleonWidgetErrorHTML")]
        public jQueryObject ChameleonWidgetErrorHTML(ClickableHtmlOptions options)
        {
            return null;
        }

        /// <summary>
        /// Draws a standard message on the Widget usually used when no content exists
        /// </summary>
        [ScriptName("chameleonWidgetConfigureHTML")]
        public jQueryObject ChameleonWidgetConfigureHTML(ConfigureHtmlOptions options)
        {
            return null;
        }

        /// <summary>
        /// Displays a standard message on the widget telling the user that this widget needs wifi
        /// </summary>
        [ScriptName("chameleonWidgetNeedWiFiHTML")]
        public jQueryObject ChameleonWidgetNeedWiFiHTML(HtmlMessageOptions options)
        {
            return null;
        }

        /// <summary>
        /// Forces all links that are a child of this element to be proxied to an external browser rather than loading in the widget.
        /// </summary>
        public void ChameleonProxyAllLinks()
        {
            return;
        }

        /// <summary>
        /// Turns an 'a' element into a select list using the options provided
        /// </summary>
        public void ChameleonSelectList(SelectListOptions options)
        {
            return;
        }

        /// <summary>
        /// Gets the selected item from the select list
        /// </summary>
        /// <returns>SelectListItem that is selected</returns>
        public SelectListItem GetSelectedListItem(SelectListItemOptions options)
        {
            return null;
        }
    }
}
