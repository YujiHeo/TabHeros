using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickParticle : MonoBehaviour
{
    public GameObject effectPrefab;    // 생성할 파티클 프리팹
    public float yOffset = 0.5f;       // 클릭 위치보다 위로
    public float lifeTime = 2f;        // 자동 제거 시간

    void Update()
    {
        //  마우스 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            // 화면 중앙 기준 (혹은 마우스 위치 사용 가능)
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            pos.z = 0;
            pos.y += yOffset;

            // 이펙트 생성
            GameObject effect = Instantiate(effectPrefab, pos, Quaternion.identity);

            // 자동 제거
            Destroy(effect, lifeTime);
        }
    }
}
