using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Networking; //Don't forget to import this(it's not imported by default)
using SimpleJSON;

public class NetworkHandler : MonoBehaviour {
	private string baseUrl = "http://leaderboard.fxraid.com/api/v1/players";

	void Start () {

		//Call this to get data
		StartCoroutine(GetScores());

		//Call this to send data
		// this.sendScore(5);			
	}
	
	void Update () {
	
	}

	/// <summary>
	/// sends the score to the server
	/// </summary>
	///
	/// <param name="score">The score</param>
	/// <param name="username">The username</param>
	void sendScore(int score, string username){
		WWWForm form = new WWWForm();

		form.AddField("username", username);
		form.AddField("score", score.ToString());

		WWW www = new WWW(this.baseUrl, form);
	}

	/// <summary>
	/// Get the scores. 
	/// Calls the succesHandlerScores() void on succes.
	/// Calls the errorHandlerScores() void on error
	/// </summary>
	///
	/// <returns>Scores.</returns>

	IEnumerator GetScores() {
        using(UnityWebRequest www = UnityWebRequest.Get(this.baseUrl)) {
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

  		var myObject = JSON.Parse(result);
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

// [Serializable]
public class Score 
{
  	public int id;
  	public string username;
  	public int score;
  	public string created_at;
  	public string updated_ad;
}

public class Scores 
{
  	public int[] scores;
}