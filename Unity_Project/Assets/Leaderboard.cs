﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    public void nextScene() {
		SceneManager.LoadScene("Leaderboard");
	}
}
