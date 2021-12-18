using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SendText : MonoBehaviour
{
    public InputField textField;
    public int ReceivedNum { get; set; }
    public string ReceivedString { get; set; }
    public Button sendButton;

    private void Start()
    {
        GameObject pb = GameObject.Find("PostBox");
        ReceivedNum = pb.GetComponent<PostBox>().GrabbedNum;
        ReceivedString = pb.GetComponent<PostBox>().GrabbedContent;
        textField.text = ReceivedNum + "" + ReceivedString;
    }

    public void CallSendToDB()
    {
        StartCoroutine(SendToDB());
    }

    IEnumerator SendToDB()
    {
        WWWForm form = new WWWForm();
        form.AddField("text", textField.text);        
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/LeeNotepadApp/SendText.php", form);
        yield return www.SendWebRequest();
        if(www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("ConnectionError");
        }
        else
        {
            Debug.Log("Send Text to Database successful");
            SceneManager.LoadScene("ListScene");
        }
    }

    public void VerifyInputs()
    {
        sendButton.interactable = (textField.text.Length >= 1);
    }
}
