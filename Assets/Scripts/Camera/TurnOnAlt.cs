using UnityEngine;
using System.Collections;

public class TurnOnAlt : MonoBehaviour {
	
	public GameObject altCamera;
	public GameObject theLens;
	public GameObject terrainALt;
	
	private float maxX = 2.698128f;
	private float maxYZ = 5.486682f;
	private Vector3 scaleVector = Vector3.zero;

	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "Player") {
			altCamera.SetActive(true);
			StartCoroutine(ScaleLens());
		}
	}
	
	private IEnumerator ScaleLens() {
		
		audio.Play();
		
		while (theLens.transform.localScale.x <= maxX) {
			
			scaleVector.x += ((maxX * 0.2f) * Time.deltaTime);
			scaleVector.y += ((maxYZ * 0.2f) * Time.deltaTime);
			scaleVector.z += ((maxYZ * 0.2f) * Time.deltaTime);
			theLens.transform.localScale = scaleVector;
			yield return null;
		}
		terrainALt.SetActive(true);
	}
}
