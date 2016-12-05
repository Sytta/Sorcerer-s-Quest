using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	// Variables modifiables dans l'éditeur de Unity
	public Object coin;
	public float delai = 2.0f;
	public float delaiSpawn_coin = 5.0f;

	// Power-up
	// Un power-up aléatoire se spawn dans un délai entre 5 à 6 secondes
	public float minDelai = 5.0f;
	public float maxDelai = 6.0f;
	public float delaiSpawn_power = 5.0f;

	public Object[] powerUps;

	public Object stopCanon;  // arrête les canons
	public Object invincible; // rend invincible
	public Object money;      // donne 2x plus de points
	public Object extraLife;  // donne une vie supplémentaire

	// Use this for initialization
	void Start () {
		// Une routine qui est exécuté en parallèle sans bloquer le déroulement du jeu
		StartCoroutine (SpawnCoin ());

		powerUps = new Object[4];
		powerUps [0] = stopCanon;
		powerUps [1] = invincible;
		powerUps [2] = money;
		powerUps [3] = extraLife;
		StartCoroutine (SpawnPowerUp ());
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
			GameObject result = (GameObject)Instantiate(coin, position, gameObject.transform.rotation);

			// Pour détruire le coin après un certain temps
			Destroy(result, delaiSpawn_coin);
		}
	}

	public IEnumerator SpawnPowerUp() {
		// boucle infinie
		while (true) {
			// Attente d'un temps aléatoire entre 5 à 6 secondes
			yield return new WaitForSeconds(Random.Range(minDelai, maxDelai));

			// position minimale pour le spawn
			Vector3 min = gameObject.transform.position - (gameObject.transform.localScale / 2.0f);

			// position maximale pour le spawn
			Vector3 max = gameObject.transform.position + (gameObject.transform.localScale / 2.0f);

			// La hauteur va être fixe (y), même plan que le joueur
			// Pour x et z, c'est une valeur aléatoire entre les valeurs min et max
			Vector3 position = new Vector3 (Random.Range(min.x, max.x), gameObject.transform.position.y, Random.Range(min.z, max.z));
			Quaternion rotation = new Quaternion (0, 90, 90, gameObject.transform.rotation.w);

			// Instantiation du power-up aléatoire
			GameObject result = (GameObject)Instantiate(powerUps[Random.Range(0,4)], position, rotation);

			// Pour détruire le power-up après un certain temps
			Destroy(result, delaiSpawn_power);
		}
	}
}
