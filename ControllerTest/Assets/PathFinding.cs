using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour {

    public GameObject path;
    
    Transform targetNode;
    public int pathNodeIndex = 0;

    public int type = 0;
    public int track = 0;
    public float speed = 5;
    float slowDown = 0;

    string trackInUse;

    bool entering = true;


	// Use this for initialization
	void Start () {
        if (type == 0)
        {
            path = GameObject.Find("PathCar");
        }
        else
    {
            switch (track)
            {
                case 0:
                    path = GameObject.FindGameObjectWithTag("TrackOne");
                    this.transform.position = new Vector3(15.8f, -3.3f, 447.4f);
                    slowDown = 0.0505f;
                    break;

                case 1:
                    path = GameObject.FindGameObjectWithTag("TrackTwo");
                    this.transform.position = new Vector3(16.7f, -3.3f, -275f);
                    slowDown = 0.0595f;
                    break;
            }
            if(path == null)
            {
                Destroy(this.gameObject);
            }

            trackInUse = path.tag;
            path.tag = "Untagged";
        }
        
	}

    void GetNextPathnode(bool entering)
    {
        if (entering)
        {
            if (pathNodeIndex < path.transform.childCount)
            {
                targetNode = path.transform.GetChild(pathNodeIndex);
                pathNodeIndex++;
            }
        }
        else
        {
            if (pathNodeIndex > 0)
            {
                pathNodeIndex--;
                targetNode = path.transform.GetChild(pathNodeIndex);
                
            }
        }
    }

	// Update is called once per frame
	void Update () {
	    if( targetNode == null )
        {
            GetNextPathnode(entering);
            Debug.Log(pathNodeIndex);

            if (targetNode == null && !entering)
            {
                ReachedGoal();
            }
            else if ( targetNode == null )
            {
                StartCoroutine(WaitForReturn());
            }
            
        }

        Vector3 dir = targetNode.position - this.transform.position;

        float distThisFrame = speed * Time.deltaTime;

        if( dir.magnitude <= distThisFrame )
        {
            //we reached the node
            targetNode = null;
        }
        else
        {
            //move to the node
            transform.Translate( dir.normalized * distThisFrame, Space.World );
            if(entering)
                speed -= slowDown;
            else
                speed += slowDown;
        }
	}

    IEnumerator WaitForReturn()
    {
        int wait = Random.Range(8, 15);
        yield return new WaitForSeconds((float)wait);
        entering = false;
        
    }

    void ReachedGoal()
    {
        path.tag = trackInUse;
        Destroy(this.gameObject);
    }
}
