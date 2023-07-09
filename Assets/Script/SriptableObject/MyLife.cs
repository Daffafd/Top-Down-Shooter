using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//diletakkan di prefab Player / Enemy
public class MyLife : MonoBehaviour
{
    [HideInInspector] public int life;
    [HideInInspector] public int maxLife;
    [HideInInspector] public MyScriptableInteger lifeScriptable;
    [HideInInspector] public MyScriptableInteger maxLifeScriptable;
    [HideInInspector] public bool useScriptable;

    public UnityEvent OnLifeReachZero;

    public void OnHit()
    {
        //Pertama kita periksa apakah useScriptable bernilai true atau false. useScriptable adalah sebuah boolean yang menentukan apakah kita akan menggunakan scriptable object sebagai sumber nilai life.
        if (useScriptable)
        {
            //akan mengurangi nilai lifeScriptable.value sebanyak 1. Namun, jika hasil pengurangannya kurang dari 0, maka nilainya di-set menjadi 0.
            lifeScriptable.value = lifeScriptable.value - 1 < 0 ? 0 : lifeScriptable.value - 1;

            //jika nilai dari lifeScriptable.value masih lebih besar dari 0, maka tidak ada event yang dipanggil. Namun, jika nilainya sudah mencapai 0 maka event OnLifeReachZero akan dipanggil.
            if (lifeScriptable.value <= 0)
            {
                //call event hp reach zero
                OnLifeReachZero?.Invoke();
            }
        }
        else // jika useScriptable adalah false
        {
            //akan mengurangi nilai value sebanyak 1. Namun, jika hasil pengurangannya kurang dari 0, maka nilainya di-set menjadi 0.
            life = life - 1 < 0 ? 0 : life - 1;


            //jika nilai darivalue masih lebih besar dari 0, maka tidak ada event yang dipanggil. Namun, jika nilainya sudah mencapai 0 maka event OnLifeReachZero akan dipanggil.
            if (life <= 0)
            {
                //call event hp reach zero
                OnLifeReachZero?.Invoke();
            }
        }
    }

    //meningkatkan nilai variabel 'life' sebanyak satu. 
    public void OnGain()
    {
        if (useScriptable)
        {
            lifeScriptable.value = lifeScriptable.value + 1 > maxLifeScriptable.value ? maxLifeScriptable.value : lifeScriptable.value + 1;
        }
        else
        {
            life = life + 1 > maxLife ? maxLife : life + 1;
            //Apabila nilai 'life' ditambahkan dengan 1 melebihi nilai maksimum 'maxLife', maka nilai variabel 'life' akan diset menjadi nilai 'maxLife'. 
            //Jika tidak, maka nilai variabel 'life' akan di-set menjadi hasil penambahan nilai 'life' dengan 1.
        }
    }
}