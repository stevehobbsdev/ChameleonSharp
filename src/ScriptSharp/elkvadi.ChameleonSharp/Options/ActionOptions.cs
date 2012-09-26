using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Core
{
    /// <summary>
    /// Properties used when using the chameleon.action method
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class ActionOptions
    {
        /// <summary>
        /// Url to the .png icon to display in the titlebar. Size: 81x81
        /// </summary>
        [IntrinsicProperty]
        public string Icon
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Changes the visibility of the icon in the titlebar.
        /// </summary>
        [IntrinsicProperty]
        public bool Visible
        {
            get { return false; }
            set { }
        }
        
    }
}
