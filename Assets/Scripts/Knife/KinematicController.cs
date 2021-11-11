using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody m_rigidBody;

    private bool wasStopped = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor") && !wasStopped)
        {
            m_rigidBody.isKinematic = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Floor") &&  !wasStopped)
        {
            wasStopped = true;
            StartCoroutine(StopCD());
        }
    }

    IEnumerator StopCD()
    {
        yield return new WaitForSeconds(0.5f);
        wasStopped = false;
    }

}
