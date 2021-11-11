using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLockSignal
{
    public OnLockSignal(bool lockStatus)
    {
        LockStatus = lockStatus;
    }

    public bool LockStatus
    {
        get; private set;
    }
}
