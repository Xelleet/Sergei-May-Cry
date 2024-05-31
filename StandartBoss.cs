using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandartBoss : Boss
{
    [SerializeField] private Image hpImage;
    [SerializeField] private GameObject godLikeAbility;

    private delegate void Attack();
    private Attack attack;

    private PlayerHealthManager player;

    private Entity entity;

    private float startBossHp;

    [SerializeField] private List<Settings> settings;
    //[SerializeField] private List<bool> passedStages = new List<bool>{true, true};
    //private int index = 0;

    private void Awake()
    {
        hpImage.gameObject.SetActive(true);

        player = FindObjectOfType<PlayerHealthManager>();

        entity = GetComponent<Entity>();
        startBossHp = entity.hp;

        attack = SimpleAttack;
    }

    private void Update()
    {
        SetHpProgress();
    }

    private void FixedUpdate()
    {
        switch (entity.hp)
        {
            case var value when value <= settings[0].ChangeStadiaHP && value >= settings[1].ChangeStadiaHP:
                attack = SimpleAttack;
                break;
            case var value when entity.hp <= settings[1].ChangeStadiaHP && value >= settings[2].ChangeStadiaHP:
                Debug.Log(123);
                attack = AdvancedAttack;
                godLikeAbility.SetActive(true);
                player.GetComponent<PlayerAttack>().currentWeapon.GetComponent<Weapon>().damage = settings[1].PlayerDamage;
                break;
            case var value when value <= settings[2].ChangeStadiaHP:
                attack = CrazyAttack;
                damage = settings[2].BossDamage;
                break;
        }

        AttackPlayer();
    }

    private void AttackPlayer()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= attackRadius)
        {
            currentCoolDown += Time.deltaTime;

            if (currentCoolDown >= standartCoolDown) attack();
        }
    }

    private void SimpleAttack()
    {
        player.ChangeHealth(damage);
        GetComponent<EnemyAnimation>().SetTriggerAnim("Attack");
        currentCoolDown = 0;
    }

    private void AdvancedAttack()
    {
        if (Random.Range(0, 5) == 4)
        {
            damage += 10;
            SimpleAttack();
            damage -= 10;
        }
        else
        {
            SimpleAttack();
        }
    }

    private void CrazyAttack()
    {
        //Если что можно будет сюда какие-нибудь фишечки присобачить
        SimpleAttack();
    }

    private void SetHpProgress()
    {
        hpImage.gameObject.SetActive(Vector3.Distance(transform.position, player.transform.position) <= 20);

        hpImage.fillAmount = entity.hp / startBossHp;
    }
}

[System.Serializable]
public class Settings
{
    public float PlayerDamage;
    public float BossDamage;
    public float StandartcoolDown;
    public float ChangeStadiaHP;
}