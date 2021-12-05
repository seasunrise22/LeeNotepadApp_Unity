using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SendText : MonoBehaviour
{
    public InputField textField;
    public Button sendButton;

    public void CallSendToDB()
    {
        StartCoroutine(SendToDB());
    }

    IEnumerator SendToDB()
    {
        WWWForm form = new WWWForm();
        /*form.AddField("datetime", System.DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss"));*/
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    public void VerifyInputs()
    {
        sendButton.interactable = (textField.text.Length >= 1);
    }
}
