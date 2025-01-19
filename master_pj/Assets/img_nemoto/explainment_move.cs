using UnityEngine;

public class MoveText3D : MonoBehaviour
{
    public float speed = 20.0f; // 移動速度
    public Vector3 direction = new Vector3(0, 0.1f, 0.173f); // z方向に0.173, y方向に0.1移動

    void Update()
    {
        // オブジェクトを指定した方向に移動
        transform.Translate(direction * speed * Time.deltaTime);
    }
}