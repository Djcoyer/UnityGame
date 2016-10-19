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
    public float score;

    void Start()
    {
        GameController game = GetComponent<GameController>();

       
        count = 0;
        countText.text = updateScore();
        rb = GetComponent<Rigidbody>();
        score = 0;

       

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
            game.ObjectCount -= 1;
            countText.text = updateScore();
        }
    }

    private string updateScore()
    {
        score += 25;
        string result = "Score: " + score.ToString();
        
        

        return result;
    }
}
