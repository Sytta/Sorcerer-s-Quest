using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	// Variables modifiables dans l'éditeur de Unity
	public Object coin;
	public float delai = 2.0f;

	// Use this for initialization
	void Start () {
		// Une routine qui est exécuté en parallèle sans bloquer le déroulement du jeu
		StartCoroutine (SpawnCoin ());
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator SpawnCoin() {
		// boucle infinie
		while (true) {
			// à chaque délai défini plus haut
			yield return new WaitForSeconds(delai);

			// position minimale pour le spawn
			Vector3 min = gameObject.transform.position 
				- (gameObject.transform.localScale / 2.0f);

			// position maximale pour le spawn
			Vector3 max = gameObject.transform.position 
				+ (gameObject.transform.localScale/ 2.0f);

			// La hauteur va être fixe (y), même plan que le joueur
			// Pour x et z, c'est une valeur aléatoire entre les valeurs minimales et maximales
			Vector3 position = new Vector3 (Random.Range(min.x, max.x), gameObject.transform.position.y, Random.Range(min.z, max.z));
		
			// Instanciation d'un objet à cette position (en l'occurence un Coin)
			Instantiate(coin, position, gameObject.transform.rotation);
		}
	}
}
