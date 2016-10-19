using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject player;
    public GameObject cheeseWheel;
    public float spawnWait;
    public int ObjectCount = 0;
    public float Timer;

    // Use this for initialization
    void Start () {
        StartCoroutine (SpawnObjects());
        Timer = 0;
	}

    void Update()
    {
        Timer += Time.deltaTime;
    }

    // Update is called once per frame
    IEnumerator SpawnObjects () {

        var spawnRotation = Quaternion.identity;
        while(Timer <= 60)
        {
            
            Instantiate(cheeseWheel, new Vector3(Random.Range(-9f, 9f), 0.5f, Random.Range(-9f, 9f)), spawnRotation);
            ObjectCount++;
            yield return new WaitForSeconds(spawnWait);
        }
                

	}


}
