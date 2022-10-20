using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] GameObject followobject;
	[SerializeField] Vector2 offsetSize;
	public float FollowSpeed = 2f;
	public Transform Target;

	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	private Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.1f;
	public float decreaseFactor = 1.0f;
	private Vector2 threshold;

	Vector3 originalPos;

	void Start()
	{
		threshold = calculateThreshold();
		Cursor.visible = false;
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	void Update(){
		Vector3 follow = followobject.transform.position;
		float xDifference = Vector2.Distance(Vector2.right * transform.position.x,Vector2.right * follow.x);
		float yDifference = Vector2.Distance(Vector2.up * transform.position.y,Vector2.up * follow.y);
		Vector3 newPosition = transform.position;

		if ( Mathf.Abs(xDifference) >= threshold.x){
			newPosition.x = follow.x;
		}
		if ( Mathf.Abs(yDifference) >= threshold.y){
			newPosition.y = follow.y;
		}
		transform.position = newPosition;
	}
	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}



	private Vector3 calculateThreshold(){
		Rect aspect = Camera.main.pixelRect;
		Debug.Log("aspect.width: " + aspect.width);
		Debug.Log("aspect.height: " + aspect.height);
		float cameraSize = Camera.main.orthographicSize;
		Vector2 threshold = new Vector2(cameraSize * aspect.width / aspect.height, cameraSize);
		Debug.Log(cameraSize);
		Debug.Log(threshold);
		threshold -= offsetSize;
		return threshold;
	}
}
