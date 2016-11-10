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

    public bool entering = true;


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
                    this.transform.position = new Vector3(166.4f, 0f, 400.2f);
                    //slowDown = 0.0505f;
                    break;

                case 1:
                    path = GameObject.FindGameObjectWithTag("TrackTwo");
                    this.transform.position = new Vector3(159.7f, 0f, 400.2f);
                    //slowDown = 0.0595f;
                    break;

                case 2:
                    path = GameObject.FindGameObjectWithTag("TrackThree");
                    this.transform.position = new Vector3(157.03f, 0f, 400.2f);
                    //slowDown = 0.0505f;
                    break;

                case 3:
                    path = GameObject.FindGameObjectWithTag("TrackFour");
                    this.transform.position = new Vector3(165.3f, 0.462f, -87.5f);
                    //slowDown = 0.0595f;
                    break;

                case 4:
                    path = GameObject.FindGameObjectWithTag("TrackFive");
                    this.transform.position = new Vector3(162.49f, 0.462f, -87.5f);
                    //slowDown = 0.0505f;
                    break;

                case 5:
                    path = GameObject.FindGameObjectWithTag("TrackSix");
                    this.transform.position = new Vector3(157.87f, 0.462f, -87.5f);
                    //slowDown = 0.0595f;
                    break;
            }

            if (path == null)
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

            if (targetNode == null && (!entering || type == 0))
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
            if (type == 1)
            {
                if (entering)
                    speed -= slowDown;
                else
                    speed += slowDown;
            }
            else
            {
                Quaternion targetRotation = Quaternion.LookRotation(dir);
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 3);
            }
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
        if (type == 1)
        {
            path.tag = trackInUse;
        }
        Destroy(this.gameObject);
    }
}
