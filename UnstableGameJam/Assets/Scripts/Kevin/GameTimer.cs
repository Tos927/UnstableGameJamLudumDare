using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	public Text TimerText;
	
	public static bool playing = true;
	private float timer;

	void Update()
	{
		if (playing == true)
		{
			timer += Time.deltaTime;
			int minutes = Mathf.FloorToInt(timer / 60f);
			int seconds = Mathf.FloorToInt(timer % 60f);
			int milliseconds = Mathf.FloorToInt((timer * 100f) % 100f);
			TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
		}
	}

}
