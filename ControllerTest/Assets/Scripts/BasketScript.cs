using UnityEngine;
using System.Collections;

public class BasketScript : MonoBehaviour {

    public AudioSource playAudio;
    public AudioClip theClip;

	// Use this for initialization
	void Start () {
        playAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("collected");
        if(col.tag == "Collectible")
        {
            theClip = col.GetComponent<MyAudioClip>().thisAudio;
            playAudio.clip = theClip;
            playAudio.Play();
            Destroy(col.gameObject);
            GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
