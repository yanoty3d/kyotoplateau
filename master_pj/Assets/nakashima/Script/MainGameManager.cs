using AWSIM.TrafficSimulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameManager : MonoSingleton<MainGameManager>
{
    public string result_scene_name;
    public float max_remaning_time;
    public TrafficManager traffic_manager;

    public float RemaningTime { get; private set; }
    bool game_playing;
    void Start()
    {
        RemaningTime = max_remaning_time;
        StartGameTimer();
    }

    public void StartGameTimer()
    {
        game_playing = true;
    }

    void Update()
    {
        if (!game_playing) { return; }

        RemaningTime -= Time.deltaTime;
        RemaningTime = Mathf.Max(RemaningTime, 0.0f);
        if(RemaningTime <= 0.0f)
        {
            print("game end");
            //SceneManager.LoadScene(result_scene_name);
            game_playing = false;
        }
    }

    int GetCurrentTrafficCount()
    {
        return traffic_manager.maxVehicleCount;
    }
}
