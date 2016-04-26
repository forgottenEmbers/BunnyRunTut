using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BunnyController : MonoBehaviour
{
    // Private Variables
    private Rigidbody2D bunnyRigidBody;
    private Animator bunnyAnim;
    private float bunnyHurtTime = -1;
    private Collider2D bunnyCollider;
    private float startTime;
    private int jumpsLeft = 2;

    // Public Variables
    public float bunnyJumpForce = 800f;
    public Text scoreText;

	// Use this for initialization
	void Start ()
    {
        bunnyRigidBody = GetComponent<Rigidbody2D>();
        bunnyAnim = GetComponent<Animator>();
        bunnyCollider = GetComponent<Collider2D>();
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (bunnyHurtTime == -1)
        {

            if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
            {
//                if (bunnyRigidBody.velocity.y < 0)
//                {
                    bunnyRigidBody.velocity = Vector2.zero;
//                }

//                if(jumpsLeft == 1)
//                {
//                    bunnyRigidBody.AddForce(transform.up * bunnyJumpForce * 0.75f);
//                }
//                else
//                {
                    bunnyRigidBody.AddForce(transform.up * bunnyJumpForce);
//                }
                jumpsLeft--;
            }

            bunnyAnim.SetFloat("vVelocity", bunnyRigidBody.velocity.y);
            scoreText.text = (Time.time - startTime).ToString("0.0");

        }
        else
        {
            if(Time.time > bunnyHurtTime + 2)
            {
                //Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {

            foreach (PrefabSpawner spawner in FindObjectsOfType<PrefabSpawner>())
            {
                spawner.enabled = false;
            }

            foreach (MoveLeft lefter in FindObjectsOfType<MoveLeft>())
            {
                lefter.enabled = false;
            }

            bunnyHurtTime = Time.time;
            bunnyAnim.SetBool("bunnyHurt", true);

            bunnyRigidBody.velocity = Vector2.zero;
            bunnyRigidBody.AddForce(transform.up * bunnyJumpForce);
            bunnyCollider.enabled = false;


        }
        else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            jumpsLeft = 2;
        }
    }
}
