using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TankControls : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    public GameObject cannon;
    public GameObject cannonEnd;
    public GameObject projectile;
    public GameObject gameEnd;
    private Text shotsFiredText;
    private Text winnerText;
    private static int shots = 0;
    private string playerID;

    private int moveSpeed = 800;
    private float aimSpeed = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        shotsFiredText = GameObject.Find("Shots").GetComponent<Text>();
        winnerText = GameObject.Find("Winner").GetComponent<Text>();
        playerID = tag;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (TurnSystem.playerTurn == playerID)
        {
            if (TurnSystem.movement == true)
            {
                basicMovement();
                cannonAim();
                shoot();
            }
        }
    }

    void basicMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(new Vector2(-moveSpeed, 0));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(new Vector2(moveSpeed, 0));
        }

        rigidbody.velocity = new Vector2(0, 0);
    }

    void cannonAim()
    {
        if (playerID == "Tank 1")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                cannon.transform.Rotate(new Vector3(0, 0, aimSpeed));
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                cannon.transform.Rotate(new Vector3(0, 0, -aimSpeed));
            }
        }
        else if (playerID == "Tank 2")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                cannon.transform.Rotate(new Vector3(0, 0, -aimSpeed));
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                cannon.transform.Rotate(new Vector3(0, 0, aimSpeed));
            }
        }

    }

    void shoot()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            TurnSystem.movement = false;
            Instantiate(projectile, cannon.transform.position, cannon.transform.rotation);
            shots++;
            shotsFiredText.text = "Shots Fired: " + shots;
            

        }
    }

    void hitByProjectile()
    {
        if(TurnSystem.playerTurn == "Tank 1")
        {
            winnerText.text = "Player 1 Wins!";
        }
        if (TurnSystem.playerTurn == "Tank 2")
        {
            winnerText.text = "Player 2 Wins!";
        }
        Instantiate(gameEnd);
        Destroy(gameObject);
    }

}
