using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Obstacle : MonoBehaviour
{
    public int Points => m_points;
    [SerializeField]
    private int m_points;

    [Inject]
    private SignalBus m_signalBus;

    private void OnDisable()
    {
        m_signalBus.Fire(new OnObstacleDestroyedSignal(this));
    }
}

