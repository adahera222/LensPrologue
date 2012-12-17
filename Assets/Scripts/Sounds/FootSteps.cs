using UnityEngine;
using System.Collections;

public class FootSteps : MonoBehaviour {
	
	public GameObject player;
	
	void Update() {
		
		if (player.GetComponent<FPSInputController>().isMoving && Input.anyKeyDown) {
			if (!audio.isPlaying)
				audio.Play();
		}
		
		if (!Input.anyKey) {
			audio.Stop();
		}
	}
}
