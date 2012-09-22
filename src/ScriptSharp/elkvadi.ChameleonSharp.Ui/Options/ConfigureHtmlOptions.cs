using jQueryApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Ui
{
    /// <summary>
    /// Properties used when calling ChameleonWidgetConfigureHTML on the ChameleonObject
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class ConfigureHtmlOptions : HtmlMessageOptions
    {     
        /// <summary>
        /// Fired when the html block is clicked by the user
        /// </summary>
        [IntrinsicProperty]
        public jQueryEventHandler OnConfigure
        {
            get { return null; }
            set {  }
        }
        
    }
}
