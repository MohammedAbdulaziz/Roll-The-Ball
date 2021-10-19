using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverXp : MonoBehaviour
{
    Vector3 floatX;
    public float Strength;

    void Update()
    {
        floatX = transform.position;
        floatX.x = (Mathf.Sin(3 * Time.time) * Strength);
        transform.position = floatX;
    }
}
