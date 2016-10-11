using UnityEngine;
using System.Collections;

public class fogScript : MonoBehaviour {

    public bool fog =  true;
    public bool linear = true;
    public bool exponential = false;
    public bool exponentialSquared = false;
    public float start = 0.1f;
    public float end = 3;
    public float fogDens = 0.1f;


	// Use this for initialization
	void Start () { 
        
        
        
	}
	
	// Update is called once per frame
	void Update () {
        RenderSettings.fog = fog;
        if (linear)
            RenderSettings.fogMode = FogMode.Linear;
        else if (exponential)
            RenderSettings.fogMode = FogMode.Exponential;
        else if (exponentialSquared)
            RenderSettings.fogMode = FogMode.ExponentialSquared;


        RenderSettings.fogStartDistance = start;
        RenderSettings.fogEndDistance = end;
        RenderSettings.fogColor = new Color(0, 0, 255);
        RenderSettings.fogDensity = fogDens;
    }

    
}
