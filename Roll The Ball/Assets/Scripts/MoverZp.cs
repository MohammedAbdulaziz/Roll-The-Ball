using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverZp : MonoBehaviour
{
    Vector3 floatZ;
    public float Strength;

    void Update()
    {
        floatZ = transform.position;
        floatZ.z = (Mathf.Sin(3 * Time.time) * Strength);
        transform.position = floatZ;
    }
}
