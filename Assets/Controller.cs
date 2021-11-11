using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Controller : ITickable
{
    [Inject]
    private SignalBus m_signalBus;

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_signalBus.Fire(new OnTapSignal());
        }
    }

}
