using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class SpawnScript : MonoBehaviour {

    public Transform player { get; set; }
    private Vector3 position;
    public float Timer;

    // Use this for initialization
    void Start()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        float x = Random.Range(-9f, 9f);
        float z = Random.Range(-9f, 9f);
        Timer += Time.deltaTime;
            if(Timer <= 60)
                spawnCube(x, z);

    }

    private void spawnCube(float x, float z)
    {
            Object.Instantiate(player, new Vector3(x, 0.5f, z), Quaternion.identity);
        
        
    }
}
