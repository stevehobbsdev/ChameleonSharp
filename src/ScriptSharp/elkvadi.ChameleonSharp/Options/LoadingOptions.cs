using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Core
{
    /// <summary>
    /// Parameters used when calling ShowLoading on the Chameleon object
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class LoadingOptions
    {
        /// <summary>
        /// Indicates wether the loading animation should be shown
        /// </summary>
        /// <value>
        ///   <c>true</c> if the loading animation should be shown; otherwise, <c>false</c>.
        /// </value>
        [IntrinsicProperty]
        [ScriptName("showloader")]
        public bool ShowLoader
        {
            get { return false; }
            set {  }
        }
        
    }
}
