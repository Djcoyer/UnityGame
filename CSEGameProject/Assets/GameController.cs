using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject player;
    public GameObject cheeseWheel;
    public float spawnWait;
    public int ObjectCount = 0;
    public float Timer;
    public Text IntroText;
    private bool gameOver;
    public Text winText;
    public Text message1Text;
    public Text message2Text;
    public PlayerScript Player;
    public Text displayTime;

    // Use this for initialization
    void Start () {

        displayTime.text = "";
        winText.text = "";
        message1Text.text = "";
        message2Text.text = "";
        gameOver = false;
        StartCoroutine (SpawnObjects());
        Timer = 0;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            message1Text.text = "Devyn Coyer, ID 1001417871";
            message2Text.text = "Course: CSE 1105-002";
        }


        if(!gameOver)
        {
            if (Timer < 5)
            {
                IntroText.text = "Collect as many cubes as you can in 60 seconds";
            }
            else if (Timer > 5 && Timer < 7)
                IntroText.text = "";
            else if (Timer >= 60)
            {
                GameOver();
            }

            Timer += Time.deltaTime;
            displayTime.text = "Time: " + Timer.ToString("F2");
        }

        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("MiniGame");
            }
        }


    }

    // Update is called once per frame
    IEnumerator SpawnObjects () {

        var spawnRotation = Quaternion.identity;
        while(!gameOver)
        {
            if (ObjectCount < 10)
            {
                Instantiate(cheeseWheel, new Vector3(Random.Range(-9f, 9f), 0.5f, Random.Range(-9f, 9f)), spawnRotation);
                ObjectCount++;
                yield return new WaitForSeconds(spawnWait);
            }
            else
                yield return new WaitForSeconds(spawnWait);
        }
                

	}

    void GameOver()
    {
        winText.text = "Game Over! Score: " + Player.score.ToString() + " Press \'R\' to Restart";
        gameOver = true;
    }

}
