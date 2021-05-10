using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBase : MonoBehaviour
{
    bool isInited;
    public virtual void  Close(){
        gameObject.SetActive(false);
    }

    public virtual void Open(){
        if (!isInited){
            Init();
        }
        gameObject.SetActive(true);
    }

    public virtual void Init(){
        isInited = true;
    }
}
