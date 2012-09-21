using elkvadi.ChameleonSharp.Core;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Ui
{
    /// <summary>
    /// Base class used when displaying formatted messages to the user
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class HtmlMessageOptions
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
        /// Allows an icon to be shown, if no icon path is specified then
        /// a default icon is shown
        /// </summary>
        [IntrinsicProperty]
        public bool NoIcon
        {
            get { return false; }
            set { }
        }
    }
}
