using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class KnifeSpin : MonoBehaviour
{
    [Inject]
    private SignalBus m_signalBus;

    [SerializeField]
    private float m_minSpeed;
    [SerializeField]
    private float m_maxSpeed;
    [SerializeField]
    private float m_boostSpeed;
    [SerializeField]
    private float m_rotationSpeed = 5;
    [SerializeField]
    private float m_currentRotation;

    private Rigidbody m_rigidBody;

    private bool m_isFree;

    private bool m_boosting = false;
    Coroutine boostCoroutine;

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_signalBus.Subscribe<OnTapSignal>(Boost);
        m_signalBus.Subscribe<OnLockSignal>(SetRotation);
    }

    void FixedUpdate()
    {
        if (!m_isFree)
        {
            m_rigidBody.angularVelocity = Vector3.zero;
            return;
        }

        if (m_boosting)
        {
            return;
        }

        m_currentRotation = transform.localRotation.eulerAngles.z;

        float velocity;
        if (m_currentRotation > 250 && m_currentRotation < 360)
        {
            velocity = m_rigidBody.angularVelocity.z + (m_rotationSpeed * Time.deltaTime);
        }
        else
        {
            velocity = m_rigidBody.angularVelocity.z - (m_rotationSpeed * Time.deltaTime);
        }

        velocity = Mathf.Clamp(velocity, m_minSpeed, m_maxSpeed);
        m_rigidBody.angularVelocity = new Vector3(0, 0, velocity);


    }

    private void Boost()
    {
        m_rigidBody.angularVelocity = new Vector3(0, 0, m_boostSpeed);
        m_isFree = true;
        if (boostCoroutine != null)
        {
            StopCoroutine(boostCoroutine);
        }
        boostCoroutine = StartCoroutine(BoostCO());
    }

    IEnumerator BoostCO()
    {
        m_boosting = true;
        yield return new WaitForSeconds(0.3f);
        m_boosting = false;
    }

    private void SetRotation(OnLockSignal signal)
    {
        m_isFree = !signal.LockStatus;
    }
}
