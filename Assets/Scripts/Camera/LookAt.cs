using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
	
	public Transform player;
	public Transform cam;
	public GameObject fader;
	
	private float t = 0.0f;
	private float time = 1.5f;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		StartCoroutine(SmoothLook());
	}
	
	private IEnumerator SmoothLook() {
		yield return StartCoroutine(fader.GetComponent<Fader>().FadeIn());
		yield return new WaitForSeconds(2.0f);
		yield return StartCoroutine(fader.GetComponent<Fader>().FadeOut());
		yield return new WaitForSeconds(2.0f);
		yield return StartCoroutine(fader.GetComponent<Fader>().FadeIn());
		yield return new WaitForSeconds(2.0f);
		Quaternion currentRotation = player.localRotation;
		Quaternion camRot = cam.localRotation;
		Quaternion lookTo = Quaternion.LookRotation(transform.position - player.localPosition, Vector3.right);
		float rate = Quaternion.Angle(currentRotation, lookTo);
		rate = 1.0f / time;
		
		while (t < 3.0f) {
			t += Time.deltaTime * rate;
			player.localRotation = Quaternion.Slerp(currentRotation, lookTo, t);
			//cam.localRotation = Quaternion.Slerp(camRot, lookTo, t);
			yield return null;
		}
		
		yield return new WaitForSeconds(3.0f);
		t = 0.0f;
		lookTo = Quaternion.Euler(new Vector3(45, 23, 12));
		camRot = cam.localRotation;
		currentRotation = player.localRotation;
		
		Vector3 finalPlayerPos = new Vector3(0.0f, 0.5f, 0.0f);
		Vector3 finalCamPos = new Vector3(0.0f, 0.5f, 0.0f);
		Vector3 currentPlayerPos = player.position;
		Vector3 currentCamPos = cam.localPosition;
		
		while (t < 1.0f) {
			t += Time.deltaTime * rate;
			player.localRotation = Quaternion.Slerp(currentRotation, lookTo, t);
			cam.localRotation = Quaternion.Slerp(camRot, lookTo, t);
			player.position = Vector3.Lerp(currentPlayerPos, finalPlayerPos, t);
			cam.localPosition = Vector3.Lerp(currentCamPos, finalCamPos, t);
			yield return null;
		}
		
		t = 0.0f;
		lookTo = Quaternion.identity;
		finalPlayerPos = new Vector3(0.0f, 1.05f, 0.0f);
		finalCamPos = new Vector3(0.0f, 0.9070835f, 0.0f);
		currentPlayerPos = player.position;
		currentCamPos = cam.localPosition;
		camRot = cam.localRotation;
		currentRotation = player.localRotation;
		
		while (t < 3.0f) {
			t += Time.deltaTime * rate;
			player.localRotation = Quaternion.Slerp(currentRotation, lookTo, t);
			cam.localRotation = Quaternion.Slerp(camRot, lookTo, t);
			player.position = Vector3.Lerp(currentPlayerPos, finalPlayerPos, t);
			cam.localPosition = Vector3.Lerp(currentCamPos, finalCamPos, t);
			yield return null;
		}
		
		player.position = finalPlayerPos;
		cam.localPosition = finalCamPos;
		cam.GetComponent<MouseLook>().enabled = true;
		MonoBehaviour[] allComponents = player.GetComponents<MonoBehaviour>();
		
		foreach (MonoBehaviour b in allComponents) {
			b.enabled = true;
		}
		
		Destroy(gameObject);
	}
}
