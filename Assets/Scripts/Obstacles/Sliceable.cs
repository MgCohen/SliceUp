﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliceable : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_slices;
    [SerializeField]
    private float popForce;

    public void Slice()
    {
        gameObject.SetActive(false);
        foreach (GameObject slice in m_slices)
        {
            slice.SetActive(true);
            PopSlice(slice);
        }
    }

    private void PopSlice(GameObject slice)
    {
        Vector3 direction = (slice.transform.position - transform.position).normalized;
        slice.GetComponent<Rigidbody>().AddForce(direction * popForce, ForceMode.Impulse);

    }
}
