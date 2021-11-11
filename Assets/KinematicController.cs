using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody m_rigidBody;

    private bool wasStopped;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            m_rigidBody.isKinematic = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(1);
    }

}
