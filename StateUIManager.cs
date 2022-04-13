using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateUIManager : MonoBehaviour
{
    public GameObject[] mainStatePanel;
    public GameObject[] skillStatePanel;
    public GameObject[] bagStatePanel;

    void Start()
    {
        
    } 
    public void OnButtonFight()
    {
        if (this.name == "Pik")
        {
            mainStatePanel[0].SetActive(false);
            skillStatePanel[0].SetActive(true);
        }
        else if (this.name == "Eve")
        {
            mainStatePanel[1].SetActive(false);
            skillStatePanel[1].SetActive(true);
        }
        
    }
    public void OnButtonBag()
    {
        if (this.name == "Pik")
        {
            mainStatePanel[0].SetActive(false);
            bagStatePanel[0].SetActive(true);
        }
        else if(this.name == "Eve")
        {
            mainStatePanel[1].SetActive(false);
            bagStatePanel[1].SetActive(true);
        }
    }
    public void OnButtonBack()
    {

        if (this.name == "Pik")
        {
            if (skillStatePanel[0].activeInHierarchy)
            {
                skillStatePanel[0].SetActive(false);
                mainStatePanel[0].SetActive(true);
            }
            else if (bagStatePanel[0].activeInHierarchy)
            {
                bagStatePanel[0].SetActive(false);
                mainStatePanel[0].SetActive(true);
            }

        }
        else if (this.name == "Eve")
        {
            if (skillStatePanel[1].activeInHierarchy)
            {
                skillStatePanel[1].SetActive(false);
                mainStatePanel[1].SetActive(true);
            }
            else if (bagStatePanel[1].activeInHierarchy)
            {
                bagStatePanel[1].SetActive(false);
                mainStatePanel[1].SetActive(true);
            }

        }

    }

    public void OnButtonRun()
    {

    }

    public void OnButtonPokemon()
    {

    }
}
