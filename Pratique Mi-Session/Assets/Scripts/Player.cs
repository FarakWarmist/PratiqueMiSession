using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Camera playerCam;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    private static int fruitCounter;
    private Vector3 initialPos;

    [SerializeField] string nextLevelName;

    private void Start()
    {
        initialPos = transform.position;
        playerCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var camPos = playerCam.transform.position;
        camPos.x = transform.position.x;
        playerCam.transform.position = camPos;

        float x = Input.GetAxis("Horizontal");

        var velocity = rb.velocity;
        velocity.x = 5f * x;
        rb.velocity = velocity;
        
        if (x != 0)
        {
            spriteRenderer.flipX = x < 0; 
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale *= -1;
            spriteRenderer.flipY = !spriteRenderer.flipY;
        }
    }

    public void TakeDomage()
    {
        rb.bodyType = RigidbodyType2D.Static;
        Invoke(nameof(Respawn), 0.5f);
    }

    private void Respawn()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.position = initialPos;
    }

    internal void CollectFruit()
    {
        if (++fruitCounter == 5)
        {
            //if (nextLevelName == "" || nextLevelName == null) or
            if (string.IsNullOrEmpty(nextLevelName))
            {
                FindAnyObjectByType<TMP_Text>().color = Color.yellow;
            }
            else
            {
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }
}
