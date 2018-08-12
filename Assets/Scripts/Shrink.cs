using UnityEngine;

public class Shrink : MonoBehaviour
{
	float origin = 0;
	float percentage = 1;
	public float smooth = 0.5f;

	Animator animator;

	void Awake()
	{
		animator = FindObjectOfType<Animator>();
		origin = transform.localScale.x;
	}
	
	public void ScaleUp(float f)
	{
		percentage += f;
		if(animator == null)
			return;
			
		animator.SetBool("Grow" , true);
		animator.SetBool("Shrink" , false);
		
	}

	public void ScaleDown(float f)
	{
		percentage -= f;
		if(animator == null)
			return;
		animator.SetBool("Grow" , false);
		animator.SetBool("Shrink" , true);
	}

	private Vector3 velocity;
	void Update()
	{
		var targetScale = new Vector3(origin * percentage , transform.localScale.y , origin * percentage);
		transform.localScale = Vector3.SmoothDamp(transform.localScale, targetScale, ref velocity, smooth);
	}
}