using UnityEngine;
using System.Collections;

public class DestroyProjectile : MonoBehaviour {
	bool isDestroyed = false;
	public AudioClip catCollision;
	public GameObject bloodSplatter;

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
				GameObject blood = (GameObject)Instantiate (bloodSplatter, other.transform.position, other.transform.rotation);
				Destroy (blood, 0.5f);
				AudioSource.PlayClipAtPoint(catCollision, transform.position);
				Destroy (other.gameObject);
				Destroy (gameObject);
			}

		}
	}
}
