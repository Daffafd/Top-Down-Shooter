using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MyMoveable))]

//script ini bisa ditambahkan ke enemy atau pool object, asal ada moveable 
public class MyTravelDistanceLimit : MonoBehaviour
{
    public float maxTravelDistance;

    private float travelDistance;
    private MyMoveable moveable;
    private MyPoolObject poolObject;

    private void Awake()
    {
        moveable = GetComponent<MyMoveable>();
        poolObject = GetComponent<MyPoolObject>();
    }

    void Start()
    {
        //Debug.Log("Start" + gameObject.name);
    }

    void Update()
    {
        //2. Jika travelDistance sudah mencapai maksimal (maxTravelDistance)
        if (travelDistance >= maxTravelDistance)
        {
            //2b jika bagian dari poolObject maka matikan (deactivate)
            if (poolObject != null)
            {

                poolObject.deactivate();
            }
            else
            {
                //2c. jika BUKAN bagian dari poolObject, kita destroy
                //Debug.Log("Testt" + gameObject.name);
                Destroy(gameObject);
                //script ini bisa kita tempel di object Enemy (misalnya)
            }
        }


        //1. mendapatkan seberapa jauh (travelDistace) object ini
        //kita perlu tambahkan function baru newPosition() pada MyMoveable.cs
        travelDistance += moveable.newPosition().magnitude;
    }

    private void OnEnable()
    {
        travelDistance = 0;
    }
}