using UnityEngine;
using System.Collections;

public class LightningZapDemo : MonoBehaviour {

	public Transform origin;
	public Transform target;
	public Light endLight;
	public GameObject sparks;

	private GameObject arcGlow;
	private GameObject startLight;
	private bool firing = false;
	
	void Start()
	{
		arcGlow	= GameObject.Find("ArcGlow");
		startLight = new GameObject("startLight");

		startLight.AddComponent<Light>();
		startLight.light.type = endLight.type;
		startLight.light.color = endLight.color;
		startLight.light.range = endLight.range;
		startLight.light.intensity = endLight.intensity;
		//two follow arcs are left on and circle the origin
		ConnectToTarget(origin.position, origin.position);
	}
	
	void Update ()
	{
		
		if(Input.GetMouseButton(0))
		{
			if(!firing)
			{
				
				//Trace a ray along the path and hit the first obstical
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
	            if (Physics.Raycast (ray, out hit, 400) )
				{
					
					
					ConnectToTarget(origin.position, hit.point);
					target.position = hit.point;
					
					//Turn on lights and emitters
					arcGlow.SetActive(true);
					sparks.particleEmitter.emit = true;
					
					startLight.light.enabled = true;
					endLight.enabled = true;
					firing = true;
				}
			}
		}else
		{
			//Turn off lights and emitters
			if(firing)
			{
				ConnectToTarget(origin.position, origin.position);

				arcGlow.SetActive(false);
				sparks.particleEmitter.emit = false;
				endLight.enabled = false;
				startLight.light.enabled = false;
				firing = false;
			}
		}
		
		
		
	}
	
	void ConnectToTarget(Vector3 P1,Vector3 P2)
    {
        transform.position = P1;
        transform.localScale = new Vector3((P1-P2).magnitude/40,1,1);
        transform.rotation = Quaternion.LookRotation(P2-P1,Vector3.forward);
		transform.Rotate(0, 90, 0);
    }
	
	
}
