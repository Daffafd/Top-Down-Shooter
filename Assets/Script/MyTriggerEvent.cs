using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyTriggerEvent : MonoBehaviour
{

    public UnityEvent OnTrigger;
    public string targetTag;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == targetTag) //jika terkena tag
        {
            //Debug.Log("kena" + col.gameObject.name);
            OnTrigger?.Invoke(); //panggil 
        }
    }
}