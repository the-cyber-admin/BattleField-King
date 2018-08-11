using UnityEngine;

public class GunRotator : MonoBehaviour
{

	public Transform center;
	public int invert = 1;
	
	Camera cam;
	void Awake()
	{
		cam = Camera.main;
	}
	
	void Update () 
	{
		//Get the Screen positions of the object
		Vector2 positionOnScreen = cam.WorldToViewportPoint (center.position);
         
		//Get the Screen position of the mouse
		Vector2 mouseOnScreen = cam.ScreenToViewportPoint(Input.mousePosition);
         
		//Get the angle between the points
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
 
		//Assign the new Rotation
		center.rotation =  Quaternion.Euler (new Vector3(0f,angle,0f));
	}

	float AngleBetweenTwoPoints(Vector3 b, Vector3 a)
	{
		a *= invert;
		b *= invert;
		
		return Mathf.Atan2(a.x - b.x, a.y - b.y) * Mathf.Rad2Deg;
	}
}
