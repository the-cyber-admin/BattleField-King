using UnityEngine;

public class CameraController : MonoBehaviour
{

	public Transform target;
	public float speed = 3f;
	public float smoothTime = 0.5f;
	public Vector3 offset;
	
	Vector3 velocity;
	void FixedUpdate ()
	{
		if(target == null)
			return;
		var newPosition = 
			new Vector3(target.position.x, target.position.y, target.position.z) + offset;
		transform.position = 
			Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
	}
}
