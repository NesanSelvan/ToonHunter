using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RadialCountdown : MonoBehaviour
{
    public GameObject LoadingText;
	public TextMeshProUGUI ProgressIndicator;
	public Image LoadingBar;
   public float seconds;
   float timeremaining = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
             timeremaining -= Time.deltaTime;
              DisplayTime(timeremaining);

	
    }
     void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
      
        // m_tm.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            // m_tm.text = string.Format("COUNTDOWN :{1:00}", minutes, seconds);
        	if (timeremaining > 0) {
          float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
         seconds = Mathf.FloorToInt(timeToDisplay % 60);
        Debug.Log("seconds" + seconds);
			ProgressIndicator.text = $"{timeToDisplay % 60:00}"; 
            //((int)seconds).ToString (); 
			LoadingText.SetActive (true);
		} else {
			//LoadingText.SetActive (false);
			ProgressIndicator.text = "00";
		}
		LoadingBar.fillAmount =Mathf.InverseLerp(0,10,timeremaining); 
    }
}
