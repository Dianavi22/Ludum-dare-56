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
        _typeSentence.WriteMachinEffect("you play as a human trying to escape immortal snails, known for their deadly legend. Though slow, they are determined to kill you if they catch you. You must run through your house to avoid them, using your surroundings to survive against this strange yet relentless threat.", _text, 0.02f);
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
