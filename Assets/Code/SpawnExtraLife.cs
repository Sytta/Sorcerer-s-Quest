using UnityEngine;
using System.Collections;

public class SpawnExtraLife : MonoBehaviour {
	public Object extraLife;
	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnLife());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator SpawnLife() {
		while (true) {
			yield return new WaitForSeconds(15);
			// position minimale pour le spawn
			Vector3 min = gameObject.transform.position
			             - (gameObject.transform.localScale / 2.0f);

			// position maximale pour le spawn
			Vector3 max = gameObject.transform.position
			             + (gameObject.transform.localScale / 2.0f);
			Vector3 position = new Vector3 (Random.Range (min.x, max.x), gameObject.transform.position.y, Random.Range (min.z, max.z));
			Instantiate (extraLife, position, gameObject.transform.rotation);
		}
	}
}
