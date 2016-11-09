using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuBehaviour : MonoBehaviour {

	public GameObject animateThis;

	void Start()
	{
		
	}

	void OnCollisionEnter(Collision other)
	{
		if (this.gameObject.tag == "start" && other.gameObject.tag == "MovableObject" ) {
			SceneManager.LoadScene (1);
			Destroy (other.gameObject);
		}

		if (this.gameObject.tag == "credits" && other.gameObject.tag == "MovableObject") {
			Destroy (other.gameObject);
			animateThis.gameObject.SetActive (true);

			StartCoroutine (CreditTimer());

		}

		if (this.gameObject.tag == "exit" && other.gameObject.tag == "MovableObject") {
			Destroy (other.gameObject);
			Application.Quit ();

		}

	}
	IEnumerator CreditTimer(){
		yield return new WaitForSeconds (5f);
		animateThis.gameObject.SetActive (false);
	}
}
