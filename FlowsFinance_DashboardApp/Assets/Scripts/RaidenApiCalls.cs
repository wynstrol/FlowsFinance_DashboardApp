using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RaidenApiCalls : MonoBehaviour
{
    private string jsonResult;
    private bool isReady=true;
    private string ipAddress;
    private string errorInfo;
    //TODO remove MonoBehaviour once initial tests are complete
    void Start()
    {

    }
    public void setIpAddress(string ip){
      ipAddress = ip;
    }

    public void getAddress(){
      string uri = "http://"+ipAddress+":5001/api/v1/address";
      startGetRoutineIfReady(uri);
    }

    public void getVersion(){
      string uri = "http://"+ipAddress+":5001/api/v1/version";
      startGetRoutineIfReady(uri);
    }

    public void getStatus(){
      string uri = "http://"+ipAddress+":5001/api/v1/status";
      startGetRoutineIfReady(uri);
    }

    public void getSettings(){
      string uri = "http://"+ipAddress+":5001/api/v1/settings";
      startGetRoutineIfReady(uri);
    }

    public void getContracts(){
      string uri = "http://"+ipAddress+":5001/api/v1/contracts";
      startGetRoutineIfReady(uri);
    }

    public void getTokens(){
      string uri = "http://"+ipAddress+":5001/api/v1/tokens";
      startGetRoutineIfReady(uri);
    }

    public void getTokenAddress(string address){
      string uri = "http://"+ipAddress+":5001/api/v1/tokens/"+address;
      startGetRoutineIfReady(uri);
    }

    public void getTokenPartners(string address){
      string uri = "http://"+ipAddress+":5001/api/v1/tokens/"+address+"/partners";
      startGetRoutineIfReady(uri);
    }

    private void startGetRoutineIfReady(string uri){
      if(isReady){
        StartCoroutine(RestfulGetRequest(uri));
      }
    }

    IEnumerator RestfulGetRequest(string uri)
    {
        isReady = false;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if(webRequest.isNetworkError || webRequest.isHttpError){
              Debug.LogError(webRequest.error);
              errorInfo = webRequest.error;
            }else{
              jsonResult = webRequest.downloadHandler.text;
              isReady = true;
            }
        }
    }
}
