using UnityEngine;
using System.Collections;

public class DestroyProjectile : MonoBehaviour {
	bool isDestroyed = false;
	public AudioClip catCollision;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.collider.tag == "Wall") {
			if (!isDestroyed) {
				isDestroyed = true;
				Destroy (gameObject);
			}
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Bullet") {
			if (!isDestroyed) {
				isDestroyed = true;
				AudioSource.PlayClipAtPoint(catCollision, transform.position);
				Destroy (other.gameObject);
				Destroy (gameObject);
			}

		}
	}
}
