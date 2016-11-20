using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public Object projectile;
	private GameObject projectileContainer;

	// Use this for initialization
	void Start () {
		projectileContainer = new GameObject ("projectile container") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && projectile!=null)
		{
			//Make a new projectile.
			GameObject projectilePlayer = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			//Set the projectile position to our position
			projectilePlayer.transform.position = transform.position + new Vector3(0.25f, 0f, 0.25f);

			projectilePlayer.transform.parent=projectileContainer.transform;

			//Access RigidBody of the projectile to change it's velocity
			Rigidbody rb = projectilePlayer.GetComponent<Rigidbody>();

			//Set velocity of the projectile in the direction where the player is looking
			rb.velocity = transform.forward * 20;

		}
	}
}
