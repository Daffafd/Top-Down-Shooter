using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MyMoveable))]
public class MyMovementBoundary : MonoBehaviour
{
    public Rect boundary;

    private MyMoveable moveable;

    private void Awake()
    {
        moveable = GetComponent<MyMoveable>();
    }



    void Update()
    {
        if (isXOutOfBoundary())
        {
            //click ctrl + . untuk generate method di mymoveable
            // lalu iisi di method direction.x = v;
            moveable.setXDirection(0f);
        }
        if (isYOutOfBoundary())
        {
            //click ctrl + . untuk generate method di mymoveable
            // lalu iisi di method direction.y = v;
            moveable.setYDirection(0f);
        }
    }

    //mepersingkat / more clean
    private bool isYOutOfBoundary()
    {
        return moveable.getNextPosition().y < boundary.yMin || moveable.getNextPosition().y > boundary.yMax;
    }

    private bool isXOutOfBoundary()
    {
        return moveable.getNextPosition().x < boundary.xMin || moveable.getNextPosition().x > boundary.xMax;
    }

    //Tambahkan function inii pada script MyMoveable
    //public Vector3 getNextPosition()
    //{
    //    return transform.position + (direction * Time.deltaTime * speed);
    //}
}