using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public static FightManager instance;

    [SerializeField] List<MonsterCardBase> monsters = new List<MonsterCardBase>();
    [SerializeField] List<MonsterCardBase> monstersInFight = new List<MonsterCardBase>();

    [SerializeField] List<Transform> spawnPoint = new List<Transform>();
    
    private bool isMonstersSpawned = false;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        SpawnMonsters();

        /*if(GameManager.instance.hit.collider.TryGetComponent(out IFightable collider) && GameManager.instance.selectedCard.TryGetComponent(out BattleCardBase soldier))
        {
            if (GameManager.instance.hit.collider.gameObject.CompareTag("Enemy"))
            {
                collider.TakeDamage(soldier.damage);
            }
        }*/
    }

    private void SpawnMonsters()
    {
        if (GameManager.instance.isFightOn && !isMonstersSpawned)
        {
            int daysPassed = GameManager.instance.day;
            for (int i = 0; i < daysPassed; i++)
            {
                int randomMonster = Random.Range(0, monsters.Count);

                monstersInFight.Add(monsters[randomMonster]);

                Instantiate(monstersInFight[i], spawnPoint[i]);
            }
            isMonstersSpawned = true;
        }
        if (GameManager.instance.isFightOn == false)
        {
            isMonstersSpawned = false;
            monstersInFight.Clear();
        }
    }
}
 