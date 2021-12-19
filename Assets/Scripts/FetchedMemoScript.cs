using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FetchedMemoScript : MonoBehaviour
{
    public int memoNum;
    public string memoContent;

    public void TaskOnClick()
    {
        //Debug.Log("Num is... " + this.MemoNum);
        GameObject pb = GameObject.Find("PostBox"); 
        pb.GetComponent<PostBox>().grabbedNum = memoNum;
        pb.GetComponent<PostBox>().grabbedContent = memoContent;
        SceneManager.LoadScene("WritingScene");
    }
}
