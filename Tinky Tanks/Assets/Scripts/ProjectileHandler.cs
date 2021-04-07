using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileHandler : MonoBehaviour
{

    Rigidbody2D rigidbody;
    private Text playerTurnText;
    private Text windResistanceText;

    int wind;

    // Start is called before the first frame update
    void Start()
    {
        wind = TurnSystem.windDirection;
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(500 * transform.up);
        playerTurnText = GameObject.Find("Turn").GetComponent<Text>();
        windResistanceText = GameObject.Find("Wind Resistance").GetComponent<Text>();
        Invoke("applyPlayerTurnToText", 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.SendMessage("hitByProjectile", SendMessageOptions.DontRequireReceiver);
        TurnSystem.swapTurn();
        randomiseWind();
        playerTurnText.text = PlayerTurnToText();
        destroyThis();
    }

    void randomiseWind()
    {
        wind = Random.Range(1, 4);
        TurnSystem.windDirection = wind;
        displayWind();
    }

    void displayWind()
    {
        if(wind == 1)
        {
            windResistanceText.text = "Wind Direction: ---";
        }
        if (wind == 2)
        {
            windResistanceText.text = "Wind Direction: >>>";
        }
        if (wind == 3)
        {
            windResistanceText.text = "Wind Direction: <<<";
        }

    }

    public static string PlayerTurnToText()
    {
        if(TurnSystem.playerTurn == "Tank 1")
        {
            return "Turn: Player 1 (Purple)";
        }
        else
        {
            return "Turn: Player 2 (Yellow)";
        }

    }

    void destroyThis()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        
        if (wind == 2)
        {
            rigidbody.AddForce(new Vector2(0.4f, 0));
        }
        else if (wind == 3)
        {
            rigidbody.AddForce(new Vector2(-0.4f, 0));
        }



    }
}
