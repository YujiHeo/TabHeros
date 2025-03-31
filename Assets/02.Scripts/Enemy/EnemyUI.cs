using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [Header("할당 오브젝트(HPBar)")]
    public RectTransform imgParentHP;
    public Image imgCurrentHP;
    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtHp;
    public TextMeshProUGUI txtDamage;

    [Header("할당 오브젝트(Timer)")]
    public GameObject goTimer;
    public Image imgCurrentTimer;
    public TextMeshProUGUI txtTimer;

    public void Init(EnemyDataBase _data)
    {
        txtName.text = _data.enemyName;
        txtHp.text = _data.hp.ToString();
        imgCurrentHP.fillAmount = 1f;

        if (_data.isBoss) // 보스라면 타이머 작동
        {
            goTimer.SetActive(true);
        }
        else
        {
            goTimer.SetActive(false);
        }
    }

    public void SetHPBar(int _maxHP, int _currentHP, int _damage)
    {
        float currentHP = imgCurrentHP.fillAmount;
        float changeHP = (float)_currentHP / _maxHP;

        // 변화할 값이 현재 값보다 작으면 - 되는 것
        if (changeHP < currentHP)
        {
            imgCurrentHP.fillAmount = changeHP;
            Decrease(changeHP, currentHP);
            DamageText(_damage);
        }
        else
        {
            imgCurrentHP.fillAmount = changeHP;
        }
        txtHp.text = _currentHP.ToString();

    }

    public void SetTimer(float _timer, float _currentTimer)
    {
        imgCurrentTimer.fillAmount = _currentTimer / _timer;
        txtTimer.text = $"{_currentTimer.ToString("N0")}초";
    }

    public void Decrease(float _changeHP, float _currentHP)
    {
        // Debug.Log(_currentHP);
        // Debug.Log(_changeHP);
        _changeHP -= 0.5f;
        _currentHP -= 0.5f;

        var pos = (_changeHP + _currentHP) / 2;
        var width = _currentHP - _changeHP;
        Image cutBar = Instantiate(imgCurrentHP.gameObject, imgParentHP.transform).GetComponent<Image>();

        var backgroundWidth = imgParentHP.sizeDelta.x;

        pos *= backgroundWidth;
        width = (width * backgroundWidth) - backgroundWidth;
        cutBar.rectTransform.anchoredPosition = new Vector2(pos, 0);
        cutBar.rectTransform.sizeDelta = new Vector2(width, 0);

        cutBar.color = Color.red;
        cutBar.fillAmount = 1.0f;
        StartCoroutine(Fadeout(cutBar));

    }

    IEnumerator Fadeout(MaskableGraphic _image)
    {
        if (_image == null)
            yield break;

        float fadeDuration = 1.0f; // 페이드아웃 지속 시간
        float moveUpHeight = 50f; // 위로 이동할 거리

        float elapsedTime = 0f;
        Color color = _image.color;
        RectTransform rectTransform = _image.rectTransform;
        Vector2 startPosition = rectTransform.anchoredPosition;
        Vector2 targetPosition = startPosition + new Vector2(0, moveUpHeight);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / fadeDuration;

            // 페이드아웃 (알파 값 감소)
            color.a = Mathf.Lerp(1f, 0f, progress);
            _image.color = color;

            // 살짝 올라갔다가 다시 내려오는 애니메이션
            float moveY = Mathf.Lerp(startPosition.y, targetPosition.y, Mathf.Sin(progress * Mathf.PI));
            rectTransform.anchoredPosition = new Vector2(startPosition.x, moveY);

            yield return null;
        }

        // 최종적으로 알파값 0, 원래 위치로 복귀
        color.a = 0f;
        _image.color = color;
        rectTransform.anchoredPosition = startPosition;

        Destroy(_image.gameObject);
    }

    public void DamageText(int _damage)
    {
        TextMeshProUGUI _txtDamage = Instantiate(txtDamage.gameObject, imgParentHP.transform).GetComponent<TextMeshProUGUI>();
        _txtDamage.gameObject.SetActive(true);
        _txtDamage.text = _damage.ToString();

        StartCoroutine(Fadeout(_txtDamage));
    }
}
