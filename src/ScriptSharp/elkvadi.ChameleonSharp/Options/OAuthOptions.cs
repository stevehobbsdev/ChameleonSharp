using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Core
{
    /// <summary>
    /// Properties used when calling the PromptOauth method on the Chameleon object
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class OAuthOptions
    {
        /// <summary>
        /// Version of OAuth to use, either 1.0 or 2.0
        /// </summary>
        [IntrinsicProperty]
        public string Version
        {
            get { return null; }
            set {  }
        }

        /// <summary>
        /// The consumer key or application id of your application, specified by the service provider.
        /// For Oauth 1, this value must be Chameleon encrypted in advance.
        /// </summary>
        [IntrinsicProperty]
        public string ConsumerKey
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Used for Oauth 1.0 only.
        /// Must be Chameleon encrypted.
        /// </summary>
        [IntrinsicProperty]
        public string ConsumerSecret
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Options used to send authorization data to the OAuth server
        /// </summary>
        [IntrinsicProperty]
        public OAuthUrlOptions Authorize
        {
            get { return null; }
            set {  }
        }

        /// <summary>
        /// Options used in the request token step of OAuth 1.0
        /// </summary>
        [IntrinsicProperty]
        public OAuthUrlOptions Request
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Options used in the access token step of OAuth 1.0
        /// </summary>
        [IntrinsicProperty]
        public OAuthUrlOptions Access
        {
            get { return null; }
            set {  }
        }

        /// <summary>
        /// The url to callback to when the Oauth process is complete.
        /// </summary>
        [IntrinsicProperty]
        public string CallbackUrl
        {
            get { return null; }
            set {  }
        }

        /// <summary>
        /// Triggered when the Oauth process completes.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonResultEventHander OnResult
        {
            get { return null; }
            set {  }
        }
        
    }
}
