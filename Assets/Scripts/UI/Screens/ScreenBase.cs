using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBase : MonoBehaviour
{
    public virtual void  Close(){
        gameObject.SetActive(false);
    }

    public virtual void Open(){
        Init();
        gameObject.SetActive(true);
    }

    public virtual void Init(){

    }
}
