using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levels;
    [SerializeField] private Transform _levelPosition;
    [SerializeField] private int _activeLevel = 0;
    private GameObject activeLevel;
    [SerializeField] private Game gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<Game>();
        gameManager.gameEvents.AddListener(SetLevel);
        SetLevel();
    }

    private void SetLevel()
    {
        if (activeLevel != null)
            Destroy(activeLevel);
          
        activeLevel = Instantiate(_levels[_activeLevel], _levelPosition.position, Quaternion.identity);
        activeLevel.transform.SetParent(_levelPosition);

        if (_activeLevel < _levels.Count - 1)
        {
            _activeLevel++;
        }
        else
        {
            _activeLevel = 0;
        }
    }
}
