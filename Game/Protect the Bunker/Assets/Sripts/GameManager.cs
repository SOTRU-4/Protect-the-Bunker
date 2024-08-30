using UnityEngine;

public class GameManager : MonoBehaviour
{
    Camera cam;
    static public GameManager instance;

    void Start()
    {
        instance = this;
        cam = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity);

            
            if (hit.collider.TryGetComponent(out IInteractable hitCollider))
            {
                hitCollider.Interact();
            }
        }
    }
}
