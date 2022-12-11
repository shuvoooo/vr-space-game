using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    CharacterController characterController;
    public Transform cameraTransform;
    GameObject gun;
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI textMeshProUGUI2;
    int finalScore;
    bool gameOver = false;
    public int score = 0;
    public int life;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        gun = gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        score = 0;
        life = 3;
        textMeshProUGUI.text = "Score: " + score + "\nLife: " + life;
    }

    public void shoot()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        // gun.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1f);
        score += 1;
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = "Score: " + score + "\nLife: " + life;
        if (gameOver == true)
        {
            finalScore = score;

            textMeshProUGUI2.text = "Game Over" + "\n Your Score: " + finalScore;
        }


        // camera move forward with gravity
        Vector3 move = new Vector3(0, 0, 1);
        move = cameraTransform.TransformDirection(move);
        move *= 0.1f;
        characterController.Move(move);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            if (life <= 0)
            {
                life = 0;
                gameOver = true;
            }

            if (life > 0)
            {
                life--;
            }

            Debug.Log("hello");
        }
    }
}