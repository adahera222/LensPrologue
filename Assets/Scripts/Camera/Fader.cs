using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {
	
	public Renderer fadePlane;
	public bool fadeOut = true;
	public float fadeValue = 0.15f;
	public GameObject player;
	public GameObject cam;

	// Use this for initialization
	void Start () {
		//if (fadeOut)
			//StartCoroutine(FadeOut());
		//else
			//StartCoroutine(FadeIn());
	}
	
	public IEnumerator FadeIn() {
		
		Color c = fadePlane.material.color;
		
		while (c.a > 0.0f) {
			c.a -= (fadeValue * Time.deltaTime);
			fadePlane.material.color = c;
			yield return null;
		}
		c.a = 0.0f;
		fadePlane.material.color = c;
		//Destroy(fadePlane.gameObject);
	}
	
	public IEnumerator FadeOut() {
		
		Color c = fadePlane.material.color;
		
		while (c.a <= 1.0f) {
			c.a += (fadeValue * Time.deltaTime);
			fadePlane.material.color = c;
			yield return null;
		}
		c.a = 1.0f;
		fadePlane.material.color = c;
		//Destroy(fadePlane.gameObject);
	}
	
	public IEnumerator FadeOutWithSound() {
		
		Color c = fadePlane.material.color;
		
		while (c.a <= 1.0f) {
			cam.audio.volume -= (fadeValue * Time.deltaTime);
			c.a += (fadeValue * Time.deltaTime);
			fadePlane.material.color = c;
			yield return null;
		}
		c.a = 1.0f;
		fadePlane.material.color = c;
		//Destroy(fadePlane.gameObject);
	}
}
