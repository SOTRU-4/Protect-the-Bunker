using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class GameManager : MonoBehaviour
{
    Camera cam;
    static public GameManager instance;

    public CardBase selectedCard;
    [SerializeField] private GameObject interactPanel;

    public bool isFightOn = false;
    float baseTimeRemaining = 60;
    [SerializeField] float timeRemaining;
    [SerializeField] TextMeshProUGUI timerText;

    public int day { get; private set; } = 1;

    public List<CardBase> playerBattleCards;
    [HideInInspector] public RaycastHit2D hit;
    private IInteractable lastInteacted;
    void Start()
    {
        instance = this;
        cam = Camera.main;
        timeRemaining = baseTimeRemaining;
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
            hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity);


            if (hit.collider != null && hit.collider.TryGetComponent(out IFightable fightObject))
            {
                if (hit.collider.CompareTag("Enemy") && selectedCard.TryGetComponent(out BattleCardBase soldier))
                {
                    fightObject.TakeDamage(soldier.damage);
                }
            }

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


            if(timeRemaining <= 0)
            {
                isFightOn = !isFightOn;

                if(isFightOn)
                {
                    timeRemaining = baseTimeRemaining / 2;
                }
                else
                {
                    timeRemaining = baseTimeRemaining;
                    day += 1;
                }
            }
        } 
    }

    private void InteractPanel()
    {
        if (!isFightOn)
        {
            if (selectedCard != null) { interactPanel.SetActive(true); }
            else { interactPanel.SetActive(false); }
        }
        
    } 


}
