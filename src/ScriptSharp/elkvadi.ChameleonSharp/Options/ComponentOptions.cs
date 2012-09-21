using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Core
{
    /// <summary>
    /// Properties used when defining an Android component to utilise
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class ComponentOptions
    {
        /// <summary>
        /// The full class name of the component to target.
        /// </summary>
        [IntrinsicProperty]
        public string Name
        {
            get { return null; }
            set {  }
        }

        /// <summary>
        /// The package the activity resides in.
        /// </summary>
        [IntrinsicProperty]
        public string Package
        {
            get { return null; }
            set {  }
        }

        /// <summary>
        /// Specify what type of component you are targeting.
        /// </summary>
        [IntrinsicProperty]
        public string Type
        {
            get { return null; }
            set {  }
        }
        
        
        
    }
}
