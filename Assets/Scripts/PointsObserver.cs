using UnityEngine;

public class PointsObserver : MonoBehaviour
{
    [Header("Observable")]
    [SerializeField] private Transform[] _observablePoints;
    [SerializeField] private float _lookDelay;
    
    [Header("Field of View")]
    [SerializeField] private GameObject _fieldOfView;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private LayerMask _playerMask;

    private float _timer = 0f;
    private int _currentObservablePointIndex = 0;

    private void Awake()
    {
        _timer = _lookDelay;
    }

    private void Update()
    {
        LookAtTimerTick();
        LookAtPoint(_currentObservablePointIndex);
    }

    private void LookAtTimerTick()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            int nextPointIndex = _currentObservablePointIndex + 1;

            if (nextPointIndex >= _observablePoints.Length)
                nextPointIndex = 0;

            _currentObservablePointIndex = nextPointIndex;
            _timer = _lookDelay;
        }
    }

    private void LookAtPoint(int pointIndex)
    {
        Vector3 distanceToPoint = _observablePoints[pointIndex].transform.position - transform.position;
        Vector3 directionToPoint = distanceToPoint.normalized;

        if (Physics.Raycast(transform.position, directionToPoint, out RaycastHit hit, distanceToPoint.magnitude, _playerMask))
            //hit.collider.GetComponent<Player>().Kill();

        _fieldOfView.SetActive(Physics.Raycast(transform.position, directionToPoint, distanceToPoint.magnitude, _obstacleMask) == false);
        transform.forward = new Vector3(directionToPoint.x, 0f, directionToPoint.z);
    }
}
