using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostBox : MonoBehaviour
{
    public int GrabbedNum { get; set; }
    public string GrabbedContent { get; set; }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); //�� �ʸӷ� �����͸� �ѱ�� ���� �̱���.
    }
}
