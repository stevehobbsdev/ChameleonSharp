using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Ui
{
    /// <summary>
    /// Properties used when calling ChameleonInvalidate on the ChameleonUiObject
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class InvalidateOptions
    {
        /// <summary>
        /// Specifies the length of time to wait before invoking the callback method
        /// </summary>
        [IntrinsicProperty]
        public int Time
        {
            get { return 0; }
            set { }
        }

        /// <summary>
        /// An action to invoke once invalidate has been executed and the timeout has completed
        /// </summary>
        [IntrinsicProperty]
        public Action Callback
        {
            get { return null; }
            set { }
        }
    }
}
