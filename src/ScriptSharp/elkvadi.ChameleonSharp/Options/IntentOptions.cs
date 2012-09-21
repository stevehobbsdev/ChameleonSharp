using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Core
{
    /// <summary>
    /// Properties used when defining Android intents to utilise
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class IntentOptions
    {
        /// <summary>
        /// The action to apply to the intent.
        /// </summary>
        [IntrinsicProperty]
        public string Action
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// A URI to apply to the intent
        /// </summary>
        [IntrinsicProperty]
        [ScriptName("data")]
        public string DataUrl
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// An object to send a component as JSON.
        /// </summary>
        [IntrinsicProperty]
        public Dictionary Data
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Target an Android component with this intent.
        /// </summary>
        [IntrinsicProperty]
        public ComponentOptions Component
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// A list of extras to add to the intent.
        /// </summary>
        [IntrinsicProperty]
        public List<NameValueOptions> Extras
        {
            get { return null; }
            set {  }
        }
        

        /// <summary>
        /// The type to apply to the intent.
        /// </summary>
        [IntrinsicProperty]
        public string Type
        {
            get { return null; }
            set {  }
        }

        /// <summary>
        /// Receive an asynchronous response from the component.
        /// You must utilize the ChameleonIntent Java class in the receiving component to use this.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonPlainResultEventHandler Result
        {
            get { return null; }
            set {  }
        }
        
    }
}
