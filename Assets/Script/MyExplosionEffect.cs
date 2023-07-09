using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script ini diletakkan pada gameobject/prefab Bullet / Bolt
public class MyExplosionEffect : MonoBehaviour
{


    public void showExplosion()
    {
        MyObjectPool.GetInstance().requestObject(MyPoolObjectType.EXPLOSION).activate(transform.position, Quaternion.identity);
    }

    /*
    showExplosion()

    meminta objek pool yang sudah ada (pembungkus beberapa objek) 
		untuk sebuah objek ledakan 
    dengan menggunakan kunci "PoolObjectType.EXPLOSION". 
    
    Kemudian, objek tersebut diaktifkan  pada posisi dan 
    rotasi yang ditentukan oleh 
    transform.position dan Quaternion.identity masing-masing.
    */
}