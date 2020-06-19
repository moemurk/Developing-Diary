using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private float fatiguePoint;
	public float fatigueSpeed = 1;
	private float time;
	public float timeSpeed = 1;
	private int date;
	public GameObject directionalLight;
	public GameObject hourHand;
	public GameObject minuteHand;
	Light lightComp;

    // Start is called before the first frame update
    void Start()
    {
        fatiguePoint = 0;
        time = 0;
        date = 1;
        lightComp = directionalLight.GetComponent<Light>();
        hourHand.transform.localEulerAngles = new Vector3 (-90f, 0f, 0f);
        minuteHand.transform.localEulerAngles = new Vector3 (-90f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        fatiguePoint += fatigueSpeed * Time.deltaTime * timeSpeed;
        if (fatiguePoint >= 100){
        	fatiguePoint = 100;
        }

        time += timeSpeed * Time.deltaTime;
        if(time >= 3600){
        	time = 0;
        	date += 1;
        }

        hourHand.transform.localEulerAngles = new Vector3(-time/5f - 90f, 0f, 0);
        minuteHand.transform.localEulerAngles = new Vector3(-time * 2.4f - 90f, 0f, 0);
        directionalLight.transform.eulerAngles = new Vector3(time/10 - 90f, 0f, 0f);

    }
}
