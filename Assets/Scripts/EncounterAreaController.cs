using UnityEngine;
using UnityEngine.Playables;

public class EncounterAreaController : MonoBehaviour
{
    public PlayableDirector playableDirector;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �v���C���[��EncounterArea�ɐG�ꂽ�ꍇ�ATimeline��L���ɂ���
            EnableTimeline();
        }
    }

    void EnableTimeline()
    {
        // Timeline��L���ɂ���
        playableDirector.enabled = true;
        // �܂��� playableDirector.Play(); �ł��Đ��\
    }
}
