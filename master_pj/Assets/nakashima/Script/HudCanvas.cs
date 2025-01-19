using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudCanvas : MonoBehaviour
{
    public TMPro.TextMeshProUGUI remaning_time_text;
    void Update()
    {
        if (MainGameManager.Instance)
        {
            remaning_time_text.text = MainGameManager.Instance.RemaningTime.ToString("0.0");
        }
    }
}
