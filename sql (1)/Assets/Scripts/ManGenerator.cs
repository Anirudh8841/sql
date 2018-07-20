
using UnityEngine;

public class ManGenerator : MonoBehaviour {
    public int buildingNo = 0;
    public float spawnTime = 3f;
    public float count = 0;
    public GameObject prefab;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        count = count + Time.deltaTime;
        if(count > spawnTime)
        {
            count = 0;
            GameObject obj =Instantiate(prefab, transform.position, transform.rotation);
            walkman man = obj.GetComponent<walkman>();
            man.routeNo = buildingNo;
        }
	}
}
