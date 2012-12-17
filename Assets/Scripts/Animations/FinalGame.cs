using UnityEngine;
using System.Collections;

public class FinalGame : MonoBehaviour {
	
	public Transform player;
	public Transform cam;
	public Transform lookAtObject;
	public Transform finalPlayerPostion;
	public GameObject VOManager;
	public GameObject fader;
	public GameObject brokenLens;
	public GameObject theLens;
	public Light directional;
	public Light directionalMain;
	public AudioClip forestClip;
	
	private MonoBehaviour[] allComponents;
	private float t = 0.0f;
	private float time = 1.5f;

	// Use this for initialization
	void Start () {
		
		allComponents = player.GetComponents<MonoBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "Player") {
			
			player.GetComponent<FootSteps>().audio.Stop();
			cam.GetComponent<MouseLook>().enabled = false;
			foreach (MonoBehaviour b in allComponents) {
				b.enabled = false;
			}
			StartCoroutine(LookToTree());
		}
	}
	
	private IEnumerator LookToTree() {		
		cam.GetComponent<MouseLook>().enabled = true;
		player.GetComponent<MouseLook>().enabled = true;
		
		while (VOManager.GetComponent<VOManager>().IsPlaying()) {
			yield return null;
		}
		
		cam.GetComponent<MouseLook>().enabled = false;
		player.GetComponent<MouseLook>().enabled = false;
		
		Quaternion currentRotation = player.localRotation;
		Quaternion lookTo = Quaternion.LookRotation(lookAtObject.position - player.localPosition, Vector3.up);
		float rate = Quaternion.Angle(currentRotation, lookTo);
		rate = 1.0f / time;
		
		while (t < 3.0f) {
			t += Time.deltaTime * rate;
			player.localRotation = Quaternion.Slerp(currentRotation, lookTo, t);
			yield return null;
		}
		
		cam.GetComponent<MouseLook>().enabled = true;
		player.GetComponent<MouseLook>().enabled = true;
		
		theLens.SetActive(false);
		brokenLens.SetActive(true);
		
		yield return new WaitForSeconds(2.0f);
		
		cam.GetComponent<MouseLook>().enabled = false;
		player.GetComponent<MouseLook>().enabled = false;
		
		directionalMain.flare = null;
		yield return StartCoroutine(fader.GetComponent<Fader>().FadeOut());
		yield return new WaitForSeconds(2.0f);
		player.position = finalPlayerPostion.position;
		fader.layer = 8;
		cam.camera.depth = -1;
		
		while (cam.audio.volume > 0.0f) {
			cam.audio.volume -= (0.2f * Time.deltaTime);
			yield return null;
		}
		
		cam.audio.Stop();
		
		cam.audio.clip = forestClip;
		cam.audio.Play();
		
		while (cam.audio.volume < 1.0f) {
			cam.audio.volume += (0.2f * Time.deltaTime);
			yield return null;
		}
		
		yield return StartCoroutine(fader.GetComponent<Fader>().FadeIn());
		cam.GetComponent<MouseLook>().enabled = true;
		player.GetComponent<MouseLook>().enabled = true;
		yield return new WaitForSeconds(10.0f);
		cam.GetComponent<MouseLook>().enabled = false;
		player.GetComponent<MouseLook>().enabled = false;
		
		t = 0.0f;
		currentRotation = player.localRotation;
		lookTo = Quaternion.LookRotation(finalPlayerPostion.position - player.localPosition, Vector3.up);
		rate = Quaternion.Angle(currentRotation, lookTo);
		rate = 1.0f / time;
		
		while (t < 3.0f) {
			t += Time.deltaTime * rate;
			player.localRotation = Quaternion.Slerp(currentRotation, lookTo, t);
			yield return null;
		}
		
		directional.flare = null;
		yield return StartCoroutine(fader.GetComponent<Fader>().FadeOutWithSound());
		EndGame();
	}
	
	private void EndGame() {
		
		Application.Quit();
	}
}
