using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//bertugas menembak peluru saja, diletakkan di Gameobject Weapon

public class MyWeapon : MonoBehaviour
{
    public float fireRate;
    private float timer = 0;
    public MyPoolObjectType type;
    void Start()
    {

    }

    void Update()
    {

        //1. kurangi timer dengan delta time.
        //jika timer lebih dari 0, jalankan timer - Time.deltaTime
        // jika tidak jalankan 0f
        // ini adalah operator ternary, yang merupakan bentuk singkat dari if-else statement.
        timer = timer - Time.deltaTime > 0 ? timer - Time.deltaTime : 0f;

        //Debug.Log("timer" + timer);
    }

    public void shoot()
    {
        //ini berfungsi mengatur fire rate, kala, jadi kalau sdh 0, br bs tembak 
        if (timer == 0f)
        {
            //Debug.Log("fire!!!");
            MyObjectPool.GetInstance().requestObject(type).activate(transform.position, transform.rotation);
            timer = fireRate;
        }
    }

}