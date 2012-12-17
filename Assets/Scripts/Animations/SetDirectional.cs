using UnityEngine;
using System.Collections;

public class SetDirectional : MonoBehaviour {
	
	public Light directional;
	public GameObject doorTrigger;

	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "Player") {
			StopAllCoroutines();
			directional.intensity = 2.0f;
			Destroy(doorTrigger);
		}
	}
}
