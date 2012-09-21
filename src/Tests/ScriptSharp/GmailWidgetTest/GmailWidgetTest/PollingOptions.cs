using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GmailWidgetTest
{
    public delegate void ChameleonEventHandler();

    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public class PollingOptions
    {
        public string id;

        public string action;

        public long interval;

        public ChameleonEventHandler callback;
    }
}
