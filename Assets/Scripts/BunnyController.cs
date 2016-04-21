using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BunnyController : MonoBehaviour
{
    // Private Variables
    private Rigidbody2D bunnyRigidBody;
    private Animator bunnyAnim;
 
    // Public Variables
    public float bunnyJumpForce = 800f;

	// Use this for initialization
	void Start ()
    {
        bunnyRigidBody = GetComponent<Rigidbody2D>();
        bunnyAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            bunnyRigidBody.AddForce(transform.up * bunnyJumpForce);
        }

        bunnyAnim.SetFloat("vVelocity", bunnyRigidBody.velocity.y);

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
