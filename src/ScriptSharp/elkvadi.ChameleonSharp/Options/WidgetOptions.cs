using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace elkvadi.ChameleonSharp.Core
{
    /// <summary>
    /// Initialisation parameters for a widget
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class WidgetOptions
    {
        /// <summary>
        /// If set to true, will allow your widget to notify Chameleon when it is finished initializing to enable clean startup sequencing.
		/// If not used, widget will be treated as initialized at onLoad.
		/// If used, you must call chameleon.initialize() within 10 seconds. Chameleon will auto initialize at that time.
        /// </summary>
        public bool ManualInitialize
        {
            get { return false; }
            set { }
        }


        /// <summary>
        /// Triggered every time the widget loads.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler OnLoad
        {
            get { return null; }
            set {  }
        }

        /// <summary>
        /// Triggered the first time the widget is created.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler OnCreate
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Triggered everytime Chameleon resumes, or when the dashboard that hosts this widget becomes
        /// the active dashboard
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler OnResume
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Triggered every time Chameleon pausesor when the dashboard that hosts this widget changes from being 
        /// the active dashboard, to being an inactive one.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler OnPause
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Triggered every time the size of the widget changes.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler OnLayout
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Triggered when the user scrolls the widget to it's top.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler OnScrollTop
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Triggered when the user scrolls the widget away from it's top.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler OnScrollElsewhere
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Triggered when the user enters dashboard edit mode.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler OnLayoutModeStart
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Triggered when the user exits dashboard edit mode.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler OnLayoutModeComplete
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Triggered when the status of network availability changes.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonConnectionAvailableChangedEventHandler OnConnectionAvailableChanged
        {
            get { return null; }
            set { }
        }
        
        /// <summary>
        /// Triggered when the user taps the configure button in the widget title bar.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler OnConfigure
        {
            get { return null; }
            set { }
        }
        

        /// <summary>
        /// Triggered when the user taps the widget titlebar.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler OnTitleBar
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Triggered when the user taps the refresh button on the widget title bar.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler OnRefresh
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Triggered when the user taps the action button on the widget title bar.
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler OnAction
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Triggered every time the widget loads, but not in Chameleon.	
        /// </summary>
        [IntrinsicProperty]
        public ChameleonEventHandler NotChameleon
        {
            get { return null; }
            set { }
        }
    }
}
