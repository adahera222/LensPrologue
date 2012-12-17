using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {
	
	public GameObject doorLeft;
	public GameObject doorRight;
	public Light directional;
	public GameObject VOManager;
	
	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "Player") {			
			StartCoroutine(DoorOpen());
		}
	}
	
	void OnTriggerExit(Collider other) {
		
		if (other.tag == "Player") {			
			StartCoroutine(DoorClose());
		}
	}
	
	private IEnumerator DoorOpen() {
		
		while (VOManager.GetComponent<VOManager>().IsPlaying()) {
			yield return null;
		}
		
		while (doorLeft.animation.isPlaying) {
			yield return null;
		}
		doorLeft.animation.Play("DoorOpen");
		doorRight.animation.Play("DoorOpen");
		DoLight(false);
	}
	
	private IEnumerator DoorClose() {
		
		while (VOManager.GetComponent<VOManager>().IsPlaying()) {
			yield return null;
		}
		
		while (doorLeft.animation.isPlaying) {
			yield return null;
		}
		doorLeft.animation.Play("DoorClose");
		doorRight.animation.Play("DoorClose");
		DoLight(true);
	}
	
	private void DoLight(bool isDim) {
		if (isDim) {
			StartCoroutine(DimLight());
		} else {
			StartCoroutine(UnDimLight());
		}
	}
	
	private IEnumerator UnDimLight() {
		while (directional.intensity <= 2.0f) {
			directional.intensity += 0.8f * Time.deltaTime;
			yield return null;
		}
		directional.intensity = 2.0f;
	}
	
	private IEnumerator DimLight() {
		while (directional.intensity > 0.0f) {
			directional.intensity -= 0.8f * Time.deltaTime;
			yield return null;
		}
		directional.intensity = 0.0f;
	}
}
