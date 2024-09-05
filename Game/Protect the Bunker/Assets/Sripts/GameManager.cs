using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    Camera cam;
    static public GameManager instance;

    public CardBase selectedCard;
    [SerializeField] private GameObject interactPanel;


    float timeRemaining = 60;
    [SerializeField] TextMeshProUGUI timerText;

    private IInteractable lastInteacted;
    void Start()
    {
        instance = this;
        cam = Camera.main;
    }

    void Update()
    {
        MouseClickHandle();
        Timer();
        InteractPanel();
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

    private void Timer()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining < 10) { timerText.color = Color.red; }
            else { timerText.color = Color.black; }

            int secunds = Mathf.FloorToInt(timeRemaining);
            int millisecunds = Mathf.FloorToInt((timeRemaining - secunds) * 100);
            
            timerText.text = string.Format("{0:00}:{1:00}", secunds, millisecunds);
        } 
    }

    private void InteractPanel()
    {
        if(selectedCard != null) { interactPanel.SetActive(true); }
        else { interactPanel.SetActive(false); }
    } 
}
