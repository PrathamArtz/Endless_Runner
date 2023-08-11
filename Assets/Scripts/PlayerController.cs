using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator animator;
    private AudioSource audioSource;

    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;

    //Particle  Death Effecct
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtEffect;

    //Audio
    public AudioClip jumpSound;
    public AudioClip crashSound;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) // player Jumping data
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetTrigger("Jump_trig");
            audioSource.PlayOneShot(jumpSound);
            dirtEffect.Stop();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtEffect.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            
            gameOver = true;
            Debug.Log("Game Over");
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtEffect.Stop();
            audioSource.PlayOneShot(crashSound, 1.0f);
            CompleteLevel();
        }
    }

    public void CompleteLevel()
    {
        Invoke("Restart", 2f);
        SceneManager.LoadScene("GameOver");
        //Invoke("Restart", 2f);
    }
}
