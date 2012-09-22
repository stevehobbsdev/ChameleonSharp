using jQueryApi;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SwitchWidgetJs.Model
{
    public class SwitchType
    {
        public string Name;

        [ScriptName("class")]
        public string ClassName;

        public string Caption;

        public string State;

        public jQueryEventHandler OnClick;
    }
}
