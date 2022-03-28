using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] private bool _timerIsOn;
    [SerializeField] private float _timerValue;
    [SerializeField] private Text _timerView;

    [Header("Objects")]
    [SerializeField] private Player _player;
    [SerializeField] private Exit _exitFromLevel;
    
    private float _timer = 0;
    private bool _gameIsEnded = false;

    private void Awake()
    {
        _timer = _timerValue;
    }

    private void Start()
    {
        _exitFromLevel.Close();
    }

    private void Update()
    {
        if(_gameIsEnded)
            return;
        
        TimerTick();
        LookAtPlayerHealth();
        LookAtPlayerInventory();
        TryCompleteLevel();
    }

    private void TimerTick()
    {
        if(_timerIsOn == false)
            return;
        
        _timer -= Time.deltaTime;
        _timerView.text = $"{_timer:F1}";
        
        if(_timer <= 0)
            Lose();
    }

    private void TryCompleteLevel()
    {
        if(_exitFromLevel.IsOpen == false)
            return;

        var flatExitPosition = new Vector2(_exitFromLevel.transform.position.x, _exitFromLevel.transform.position.z);
        var flatPlayerPosition = new Vector2(_player.transform.position.x, _player.transform.position.z);
        
        if(flatExitPosition == flatPlayerPosition)
            Victory();
    }

    private void LookAtPlayerHealth()
    {
        if(_player.IsAlive)
            return;

        Lose();
        Destroy(_player.gameObject);
    }

    private void LookAtPlayerInventory()
    {
        if(_player.HasKey)
            _exitFromLevel.Open();
    }

    public void Victory()
    {
        _gameIsEnded = true;
        _player.Disable();
        Debug.LogError("Victory");
    }

    public void Lose()
    {
        _gameIsEnded = true;
        _player.Disable();
        Debug.LogError("Lose");
    }
}
