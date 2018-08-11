using UnityEngine;

public class Shrink : MonoBehaviour
{
	private float persentage = 1f;

	public float speed = 1f;

	void Update()
	{
		persentage -= speed * Time.deltaTime;
		var scale = new Vector3(persentage, transform.localScale.y, persentage);
		
		scale.x = Mathf.Clamp(scale.x, 0f, 1f);
		scale.z = Mathf.Clamp(scale.z, 0f, 1f);
		
		transform.localScale = scale;
	}

	public void ScaleUp(float f)
	{
		persentage += f;
	}

	public void ScaleDown(float f)
	{
		persentage -= f;
	}
}
