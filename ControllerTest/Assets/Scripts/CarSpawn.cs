using UnityEngine;
using System.Collections;

public class CarSpawn : MonoBehaviour {

    public GameObject car;
    public int minSpawnTime;
    public int maxSpawnTime;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnCar());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnCar()
    {
        int wait = Random.Range(minSpawnTime, maxSpawnTime);
        yield return new WaitForSeconds((float)wait);

        Instantiate(car, new Vector3(275, 0.95f, -215), Quaternion.identity);
        StartCoroutine(SpawnCar());
    }
}
