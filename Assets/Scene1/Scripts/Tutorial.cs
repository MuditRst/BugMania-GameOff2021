using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public TMP_Text text;
	string writer;

    string writefrom;
    public GameObject player;
    public GameObject enemy;

    public Transform spawnPoint;

    public Canvas canvas;

    public GameObject Exit;

    [SerializeField] bool startingText,gameMechanicsText,exitText;

	[SerializeField] float delayBeforeStart = 0f;
	[SerializeField] float timeBtwChars = 0.1f;
	[SerializeField] string leadingChar = "";
	[SerializeField] bool leadingCharBeforeDelay = false;

    void Start()
    {
        startingText = true;
        gameMechanicsText = true;
        player.SetActive(false);
        canvas.gameObject.SetActive(false);
        StartingText();
        Exit.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(startingText == false && gameMechanicsText==true)
            GameMechanicsText();
        if(!gameMechanicsText && GameObject.FindGameObjectsWithTag("Enemy").Length == 0){
            StartCoroutine(exitSpawn());
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        }

        
        Destroy(GameObject.FindGameObjectWithTag("corpse"),0.3f);
        
        
    }

    void StartingText(){
         writefrom = "Hey Bugger!\n\n" +
                    "Let Me Brief You on your Mission...\n\n" +
                    "There has been a report talking About Infestation\n"+
                    "And you have been send to clear it up...\n\n" +
                    "But you have to be <color=red>careful</color>...\n\n" +
                    "Many were sent and they are stuck there now...\n\n" +
                    "Now you can either find them and give them a helping hand\n" +
                    "Or you can just complete your mission and get out of here...\n\n";
        
        writer = writefrom;

        if(text.text != null)
        {
            StartCoroutine(TypeWriterTMP());
        }
    }

    void GameMechanicsText(){
        player.SetActive(true);
        canvas.gameObject.SetActive(true);
        
        writefrom = "This is Gary the Grasshopper.\n" +  //spawn player model
                    "Gary is fast and nimble. Use <color=red>WASD</color> to move around.\n" + //player moves around
                    "Use <color=yellow>LMB</color> to attack\n\n" +
                    "You can use <color=green>Q</color> to use your special ability\n" +
                    "For Gary it is dash.\n\n" +
                    "If You are ready Touch\n" +
                    "That <color=red>Red Button</color> to Move on.\n" +
                    "Good Luck!\n\n";
        writer = writefrom;
        StartCoroutine(TypeWriterTMP());
        gameMechanicsText = false;
    }



    
	IEnumerator TypeWriterTMP()
    {
        text.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

		foreach (char c in writer)
		{
			if (text.text.Length > 0)
			{
				text.text = text.text.Substring(0, text.text.Length - leadingChar.Length);
			}
			text.text += c;
			text.text += leadingChar;
			yield return new WaitForSeconds(timeBtwChars);
		}

		if (leadingChar != "")
		{
			text.text = text.text.Substring(0, text.text.Length - leadingChar.Length);
		}
        startingText = false;
	}

    IEnumerator exitSpawn(){
        yield return new WaitForSeconds(30f);
        Exit.SetActive(true);
    }


}


