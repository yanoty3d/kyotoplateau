using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceanManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI tree_count_text;
    public TMPro.TextMeshProUGUI grass_count_text;
    public string title_scene_name;

    void Start()
    {
        tree_count_text.text = ScoreManager.spawned_tree_count.ToString();
        grass_count_text.text = ScoreManager.spawned_grassed_count.ToString();
    }

    void Update()
    {
        
    }
    private void OnDestroy()
    {
        ScoreManager.Clear();
    }

    public void OnClickedToTitleButton()
    {
        SceneManager.LoadScene(title_scene_name);
    }
}
