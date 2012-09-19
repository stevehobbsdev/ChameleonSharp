using elkvadi.ChameleonSharp.Core;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Ui
{
    /// <summary>
    /// Parameters used in when calling chameleonWidgetMessageHTML on a ChameleonObject
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class WidgetMessageOptions
    {
        /// <summary>
        /// The title of the message
        /// </summary>
        [IntrinsicProperty]
        public string Title
        {
            get { return null; }
            set {  }
        }

        /// <summary>
        /// A more detailed message to display under the title.
        /// </summary>
        [IntrinsicProperty]
        public string Caption
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// An optional url to a transparent image to load as the icon. Standard size is 68x68
        /// </summary>
        [IntrinsicProperty]
        public string Icon
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// An optional callback function that is triggered when the user taps the message.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler OnClick
        {
            get { return null; }
            set { }
        }
    }
}
