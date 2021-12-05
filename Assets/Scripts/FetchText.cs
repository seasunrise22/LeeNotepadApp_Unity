using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FetchText : MonoBehaviour
{
    public Text textField;

    private void Start()
    {
        StartCoroutine(FetchFromDB());
    }

    IEnumerator FetchFromDB()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/LeeNotepadApp/FetchText.php");
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("ConnectionError");
        }
        else
        {
            Debug.Log("FetchText from Database successful");
            string fetchText = www.downloadHandler.text;
            Debug.Log(fetchText);
            textField.text = fetchText;
        }
    }
}
