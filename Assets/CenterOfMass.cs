using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    private Rigidbody m_rigidBody;
    [SerializeField]
    private Vector3 m_centerOfMass;

    bool going = false;

    private void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        SetCenterOfMass(m_centerOfMass);
    }

    public void SetCenterOfMass(Vector3 point)
    {
        m_centerOfMass = point;
        m_rigidBody.centerOfMass = m_centerOfMass;
    }

    private void Update()
    {
        m_centerOfMass += Vector3.right * Time.deltaTime * ((going) ? 1 : -1);
        m_rigidBody.centerOfMass = m_centerOfMass;
        if(Mathf.Abs(m_centerOfMass.x) > 1)
        {
            going = !going;
        }
    }
}
