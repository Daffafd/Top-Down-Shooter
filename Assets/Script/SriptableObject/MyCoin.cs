using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCoin : MonoBehaviour
{
    public MyScriptableInteger coin;

    public void OnGain()
    {
        coin.value += 1;
    }
}