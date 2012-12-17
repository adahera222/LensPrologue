using UnityEngine;
using System.Collections;

public class FloatBob : MonoBehaviour {
	
	private float xMultiplier;
	private float yMultiplier;
	private float zMultiplier;
	
	private Vector3 originalPosition;
	private Vector3 temp;
	
	void Start() {
		originalPosition = transform.position;
		temp = transform.position;
		
		xMultiplier = Random.Range(0.01f, 0.3f);
		yMultiplier = Random.Range(0.01f, 0.3f);
		zMultiplier = Random.Range(0.01f, 0.3f);
	}
	
	void Update() {
		
		temp.x = originalPosition.x + Mathf.Sin(Time.time) * xMultiplier;
		temp.y = originalPosition.y + Mathf.Sin(Time.time) * yMultiplier;
		temp.z = originalPosition.z + Mathf.Sin(Time.time) * zMultiplier;
		
		transform.position = temp;
	}
}
