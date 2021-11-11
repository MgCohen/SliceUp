using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FloatingTextManager
{
    [Inject]
    private FloatingText.Factory m_factory;
    [Inject]
    private SignalBus m_signalBus;

    private List<FloatingText> m_availableFloaters = new List<FloatingText>();
    private List<FloatingText> m_usedFloaters = new List<FloatingText>();


    [Inject]
    private void Init()
    {
        Debug.Log(2);
        m_signalBus.Subscribe<OnObstacleDestroyedSignal>(OnTextRequest);
    }

    public void OnTextRequest(OnObstacleDestroyedSignal signal)
    {
        Debug.Log(1);
        string points = signal.Obstacle.Points.ToString();
        Transform target = signal.Obstacle.transform;

        if (m_availableFloaters.Count <= 0)
        {
            FloatingText newFloatter = m_factory.Create(points, target);
            m_usedFloaters.Add(newFloatter);
            return;
        }

        FloatingText selectedFloatter = m_availableFloaters[0];
        UseText(selectedFloatter);
        selectedFloatter.Init(points, target);
    }

    private void UseText(FloatingText floatter)
    {
        m_availableFloaters.Remove(floatter);
        m_usedFloaters.Add(floatter);
        floatter.gameObject.SetActive(true);
    }

    public void ExpireText(FloatingText floater)
    {
        m_usedFloaters.Remove(floater);
        m_availableFloaters.Add(floater);
        floater.gameObject.SetActive(false);
    }

}

