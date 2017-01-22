using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{

    public GameObject player;
    public GameObject hurtBox;
    public GameObject hurtFlash;
    public GameObject mask;
    public float direction = 1;
    public float healthMax = 3;
    public float health = 3;
    public bool damaged = false;
    public bool justHit = false;
    float hurting = 0f;
    public float hurtTimer = 20f;
    public float movementSpeed = 0.09f;
    public float hurtSpeed = 0.5f;
    public float jumpSpeed = 1f;
    public bool grounded = true;
    public bool attacking = false;
    public bool ducking = false;
    float attackTimer = 15f;
    float attackTick = 0f;
    public Rigidbody2D rb;
    public BoxCollider2D bc2;

	//True if the game ends, false if the game should keep playing
	public bool gameOver;
	//Assign the GUI script here
	public GUIscript gui;


	public AudioSource[] audio;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc2 = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        

        hurtBox.transform.position = new Vector3(player.transform.position.x + ( 0.8f * direction), player.transform.position.y, player.transform.position.z);
        hurtBox.SetActive(false);
        Debug.Log("damaged: " + damaged.ToString());
        if (damaged)
        {
            //justHit = true;
            if(hurting < hurtTimer)
            {
                hurting += 1f;
            }
            if(hurting < 6f)
            {
                justHit = true;
            }
            if(hurting >= 6f && justHit)
            {
                justHit = false;
            }
            if(hurting >= hurtTimer)
            {
                damaged = false;
                hurting = 0f;
            }
        }

        if (justHit)
        {
            //player.transform.Translate(new Vector3(hurtSpeed * (direction * -1), 0.0f, 0.0f));
            rb.AddForce(player.transform.right * (hurtSpeed * (direction * -1)), ForceMode2D.Impulse);
			audio[0].Play ();
        }

		//Player inputs should only be calculated when the game is still playing
		if (!gameOver) {
			//player inputs
			if (Input.GetKey ("a") && attacking == false && justHit == false) {
	            
				if (ducking == false && justHit == false) {
					if (grounded) {
						mask.GetComponent<Animator> ().Play ("walkLeft");
						player.transform.Translate (new Vector3 (-movementSpeed, 0.0f, 0.0f));
						direction = -1;
					}
					if (!grounded) {
						mask.GetComponent<Animator> ().Play ("JumpLeft");
						player.transform.Translate (new Vector3 (-movementSpeed, 0.0f, 0.0f));
						direction = -1;
					}
	                
	                
				} else if (ducking && justHit == false) {
					direction = -1;
				}
			}
			if (Input.GetKeyUp ("a")) {
				mask.GetComponent<Animator> ().Play ("IdleLeft");
			}
			if (Input.GetKey ("d") && attacking == false && justHit == false) {
				if (ducking == false && justHit == false) {
					if (grounded) {
						mask.GetComponent<Animator> ().Play ("walk");
	                    
						player.transform.Translate (new Vector3 (movementSpeed, 0.0f, 0.0f));
						direction = 1;
					}
					if (!grounded) {
						mask.GetComponent<Animator> ().Play ("Jump");
						player.transform.Translate (new Vector3 (movementSpeed, 0.0f, 0.0f));
						direction = 1;

					}
				} else if (ducking && justHit == false) {
					direction = 1;
				}
			}
			if (Input.GetKeyUp ("d")) {
				mask.GetComponent<Animator> ().Play ("Idle");
			}
			if (Input.GetKeyDown ("k") && grounded == true && justHit == false) {
				if (direction == -1) {
					mask.GetComponent<Animator> ().Play ("JumpLeft");
					rb.AddForce (player.transform.up * jumpSpeed, ForceMode2D.Impulse);
				}
				if (direction == 1) {
					mask.GetComponent<Animator> ().Play ("Jump");
					rb.AddForce (player.transform.up * jumpSpeed, ForceMode2D.Impulse);
				}


			}

			if (Input.GetKeyDown ("s") && grounded && justHit == false) {
				if (direction == -1) {
					mask.GetComponent<Animator> ().Play ("crouchleft");
					ducking = true;
				}
				if (direction == 1) {
					mask.GetComponent<Animator> ().Play ("crouch");
					ducking = true;
				}
	            
			} else if (Input.GetKeyUp ("s")) {
				if (direction == -1) {
					mask.GetComponent<Animator> ().Play ("IdleLeft");
					ducking = false;
				}
				if (direction == 1) {
					mask.GetComponent<Animator> ().Play ("Idle");
					ducking = false;
				}
	           
			}

			if (ducking) {
				bc2.offset = new Vector2 (0f, -0.25f);
				bc2.size = new Vector2 (1f, 0.5f);
	            
			} else {
				bc2.offset = new Vector2 (0f, 0f);
				bc2.size = new Vector2 (1f, 1f);
	            
			}

			//player Attacks
			if (attacking) {
				if (attackTick < attackTimer) {
					attackTick += 1;
					if (attackTick >= 3) {
						hurtBox.SetActive (true);
	                    
						Debug.Log ("attacking");
					}
					if (attackTick >= 10) {
						if (hurtBox.activeSelf) {
							hurtBox.SetActive (false);
						}
					}
					Debug.Log (attacking.ToString ());
				}
				if (attackTick >= attackTimer) {
					attacking = false;
					attackTick = 0f;
					Debug.Log (attacking.ToString ());
				}
			}

			if (Input.GetKeyDown ("j") && attacking == false && justHit == false) {
				if (direction == 1) {
					if (ducking) {
						mask.GetComponent<Animator> ().Play ("New Animation");
						attacking = true;
					} else {
						mask.GetComponent<Animator> ().Play ("kick");
						attacking = true;
					}
				}
				if (direction == -1) {
					if (ducking) {
						mask.GetComponent<Animator> ().Play ("crouchAttackLeft");
						attacking = true;
					} else {
						mask.GetComponent<Animator> ().Play ("kickLeft");
						attacking = true;
					}
				}
            
			}
				

			if (health <= 0f || transform.position.y < -12) {
				transform.position = new Vector3 (0, -24, 0);
				gui.endGame ();
				gameOver = true;
			}
		} 

		//If the game is over, check for restart
		else 
		{
			if(Input.GetKeyDown( KeyCode.Return ))
			{
				Time.timeScale = 1;
				SceneManager.LoadScene(0);
			}
		}
    }

    //ground Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
            Debug.Log(grounded.ToString());
        }
        

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = false;
            Debug.Log(grounded.ToString());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if (!damaged)
            {
                health -= 1;
                damaged = true;
                flashHurt();
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if (!damaged)
            {
                health -= 1;
                damaged = true;
                flashHurt();
            }

        }
    }

    void flashHurt()
    {
        var hurtFlashFab = (GameObject)Instantiate(hurtFlash, player.transform.position, player.transform.rotation);
    }
}
    
