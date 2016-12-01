using UnityEngine;
using System.Collections;

public class DestroyCats : MonoBehaviour {
	bool isDestroyed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Wall") {
			if (!isDestroyed) {
				isDestroyed = true;
				Destroy (gameObject);
			}
		}
	}
}
