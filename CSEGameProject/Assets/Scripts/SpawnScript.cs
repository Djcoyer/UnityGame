using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class SpawnScript : MonoBehaviour {

    public GameObject PickUp;
    private Vector3 position;
    private Quaternion quaternian = new Quaternion(0,0,0,0);
    private Stopwatch sw = new Stopwatch();
    // Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {


        sw = new Stopwatch();
        sw.Start();
        if(sw.Elapsed.Seconds % 2 == 0)
        {
            if (sw.Elapsed.Seconds <= 60)
            {
                float xRange = Random.Range(-9, 9);
                float zRange = Random.Range(-9, 9);
                spawnCube(xRange, zRange, sw);

            }
        }
        

    }

    private void spawnCube(float x, float z, Stopwatch sw)
    {
            Object.Instantiate(PickUp, new Vector3(x, 0.5f, z), quaternian);
        
        
    }
}
