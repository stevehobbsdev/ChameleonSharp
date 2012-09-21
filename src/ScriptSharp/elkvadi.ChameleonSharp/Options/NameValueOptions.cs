using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Core
{
    /// <summary>
    /// Simple name and value object used in various methods on the Chameleon object
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class NameValueOptions
    {
        /// <summary>
        /// The name of the option
        /// </summary>
        [IntrinsicProperty]
        public string Name
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Value of the option
        /// </summary>
        [IntrinsicProperty]
        public Object Value
        {
            get { return null; }
            set { }
        }
        
    }
}