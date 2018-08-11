using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
	public float speed = 5f;
	public float movementSmoothing = 0.05f;

	Vector2 axis;
	
	Rigidbody rb;
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
	{
		axis.x = Input.GetAxis("Horizontal");
		axis.y = Input.GetAxis("Vertical");
	}

	Vector3 velocity;
	void FixedUpdate()
	{
		var axisReal = new Vector3(axis.x, 0, axis.y);
		//rb.AddForce(axis * speed * Time.fixedDeltaTime);
		var force = axisReal * speed;
		Vector3 targetVelocity = new Vector3(force.x , 0 , force.z);
		rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
	}
}
