using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _snails = new List<GameObject>();
    [SerializeField] TypeSentence _typeSentence;
    [SerializeField] TMP_Text _text;
    [SerializeField] GameManager _gameManager;
    public bool isIntroFinish = false;
    void Start()
    {
        _typeSentence.WriteMachinEffect("Lorem ipsum dolor sit amet, consectetur adipiscing elit,", _text, 0.04f);
        StartCoroutine(Snails());
    }

    void Update()
    {
        if(isIntroFinish == true)
        {
            _typeSentence.StopWriteMachineSound();
        }
    }

    private IEnumerator Snails()
    {
        for (int i = 0; i < _snails.Count; i++)
        {
            _snails[i].SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.7f,1.3f));
        }
    }

    public void ReadyToSetUp()
    {
        _gameManager._isSetuping = true;
    }
}
