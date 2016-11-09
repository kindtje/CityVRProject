using UnityEngine;
using System.Collections;

public class MenuPropSpawning : MonoBehaviour {

	private float timer = 5f;
	public GameObject propPrefab;

	// Use this for initialization
	void Start () {
		Instantiate (propPrefab, new Vector3(0, 1, -29), Quaternion.identity);
	}

    void OnTriggerEnter(Collider other)
    {
        StopAllCoroutines();
    }

	void OnTriggerExit(Collider other){

		StartCoroutine (Spawner());
	}

	IEnumerator Spawner()
	{
		yield return new WaitForSeconds (timer);
		Instantiate (propPrefab, new Vector3(0, 1, -29), Quaternion.identity);

	}
}
