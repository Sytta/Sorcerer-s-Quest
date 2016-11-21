using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
    // Temps minimal et maximal entre les tirs du cannon.
    public float MinDelai = 1.0f;
    public float MaxDelai = 2.0f;
    // Projectile à tirer.
    public Object Bullet;
    // Vitesse du projectile lors du tir.
    public float BulletSpeed = 15.0f;

	public float delaiSpawn = 2.0f;

    // Use this for initialization
	void Start () {
        // Nous démarrons une coroutine parce que cette logique de tir s'étendra tout au long de la partie.
	    StartCoroutine(StartFiring());
    }

    //Logique de tir.
    public IEnumerator StartFiring()
    {
        while (true)
        {
            // Nous attendons pour un temps déterminé aléatoirement.
            yield return new WaitForSeconds(Random.Range(MinDelai, MaxDelai));

            // Nous choisissons une position en z aléatoire à l'intérieur du cannon.
            // Le cannon est centré en (0, 0, 0)
			// Le canon a une longueur de 1
            float minimum = -Random.Range(0.0f, 0.5f);
            float maximum =  Random.Range(0.0f, 0.5f);

            Vector3 position = new Vector3(0, 0, Random.Range(minimum, maximum));
            // Nous créons le projectile selon la position déterminée et l'orientons dans le même sens que le cannon.
            // transform.TransformPoint transformera les coordonées locales utilisées en coordonées du monde.
            // De cette façon, c'est lui qui prend en charge le scale fait dans l'éditeur. Ainsi, 1 unité en z en vaut 13 dans le monde avec le scale du cannon.
			GameObject result = (GameObject)Instantiate(Bullet, transform.TransformPoint(position) + new Vector3(1f, 0f, 1f), transform.rotation);
            // Nous denons une vitesse au projectile pour qu'il puisse se déplacer lorsqu'il apparaît.
            result.GetComponent<Rigidbody>().velocity = transform.right.normalized*BulletSpeed; // vitesse pointant vers les x positif
        }
    }
}
