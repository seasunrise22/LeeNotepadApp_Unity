using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FetchText : MonoBehaviour
{
    public GameObject memoPrefab;

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
                if (resultText == "0 results")
                    break;
                //Debug.Log(resultText);
                GameObject go = Instantiate(memoPrefab, transform.position, transform.rotation);
                go.transform.SetParent(GameObject.Find("Contents").transform, false);
                go.GetComponentInChildren<Text>().text = resultText;
                go.GetComponent<FetchedMemoScript>().MemoNum = num;
                go.GetComponent<FetchedMemoScript>().MemoContent = resultText;
                num++;
            }
        } while (resultText != "0 results");
    }
}
