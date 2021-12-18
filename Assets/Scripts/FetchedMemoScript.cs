using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FetchedMemoScript : MonoBehaviour
{    
    public int MemoNum { get; set; }
    public string MemoContent { get; set; }

    public void TaskOnClick()
    {
        //Debug.Log("Num is... " + this.MemoNum);
        GameObject pb = GameObject.Find("PostBox"); 
        pb.GetComponent<PostBox>().GrabbedNum = MemoNum;
        pb.GetComponent<PostBox>().GrabbedContent = MemoContent;
        SceneManager.LoadScene("WritingScene");
    }
}
