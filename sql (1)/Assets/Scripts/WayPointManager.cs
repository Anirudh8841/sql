
using UnityEngine;

public class WayPointManager : MonoBehaviour {
    public static Transform[] waypointGroup;
    public static Transform[] way1;
    public static Transform[] way2;
    public static Transform[] way3;
    public static Transform[] way4;

    void Awake()
    {
        waypointGroup = new Transform[transform.childCount];
        for(int i =0; i < transform.childCount; i++)
        {
            waypointGroup[i] = transform.GetChild(i);
        }
        way1 = new Transform[waypointGroup[0].childCount];
        way2 = new Transform[waypointGroup[1].childCount];
        way3 = new Transform[waypointGroup[2].childCount];
        way4 = new Transform[waypointGroup[3].childCount];
        for (int i = 0;i< waypointGroup[0].childCount; i++)
        {
            way1[i] = waypointGroup[0].GetChild(i);
        }
        for (int i = 0; i < waypointGroup[1].childCount; i++)
        {
            way2[i] = waypointGroup[1].GetChild(i);
        }
        for (int i = 0; i < waypointGroup[2].childCount; i++)
        {
            way3[i] = waypointGroup[2].GetChild(i);
        }
        for (int i = 0; i < waypointGroup[3].childCount; i++)
        {
            way4[i] = waypointGroup[3].GetChild(i);
        }
    }
}
