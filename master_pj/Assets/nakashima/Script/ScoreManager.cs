using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    // �Ԃ�؂ɕς�����
    public static int spawned_tree_count;
    // ���ɐ��₵�����̐�
    public static int spawned_grassed_count;
    public static void Clear()
    {
        spawned_tree_count = 0;
        spawned_grassed_count = 0;
    }
}
