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
    protected SignalBus m_signalBus;

}

