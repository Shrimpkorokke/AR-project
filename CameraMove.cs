using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public static CameraMove instance;
    public float shakeTime;
    public float shakeIntensity;
    private void Awake()
    {
        instance = this;
    }

    public void OnShakeCamera(float shakeTime = 0.02f, float shakeIntensity = 0.05f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }
    // 카메라를 shakeTime동안 shakeIntensity의 세기로 흔드는 코루틴 함수
    public IEnumerator ShakeByPosition()
    {
        Vector3 startPosition = transform.position;

        while (shakeTime > 0.0f)
        {

            //특정 축만 변경하길 원하면 아래 코드 이용 (이동하지 않을 축은 0 값만 사용)
            //float x = Random.Range(-1f, 1f);
            //float y = Random.Range(-1f, 1f);
            //float z = Random.Range(-1f, 1f);
            //transform.position = startPosition + new Vector3(x, y, z) * shakeIntensity;

            // 초기 위치로부터  구 범위(Size 1) * shakeIntensity의 범위 안에서 카메라 위치 이동
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;

            // 시간 감소
            shakeTime -= Time.deltaTime;
            yield return null;
        }
        transform.position = startPosition;
    }
}
