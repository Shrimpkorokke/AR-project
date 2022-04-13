using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

// ���� ī�޶� ��ġ���� ī�޶��� �չ������� Ray�� �����
// �ε��� ���� �ִٸ� �װ��� �ε������͸� ��ġ�ϰ� �ʹ�.
// Ray�� �ٶ� �� Indicator ���̾ �����ϰ� �ʹ�.
// ȭ���� ��ġ �Ǵ� Ŭ�� ���� �� �ε������Ͷ�� �� ��ġ�� ġŲ�� ��ġ�ϰ� �ʹ�.
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
        // ȭ���� ��ġ �ߴٸ� (1ȸ �̻��� ��ġ�� �Ͼ�ٸ�)
        if (Input.touchCount > 0)
        {
            // ���� ���� ���� ��ġ Input.GetTouch(0)
            Touch touch = Input.GetTouch(0);
            // ��ġ�� �Ǵ� �����̶��
            if (touch.phase == TouchPhase.Began)
            {
                // ��ġ�� ��ġ�� �������� Ray�� �����
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hitInfo;
                // �ε��� ���� ���Ϻ����
                if (Physics.Raycast(ray, out hitInfo))
                {
                    // �� ��ġ�� ġŲ�� �����ؼ� ��ġ�ϰ� �ʹ�
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
            // ���� ���� ���� ��ġ Input.GetTouch(0)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            // ��ġ�� �Ǵ� �����̶��

            if (Physics.Raycast(ray, out hitInfo))
            {
                print(hitInfo);
                // �� ��ġ�� ġŲ�� �����ؼ� ��ġ�ϰ� �ʹ�
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


