using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public GameObject player;
    public GameObject hurtBox;
    public float direction = 1;
    public float movementSpeed = 0.09f;
    public float jumpSpeed = 1f;
    public bool grounded = true;
    public bool attacking = false;
    public bool ducking = false;
    float attackTimer = 15f;
    float attackTick = 0f;
    public Rigidbody2D rb;
    public BoxCollider2D bc2;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc2 = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //player inputs
        if (Input.GetKey("a") && attacking == false)
        {
            if(ducking == false)
            {
                player.transform.Translate(new Vector3(-movementSpeed, 0.0f, 0.0f));
                direction = -1;
            }
            else if(ducking){
                direction = -1;
            }
        }
        if (Input.GetKey("d") && attacking == false)
        {
            if (ducking == false)
            {
                player.transform.Translate(new Vector3(movementSpeed, 0.0f, 0.0f));
                direction = 1;
            } else if (ducking)
            {
                direction = 1;
            }
        }
        if (Input.GetKeyDown("k") && grounded == true)
        {
            rb.AddForce(player.transform.up * jumpSpeed, ForceMode2D.Impulse);         
        }

        if(Input.GetKeyDown("s") && grounded)
        {
            ducking = true;
        }else if (Input.GetKeyUp("s"))
        {
            ducking = false;
        }

        if (ducking)
        {
            bc2.offset = new Vector2(0f, -0.25f);
            bc2.size = new Vector2(1f, 0.5f);
        }else
        {
            bc2.offset = new Vector2(0f, 0f);
            bc2.size = new Vector2(1f, 1f);
        }

        //player Attacks
        if (attacking)
        {
            if (attackTick < attackTimer)
            {
                attackTick += 1;
                if (attackTick == 3)
                {
                    var hurtBoxFab = (GameObject)Instantiate(hurtBox, player.transform.position + new Vector3(0.8f * direction, 0.0f, 0.0f), player.transform.rotation);
                    Debug.Log("attacking");
                }
                Debug.Log(attacking.ToString());
            }
            if (attackTick >= attackTimer)
            {
                attacking = false;
                attackTick = 0f;
                Debug.Log(attacking.ToString());
            }
        }

        if (Input.GetKeyDown("j") && attacking == false)
        {
            attacking = true;
            
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
}
    
