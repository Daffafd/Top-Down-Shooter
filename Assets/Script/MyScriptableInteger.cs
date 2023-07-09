using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "My New Scriptable Integer", menuName = "My Scriptable Variable/Integer")]
public class MyScriptableInteger : ScriptableObject
{
    public int value;
    public int defaultValue;
    public bool resetOnEnable;


    /*
    OnEnable()" : Fungsi ini akan dipanggil 
    ketika sebuah objek aktif / enabled 
    (misalnya setelah diaktifkan melalui script). 

    Jika nilai dari variabel "resetOnEnable" adalah true, 
    maka fungsi "reset()" akan dipanggil juga.
    */
    private void OnEnable()
    {
        if (resetOnEnable)
        {
            reset();
        }
    }

    internal void reset()
    {
        value = defaultValue;
    }

    /*
    "reset()"  
    Fungsi ini akan mengganti nilai "value" menjadi "defaultValue".
    */
}