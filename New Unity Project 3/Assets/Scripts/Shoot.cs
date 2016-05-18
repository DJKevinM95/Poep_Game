using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bullet_prefab;
	float bulletImpulse = 20f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetButtonDown("Fire1") ) {
			Camera cam = Camera.main;
			GameObject thebullet = (GameObject)Instantiate(bullet_prefab, cam.transform.position + cam.transform.forward, cam.transform.rotation);
			thebullet.GetComponent<Rigidbody>().AddForce( cam.transform.forward * bulletImpulse, ForceMode.Impulse);
		}
	}
}
