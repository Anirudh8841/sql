
using UnityEngine;

public class ShowSphere : MonoBehaviour {

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 2);
    }
}
