using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private PhotonView view;
    [SerializeField] public int score;
    void Start()
    {
        text = GetComponent<TMP_Text>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();

        if (Input.GetKeyDown(KeyCode.T))
        {
            view.RequestOwnership();
            AddScore();
        }
    }

    private void AddScore()
    {
        score++;
    }
}
