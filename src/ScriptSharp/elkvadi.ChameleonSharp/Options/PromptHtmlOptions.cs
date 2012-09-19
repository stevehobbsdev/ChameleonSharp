using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Core
{
    /// <summary>
    /// Parameters used when calling PromptHTML on the Chameleon object
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class PromptHtmlOptions
    {
        /// <summary>
        /// The url to load in the window.
        /// </summary>
        [IntrinsicProperty]
        public string Url
        {
            get { return null; }
            set {  }
        }

        /// <summary>
        /// A desired width for the window. Not required.
        /// </summary>
        [IntrinsicProperty]
        public Number Width
        {
            get { return 0; }
            set { }
        }

        /// <summary>
        /// A desired height for the window. Not required.
        /// </summary>
        [IntrinsicProperty]
        public Number Height
        {
            get { return 0; }
            set { }
        }

        /// <summary>
        /// Called when the window is closed.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonCloseEventHander Result
        {
            get { return null; }
            set {  }
        }
        
    }
}
