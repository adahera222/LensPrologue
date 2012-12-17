using UnityEngine;
using System.Collections;

public class VOManager : MonoBehaviour {
	
	public AudioClip[] allVoiceClips;
	
	private int currentClip = 0;
	private bool isPlaying = false;

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(3.0f);
		audio.clip = allVoiceClips[currentClip];
		audio.Play();
		++currentClip;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (audio.isPlaying) {
			isPlaying = true;
		} else {
			isPlaying = false;
		}
	}
	
	public bool IsPlaying() {
		return isPlaying;
	}
	
	public void PlayNextClip() {
		
		StartCoroutine(PlayClip());
	}
	
	private IEnumerator PlayClip() {
		
		while (IsPlaying()) {
			yield return null;
		}
		
		yield return new WaitForSeconds(1.0f);
		
		audio.clip = allVoiceClips[currentClip];
		audio.Play();
		++currentClip;
	}
}
