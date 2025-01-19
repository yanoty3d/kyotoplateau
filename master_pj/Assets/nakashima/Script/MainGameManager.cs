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
    int max_traffic;
    void Start()
    {
        RemaningTime = max_remaning_time;
        StartGameTimer();
        max_traffic = traffic_manager.maxVehicleCount;
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

        print(GetCurrentTrafficCount());
        AkSoundEngine.SetRTPCValue("car_amount", GetCurrentTrafficCount(), AkSoundEngine.AK_INVALID_GAME_OBJECT);
    }

    public void DecreeseCarMax()
    {
        traffic_manager.maxVehicleCount--;
    }

    float  GetCurrentTrafficCount()
    {
        return (float)traffic_manager.maxVehicleCount/ max_traffic * 100.0f;
    }
}
