using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour {

    public string nameOfObject;
    public float radius = 3f;
    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;
    bool isMeasuring = false;
    float distance;
    public Vector3 originalRotation;
    private void Start()
    {
        // store the default state of the interactable
        originalRotation = new Vector3(transform.rotation.x,transform.rotation.y,transform.rotation.z);
    }
    IEnumerator distanceMeasure()
    {
        while (true)
        {
            if(player !=null)
                distance = Vector3.Distance(player.position, transform.position);
            yield return new WaitForSeconds(0.6f);
        }
    }
    void Update()
    {
        if (isFocus&&!hasInteracted)
        {
            if (!isMeasuring)
            {
                StartCoroutine(distanceMeasure());

                isMeasuring = true;
            }
            if (distance < radius)
            {

                // can make the interactable face towards the player
                // display the button
                hasInteracted = true;
                GuiManager.manager.showInteractButton();
                FacePlayer();
            }
        }
    }
    public void FacePlayer()
    {
        Vector3 dir = player.position - transform.position;
        Quaternion lookTowards = Quaternion.LookRotation(new Vector3(dir.x, 0f, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookTowards, Time.deltaTime * 5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OnDeFocused()
    {
        isFocus = false;
        StopCoroutine(distanceMeasure());
        // hide the button
        GuiManager.manager.hideInteractButton();
        transform.rotation = Quaternion.Euler(originalRotation.x,originalRotation.y,originalRotation.z);
        player = null;
        hasInteracted = false;
    }
}
