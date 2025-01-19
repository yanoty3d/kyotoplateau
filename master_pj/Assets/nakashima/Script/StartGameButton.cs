using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public string main_game_scene_name;
    public void OnClickedGameStartButton()
    {
        SceneManager.LoadScene(main_game_scene_name)
    }
}
