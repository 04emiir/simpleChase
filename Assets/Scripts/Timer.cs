using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer = 0.0f;
    public TextMeshProUGUI texto;
    public TextMeshProUGUI textoDos;
    public bool pillado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!pillado) {
            timer += Time.deltaTime;
            int seconds = (int)timer % 60;
            texto.text = "TIEMPO: " + seconds.ToString();
        } else if (pillado) {
            textoDos.text = "TE HAN PILLADO";
            Invoke("Reset", 3.0f);
        }
        
    }

    public void Reset() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
