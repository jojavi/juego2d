using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{

    [SerializeField] Score score;
    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update

    private void OnEnable(){
        score.onScoreUpdated += UpdateText;

    }

    private void OnDisable(){
        score.onScoreUpdated -= UpdateText;
    }

    private void UpdateText(){
        score.onScoreUpdated -= UpdateText;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
