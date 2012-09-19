using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Core
{
    /// Parameters used when calling SetTitle on the Chameleon object
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class TitleOptions
    {
        /// <summary>
        /// Text to be shown in the Title bar
        /// </summary>
        [IntrinsicProperty]
        public string Text
        {
            get { return null; }
            set {  }
        }
        
    }
}
