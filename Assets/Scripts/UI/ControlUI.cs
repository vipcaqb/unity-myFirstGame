using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ControlUI : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    PlayerControl pControl;

    private void Awake() {
        pControl = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    public void OnPointerDown(PointerEventData data){
        if(gameObject.name=="Left"){
            pControl.moveLeft = true;
        }
        if(gameObject.name=="Right"){
            pControl.moveRight = true;
        }
    }

    public void OnPointerUp(PointerEventData data){
        if(gameObject.name=="Left"){
            pControl.moveLeft = false;
        }
        if(gameObject.name=="Right"){
            pControl.moveRight = false;
        }
    }
}
