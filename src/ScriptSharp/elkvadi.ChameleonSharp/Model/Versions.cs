using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Core
{
    /// <summary>
    /// Represents versions for each of the Chameleon components
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class Versions
    {
        /// <summary>
        /// Version of Chameleon
        /// </summary>
        [IntrinsicProperty]
        public string Chameleon
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Version of Chameleon.js
        /// </summary>
        [IntrinsicProperty]
        [ScriptName("chameleon_js")]
        public string ChameleonJs
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Version of Chameleon_jquery_js
        /// </summary>
        [IntrinsicProperty]
        [ScriptName("chameleon_jquery_js")]
        public string ChameleonJQueryJs
        {
            get { return null; }
            set { }
        }
    }
}
