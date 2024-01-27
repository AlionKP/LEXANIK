using UnityEngine;
using Photon.Pun;

public class IsMine : MonoBehaviour
{
    [SerializeField] private FirstPersonController _playerMovement;
    [SerializeField] private grabb _grabb;
    [SerializeField] private GameObject _camera;
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private GameObject _playerModel;


    void Start()
    {
        _photonView.GetComponent<PhotonView>();
        if (!_photonView.IsMine)
        {
            _grabb.enabled = false;
            _playerMovement.enabled = false;
            _camera.SetActive(false);
            _playerModel.SetActive(true);
        }
    }
}
