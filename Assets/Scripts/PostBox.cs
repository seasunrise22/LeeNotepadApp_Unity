using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostBox : MonoBehaviour
{
    public int GrabbedNum { get; set; }
    public string GrabbedContent { get; set; }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); //씬 너머로 데이터를 넘기기 위한 싱글턴.
    }
}
