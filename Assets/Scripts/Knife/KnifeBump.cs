using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class KnifeBump : MonoBehaviour
{
    [Inject]
    private SignalBus m_signalBus;

    [SerializeField]
    private Vector3 m_forceDirection;

    private Rigidbody m_rigidBody;
    
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_signalBus.Subscribe<OnTapSignal>(Boost);
    }


    private void Boost()
    {
        m_rigidBody.isKinematic = false;
        Vector3 velocity = m_rigidBody.velocity;
        velocity.y = 0;
        m_rigidBody.velocity = velocity;
        m_rigidBody.AddForce(m_forceDirection, ForceMode.Impulse);
    }
}
