using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Ui
{
    /// <summary>
    /// Properties used when retrieving the selected item from a select list
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class SelectListItemOptions
    {
        /// <summary>
        /// Indicates if the selected list item should be returned
        /// </summary>
        [IntrinsicProperty]
        public bool GetSelectedItem
        {
            get { return false; }
            set { }
        }
        
    }
}
