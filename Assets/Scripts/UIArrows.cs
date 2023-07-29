using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIArrows : MonoBehaviour
{
    void Update()
    {
        int playerCount = GetComponent<UIDanger>().PlayerArray.Count;
        if(playerCount >= 1)
        {
            Vector3 playerPos = GetComponent<UIDanger>().PlayerArray[0].transform.position;
            transform.Find("Arrow1").gameObject.SetActive(true);
            transform.Find("Arrow1").GetComponent<RectTransform>().anchoredPosition = (Camera.main.WorldToScreenPoint(playerPos)) * (1080f / Screen.height);
            transform.Find("Arrow1").GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 100);
        }
        if (playerCount >= 2)
        {
            Vector3 playerPos = GetComponent<UIDanger>().PlayerArray[1].transform.position;
            Camera.main.WorldToScreenPoint(playerPos);
            transform.Find("Arrow2").gameObject.SetActive(true);
            transform.Find("Arrow2").GetComponent<RectTransform>().anchoredPosition = (Camera.main.WorldToScreenPoint(playerPos)) * (1080f / Screen.height);
            transform.Find("Arrow2").GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 100);
        }
        if (playerCount >= 3)
        {
            Vector3 playerPos = GetComponent<UIDanger>().PlayerArray[2].transform.position;
            Camera.main.WorldToScreenPoint(playerPos);
            transform.Find("Arrow3").gameObject.SetActive(true);
            transform.Find("Arrow3").GetComponent<RectTransform>().anchoredPosition = (Camera.main.WorldToScreenPoint(playerPos)) * (1080f / Screen.height);
            transform.Find("Arrow3").GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 100);
        }
        if (playerCount >= 4)
        {
            Vector3 playerPos = GetComponent<UIDanger>().PlayerArray[3].transform.position;
            Camera.main.WorldToScreenPoint(playerPos);
            transform.Find("Arrow4").gameObject.SetActive(true);
            transform.Find("Arrow4").GetComponent<RectTransform>().anchoredPosition = (Camera.main.WorldToScreenPoint(playerPos)) * (1080f / Screen.height);
            transform.Find("Arrow4").GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 100);
        }
    }
}
