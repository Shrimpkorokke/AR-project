using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    GameObject enemy;
    GameObject player;
    Pikachu pikInfo;
    Eve eveInfo;

    AudioSource theAudio;
    public AudioClip[] clip;
    
    public int damage;
    void Start()
    {
        theAudio = GetComponent<AudioSource>();
        player = MultiMarker.instance.selectedPokeMon[0].GetComponentInChildren<BoxCollider>().transform.gameObject;
        enemy = MultiMarker.instance.selectedPokeMon[1].GetComponentInChildren<BoxCollider>().transform.gameObject;
        if (enemy.name == "Img Target Pik")
        {
            pikInfo = enemy.GetComponentInParent<Pikachu>();
        }
        else if (enemy.name == "Img Target Eve")
        {
            eveInfo = enemy.GetComponentInParent<Eve>();
        }
        /*else if (enemy.name == "Na")
        {

        }
        else if (enemy.name == "Jam")
        {

        }
*/
        damage = UnityEngine.Random.Range(8, 13);
        print(player.gameObject.name);
        print(enemy.gameObject.name);
        
        print(eveInfo.name);
    }

    public void OnButtonTackle()
    {
        StartCoroutine("IETackle");
    }

    public void OnButtonQuickAttack()
    {
        StartCoroutine("IEQuickAttack");
    }
    public void OnButtonShork()
    {
        StartCoroutine("IEShork");
    }
    public void Tackle()
    {
       
        float tackleDmg = damage * 1.2f;
        if (eveInfo != null)
        {
            eveInfo.GetDamage(tackleDmg);
        }
        else if (pikInfo != null)
        {
            pikInfo.GetDamage(tackleDmg);
        }
    }
    Vector3 playerPos;
    IEnumerator IETackle()
    {
        playerPos = player.transform.position;
        AudioManager.instance.PlayAudio();
        yield return new WaitForSeconds(0.2f);
        for (float t = 0; t < Time.deltaTime * 20f; t += Time.deltaTime)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, enemy.transform.position, Time.deltaTime * 20f);
            yield return 0;
        }
        Tackle();
        CameraMove.instance.OnShakeCamera(0.05f, 0.1f);
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            
            player.transform.position = Vector3.Lerp(player.transform.position, playerPos, Time.deltaTime * 20f);
            yield return 0;
        }
        

    }
    public void Shork()
    {

        float tackleDmg = damage * 1.5f;
        if (eveInfo != null)
        {
            eveInfo.GetDamage(tackleDmg);
        }
        else if (pikInfo != null)
        {
            pikInfo.GetDamage(tackleDmg);
        }
    }
    IEnumerator IEShork()
    {
          
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            
            yield return 0;
        }
        Shork();
    }





    public void QuickAttack()
    {
        float quickDmg = damage * 1.3f;
        if (eveInfo != null)
        {
            eveInfo.GetDamage(quickDmg);
        }
        else if (pikInfo != null)
        {
            pikInfo.GetDamage(quickDmg);
        }
    }

    float xPos=0;
    float zPos=0;
    
    IEnumerator IEQuickAttack()
    {
        playerPos = player.transform.position;
        Vector3 enemyPos = enemy.transform.position;
        xPos = playerPos.x;
        zPos = playerPos.z;

        for (float t = 0; t < Time.deltaTime * 10f; t += Time.deltaTime)
        {
            print("a");
            xPos += 0.2f * (enemyPos.x - playerPos.x);
            Vector3 firstPoint = new Vector3(xPos, 0, zPos);
            player.transform.position = Vector3.MoveTowards(player.transform.position, firstPoint, Time.deltaTime * 50f);
            yield return 0;
        }
        yield return new WaitForSeconds(0.1f);
        for (float t = 0; t < Time.deltaTime * 10f; t += Time.deltaTime)
        {
            Vector3 firstPos = player.transform.position;
            Vector3 firstEnemyPos = enemy.transform.position;
            zPos += 0.4f * (firstEnemyPos.z - firstPos.z);
            Vector3 secondPoint = new Vector3(playerPos.x, 0, zPos);
            player.transform.position = Vector3.MoveTowards(player.transform.position, secondPoint, Time.deltaTime * 50f);
            yield return 0;
        }
        yield return new WaitForSeconds(0.1f);
        for (float t = 0; t < Time.deltaTime * 10f; t += Time.deltaTime)
        {
            Vector3 secondPos = player.transform.position;
            Vector3 secondEnemyPos = enemy.transform.position;
            xPos += 0.6f * (secondEnemyPos.x - secondPos.x);
            Vector3 thirdPoint = new Vector3(xPos, 0, playerPos.z);
            player.transform.position = Vector3.MoveTowards(player.transform.position, thirdPoint, Time.deltaTime * 50f);
            yield return 0;
        }
        AudioManager.instance.PlayAudio();
        yield return new WaitForSeconds(0.1f);
        for (float t = 0; t < Time.deltaTime * 10f; t += Time.deltaTime)
        {
            player.transform.position = Vector3.Lerp(player.transform.position, playerPos, Time.deltaTime * 50f);
            yield return 0;
        }
        yield return new WaitForSeconds(0.1f);
        for (float t = 0; t < Time.deltaTime * 10f; t += Time.deltaTime)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, enemy.transform.position, Time.deltaTime * 60f);
            yield return 0;

        }
        QuickAttack();
        CameraMove.instance.OnShakeCamera(0.05f, 0.1f);
        for (float t = 0; t < 1; t += Time.deltaTime)
        {

            player.transform.position = Vector3.Lerp(player.transform.position, playerPos, Time.deltaTime * 20f);
            yield return 0;
        }

    }


}
