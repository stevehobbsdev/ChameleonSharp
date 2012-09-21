using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Core
{
    /// <summary>
    /// Used to populate properties of the OAuthOptions object
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class OAuthUrlOptions
    {
        /// <summary>
        /// The url for the authorize step of the Oauth process.
        /// </summary>
        [IntrinsicProperty]
        public string Url
        {
            get { return null; }
            set {  }
        }

        /// <summary>
        /// Extra arguments to send on the query string of the authorize url.
        /// </summary>
        [IntrinsicProperty]
        public Dictionary Args
        {
            get { return null; }
            set { }
        }
    }
}
