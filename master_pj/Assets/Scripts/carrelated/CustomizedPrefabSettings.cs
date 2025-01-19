using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizedPrefabSettings : MonoBehaviour
{
    
    private Vector3 colliderSize = new Vector3(2.5f, 1.5f, 4f);
    private Vector3 colliderCenter = new Vector3(0, 1f, 0);

    // Start is called before the first frame update
    void Start()
    {
        // ゲームオブジェクトにタグを設定
        SetTagRecursively(gameObject, "Car");
        AddBoxCollider();
        AkSoundEngine.PostEvent("Play_Car_Sound", gameObject);
        /*

        // 自分自身に Collider がない場合、子オブジェクトを探索
        if (!TryGetComponent<Collider>(out _))
        {
            AddCollisionNotifierToChildren();
        }
        */
    }

    void OnDisable()
    {
        AkSoundEngine.PostEvent("Stop_Car_Sound", gameObject);
    }

    // 再帰的にタグを設定するメソッド
    private void SetTagRecursively(GameObject obj, string tag)
    {
        obj.tag = tag; // 現在のオブジェクトにタグを設定

        // 全ての子オブジェクトを取得し、再帰的にタグを設定
        foreach (Transform child in obj.transform)
        {
            SetTagRecursively(child.gameObject, tag);
        }
    }
    
    private void AddBoxCollider()
    {
        // BoxCollider が既にある場合は何もしない
        if (TryGetComponent<BoxCollider>(out BoxCollider existingCollider))
        {
            Debug.Log("既に BoxCollider が存在します: " + gameObject.name);
            return;
        }

        // BoxCollider を追加
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();

        // サイズと位置を設定
        boxCollider.size = colliderSize;
        boxCollider.center = colliderCenter;

        Debug.Log("BoxCollider を追加しました: " + gameObject.name);
    }
    
    /*
    void OnCollisionEnter(Collision collision)
    {
        // 衝突相手のタグが "Bullet" の場合のみログを出力
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log($"親オブジェクト: 衝突しました！相手: {collision.gameObject.name} (タグ: Bullet)");
        }
    }

    public void OnChildCollisionEnter(Collision collision)
    {
        // 衝突相手のタグが "Bullet" の場合のみログを出力
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log($"親オブジェクトが子オブジェクトから通知を受け取りました: {collision.gameObject.name} (タグ: Bullet)");
        }
    }

    private void AddCollisionNotifierToChildren()
    {
        // 子オブジェクトを探索して MeshCollider を持つものにコンポーネントを追加
        MeshCollider[] meshColliders = GetComponentsInChildren<MeshCollider>();

        foreach (MeshCollider meshCollider in meshColliders)
        {
            if (meshCollider.gameObject.GetComponent<CollisionNotifier>() == null)
            {
                meshCollider.gameObject.AddComponent<CollisionNotifier>();
                Debug.Log($"CollisionNotifier を追加しました: {meshCollider.gameObject.name}");
            }
        }
    }
    */
}