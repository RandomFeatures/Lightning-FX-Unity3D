using UnityEngine;
using System.Collections;

public class Lightning_Manualfire: MonoBehaviour
{
	private Vector3 origin;
	private Vector3 target;
	private GameObject arcGlow;
	private bool firing = false;
	
	void Start()
	{
		arcGlow	= GameObject.Find("ArcGlow");
		gameObject.GetComponent<MeshRenderer>().enabled = false;
	}
	
	
	public bool Firing()
	{
		return firing; 
	}
	
	public void Fire(Vector3 org, Vector3 trgt)
	{
		if(!firing)
		{
			origin = org;
			target = trgt;
			
			ConnectToTarget(origin, target);
			//Turn everything on
			gameObject.GetComponent<MeshRenderer>().enabled = true;
			arcGlow.SetActive(true);
			firing = true;
		}
	}
	
	public void CeaseFire()
	{
		if(firing)
		{
			//Turn everything off
			
			//ConnectToTarget(origin, origin);
			//Uncomment above and comment below to make bolts dance around the source like the demo
			gameObject.GetComponent<MeshRenderer>().enabled = false;
			
			arcGlow.SetActive(false);
			firing = false;
		}
	}
	
	void ConnectToTarget(Vector3 P1,Vector3 P2)
    {
        transform.position = P1;
        transform.localScale = new Vector3((P1-P2).magnitude/40,1,1);
        transform.rotation = Quaternion.LookRotation(P2-P1,Vector3.forward);
		//The mesh was exported wrong and is facing the wrong direction
		transform.Rotate(0, 90, 0);
    }
	
	void Update ()
	{
		
		
	}
	
	
	
}