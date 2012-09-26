using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Ui
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
    }
}
