using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	// Variables modifiables dans l'éditeur de Unity
	public Object coin;
	public float delai = 2.0f;
	public float delaiSpawn_coin = 5.0f;

	// Power-up spawn
	// Chaque objet se spawn aléatoirement dans un délai entre 5 à 15 secondes
	// TO-DO : À chaque 7 secondes, spawn un power-up aléatoire parmi tous les power-ups
	public float minDelai = 5.0f;
	public float maxDelai = 15.0f;
	public float delaiSpawn_power = 5.0f;

	// Power-up : arrête les canons
	public Object stopCanon;
	public Object invincible;
	public Object money;

	// Shop (pour l'instant c'est un power-up qui n'a pas de durée)
	public Object boots;

	// Power-up : Extra life
	public Object extraLife;

	// Shop (protection)
	public Object protection;

	// Use this for initialization
	void Start () {
		// Une routine qui est exécuté en parallèle sans bloquer le déroulement du jeu
		StartCoroutine (SpawnCoin ());
		StartCoroutine (SpawnPowerUpStopCanon ());
		StartCoroutine (SpawnPowerUpInvincible ());
		StartCoroutine (SpawnPowerUpMoney ());
		StartCoroutine (SpawnPowerUpBoots ());
		StartCoroutine (SpawnLife ());
		StartCoroutine (SpawnProtection ());
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

	public IEnumerator SpawnPowerUpStopCanon() {
		// boucle infinie
		while (true) {
			// Attente d'un temps aléatoire
			yield return new WaitForSeconds(Random.Range(minDelai, maxDelai));

			// position minimale pour le spawn
			Vector3 min = gameObject.transform.position - (gameObject.transform.localScale / 2.0f);

			// position maximale pour le spawn
			Vector3 max = gameObject.transform.position + (gameObject.transform.localScale / 2.0f);

			// La hauteur va être fixe (y), même plan que le joueur
			// Pour x et z, c'est une valeur aléatoire entre les valeurs min et max
			Vector3 position = new Vector3 (Random.Range(min.x, max.x), gameObject.transform.position.y, Random.Range(min.z, max.z));

			// Instantiation du power-up (en l'occurence le StopCanon)
			GameObject result = (GameObject)Instantiate(stopCanon, position, gameObject.transform.rotation);

			// Pour détruire le power-up après un certain temps
			Destroy(result, delaiSpawn_power);
		}
	}

	public IEnumerator SpawnPowerUpInvincible() {
		// boucle infinie
		while (true) {
			// Attente d'un temps aléatoire
			yield return new WaitForSeconds(Random.Range(minDelai, maxDelai));

			// position minimale pour le spawn
			Vector3 min = gameObject.transform.position - (gameObject.transform.localScale / 2.0f);

			// position maximale pour le spawn
			Vector3 max = gameObject.transform.position + (gameObject.transform.localScale / 2.0f);

			// La hauteur va être fixe (y), même plan que le joueur
			// Pour x et z, c'est une valeur aléatoire entre les valeurs min et max
			Vector3 position = new Vector3 (Random.Range(min.x, max.x), gameObject.transform.position.y, Random.Range(min.z, max.z));

			// Instantiation du power-up (en l'occurence le StopCanon)
			GameObject result = (GameObject)Instantiate(invincible, position, gameObject.transform.rotation);

			// Pour détruire le power-up après un certain temps
			Destroy(result, delaiSpawn_power);
		}
	}

	public IEnumerator SpawnPowerUpMoney() {
		// boucle infinie
		while (true) {
			// Attente d'un temps aléatoire
			yield return new WaitForSeconds(Random.Range(minDelai, maxDelai));

			// position minimale pour le spawn
			Vector3 min = gameObject.transform.position - (gameObject.transform.localScale / 2.0f);

			// position maximale pour le spawn
			Vector3 max = gameObject.transform.position + (gameObject.transform.localScale / 2.0f);

			// La hauteur va être fixe (y), même plan que le joueur
			// Pour x et z, c'est une valeur aléatoire entre les valeurs min et max
			Vector3 position = new Vector3 (Random.Range(min.x, max.x), gameObject.transform.position.y, Random.Range(min.z, max.z));

			// Instantiation du power-up (en l'occurence le StopCanon)
			GameObject result = (GameObject)Instantiate(money, position, gameObject.transform.rotation);

			// Pour détruire le power-up après un certain temps
			Destroy(result, delaiSpawn_power);
		}
	}

	public IEnumerator SpawnPowerUpBoots() {
		// boucle infinie
		while (true) {
			// Attente d'un temps aléatoire
			yield return new WaitForSeconds(Random.Range(minDelai, maxDelai));

			// position minimale pour le spawn
			Vector3 min = gameObject.transform.position - (gameObject.transform.localScale / 2.0f);

			// position maximale pour le spawn
			Vector3 max = gameObject.transform.position + (gameObject.transform.localScale / 2.0f);

			// La hauteur va être fixe (y), même plan que le joueur
			// Pour x et z, c'est une valeur aléatoire entre les valeurs min et max
			Vector3 position = new Vector3 (Random.Range(min.x, max.x), gameObject.transform.position.y, Random.Range(min.z, max.z));

			// Instantiation du power-up (en l'occurence le StopCanon)
			GameObject result = (GameObject)Instantiate(boots, position, gameObject.transform.rotation);

			// Pour détruire le power-up après un certain temps
			Destroy(result, delaiSpawn_power);
		}
	}

	public IEnumerator SpawnLife() {
		while (true) {
			yield return new WaitForSeconds(Random.Range(minDelai, maxDelai));
			// position minimale pour le spawn
			Vector3 min = gameObject.transform.position - (gameObject.transform.localScale / 2.0f);

			// position maximale pour le spawn
			Vector3 max = gameObject.transform.position + (gameObject.transform.localScale / 2.0f);
			Vector3 position = new Vector3 (Random.Range (min.x, max.x), gameObject.transform.position.y, Random.Range (min.z, max.z));
			GameObject result = (GameObject)Instantiate (extraLife, position, gameObject.transform.rotation);
			Destroy(result, delaiSpawn_power);
		}
	}

	public IEnumerator SpawnProtection() {
		while (true) {
			yield return new WaitForSeconds(Random.Range(minDelai, maxDelai));
			// position minimale pour le spawn
			Vector3 min = gameObject.transform.position - (gameObject.transform.localScale / 2.0f);

			// position maximale pour le spawn
			Vector3 max = gameObject.transform.position + (gameObject.transform.localScale / 2.0f);
			Vector3 position = new Vector3 (Random.Range (min.x, max.x), gameObject.transform.position.y, Random.Range (min.z, max.z));
			GameObject result = (GameObject)Instantiate (protection, position, gameObject.transform.rotation);
			Destroy(result, delaiSpawn_power);
		}
	}
}
