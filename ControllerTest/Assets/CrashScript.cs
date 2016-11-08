using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrashScript : MonoBehaviour {

    public string nameObject;
    public Text jumpedText;
    public Image background;

	void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            Debug.Log("you dead");
            col.transform.position = new Vector3(49, 1.25f, 52);
            jumpedText = col.GetComponentInChildren<Text>();
            background = col.GetComponentInChildren<Image>();
            jumpedText.enabled = true;
            background.enabled = true;
            jumpedText.text = "Don't stand in front of " + nameObject + "\n or you're gonna have a \nbad time";
            StartCoroutine(disableText());
        }
    }

    IEnumerator disableText()
    {
        yield return new WaitForSeconds(5f);
        jumpedText.enabled = false;
        background.enabled = false;
    }
}
