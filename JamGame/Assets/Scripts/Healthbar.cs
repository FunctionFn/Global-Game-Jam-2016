﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{
	public Player player;

	PlayerPubMethods ppm;
	void Awake()
	{
		ppm = player.GetComponent<PlayerPubMethods>();
	}

	void Update()
	{
		float H = ppm.GetCurrentHealth();
		Image HealthBar = GetComponent<Image>();
		HealthBar.fillAmount = H / 100f;
	}
}
