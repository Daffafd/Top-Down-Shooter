using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDestroyable : MonoBehaviour
{
    public void destroyObject()
    {
        Destroy(gameObject);
    }
}