using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Slicer : MonoBehaviour
{

    [Inject]
    private SignalBus m_signalBus;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Sliceable slice))
        {
            slice.Slice();
            m_signalBus.Fire(new OnLockSignal(true));
            return;
        }
    }


}
