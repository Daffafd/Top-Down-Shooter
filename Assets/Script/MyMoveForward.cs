using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MyMoveable))]
public class MyMoveForward : MonoBehaviour
{
    private MyMoveable moveable;

    private void Awake()
    {
        moveable = GetComponent<MyMoveable>();
    }
    void Update()
    {
        moveable.setDirection(transform.up);
    }
}