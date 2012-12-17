using UnityEngine;
using System.Collections;

public class VOTrigger : MonoBehaviour {
	
	public GameObject VOManager;
	
	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "Player") {
			
			VOManager.GetComponent<VOManager>().PlayNextClip();
			Destroy(gameObject);
		}
	}
}
