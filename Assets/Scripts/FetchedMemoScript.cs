using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FetchedMemoScript : MonoBehaviour
{
    public int MemoNum { get; set; }

    public void TaskOnClick()
    {
        Debug.Log("Num is... " + this.MemoNum);
    }
}
