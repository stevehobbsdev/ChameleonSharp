using jQueryApi;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Ui
{
    /// <summary>
    /// Properties used when to display formatted clickable messages to the user
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class ClickableHtmlOptions : HtmlMessageOptions
    {
        /// <summary>
        /// Fired when the html block is clicked by the user
        /// </summary>
        [IntrinsicProperty]
        public jQueryEvent OnClick
        {
            get { return null; }
            set { }
        }
    }
}
