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
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_signalBus.Fire(new OnTapSignal());
        }
    }

}
