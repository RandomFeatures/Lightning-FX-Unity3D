using UnityEngine;
using System.Collections;

public class Manualfire_example : MonoBehaviour {
	
	private Lightning_Manualfire zap;
	
	public Transform point1;
	public Transform point2;
	
	
	// Use this for initialization
	void Start () {
		
		GameObject go = GameObject.Find("LightningBolt_Manualfire");
        zap =  go.GetComponent<Lightning_Manualfire>();
		   
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButton(0))
		{
			if(!zap.Firing())
				zap.Fire(point1.position, point2.position);
			
		}else
		{
			
			if(zap.Firing())
				zap.CeaseFire();
		}
	}
}
