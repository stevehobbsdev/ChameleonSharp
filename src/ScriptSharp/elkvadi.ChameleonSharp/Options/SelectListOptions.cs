using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Core
{
    /// <summary>
    /// Properties used when using the chameleonSelectList method
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class SelectListOptions
    {
        /// <summary>
        /// Text to be displayed in the select list label
        /// </summary>
        [IntrinsicProperty]
        public string Title
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Items to be displayed in the select list
        /// </summary>
        [IntrinsicProperty]
        public List<SelectListItem> List
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// A callback function that let's you determine what was selected by the user.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonPlainResultEventHandler Result
        {
            get { return null; }
            set { }
        }
    }
}
