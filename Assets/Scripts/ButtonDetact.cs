using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonDetact : MonoBehaviour, IPointerClickHandler
{
	public Vector3 pos; //Original puzzle position
	public LargePad lpp;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left){
            //Debug.Log("Left click");
            lpp.Transport(this.gameObject);
        }
        //else if (eventData.button == PointerEventData.InputButton.Middle)
        else if (eventData.button == PointerEventData.InputButton.Right){
            //Debug.Log("Right click");
            Rotate();
        }
    }

    public void Rotate(){
    	Debug.Log("2");
    }

}
