using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MyMoveable))]
public class MyPlayerController : MonoBehaviour
{
    //Assign script MyInputHandle.cs agar bisa berkomunikasi
    public MyInputHandler myInputHandler;

    private MyMoveable moveable;
    void Awake()
    {
        moveable = GetComponent<MyMoveable>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnSetDirect(Vector2 direction)
    {
        Debug.Log("OnSetDirect");
        moveable.setDirection(direction);
    }

    private void OnEnable()
    {
        //+= subscribe funtion OnSetDirect ke Unity Action, jadi dia kepanggil
        myInputHandler.OnSetDirectionAction += OnSetDirect;
    }

    private void OnDisable()
    {
        //-= subscribe funtion OnSetDirect ke Unity Action, jadi dia ga kepanggil
        myInputHandler.OnSetDirectionAction -= OnSetDirect;
    }

}