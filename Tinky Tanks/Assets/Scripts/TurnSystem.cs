using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnSystem : MonoBehaviour
{

    public static string playerTurn;

    private int turn;

    public static bool movement = true;

    private Text playerTurnText;

    public static int windDirection;

    private Text windResistanceText;

    

    // Start is called before the first frame update
    void Awake()
    {
        turn = Random.Range(1, 3);

        if(turn == 1)
        {
            playerTurn = "Tank 1";
        }
        else if (turn == 2)
        {
            playerTurn = "Tank 2";
        }


        windDirection = Random.Range(1, 3);


        print(playerTurn);
    }

    private void Start()
    {
        playerTurnText = GameObject.Find("Turn").GetComponent<Text>();
        windResistanceText = GameObject.Find("Wind Resistance").GetComponent<Text>();
        playerTurnText.text = ProjectileHandler.PlayerTurnToText();
        displayWind();
    }

    void applyTurnToText()
    {
        playerTurnText.text = ProjectileHandler.PlayerTurnToText();
    }

    void displayWind()
    {
        if (windDirection == 1)
        {
            windResistanceText.text = "Wind Direction: ---";
        }
        if (windDirection == 2)
        {
            windResistanceText.text = "Wind Direction: >>>";
        }
        if (windDirection == 3)
        {
            windResistanceText.text = "Wind Direction: <<<";
        }

    }

    public static void swapTurn()
    {

        if (playerTurn == "Tank 1")
        {
            playerTurn = "Tank 2";
            
        }
        else if(playerTurn == "Tank 2")
        {
            playerTurn = "Tank 1";
        }
        
        movement = true;
        
    }

    public static void endGame()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
