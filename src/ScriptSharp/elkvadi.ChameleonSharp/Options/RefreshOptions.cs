using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Core
{
    /// <summary>
    /// Parameters used when calling Refresh on the Chameleon object
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class RefreshOptions
    {
        /// <summary>
        /// Indicates wether the widget should be refreshed
        /// </summary>
        /// <value>
        ///   <c>true</c> if refresh; otherwise, <c>false</c>.
        /// </value>
        [IntrinsicProperty]
        public bool Refresh
        {
            get { return false; }
            set {  }
        }
        
    }
}
