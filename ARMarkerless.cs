using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

// 메인 카메라 위치에서 카메라의 앞방향으로 Ray를 만들고
// 부딪힌 것이 있다면 그곳에 인디케이터를 배치하고 싶다.
// Ray로 바라볼 때 Indicator 레이어를 제외하고 싶다.
// 화면을 터치 또는 클릭 했을 때 인디케이터라면 그 위치에 치킨을 배치하고 싶다.
public class ARMarkerless : MonoBehaviour
{
    public static ARMarkerless instance;

    public GameObject[] pokeBall;
    public GameObject[] pokeMon;
    public GameObject[] prefabs;
    ARRaycastManager aRRaycastManager;
    GameObject aRRaycastManagerObj;
    public int count;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        aRRaycastManagerObj = GameObject.Find("AR Session Origin");
        aRRaycastManager = aRRaycastManagerObj.GetComponent<ARRaycastManager>();   
    }
    void Update()
    {
        UpdateMakeChickenForAndroid();
       
    }
   
    
    void UpdateMakeChickenForAndroid()
    {
        // 화면을 터치 했다면 (1회 이상의 터치가 일어났다면)
        if (Input.touchCount > 0)
        {
            // 가장 먼저 눌린 터치 Input.GetTouch(0)
            Touch touch = Input.GetTouch(0);
            // 터치가 되는 순간이라면
            if (touch.phase == TouchPhase.Began)
            {
                // 터치한 위치를 기준으로 Ray를 만들고
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hitInfo;
                // 부딪힌 것이 포켓볼라면
                if (Physics.Raycast(ray, out hitInfo))
                {
                    // 그 위치에 치킨을 생성해서 배치하고 싶다
                    if (hitInfo.transform.gameObject.name == "PikBall")
                    {
                        pokeBall[0].SetActive(false);
                        pokeMon[0].SetActive(true);
                        count++;
                    }
                    else if (hitInfo.transform.gameObject.name == "EveBall")
                    {
                        pokeBall[1].SetActive(false);
                        pokeMon[1].SetActive(true);
                        count++;


                    }
                    else if (hitInfo.transform.gameObject.name == "NaBall")
                    {
                        pokeBall[2].SetActive(false);
                        pokeMon[2].SetActive(true);
                        count++;
                    }
                    else if (hitInfo.transform.gameObject.name == "JamBall")
                    {
                        pokeBall[3].SetActive(false);
                        pokeMon[3].SetActive(true);
                        count++;
                    }
                }
            }
           
        }

        if (Input.GetButtonDown("Fire1"))
        {
            // 가장 먼저 눌린 터치 Input.GetTouch(0)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            // 터치가 되는 순간이라면

            if (Physics.Raycast(ray, out hitInfo))
            {
                print(hitInfo);
                // 그 위치에 치킨을 생성해서 배치하고 싶다
                if (hitInfo.transform.gameObject.CompareTag("PikPokeBall"))
                {
                    pokeBall[0].SetActive(false);
                    pokeMon[0].SetActive(true);

                }
                else if (hitInfo.transform.gameObject.CompareTag("EvePokeBall"))
                {
                    pokeBall[1].SetActive(false);
                    pokeMon[1].SetActive(true);
                  
                }
                else if (hitInfo.transform.gameObject.CompareTag("NaPokeBall"))
                {
                    pokeBall[2].SetActive(false);
                    pokeMon[2].SetActive(true);
                   
                }
                else if (hitInfo.transform.gameObject.CompareTag("JamPokeBall"))
                {
                    pokeBall[3].SetActive(false);
                    pokeMon[3].SetActive(true);
                   
                }

            }
        }

    }
}


