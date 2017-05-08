using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	public float speed = 7f;

	void Update ()
	{
		transform.Rotate (0,0,speed*Time.deltaTime); //rotates around z axis
	}
}
