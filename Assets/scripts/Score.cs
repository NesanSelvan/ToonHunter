using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI m_TextComponent;
    public FireButton fire;
    // Start is called before the first frame update
    void Start()
    {
        fire = fire.GetComponent<FireButton>();
    }

    // Update is called once per frame
    void Update()
    {
         m_TextComponent.text = fire.hitscore.ToString();
m_TextComponent.text = string.Format("Score: {0:00000}", fire.hitscore.ToString());
Debug.Log("Score :" + fire.hitscore);    }
}
