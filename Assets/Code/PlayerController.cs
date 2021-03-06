﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UIAddons;

public class PlayerController : MonoBehaviour
{
    public float nouvellePosition;

	// Collision
	public AudioClip catCollision;
	public GameObject bloodSplatter;

	// Vies
	public int   vies = 3;
	public Text  texteVies; // nouveau type de UI, sur Unity 4.6 et plus
	public Text  texteMort;

	// Score
	public int   score = 0;
	public Text  texteScore;
    public AudioSource coinGagne;
	public CustomProgressBar progressBar;
    public LifeSlider lifeSlider;

	// Power-ups
	public AudioClip powerUp;

	// Texte power-up activé (blinking text)
	public BlinkEffect textePowerUp;
	public bool  textePowerUpActivated = false;
	public float textePowerUpActivatedTimeOnScreen = 2.0f;

	// Power up icons
	public GameObject[] canons;

	public bool  powerUpActivatedStopCanon = false;
	public Image stopCanonActivatedIcon;
	public float stopCanonTimeRemaining = 5.0f;

	public bool  powerUpActivatedInvincible = false;
	public Image invincibleActivatedIcon;
	public float invincibleTimeRemaining = 5.0f;

	public bool  powerUpActivatedMoney = false;
	public Image moneyActivatedIcon;
	public float moneyTimeRemaining = 5.0f;

	// Item shop
    public ShopController shopController;
	public Projectile gun;
	public Text  gunQuantity;
	public int   shieldQuantity;
	public Text  texteShieldQuantity;
	public Text  bootsQuantity;
	public bool  itemShopActivatedBoots = false;

    //Message panel
    public MessagePanel messagePanel;

	// Animator
	public Animator animator;

	// Use this for initialization (valeurs de défaut de l'objet)
    void Start()
    {
		// Trouve tous les GameObject ayant le tag "Wall"
		canons = GameObject.FindGameObjectsWithTag ("Wall");
        //Gun
        gun = FindObjectOfType<Projectile>();

		// Reset icons
		moneyActivatedIcon.GetComponent<Image> ().fillAmount = 0.0f;
		stopCanonActivatedIcon.GetComponent<Image> ().fillAmount = 0.0f;
		invincibleActivatedIcon.GetComponent<Image> ().fillAmount = 0.0f;

        //Cacher le magasins de Power-ups et le panel de message
        shopController.CloseShop();
        shopController.openShop = true;
        messagePanel.Close();
        messagePanel.openPanel = true;

        //Appliquer les power-ups que le joueur a achete
        if (GlobalControl.Instance.nbProtection > 0 && SceneManager.GetActiveScene().name != "Scene")
        {
			shieldQuantity = GlobalControl.Instance.nbProtection;
			texteShieldQuantity.text = "" + shieldQuantity;
        }
        if (GlobalControl.Instance.bootsSelected)
        {
            itemShopActivatedBoots = true;
			bootsQuantity.text = "1";
        }
        if (GlobalControl.Instance.gunSelected)
        {
            gun.gunActivated = true;
			gunQuantity.text = "1";
        }

        GlobalControl.Instance.Reset();

        if (SceneManager.GetActiveScene().name == "Scene")
        {
            progressBar.slider.maxValue = 10;
            progressBar.slider.minValue = 0;
            progressBar.slider.value = 0;
        }
        else if (SceneManager.GetActiveScene().name == "Scene_LV2")
        {
            progressBar.slider.maxValue = 15;
            progressBar.slider.minValue = 0;
            progressBar.slider.value = 0;
        }
        else if (SceneManager.GetActiveScene().name == "Scene_LV3")
        {
            progressBar.slider.maxValue = 20;
            progressBar.slider.minValue = 0;
            progressBar.slider.value = 0;
        }
    }

    public void NextLevel()
    {
        shopController.CloseShop();
        int levelLoaded = SceneManager.GetActiveScene().buildIndex;
        Initiate.Fade(levelLoaded + 1, Color.black, 0.5f);
    }

    // Update is called once per frame (approx. 60 times per second)
    void Update()
    {
        //Verifie si le ItemShop et le panel de message ont besoin d'etre active
        if ((SceneManager.GetActiveScene().name == "Scene" && score >= 10) || (SceneManager.GetActiveScene().name == "Scene_LV2" && score >= 15))
        {
            //Cacher les textes pour les powerups
            ClearTexts();

            //Mettre les power-ups (sauf Shield) à 0
            bootsQuantity.text = "0";
            gunQuantity.text = "0";

            if (messagePanel.openPanel)
                messagePanel.Open();
            else
                messagePanel.Close();

            if (shopController.openShop)
                shopController.OpenShop();
            else
                shopController.CloseShop();
        }
        else if (SceneManager.GetActiveScene().name == "Scene_LV3" && score >= 20)
        {
            //Cacher les textes pour les powerups
            ClearTexts();

            if (messagePanel.openPanel)
                messagePanel.Open();
            else
            {
                messagePanel.Close();
                NextLevel(); //Revenir au menu principal
            }
        }
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
		if (itemShopActivatedBoots) {
			gameObject.GetComponent<Rigidbody> ().drag = 1.45f;
			gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (entreHorizontal * 30f, 0f, entreVertical * 30f));
		} else {
			gameObject.GetComponent<Rigidbody> ().drag = 0.75f;
			gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (entreHorizontal * 20f, 0f, entreVertical * 20f));
		}

		// Déterminer la vitesse d'animation
		animator.SetFloat("Speed", Mathf.Clamp(gameObject.GetComponent<Rigidbody>().velocity.magnitude, 0.0f, 1.0f));

		gameObject.transform.rotation = Quaternion.LookRotation (new Vector3 (entreHorizontal, 0, entreVertical));

		// power ups are activated when player collide with power up object
		if (powerUpActivatedStopCanon) {

			stopCanonTimeRemaining -= Time.deltaTime;
			stopCanonActivatedIcon.GetComponent<Image> ().fillAmount = stopCanonTimeRemaining / 5.0f;

			// Retour à la normale
			if (stopCanonTimeRemaining < 0) {
				powerUpActivatedStopCanon = false;

				stopCanonTimeRemaining = 5.0f;
				stopCanonActivatedIcon.GetComponent<Image>().fillAmount = 0.0f;

				// Réactive les canons
				foreach (GameObject canon in canons) {
					Cannon script = canon.GetComponent<Cannon> ();
					script.StartCoroutine (script.StartFiring ());
				}
			}
		}

		if (powerUpActivatedInvincible) {

			invincibleTimeRemaining -= Time.deltaTime;
			invincibleActivatedIcon.GetComponent<Image> ().fillAmount = invincibleTimeRemaining / 5.0f;

			// Retour à la normale
			if (invincibleTimeRemaining < 0) {
				powerUpActivatedInvincible = false;

				invincibleTimeRemaining = 5.0f;
				invincibleActivatedIcon.GetComponent<Image>().fillAmount = 0.0f;
			}
		}

		if (powerUpActivatedMoney) {

			moneyTimeRemaining -= Time.deltaTime;
			moneyActivatedIcon.GetComponent<Image> ().fillAmount = moneyTimeRemaining / 5.0f;

			// Retour à la normale
			if (moneyTimeRemaining < 0) {
				powerUpActivatedMoney = false;

				moneyTimeRemaining = 5.0f;
				moneyActivatedIcon.GetComponent<Image>().fillAmount = 0.0f;
			}
		}

		// Quand on active un power-up, un texte blink sur l'écran pendant 2 secondes
		if (textePowerUpActivated) {
			
			if (textePowerUpActivatedTimeOnScreen == 2.0f) {
				textePowerUp.enabled = true;
				textePowerUp.GetComponent<Text> ().enabled = true;
				textePowerUp.GetComponent<Shadow> ().enabled = true;
				textePowerUp.GetComponent<BlinkEffect> ().enabled = true;
			}

			textePowerUpActivatedTimeOnScreen -= Time.deltaTime;

			if (textePowerUpActivatedTimeOnScreen < 0) {
				textePowerUp.enabled = false;
				textePowerUp.GetComponent<Text> ().enabled = false;
				textePowerUp.GetComponent<Shadow> ().enabled = false;
				textePowerUp.GetComponent<BlinkEffect> ().enabled = false;
				textePowerUpActivatedTimeOnScreen = 2.0f;
				textePowerUpActivated = false;
			}
		}

    }

    public void OnCollisionEnter(Collision collision)
    {

    }

    private void ClearTexts() {
        textePowerUp.GetComponent<Text>().text = "";
    }

    public void OnTriggerEnter(Collider other)
    {
		if (vies <= 0)
			return;
		
		// Réagit aux collisions non physique
        if (other.gameObject.tag == "Coin")
        {
			// Désactiver les multiples points
			other.GetComponent<BoxCollider>().enabled = false;
			other.GetComponentInChildren<Light> ().enabled = false;

			// Joue le système de particules
			other.GetComponentInChildren<ParticleSystem> ().Play ();

            coinGagne.Play();

			// Cache le cube
			other.GetComponent<MeshRenderer> ().enabled = false;

			// Détruit l'objet après une seconde pour laisser l'animation jouer
            Destroy(other.gameObject, 1.0f);

			// Incrémentation du score
			if (powerUpActivatedMoney) {
				score = score + 2;
				progressBar.slider.value = progressBar.slider.value + 2;
			} else {
				score++;
				progressBar.slider.value++;
			}

			texteScore.text = "Coins : " + score;
        }

		if (other.gameObject.tag == "Bullet" && !powerUpActivatedInvincible)
		{
			if (shieldQuantity == 0) {
				// Si le joueur est touché, on décrémente sa vie
				vies--;
                lifeSlider.SetValue((float)vies/3);

                // Joue le système de particules
                //GetComponentInChildren<ParticleSystem> ().Play ();
				GameObject blood = (GameObject)Instantiate (bloodSplatter, transform.position, transform.rotation);
				Destroy (blood, 0.5f);

                // Joue le son
				AudioSource.PlayClipAtPoint(catCollision, transform.position);

                // Détruit l'objet
                Destroy(other.gameObject);

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
				shieldQuantity--;
				texteShieldQuantity.text = "" + shieldQuantity;
			}

			texteVies.text = "Life : " + vies;
			texteScore.text = "Coins : " + score;
		}

		// Power-up : ExtraLife permet de gagner une vie supplémentaire
		if (other.gameObject.tag == "ExtraLife")
		{
			AudioSource.PlayClipAtPoint (powerUp, other.transform.position);

			// Cache le power-up
			other.GetComponentInChildren<Light> ().enabled = false;
			Destroy(other.gameObject);

			if (vies < 3) { //3 vies max
				vies++;
				textePowerUp.GetComponent<Text> ().text = "1 Up!";
			} else {
				textePowerUp.GetComponent<Text> ().text = "Max Life!";
			}

			texteVies.text = "Life : " + vies;
			lifeSlider.SetValue((float)vies / 3);

			textePowerUpActivated = true;
		}

		// Power-up : StopCanon permet d'arrêter le tir des canons
		if (other.gameObject.tag == "StopCanon") {
			AudioSource.PlayClipAtPoint (powerUp, other.transform.position);

			// Cache le power-up
			other.GetComponentInChildren<Light> ().enabled = false;
			Destroy(other.gameObject);

			// Arrête les canons
			foreach (GameObject canon in canons) {
				canon.GetComponent<Cannon> ().StopAllCoroutines ();
			}

			powerUpActivatedStopCanon = true;

			// Cooldown
			stopCanonTimeRemaining = 5.0f;
			stopCanonActivatedIcon.GetComponent<Image>().fillAmount = 1.0f;

			textePowerUp.GetComponent<Text>().text = "Freeze! Let It Go ~";
			textePowerUpActivated = true;
		}

		// Power-up : Invincible ignore les collision avec les chats
		if (other.gameObject.tag == "Invincible") {
			AudioSource.PlayClipAtPoint (powerUp, other.transform.position);

			// Cache le power-up
			other.GetComponentInChildren<Light> ().enabled = false;
			Destroy(other.gameObject);

			powerUpActivatedInvincible = true;

			// Cooldown
			invincibleTimeRemaining = 5.0f;
			invincibleActivatedIcon.GetComponent<Image>().fillAmount = 1.0f;

			textePowerUp.GetComponent<Text>().text = "God Mode!";
			textePowerUpActivated = true;
		}

		// Power-up : Money double les points obtenus avec un Coin
		if (other.gameObject.tag == "Money") {
			AudioSource.PlayClipAtPoint (powerUp, other.transform.position);

			// Cache le power-up
			other.GetComponentInChildren<Light> ().enabled = false;
			Destroy(other.gameObject);

			powerUpActivatedMoney = true;

			// Cooldown
			moneyTimeRemaining = 5.0f;
			moneyActivatedIcon.GetComponent<Image>().fillAmount = 1.0f;

			textePowerUp.GetComponent<Text>().text = "Bling Bling $$$";
			textePowerUpActivated = true;
		}
    }

	public void CacherText() {
		texteMort.enabled = false;

		// Reset la scène
		SceneManager.LoadScene (0);
	}
}