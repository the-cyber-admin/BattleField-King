using UnityEngine;

public class Shrink : MonoBehaviour
{
	private float persentage = 1f;
	public float speed = 1f;
	float origin = 0;
	EnemySpawner es;
	void Awake()
	{
		es = FindObjectOfType<EnemySpawner>();
		persentage = transform.localScale.x;
		origin = persentage;
	}
	
	void Update()
	{
		persentage -= speed * Time.deltaTime;
		var scale = new Vector3(persentage, transform.localScale.y, persentage);

		scale.x = Mathf.Clamp(scale.x, 0f, origin);
		scale.z = Mathf.Clamp(scale.z, 0f, origin);
		
		transform.localScale = scale;
		es.radius = persentage;
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
