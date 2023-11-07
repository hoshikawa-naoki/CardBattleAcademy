using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEncount : MonoBehaviour
{
    public float encounterRate = 0.05f; // �����_���G���J�E���g�̔����� (0����1�̊ԂŐݒ�)

    void Update()
    {
        if (Random.value < encounterRate)
        {
            StartEncounter();
        }
    }

    void StartEncounter()
    {
        // �o�g���V�[���ɑJ��
        SceneManager.LoadScene("BattleScene");
    }
}
