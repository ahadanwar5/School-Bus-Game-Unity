using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class busScript : MonoBehaviour
{
    public Text healthText;
    public Text passengerText;
    float healthValue = 50;
    float passengerValue = 0;
    int flag1 = 0;
    int flag2 = 0;

    public GameObject childrenGroup1;
    public GameObject childrenGroup2;

    public AudioClip horn;


    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "Health: " + healthValue.ToString();
        passengerText.text = "Passengers Onboard: " + passengerValue.ToString();
        GetComponent<AudioSource>().clip = horn;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthValue <= 0)
        {
            SceneManager.LoadScene("gameOverScene");
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, 0f, 0.2f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, 0f, -0.2f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, -1.5f, 0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f, 1.5f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            GetComponent<AudioSource>().PlayOneShot(horn);
        }

        StartCoroutine(pickPassengers());

    }//update end

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name.StartsWith("House") || col.gameObject.name.StartsWith("car"))
        {
            healthValue -= 10;
            healthText.text = "Health: " + healthValue.ToString();
        }
    }

    IEnumerator pickPassengers()
    {
        Vector3 busPosition = transform.position;
        if (busPosition.z > -44 && busPosition.z < -40 && busPosition.x > -89 && busPosition.x < -88)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (passengerValue < 30 && flag1==0)
                {
                    passengerValue += 5;
                    passengerText.text = "Passengers Onboard: " + passengerValue.ToString();
                    childrenGroup1.gameObject.SetActive(false);
                    flag1 = 1;
                    yield return new WaitForSecondsRealtime(10);
                    childrenGroup1.gameObject.SetActive(true);
                    flag1 = 0;

                }

            }
        }

        if (busPosition.z > -38 && busPosition.z < -35 && busPosition.x > -3.2 && busPosition.x < -1.5)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (passengerValue < 30 && flag2 == 0)
                {
                    passengerValue += 5;
                    passengerText.text = "Passengers Onboard: " + passengerValue.ToString();
                    childrenGroup2.gameObject.SetActive(false);
                    flag2 = 1;
                    yield return new WaitForSecondsRealtime(10);
                    childrenGroup2.gameObject.SetActive(true);
                    flag2 = 0;
                }

            }
        }
    }

}