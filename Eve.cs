using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eve : MonoBehaviour
{
    public static Eve instance;

    public GameObject playerUI;
    public GameObject enemyUI;

    public bool amIPlayer;
    public float maxHP;
    public float hp;
    int damage;
    public Slider enemyHPBar;
    public Slider playerHPBar;
    public Text playerHpTxt;



    public float HP
    {
        get { return hp; }
        set
        {
            hp = value;
            enemyHPBar.value = hp;
            playerHPBar.value = hp;
            
        }
    }

    public float MaxHP
    {
        get { return maxHP; }
        set
        {
            hp = value;
            enemyHPBar.value = maxHP;
            playerHPBar.value = maxHP;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (MultiMarker.instance.selectedPokeMon[0].name == "Eve")
        {
            amIPlayer = true;
        }

        maxHP = UnityEngine.Random.Range(100, 170);
        enemyHPBar.maxValue = maxHP;
        playerHPBar.maxValue = maxHP;
        HP = maxHP;
        playerHpTxt.text = string.Format("{0} / {1}", HP, maxHP);


    }

    // Update is called once per frame
    void Update()
    {
        if (amIPlayer && GameManager.instance.gameStart && !playerUI.activeInHierarchy)
        {
            playerUI.SetActive(true);
            enemyUI.SetActive(false);
        }
        else if (!amIPlayer && GameManager.instance.gameStart && !enemyUI.activeInHierarchy)
        {
            enemyUI.SetActive(true);
            playerUI.SetActive(false);
        }
        playerHpTxt.text = string.Format("{0} / {1}", HP, maxHP);

    }

    IEnumerator IEDamage(float damage)
    {
        for (float t = 0; t < 1.5; t += Time.deltaTime)
        {
            enemyHPBar.value -= damage * ( Time.deltaTime / 1.5f );
            yield return 0;
        }
    }

    public void GetDamage(float damage)
    {
        hp -= damage;
        StartCoroutine(IEDamage(damage));
        print(HP);
    }
}
