using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Script ini digunakan untuk membuat custom editor untuk kelas MyLife di Unity, yang menampilkan variabel dan mengeditnya dalam tampilan Inspector. Jika toggle button diaktifkan, EditorGUILayout.ObjectField() akan muncul, jika tidak maka EditorGUILayout.IntField() akan ditampilkan.

//[CustomEditor(typeof(Life))] digunakan untuk memberi tahu Unity bahwa kita ingin membuat sebuah custom editor untuk kelas Life. Jadi ketika  membuka editor untuk objek yang memiliki komponen Life, Unity akan menampilkan tampilan editor kustom yang kamu buat.
[CustomEditor(typeof(MyLife))]
public class MyLifeEditor : Editor
{
    private MyLife life;

    /*
    OnInspectorGUI() yang digunakan pada Unity Editor. 
    Fungsi tersebut digunakan untuk menampilkan dan 
    mengedit variabel-variabel dari sebuah objek pada tampilan Inspector di Unity.
    */

    public override void OnInspectorGUI()
    {

        /* Fungsi ini merupakan overriding dari fungsi OnInspectorGUI() 
            yang sudah ada sebelumnya.*/

        //digunakan untuk memanggil fungsi asli OnInspectorGUI().
        base.OnInspectorGUI();

        //Kemudian variabel life diset agar sama dengan target.
        life = (MyLife)target;

        /*
         Dibawah adalah baris kode untuk menampilkan toggle button untuk mengaktifkan atau 
         menonaktifkan MyScriptableObject pada class Life. 
         
         Jika toggle button diset ke true, maka useScriptable akan bernilai true. 
         Jika toggle button diset ke false, maka useScriptable akan bernilai false.
        */
        life.useScriptable = EditorGUILayout.Toggle("Use Scriptable?", life.useScriptable);

        //if berikutnya mengecek apakah useScriptable bernilai true atau false.
        if (life.useScriptable)
        {
            /*
            Jika nilai useScriptable adalah true, maka akan muncul dua MyScriptableObject 
            field yang dapat diisi melalui EditorGUILayout.ObjectField(). 
            Field pertama digunakan untuk MyScriptableObject lifeScriptable 
            Field kedua digunakan untuk MyScriptableObject maxLifeScriptable
            */

            life.lifeScriptable = (MyScriptableInteger)EditorGUILayout.ObjectField("Life", life.lifeScriptable, typeof(MyScriptableInteger), true);

            life.maxLifeScriptable = (MyScriptableInteger)EditorGUILayout.ObjectField("Max Life", life.maxLifeScriptable, typeof(MyScriptableInteger), true);
        }

        else
        {
            life.life = EditorGUILayout.IntField("Life", life.life);
            life.maxLife = EditorGUILayout.IntField("Max Life", life.maxLife);

            //Jika nilai useScriptable adalah false, maka akan muncul dua integer field yang dapat diisi melalui EditorGUILayout.IntField(). Field pertama digunakan untuk integer value life dan field kedua digunakan untuk integer value maxLife.
        }
    }
}