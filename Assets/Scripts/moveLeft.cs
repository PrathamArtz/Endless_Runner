using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    public float speed = 30f;
    private PlayerController playercontrollerScript;
    private float leftBoundry = -15;

    // Start is called before the first frame update
    void Start()
    {
        playercontrollerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playercontrollerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        }

        if (transform.position.x < leftBoundry && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
