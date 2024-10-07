using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class introManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _snails = new List<GameObject>();
    [SerializeField] TypeSentence _typeSentence;
    [SerializeField] TMP_Text _text;
    [SerializeField] GameManager _gameManager;
    public bool isIntroFinish = false;
    void Start()
    {
        _typeSentence.WriteMachinEffect("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident,", _text, 0.02f);
        StartCoroutine(Snails());
    }

    void Update()
    {
        
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
