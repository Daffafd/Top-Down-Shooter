using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//0. Input Library si Input System
using UnityEngine.InputSystem;

//11a. Menggunakan Unity Action untuk menghubungkan ke Player Controller 
using UnityEngine.Events;

//1 .jadikan scritable object (Penjelasan ScriptableObject http://tiindonesia.blogspot.com/2015/07/scriptable-object.html) 

//4. menggunakan Interface MyCustomInput.IGameplayActions, ketik MyCustomInput.IGameplayActions klik ctrl . lalu pilih implement interface,
//   nanti akan membuat function OnSetDirection ini yang tadi di action SetDirection yg di Custom Mapping
//   membuat script ini memaksa implement semua Custom Input yang sdh kita mapping sblmnya
//   penjelasan interface - https://learn.unity.com/tutorial/interfaces atau lihat ruangbelajar.fajarnadril.com -> Unity Notes -> SOLID


//8. Membuat My Input Handler muncul saat klik kanan di project Window -> Create -> MyInputHandler. Hal ini karena Scriptable Object
[CreateAssetMenu(fileName = "My Input Handler", menuName = "My Input Handler")]
public class MyInputHandler : ScriptableObject, MyCustomInput.IGameplayActions
{
    //2.membuat MyCustomInput menjadi object
    private MyCustomInput input;

    //11b. Menggunakan Unity Action untuk menghubungkan ke Player Controller 
    public UnityAction<Vector2> OnSetDirectionAction; //ini menyimpan class



    //3a. Membuat function OnEnable, untuk assign CustomInput ke input
    private void OnEnable()
    {
        //3b. Untuk assign CustomInput ke input
        if (input == null)
        {
            input = new MyCustomInput();
        }

        //5. Segala macam action akan di handle di class ini (this)
        input.Gameplay.SetCallbacks(this);

        //6. Gameplay itu Action Maps tadi 
        input.Gameplay.Enable();
    }

    //7.Ketika aplikasi sdg disable, maka disable jg input yang diterima
    private void OnDisable()
    {
        input.Gameplay.Disable();
    }

    public void OnSetDirection(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();

        // 9. Debug.Log untuk lihat tombol dipencet
        //terima value vector 2 dari Set Direction + mendapatkan phase dari tombol
        // phase ditombol : ketikan baruditekan (started), ditekan (performed), diangkat(canceled)
        Debug.Log(" Set Direction " + context.ReadValue<Vector2>() + context.phase);

        //10. Kita akan pakai pas tombol saat Performed atau Canceled (note : kalau Canceled gak dippakai akan jalan terus)
        if (context.phase == InputActionPhase.Performed || context.phase == InputActionPhase.Canceled)
        {
            //11c.Semua function yg ada di OnSetDirectionAction akan diinvoke / dipanggiil
            // dapat menambahkan tanda setelah OnSetDirectionAction? untuk cek dulu, jadi kalo kosong tidak di invoke

            //12. menambahkan context.ReadValue<Vector2>() di parameter  OnSetDirectionAction?.Invoke();
            //12b. menambahkan <Vector2>  menjadi public UnityAction<Vector2> public UnityAction<Vector2> OnSetDirectionActio
            OnSetDirectionAction?.Invoke(context.ReadValue<Vector2>());

        }
    }
}