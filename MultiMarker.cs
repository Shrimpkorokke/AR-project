using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

// ARTrackedImageManager ���� �̹����� �����Ǿ����� ������ �ް� �ʹ�.
// ������ ��Ŀ�� ���� �˰� �ִ� ��Ͽ� �ִ� �༮�̶��
// �� ��Ŀ�� �ش��ϴ� ������Ʈ�� �� ��ġ�� ��ġ�ϰ� �ʹ�.
public class MultiMarker : MonoBehaviour
{
    public static MultiMarker instance;
    GameObject arSessionOrigion;
    ARTrackedImageManager aRTrackedImageManager;
    public List<GameObject> selectedPokeMon;

    public bool isTraking;

    void Awake()
    {
        arSessionOrigion = GameObject.Find("AR Session Origin");
        aRTrackedImageManager = arSessionOrigion.GetComponent<ARTrackedImageManager>();
        instance = this;
    }
    private void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OntrackedImagesChanged;
    }

    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OntrackedImagesChanged;
    }
    private void Start()
    {
        isTraking = false;
    }
    [System.Serializable]
    public class MarkerInfo
    {
        public string name;
        public GameObject obj;
    }
    public MarkerInfo[] infos;
   
    /*public string[] markerName;
    public GameObject[] markerObj;*/


    private void OntrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        var list = args.updated;
        for (int i = 0; i < list.Count; i++)
        {
            ARTrackedImage marker = list[i];
            
            for (int j = 0; j < infos.Length; j++)
            {
                if(marker.referenceImage.name == infos[j].name)
                {   
                    // ���õ� ���ϸ��� 2���� �̸��϶� ���� ���� ���̸� 
                    if(marker.trackingState == TrackingState.Tracking && isTraking)
                    {
                        if (!selectedPokeMon.Contains(infos[j].obj))
                        {
                            selectedPokeMon.Add(infos[j].obj);
                        }
                        
                        selectedPokeMon[j].SetActive(true);
                        selectedPokeMon[j].transform.position = marker.transform.position;
                        selectedPokeMon[j].transform.rotation = marker.transform.rotation;
       
                    }
                   
                    /*else if(marker.trackingState != TrackingState.Tracking)
                    {
                        infos[j].obj.SetActive(false);
                    }*/
                }
            }

        }

    }

    void Update()
    {
        
    }
}
