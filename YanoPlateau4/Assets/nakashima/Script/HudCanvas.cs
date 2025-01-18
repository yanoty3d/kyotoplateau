using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudCanvas : MonoBehaviour
{
    public TMPro.TextMeshProUGUI remaning_time_text;
    public float max_remaning_time;
    float remaning_time;
    void Start()
    {
        remaning_time = max_remaning_time;
    }

    void Update()
    {
        remaning_time -= Time.deltaTime;
        remaning_time = Mathf.Max(remaning_time, 0.0f);
        remaning_time_text.text = remaning_time.ToString("0.0");
    }
}
