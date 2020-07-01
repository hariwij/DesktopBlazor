using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopBlazor.Shared
{
    [Serializable]
    public enum MessageBoxButtons:int
    {
        AbortRetryIgnore = 2,
        OK = 0,
        OKCancel = 1,
        RetryCancel = 5,
        YesNo = 4,
        YesNoCancel = 3
    }
}
