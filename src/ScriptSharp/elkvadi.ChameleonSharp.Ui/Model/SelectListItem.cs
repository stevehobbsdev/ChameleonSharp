using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Ui
{
    /// <summary>
    /// An item represented in a SelectList
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class SelectListItem
    {
        /// <summary>
        /// Name that will be displayed on the UI
        /// </summary>
        [IntrinsicProperty]
        public string Name
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Value that this item represents
        /// </summary>
        [IntrinsicProperty]
        public string Value
        {
            get { return null; }
            set { }
        }
        
    }
}
