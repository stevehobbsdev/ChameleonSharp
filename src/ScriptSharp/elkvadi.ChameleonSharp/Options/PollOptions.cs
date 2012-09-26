using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Core
{
    /// <summary>
    /// Properties used when using the Poll method on the Chameleon object
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class PollOptions
    {
        /// <summary>
        /// The id to register as a poll, or the poll to target.
        /// </summary>
        [IntrinsicProperty]
        public string Id
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// "start" to start a poll, or "stop" to stop it.
        /// </summary>
        [IntrinsicProperty]
        public string Action
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Desired duration in milliseconds for the poll. May not actually occur exactly on this interval.
        /// </summary>
        [IntrinsicProperty]
        public Number Interval
        {
            get { return 0; }
            set { }
        }

        /// <summary>
        /// The function to call when the poll runs.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler Callback
        {
            get { return null; }
            set { }
        }
        
    }
}
