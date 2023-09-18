using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Unity.VisualScripting;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private PhotonView view;
    public Die dice;
    [SerializeField] public int score;
    void Start()
    {
        text = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TMP_Text>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        score = dice.value;
        text.text = score.ToString();
    }

    private void AddScore()
    {
        score++;
    }
}
