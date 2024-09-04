using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    Camera cam;
    static public GameManager instance;

    private IInteractable lastInteacted;
    void Start()
    {
        instance = this;
        cam = Camera.main;
    }

    void Update()
    {
        MouseClickHandle();
    }

    private void MouseClickHandle()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity);

            if (hit.collider != null && hit.collider.TryGetComponent(out IInteractable hitCollider))
            {
                hitCollider.Interact();

                if(lastInteacted != null && lastInteacted != hitCollider)
                {
                    lastInteacted.StopInteract();
                }

                lastInteacted = hitCollider;
            }

            else
            {
                if(lastInteacted != null)
                {
                    lastInteacted.StopInteract();
                    lastInteacted = null;
                }
            }
        }
    }
}
