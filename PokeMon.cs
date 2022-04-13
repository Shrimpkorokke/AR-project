using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PokeMon : MonoBehaviour
{
    private bool myTurn;

    public float maxHP;
    public float hp;
    public Slider sliderHP;

    public float HP
    {
        get { return hp; }
        set
        {
            hp = value;
            sliderHP.value = hp;
        }
    }

    public float MaxHP
    {
        get { return maxHP; }
        set
        {
            maxHP = value;
            sliderHP.maxValue = maxHP;
        }
    }

    private void Start()
    {
        MaxHP = maxHP;
        HP = maxHP;
    }
    void Update()
    {
        if(myTurn == true)
        {
            Attack();
        }
    }

    private void Attack()
    {
       
    }
}
