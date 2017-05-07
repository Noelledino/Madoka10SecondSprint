using System.Collections;
using System.Collections.Generic;
using UnityEngine;

		 class CameraScript : MonoBehaviour
         {

	public Transform target;
	public SpriteRenderer scene;

	//zeros out the velocity
	Vector3 velocity = Vector3.zero;

	//time it takes to follow the target
	public float smoothTime = .15f;

	void FixedUpdate()
	{
		Vector3 targetPos = target.position;

		targetPos.x = Mathf.Clamp (target.position.x, scene.bounds.min.x + Camera.main.aspect*Camera.main.orthographicSize, scene.bounds.max.x - Camera.main.aspect*Camera.main.orthographicSize);
		targetPos.y = Mathf.Clamp (target.position.y, scene.bounds.min.y  + Camera.main.orthographicSize, scene.bounds.max.y - Camera.main.orthographicSize);
	




		//aligns target and camera's z
		targetPos.z = transform.position.z;

		transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref velocity, smoothTime);
	}
}