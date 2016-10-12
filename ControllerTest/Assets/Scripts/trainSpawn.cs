using UnityEngine;
using System.Collections;

public class trainSpawn : MonoBehaviour {

    public GameObject train;
    public int minSpawnTime;
    public int maxSpawnTime;
    public int amountOfTracks = 2;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnTrain());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnTrain()
    {
        int wait = Random.Range(minSpawnTime, maxSpawnTime);
        yield return new WaitForSeconds((float)wait);
        GameObject trainType = Instantiate(train, new Vector3(0, 6.5f, 0), Quaternion.identity) as GameObject;
        trainType.GetComponent<PathFinding>().track = Random.Range(0, amountOfTracks);

        StartCoroutine(SpawnTrain());
    }
}
