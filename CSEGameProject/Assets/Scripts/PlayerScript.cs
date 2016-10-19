using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText;
    public GameController game;
    public Text winText;
    public Text messageText;

    void Start()
    {
        GameController game = GetComponent<GameController>();
        winText.text = "";
        messageText.text = "";
        count = 0;
        countText.text = updateScore();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (game.Timer > 10)
        {
            winText.text = "You Win! Score: " + count.ToString();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            messageText.text = "Devyn Coyer, ID 1001417871";
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
            count += 1;
            countText.text = updateScore();
        }
    }

    private string updateScore()
    {
        string result = "Score: " + count.ToString();
        

        return result;
    }
}
