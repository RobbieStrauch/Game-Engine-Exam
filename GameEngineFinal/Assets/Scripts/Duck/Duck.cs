using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    PlayerControl inputAction;
    Camera mainCamera;

    public LayerMask duckLayer;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        transform.position = new Vector3(Random.Range(-10f, 10f), 0.25f, Random.Range(-10f, 10f));

        inputAction = PlayerInputController.controller.inputAction;
        inputAction.Player.Attack.performed += cntxt => Attack();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, duckLayer))
        {
            if (hit.collider.gameObject.activeSelf)
            {
                hit.collider.gameObject.SetActive(false);
                ScoreManager.instance.AddScore();
                ScoreManager.instance.ResetMiss();
            }
        }
        else
        {
            ScoreManager.instance.AddMiss();
        }
    }
}
