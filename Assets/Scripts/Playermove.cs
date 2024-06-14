using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Rendering;

public class Playermove : MonoBehaviour
{

    bool alive = true;
    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;
    public float speedIncreasePoint = 0.11f;
    public float jumpfor = 400f;
    public LayerMask groundMask;

    public void Start()
    {
        CapsuleCollider torsoCollider = gameObject.AddComponent<CapsuleCollider>();
        torsoCollider.center = new Vector3(0, 1, 0);
        torsoCollider.radius = 0.5f;
        torsoCollider.height = 2.0f;
    }
    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (transform.position.y < -5)
        {
            Die();
        }
    }




    public void Die()
    {
        alive = false;

        if (GameManager.inst != null)
        {
            GameManager.inst.SaveScore();
        }

        if (GameManager.inst.score >= 100)
        {
            SceneManager.LoadScene("Map");
        }
        else
        {
            SceneManager.LoadScene("Death");
        }

    }


    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        rb.AddForce(Vector3.up * jumpfor);
    }

    public void ChangeScene()
    {

    }
}