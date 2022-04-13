using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pikachu : MonoBehaviour
{
    public static Pikachu instance;

    public GameObject playerUI;
    public GameObject enemyUI;

    public bool amIPlayer;
    public float maxHP;
    public float hp;
   
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
        if(MultiMarker.instance.selectedPokeMon.Count >= 0)
        {
            if(MultiMarker.instance.selectedPokeMon[0].name == "Pik")
            {
                amIPlayer = true;
            }
           
        }

        
        maxHP = UnityEngine.Random.Range(100, 170);
        enemyHPBar.maxValue = maxHP;
        playerHPBar.maxValue = maxHP;
        HP = maxHP;
        playerHpTxt.text = string.Format("{0} / {1}",HP , maxHP);   
    }

    
    void Update()
    {
        if (amIPlayer && GameManager.instance.gameStart && !playerUI.activeInHierarchy  && ARMarkerless.instance.count >= 2)
        {
            playerUI.SetActive(true);
            enemyUI.SetActive(false);
        }
        else if(!amIPlayer && GameManager.instance.gameStart && !enemyUI.activeInHierarchy && ARMarkerless.instance.count >= 2)
        {
            enemyUI.SetActive(true);
            playerUI.SetActive(false);
        }
        playerHpTxt.text = string.Format("{0} / {1}", HP, maxHP);
        
    }

    public void GetDamage(float damage)
    {
        HP -= damage;
        print(HP);
    }
}
