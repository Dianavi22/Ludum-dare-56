using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSnail : MonoBehaviour
{

    [SerializeField] List<string> _txt = new List<string>();
    [SerializeField] TMP_Text _text;
    [SerializeField] GameObject _bubble;
    private bool isShowing;
    void Start()
    {
        
    }

    void Update()
    {
        if (!isShowing)
        {
            StartCoroutine(RandomText());
        }
    }

    private  IEnumerator RandomText()
    {
        isShowing = true;
        print("HERE");
        yield return new WaitForSeconds(Random.Range(10, 20));
        _bubble.SetActive(true);
        _text.text = "";
        _text.text = _txt[Random.Range(0, _txt.Count)];

        yield return new WaitForSeconds(4);
        _bubble.SetActive(false);
        isShowing = false;

    }
}
