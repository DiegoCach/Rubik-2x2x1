using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class GameController : MonoBehaviour {
    private GameObject[] Cubes = new GameObject[4];
    private float[] FixedPositions = new float[] {0f, 90f, 180f, 270f};
    private Quaternion[] SavedPositions = new Quaternion[4];
    private bool isEqual = false;
    private Quaternion rotation;
    private int gameMoves = 0;
    AudioSource[] audios;
    private GameObject moves, BestPunt;
	// Use this for initialization
	void Start () {
        audios = GetComponents<AudioSource>();
        moves = GameObject.Find("Puntuacion");
        BestPunt = GameObject.Find("Best");
        BestPunt.GetComponent<Text>().text = "Mejor numero de  " + PlayerPrefs.GetString("Mejor");
        for (int i = 0; i < 4; i++) {
            Cubes[i] = GameObject.Find("Dice" + i);
            //Cubes[i].transform.Rotate(0f, FixedPositions[Random.Range(0, FixedPositions.Length)], 0f, Space.Self);
            //Cubes[i].transform.Rotate(FixedPositions[Random.Range(0, FixedPositions.Length)], 0f, 0f, Space.World);
            SavedPositions[i] = Cubes[i].transform.rotation;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void Move() {
        switch (EventSystem.current.currentSelectedGameObject.name) {
            case "izq1":
                CheckRotationLR(0,3,90f);
                break;
            case "izq2":
                CheckRotationLR(1,2,90f);

                break;
            case "derecha1":
                CheckRotationLR(0,3,-90f);

                break;
            case "derecha2":
                CheckRotationLR(1, 2, -90f);

                break;
            case "arriba1":
                CheckRotationUD(2, 3, 90f);

                break;
            case "arriba2":
                CheckRotationUD(0, 1, 90f);

                break;
            case "abajo1":
                CheckRotationUD(2, 3, -90f);

                break;
            case "abajo2":
                CheckRotationUD(0, 1, -90f);

                break;
        }
        audios[0].Play();
        moves.GetComponent<Text>().text = "Movimientos: " + gameMoves++;
        ComparePositions();
    }

    private void ComparePositions() {
        for (int i = 0; i < 3; i++)
        {
            if (SavedPositions[i].x == SavedPositions[i + 1].x && SavedPositions[i].y == SavedPositions[i + 1].y)
            {
                isEqual = true;
            }
            else
            {
                Debug.Log("Nada");
                break;
            }
        }
        if (isEqual == true)
        {
            PlayerPrefs.SetString("Mejor", moves.GetComponent<Text>().text);
            Debug.Log("GANASTE");
        }
    }

    private void CheckRotationLR(int a, int b, float direction) {
        if (Cubes[a].transform.rotation.eulerAngles.x == 90f || Cubes[b].transform.rotation.eulerAngles.x == -90f)
        {
            Cubes[a].transform.Rotate(0f, direction, 0f, Space.World);
            SavedPositions[a] = Cubes[a].transform.rotation;
        }
        else
        {
            Cubes[a].transform.Rotate(0f, direction, 0f, Space.Self);
            SavedPositions[a] = Cubes[a].transform.rotation;
        }
        if (Cubes[b].transform.rotation.eulerAngles.x == 90f || Cubes[b].transform.rotation.eulerAngles.x == -90f)
        {
            Cubes[b].transform.Rotate(0f, direction, 0f, Space.World);
            SavedPositions[b] = Cubes[b].transform.rotation;
        }
        else
        {
            Cubes[b].transform.Rotate(0f, direction, 0f, Space.Self);
            SavedPositions[b] = Cubes[b].transform.rotation;
        }
    }

    private void CheckRotationUD(int a, int b, float direction)
    {
        if (Cubes[a].transform.rotation.eulerAngles.y == 90 || Cubes[b].transform.rotation.eulerAngles.x == -90f || Cubes[a].transform.rotation.eulerAngles.y == 270f)
        {
            Cubes[a].transform.Rotate(direction, 0f, 0f, Space.World);
            SavedPositions[a] = Cubes[a].transform.rotation;
        }
        else
        {
            Cubes[a].transform.Rotate(direction, 0f, 0f, Space.Self);
            SavedPositions[a] = Cubes[a].transform.rotation;
        }
        if (Cubes[b].transform.rotation.eulerAngles.y == 90f || Cubes[b].transform.rotation.eulerAngles.x == -90f || Cubes[b].transform.rotation.eulerAngles.y == 270f)
        {
            Cubes[b].transform.Rotate(direction, 0f, 0f, Space.World);
            SavedPositions[b] = Cubes[b].transform.rotation;
        }
        else
        {
            Cubes[b].transform.Rotate(direction, 0f, 0f, Space.Self);
            SavedPositions[b] = Cubes[b].transform.rotation;
        }
    }
    public void DeactivateSounds() {
        if (audios[0].enabled == true)
        {
            audios[0].enabled = false;
            audios[1].enabled = false;
        }
        else {
            audios[0].enabled = true;
            audios[1].enabled = true;
        }
    }
}
