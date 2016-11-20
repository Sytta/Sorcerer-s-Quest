using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float nouvellePosition;
	public int   vies = 3;
	public int protection = 0;
	public Text  texteVies; // nouveau type de UI, sur Unity 4.6 et plus
	public Text  texteMort;
	public Text texteProtection;

	// à ajouter : le score (quand on frappe un coin)
	public int   score = 0;
	public Text  texteScore;

	// Animator
	public Animator animator;

	// Use this for initialization (valeurs de défaut de l'objet)
    void Start()
    {

    }
		
	// Update is called once per frame (approx. 60 times per second)
    void Update()
    {

    }

	// Update at a lower rate
    public void FixedUpdate()
    {
		// SI le joueur meurt, on ne veut plus pouvoir le déplacer
		if (vies <= 0)
			return;
		
		// transform est la seule composante qu'on peut accéder à partir de gameObject directement
		// Cela force la position de l'objet.
		// gameObject.transform.position = new Vector3(entreeHorizontale, 0f, 0f); // transform position of game object to (x,y,z)

		// Déplacement de gameObjet
		// Une entrée au clavier vaut -1 ou 1. (Raw pure; sinon entre -1 à 1)
		float entreHorizontal = Input.GetAxisRaw("Horizontal");  // prend la valeur du clavier
        float entreVertical = Input.GetAxisRaw("Vertical");
        
		// Pour accéder à la composante Rigidbody, on doit utiliser la classe GetComponent (template)
		// La force entreeHorizontale est très faible (1N).
		// Ainsi, on multiplie la valeur de la force entreeHorizontale.
		// La physique effectue son travail pour bouger l'objet.
		// y est l'axe pointant vers le haut
		gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(entreHorizontal * 20f, 0f, entreVertical * 20f));

		// Déterminer la vitesse d'animation
		animator.SetFloat("Speed", Mathf.Clamp(gameObject.GetComponent<Rigidbody>().velocity.magnitude, 0.0f, 1.0f));

		gameObject.transform.rotation = Quaternion.LookRotation (new Vector3 (entreHorizontal, 0, entreVertical));

    }

    public void OnCollisionEnter(Collision collision)
    {

    }

    public void OnTriggerEnter(Collider other)
    {
		if (vies <= 0)
			return;
		
		// Réagit aux collisions non physique
        if (other.gameObject.tag == "Coin")
        {
			// Joue le système de particules
			other.GetComponentInChildren<ParticleSystem> ().Play ();

			// Cache le cube
			other.GetComponent<MeshRenderer> ().enabled = false;

			// Détruit l'objet après une seconde pour laisser l'animation jouer
            Destroy(other.gameObject, 1.0f);

			// Incrémentation du score
			score++;

			texteScore.text = "Score : " + score;
        }

		if (other.gameObject.tag == "ExtraLife")
		{
			Destroy(other.gameObject);
			vies++;
			texteVies.text = "Vies : " + vies;
		}

		if (other.gameObject.tag == "Protection")
		{
			Destroy(other.gameObject);
			protection = 3;
			texteProtection.text = "Protection : " + protection;
		}

		if (other.gameObject.tag == "Bullet")
		{
			if (protection == 0) {
				// Si le joueur est touché, on décrémente sa vie
				vies--;

				// quand le joueur a été touché 3 fois
				if (vies == 0) {
					// Contradiction avec le fait que le joueur meurt
					//gameObject.transform.position = Vector3.zero;
					//vies = 3

					// reset du score et de la vie
					score = 0;

					// Animation de mort
					animator.SetTrigger ("Die");

					// Affichage du game over!
					texteMort.enabled = true;
					Invoke ("CacherText", 3.0f);
				}
			} else {
				protection--;
				texteProtection.text = "Protection : " + protection;
			}

			texteVies.text = "Vies : " + vies;
			texteScore.text = "Score : " + score;
		}
    }

	public void CacherText() {
		texteMort.enabled = false;

		// Reset la scène
		SceneManager.LoadScene (0);
	}
}

// challenge, jeu ou on esquive des objets
// pour la fin de la session, ajouter des fonctionnalités au jeu
// powerup (GODMODE) : penser au fait que le player peut être invincible
// powerup (FREEZE - Let it go!) : ralentir le temps (balle ralentisse)
// powerup (HEART) : gagne une vie (max. de 3)

// Après un certain score, on peut faire plus difficile, genre plus de chat, plus rapide