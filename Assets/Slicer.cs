using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Sliceable slice))
        {
            slice.Slice();
        }
    }


}
