using System;
using System.Collections;
using System.Collections.Generic;

namespace elkvadi.ChameleonSharp.Core
{
    /// <summary>
    /// 
    /// </summary>
    public delegate void ChameleonEventHandler();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="available"></param>
    public delegate void ChameleonConnectionAvailableChangedEventHandler(bool available);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="success"></param>
    /// <param name="data"></param>
    public delegate void ChameleonResultEventHander(bool success, Dictionary data); 

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    public delegate void ChameleonPlainResultEventHandler(Dictionary data);
}
