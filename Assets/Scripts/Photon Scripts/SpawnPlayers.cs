using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject cameraPrefab;

    public float minX, maxX;
    public float minZ, maxZ;

    new GameObject camera;
    GameObject jumpButton;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 0.15f, Random.Range(minZ, maxZ));
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        player.tag = "Player";
        camera = Instantiate(cameraPrefab, randomPosition, Quaternion.identity);

        jumpButton = camera.GetComponentInChildren<Button>().gameObject;

        if (player.GetComponentInChildren<PhotonView>().IsMine)
        {
            player.GetComponentInChildren<PlayerController>().SetData(camera);
            camera.GetComponent<CameraLook>().SetData(camera);
            camera.GetComponent<CameraLook>().SetCameraPosition(player.GetComponentInChildren<PlayerController>().gameObject);
            jumpButton.GetComponent<Button>().onClick.AddListener(player.GetComponentInChildren<PlayerController>().Jump);
        }
        
    }

}
