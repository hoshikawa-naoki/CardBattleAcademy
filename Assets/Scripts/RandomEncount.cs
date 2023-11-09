using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEncount : MonoBehaviour
{
    public float encountChance = 0.2f;
    public move_chara playerMovement;

    void Update()
    {
        Debug.Log("���Ԃ񂱂�");
        Encount();
    }

    private void Encount()
    {
        Debug.Log("playerMovement �̒l: " + playerMovement);// playerMovement �ϐ��̒l��\��
        if (playerMovement != null)
        {
            Debug.Log("�v���C���[�������Ă���Ƃ��̏���");

            Rigidbody2D rb = playerMovement.GetComponent<Rigidbody2D>();
            var PlayerSpeed = rb.velocity.magnitude;
            var RateEncount = Random.Range(0f, 1f); // 0����1�̊ԂŃ����_���Ȓl���擾
            Debug.Log(PlayerSpeed);
            Debug.Log(RateEncount);

            if (PlayerSpeed > 0.5 && RateEncount < encountChance) // encountChance�𗘗p���Ċm����ݒ�
            {
                SceneManager.LoadScene("BattleScene");
            }
        }
    }
}