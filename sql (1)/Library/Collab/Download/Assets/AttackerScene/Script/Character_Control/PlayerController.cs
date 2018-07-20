using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    public LayerMask movementMask;
    PlayerMotor motor;
    public Interactable focus;
    public bool lockConversation;
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))        // for movement
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                
                return;
            }
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit,100,movementMask))
            {
                // move the player to what we hit
                // stop focusing on object
                RemoveFocus();
                motor.moveToPoint(hit.point);

            }
        }

        if (Input.GetMouseButtonDown(1))                 // for interactable objects
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                
                return;
            }
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //check if the object is interactable
                Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();

                if(interactable != null) // We could interact with the object
                {
                    SetFocus(interactable);
                }
            }
        }

    }
    void SetFocus(Interactable newFocus)
    {
        if (focus != newFocus)
        {
            if (focus != null)
            {
                focus.OnDeFocused();
            }
        }
        focus = newFocus;
        focus.OnFocused(transform);
        motor.FollowTarget(focus);
    }
    public void RemoveFocus()
    {
        if(focus!= null)
            focus.OnDeFocused();
        focus = null;
        if (DialogueManageSystem.manager.isTalking)
        {
            DialogueManageSystem.manager.EndConversationOnCancel();
        }
        motor.StopFollowing();
    }
}