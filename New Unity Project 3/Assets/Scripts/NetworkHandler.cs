using UnityEngine;
using UnityEngine.Experimental.Networking; //Don't forget to import this(it's not imported by default)
using System.Collections;

public class NetworkHandler : MonoBehaviour {
	private string url = "http://localhost:8081/webtest/index.php";

	void Start () {
		//Call this to get data
		StartCoroutine(GetScores());

		//Call this to send data
		this.sendScore(5);			
	}
	
	void Update () {
	
	}

	/// <summary>
	/// Sends the int score to the score API.
	/// Usses the private field url of this class
	/// </summary>
	///
	/// <param name="score">The score</param>
	/// <returns>void</returns>c
	void sendScore(int score){
		WWWForm form = new WWWForm();
		form.AddField("score", score.ToString());
		WWW www = new WWW(this.url, form);
	}

	/// <summary>
	/// Get the scores. 
	/// Calls the succesHandlerScores() void on succes.
	/// Calls the errorHandlerScores() void on error
	/// </summary>
	///
	/// <returns>Scores.</returns>

	IEnumerator GetScores() {
        using(UnityWebRequest www = UnityWebRequest.Get(this.url)) {
            yield return www.Send();
     
            if(www.isError) {
                this.errorHandlerScores(www.error);
            }
            else {
                this.succesHandlerScores(www.downloadHandler.text);
            }
        }
    }

    /// <summary>
    /// succeshandler for the getScores() IEnumerator
    /// </summary>
    ///
    /// <param name="result">The result</param>
    /// <returns>void</returns>
    void succesHandlerScores(string result){
    	Debug.Log(result);
    }

    /// <summary>
    /// errorHandler for the getScores IEnumerator
    /// </summary>
    ///
    /// <param name="error">The error</param>
    /// <returns>void</returns>
    void errorHandlerScores(string error){
    	Debug.Log(error);
    }
}
