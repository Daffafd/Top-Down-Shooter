using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ditaro di Gameobject Enemy
public class MyAutoShoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (MyWeapon w in GetComponentsInChildren<MyWeapon>())
        {
            w.shoot();
        }
    }
}

