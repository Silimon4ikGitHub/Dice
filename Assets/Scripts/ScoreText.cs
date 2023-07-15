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
    [SerializeField] private Die d10;
    [SerializeField] public int score;
    void Start()
    {
        text = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TMP_Text>();
        d10 = GetComponent<Die>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        score = d10.value;
        text.text = score.ToString();
    }

    private void AddScore()
    {
        score++;
    }
}
