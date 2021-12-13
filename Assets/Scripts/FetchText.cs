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
        string resultText = "";
        int num = 1;
        do
        {            
            WWWForm form = new WWWForm();
            form.AddField("num", num);
            UnityWebRequest www = UnityWebRequest.Post("http://localhost/LeeNotepadApp/FetchText.php", form);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("ConnectionError");
            }
            else
            {
                resultText = www.downloadHandler.text;
                Debug.Log(resultText);
                /*textField.text = fetchText;*/
                num++;
            }
        } while (resultText != "0 results");
    }
}
