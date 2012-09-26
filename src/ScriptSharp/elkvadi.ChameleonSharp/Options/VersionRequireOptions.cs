using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Core
{
    /// <summary>
    /// Properties used when for checking compatability with various versions of Chameleon
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class VersionRequireOptions
    {
        /// <summary>
        /// Sets the versions to check for compatability
        /// </summary>
        [IntrinsicProperty]
        public Versions Require
        {
            get { return null; }
            set { }
        }
    }
}
