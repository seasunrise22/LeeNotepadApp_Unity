using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SendText : MonoBehaviour
{
    public InputField textField;
    public int receivedNum;
    public string receivedString;
    public Button sendButton;

    private void Start()
    {
        receivedNum = -1;
        GameObject pb = GameObject.Find("PostBox");
        if(pb != null)
        {
            receivedNum = pb.GetComponent<PostBox>().grabbedNum;
            receivedString = pb.GetComponent<PostBox>().grabbedContent;
            textField.text = receivedNum + "" + receivedString;
        }        
    }

    public void CallSendToDB()
    {
        StartCoroutine(SendToDB());
    }

    IEnumerator SendToDB()
    {
        WWWForm form = new WWWForm();
        Debug.Log("ReceivedNum is " + receivedNum);
        if(receivedNum != -1) //기존에 작성된 글을 수정
        {
            Debug.Log("ReceivedNum != -1");            
            form.AddField("num", receivedNum);
            form.AddField("text", textField.text);
            UnityWebRequest www = UnityWebRequest.Post("http://localhost/LeeNotepadApp/SendText.php", form);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("ConnectionError");
            }
            else
            {
                Debug.Log("Send Text to Database successful");
                SceneManager.LoadScene("ListScene");
            }
        }
        else // 새 글 작성
        {
            form.AddField("text", textField.text);
            UnityWebRequest www = UnityWebRequest.Post("http://localhost/LeeNotepadApp/SendText.php", form);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("ConnectionError");
            }
            else
            {
                Debug.Log("Send Text to Database successful");
                SceneManager.LoadScene("ListScene");
            }
        }      
    }

    public void VerifyInputs()
    {
        sendButton.interactable = (textField.text.Length >= 1);
    }
}
