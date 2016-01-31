using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Lightbar : MonoBehaviour
{
	public Player player;

	PlayerPubMethods ppm;
	void Awake()
	{
		ppm = player.GetComponent<PlayerPubMethods>();
	}

	void Update()
	{
		float H = ppm.GetCurrentLight();
		Image HealthBar = GetComponent<Image>();
		HealthBar.fillAmount = H / 100f;
	}
}
