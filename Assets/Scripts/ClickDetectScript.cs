using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetectScript : MonoBehaviour,UnityEngine.EventSystems.IPointerDownHandler
{
    private PauseScript pauseScript;
    private FlappyBird flappyBird;
    void Start() {
        pauseScript=FindObjectOfType<PauseScript>();
        flappyBird=FindObjectOfType<FlappyBird>();
    }
  public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        Debug.Log("PointerDown is executed " + eventData.pointerCurrentRaycast.gameObject.name);
        if(pauseScript.isPause)pauseScript.onResume();
        else flappyBird.flapping=true;
    }
}
