using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightLimiter : MonoBehaviour
{
    [SerializeField]
    private float maxY;

    private void Update()
    {
        if(transform.position.y <= maxY)
        {
            return;
        }

        Vector3 pos = transform.position;
        pos.y = Mathf.Min(maxY, pos.y);
        transform.position = pos;
    }
}
