using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SymbolEncounter : MonoBehaviour
{
    public float encounterInterval = 2.0f; // �G���J�E���g�̊Ԋu�i�b�j
    public string bossBattleSceneName = "BossBattle"; // �{�X�o�g���̃V�[����

    private bool canEncounter = true;

    private void Start()
    {
        // �V�[��������v���C���[��PlayableDirector���擾
        // �����ŕK�v�Ȃ��PlaybleDirector�̐ݒ���s��
    }

    // �V���{���G���J�E���g�̃g���K�[�𔭐������郁�\�b�h
    public void TriggerEncount()
    {
        if (canEncounter)
        {
            StartCoroutine(EncountCoroutine());
        }
    }

    // �G���J�E���g�����������Ƃ��̏���
    private void DoEncount()
    {
        Debug.Log("�V���{���G���J�E���g�I�������I");

        // �{�X�o�g���̃V�[����񓯊��Ń��[�h
        StartCoroutine(LoadBossBattleScene());
    }

    // �{�X�o�g���̃V�[����񓯊��Ń��[�h����R���[�`��
    private IEnumerator LoadBossBattleScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(bossBattleSceneName);

        // ���[�h����������܂őҋ@
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // �V���{���G���J�E���g�̏������ĊJ
        canEncounter = true;
    }

    // �G���J�E���g����������܂ł̑ҋ@���Ԃ�݂���R���[�`��
    private IEnumerator EncountCoroutine()
    {
        canEncounter = false; // �G���J�E���g�̘A��������h�����߂Ƀt���O���I�t�ɂ���

        // �G���J�E���g����������܂ł̑ҋ@����
        yield return new WaitForSeconds(encounterInterval);

        DoEncount(); // �G���J�E���g�����������Ƃ��̏��������s
    }
}
