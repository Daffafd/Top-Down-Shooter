using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script ini diletakkan pada gameobject/prefab Explosion
public class MyExplosionBehaviour : MonoBehaviour
{
    private Animator animator;
    private MyPoolObject poolObject;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        poolObject = GetComponent<MyPoolObject>();
    }


    /*
    Update()

    Kode di dalam fungsi Update() memeriksa apakah sebuah objek 
		di dalam game sudah aktif 
    jika menggunakan poolObject.isActive(). 
    
    Jika iya, maka kode akan memeriksa apakah animasinya telah selesai dengan 
    menggunakan fungsi animationIsDone().
    
    Jika animasi telah selesai, maka poolObject.deactivate() akan dipanggil 
    untuk menonaktifkan objek tersebut. 

    Jika tidak, fungsi ini tidak melakukan apa-apa 
    dan terus menunggu sampai animasi selesai.
    */

    void Update()
    {
        if (poolObject.isActive())
        {
            if (animationIsDone())
            {
                poolObject.deactivate();
            }
        }
    }

    private bool animationIsDone()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        {
            return true;
        }
        return false;
    }

    /*
        animationIsDone()

        Pertama, function ini akan menggunakan perintah 
        animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 
				untuk mengecek apakah 
        nilai waktu normalisasi animasi (dalam satuan detik) lebih besar dari 1. 
        
				Jika iya, itu artinya animasi sudah selesai 
        (karena tidak mungkin ada nilai waktu normalisasi yang lebih besar dari 1).
        
        Kemudian, function juga akan mengecek apakah animator sedang dalam keadaan 
        transit/berpindah ke state animasi yang lain menggunakan perintah 
        animator.IsInTransition(0). Ini dilakukan agar kita yakin bahwa 
				animasi memang sudah benar-benar berakhir dan 
				bukan hanya sedang menuju ke state animasi berikutnya.
        
        Jika kedua kondisi tersebut ternyata benar, maka function 
				akan mengembalikan nilai true, yang artinya animasi sudah selesai. 
        
        Namun jika salah satu kondisinya masih belum terpenuhi, 
        maka function akan mengembalikan nilai false, 
        yang artinya animasi masih sedang berjalan.
    */
}