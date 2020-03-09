using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeChangeEffect : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    public void ShowEffect(string value = "", float startY = 0 , float endY = 0, float time = 1)
    {
        if (text == null) text = GetComponent<TextMeshProUGUI>();
        if (text == null) text = GetComponentInChildren<TextMeshProUGUI>();
        if (text != null) text.text = value;

        LeanTween.cancel(gameObject);
        this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, startY, this.gameObject.transform.localPosition.z);
        LeanTween.moveLocalY(gameObject, endY, time).setOnComplete(()=> { this.gameObject.SetActive(false); });
    }
}
