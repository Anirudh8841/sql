using System.Collections;
using UnityEngine;

public class walkman : MonoBehaviour {

    public float speed = 5.0f;
    public int checkpoint = 0;
    public int routeNo = 0;
    public Transform[] route;
    public Transform target;

    void Start()
    {
        if(routeNo == 0)
        {
            route = WayPointManager.way1;
        }
        else if (routeNo == 1)
        {
            route = WayPointManager.way2;
        }
        else if (routeNo == 2)
        {
            route = WayPointManager.way3;
        }
        else
        {
            route = WayPointManager.way4;
        }

        target = route[0];
        checkpoint = 0;
    }

    void Update()
    {
        
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * Time.deltaTime * speed);
        if (Vector3.Distance(target.position, transform.position) < 0.3f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(checkpoint>= route.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        checkpoint++;
        target = route[checkpoint];
    }
    
}
