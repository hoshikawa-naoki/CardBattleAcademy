using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEncount : MonoBehaviour
{
    public float encountChance = 0.2f;

    private move_chara playerMovement; // move_chara�X�N���v�g���Q�Ƃ��邽�߂̕ϐ�

    void Start()
    {
        playerMovement = GetComponent<move_chara>(); // move_chara�X�N���v�g���擾
        
    }

    void Update()
    {
        if (playerMovement != null && playerMovement.IsMoving()) // move_chara�X�N���v�g����ړ���Ԃ��擾
        {
            TryEncount();
            Debug.Log("����");
        }
    }

    void TryEncount()
    {
        if (ShouldEncountOccur())
        {
            StartBattleScene();
        }
    }

    bool ShouldEncountOccur()
    {
        return Random.value < encountChance;
    }

    void StartBattleScene()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
