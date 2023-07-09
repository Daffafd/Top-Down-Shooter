using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MyMoveable))]
public class MyMoveRandomDirection : MonoBehaviour
{
    private MyMoveable moveable;
    private void Awake()
    {
        moveable = GetComponent<MyMoveable>();
    }

    void Start()
    {
        moveable.setDirection(randomDirection(), randomDirection());
    }


    //random range untuk arah yang berbeda
    private float randomDirection()
    {
        return Random.Range(-1f, 1);
    }
}