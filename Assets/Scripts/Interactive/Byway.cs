using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Byway : InteractiveObject
{
    private const string FIND_STRING = "������ �߰��Ͽ����ϴ�. \\n�����Ͻðڽ��ϱ�?? \\n( Y / N )";
    public GameObject targetObj;

    private float checkTime = 0;
    private Coroutine answerCor;

    public override void Interact()
    {
        TutorialManager.instance.ShowTutoWindow(FIND_STRING, 999f);

        if (answerCor != null) 
            StopCoroutine(answerCor);
        answerCor = StartCoroutine(WaitAnswer());
    }

    private IEnumerator WaitAnswer()
    {
        checkTime = 0;
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                GameManager.instance.player.transform.position
                    = targetObj.transform.position;
                break;
            }
            else if (Input.GetKeyDown(KeyCode.N))
                break;
            

            //0.5�ʸ��� �÷��̾� ���� üũ
            checkTime += Time.deltaTime;
            if (checkTime >= 0.5f && !IsInPlayer())
                break;

            yield return null;
        }

        TutorialManager.instance.StopShow();
    }

    private bool IsInPlayer()
    {
        checkTime = 0;
        Collider[] colliders 
                = Physics.OverlapSphere(transform.position, 3, GameData.PLAYER_LAYER_MASK);


        return colliders.Length > 0;
    }

}
