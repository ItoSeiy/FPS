
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
	private int minute;
	private float seconds;
	//　前のUpdateの時の秒数
	private float oldSeconds;
	//　タイマー表示用テキスト
	[SerializeField] private TextMeshProUGUI m_timerText;
	[SerializeField] private Animator m_anim;
	private bool stay;
	private bool pause;

    void Start()
	{
		minute = 0;
		seconds = 0f;
		oldSeconds = 0f;
		m_timerText.GetComponent<TextMeshProUGUI>();
		/*m_anim.GetComponent<Animator>();*/
	}

	void Update()
	{
		if (stay == false && pause == false)
		{
			seconds += Time.deltaTime;
			if (seconds >= 60f)
			{
				minute++;
				seconds -= 60;
			}
			//　値が変わった時だけテキストUIを更新
			if ((int)seconds != (int)oldSeconds)
			{
				m_timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
			}
			oldSeconds = seconds;
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		//もしゴールオブジェクトのコライダーに接触した時の処理。
		if (other.gameObject.tag == "Player")
		{
			m_anim.Play("ClearTime");
			stay = true;
		}
	}
	public void ClearTime()
    {
		m_timerText.text = "Clear Time " + minute.ToString("00") + ":" + ((int)seconds).ToString("00");
	}
}