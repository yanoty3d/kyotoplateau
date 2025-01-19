using UnityEngine;
using UnityEditor;
using System.IO;

public class MultiplePrefabModifier : MonoBehaviour
{
    [MenuItem("Tools/Add CustomizedPrefabSettings to Prefabs")]
    public static void AddAudioManagerToPrefabs()
    {
        // プレハブが保存されているフォルダパス
        string folderPath = "Assets/Samples/PLATEAU SDK-Toolkits for Unity/2.1.0-beta/URP Sample Assets/Vehicles/Prefabs"; // 必要に応じて変更

        // フォルダ内のすべてのプレハブを取得
        string[] prefabPaths = Directory.GetFiles(folderPath, "*.prefab", SearchOption.AllDirectories);

        foreach (string prefabPath in prefabPaths)
        {
            // プレハブをロード
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            if (prefab == null)
            {
                Debug.LogWarning($"Failed to load prefab at path: {prefabPath}");
                continue;
            }

            // コンポーネントがすでにアタッチされていない場合のみ追加
            if (prefab.GetComponent<CustomizedPrefabSettings>() == null)
            {
                // プレハブのインスタンスを編集可能にする
                GameObject prefabInstance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                prefabInstance.AddComponent<CustomizedPrefabSettings>();

                // プレハブを適用して保存
                PrefabUtility.SaveAsPrefabAsset(prefabInstance, prefabPath);
                DestroyImmediate(prefabInstance);

                Debug.Log($"Added CustomizedPrefabSettings to prefab: {prefabPath}");
            }
            else
            {
                Debug.Log($"CustomizedPrefabSettings already exists in prefab: {prefabPath}");
            }
        }

        Debug.Log("Completed adding CustomizedPrefabSettings to all prefabs.");
    }
}