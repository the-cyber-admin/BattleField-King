using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{

	public GameObject projectileShoot;
	public GameObject projectileCharge;
	public Transform shootingPoint;
	public Transform center;
	public Text mode;
	public float reloadRate = 0.5f;
	public float force = 5f;
	public bool automatic = true;
	
	float _nextTimeFire;

	void Start ()
	{
		_nextTimeFire = Time.time + reloadRate;
	}

	bool isCharging = false;

	void Update()
	{
		SwitchLabel();

		if (automatic && !isCharging)
		{
			if (Time.time > _nextTimeFire && Input.GetButton("Fire1"))
			{
				Fire();
			}
		}

		if (!automatic && !isCharging && Input.GetButtonDown("Fire1"))
			Charge();

		if (isCharging && Input.GetButtonUp("Fire1"))
			Release();
	}

	void SwitchLabel()
	{
		if (Input.GetButtonDown("Switch"))
		{
			automatic = !automatic;
			mode.text = automatic ? "Automatic" : "Charged";
		}
	}

	GameObject pro;
	void Fire()
	{
		_nextTimeFire = Time.time + reloadRate;
		var differnce = shootingPoint.position - transform.position;
		pro = Instantiate(projectileShoot, shootingPoint.position, transform.rotation);
		pro.GetComponent<ShotController>().Shoot(differnce.normalized , force);
	}

	void Charge()
	{
		isCharging = true;
		pro = Instantiate<GameObject>(projectileCharge, shootingPoint.position, transform.rotation , shootingPoint);
	}

	void Release()
	{
		isCharging = false;
		_nextTimeFire = Time.time + reloadRate;
		var differnce = shootingPoint.position - transform.position;
		pro.transform.SetParent(null);
		pro.GetComponent<ShotController>()
			.Shoot(differnce.normalized , force);
	}
}
