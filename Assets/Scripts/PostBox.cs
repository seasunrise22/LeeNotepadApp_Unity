using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostBox : MonoBehaviour
{
    public int grabbedNum;
    public string grabbedContent;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); //�� �ʸӷ� �����͸� �ѱ�� ���� �̱���.
    }
}
