using UnityEngine;
using TMPro;  // Make sure you have the TextMeshPro namespace
using System.Collections;
using JetBrains.Annotations;
using UnityEngine.UIElements;

public class cutsceneOne : MonoBehaviour
{
    // The object that needs to move (can be set in Inspector or found dynamically)
    public GameObject objectToMove;

    // The waypoint position (can also be set via Inspector)
    public Transform[] waypoints;
    private bool waypointsReached = false;

    // Speed at which the object moves towards the waypoint
    public float speed = 5f;

    // Optional: A tolerance for when the object is "close enough" to the waypoint
    public float arrivalThreshold = 0.1f;

    // UI Elements to activate when the object reaches the waypoint
    public GameObject character;
    public GameObject textbox;
    public TextMeshProUGUI textLabel;
    private string characterSpeech;
    public int speechCheck;
    private bool speechPause = false;
    public TMP_InputField nameInput;
    public GameObject playerImage;

    // Typewriter effect settings
    public float typingSpeed = 0.05f;  // Time delay between each character

    // A flag to track whether the typing effect has started
    private bool typingStarted = false;

    //character name input
    public GameObject player;
    private string playerNameSet;

    private void Start()
    {
        character.SetActive(false);
        textbox.SetActive(false);
        textLabel.gameObject.SetActive(false);
        playerImage.SetActive(false);
        nameInput.gameObject.SetActive(false);
    }
    void Update()
    {
        if (objectToMove != null)
        {
            // Move the object towards the waypoint
            MoveTowardsWaypoint();
        }
        getInput();
        speechText();
    }

    void speechText()
    {
        //scene text
        if (speechCheck == 0)
        {
            characterSpeech = "Welcome traveller, your arrival has been much anticipated. It has been some time since anyone has entered our colony. Visitors here are rare, rarer than the purest gold, if you’ll allow my exaggeration.";
        }
        else if (speechCheck == 1)
        {
            characterSpeech = "I assure you, your assimilation into the colony - and I hope into my servitude - shall be swift and executed with ease. Disregard all that you believe you know about life.";
        }
        else if (speechCheck == 2)
        {
            characterSpeech = "The way in which you lived before the colony should become nothing more than dream-like memories. If you wish to live here, you will do so under my command. You will contribute to my colony just as any other citizen under my authority does.";
        }
        else if (speechCheck == 3)
        {
            characterSpeech = "Come now, let us not torment our newest member of the colony in such a way. Say, what is your name?";
        }
        else if (speechCheck == 4)
        {
            characterSpeech = "Brother, whilst I appreciate your position as my advisor, allow me to advise you. Should you wish to interrupt me again, there will be dire consequences.";
        }
        else if (speechCheck == 5)
        {
            characterSpeech = "Of course, forgive me.";
        }
    }

    void getInput()
    {
        //input
        if (Input.GetKeyDown(KeyCode.Mouse0) && speechPause == true && speechCheck < 2)
        {
            speechCheck += 1;
            MoveTowardsWaypoint();
            DeactivateUIElements();
            typingStarted = false;
            speechPause = false;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && speechPause == true && speechCheck == 2 || Input.GetKeyDown(KeyCode.Mouse0) && speechPause == true && speechCheck > 3 && speechCheck <= 5)
        {
            speechCheck += 1;
            Debug.Log(speechCheck);
            waypointsReached = true;
            MoveTowardsWaypoint();
            typingStarted = false;
            speechPause = false;
        }
        else if (speechCheck == 3 && Input.GetKeyDown(KeyCode.Return)) // this is wrong
        {
            speechCheck += 1;
            waypointsReached = true;
            MoveTowardsWaypoint();
            ActivateUIElements();
            typingStarted = false;
            speechPause = false;
        } else if (speechCheck > 5)
        {
            objectToMove.transform.position = objectToMove.transform.position -= transform.right * speed * Time.deltaTime;
            DeactivateUIElements();
        }
    }

    private void MoveTowardsWaypoint()
    {
        if (waypointsReached == true)
        {
            Debug.Log("waypoints reached");
            // Start the typewriter effect if it hasn't started already
            if (!typingStarted && textLabel != null)
            {
                typingStarted = true; // Set the flag to true
                Debug.Log("Object has reached the waypoint!");
                textLabel.text = "";
                StartCoroutine(TypeWriterEffect(characterSpeech));
            }
            if (speechCheck == 3)
            {
                ActivateUIElements();
            }
        }
        else
        {
            // Get the position of the object to move
            Vector3 currentPosition = objectToMove.transform.position;

            // Calculate direction from the current position to the waypoint
            Vector3 direction = (waypoints[speechCheck].position - currentPosition).normalized;

            // Move the object towards the waypoint at the specified speed
            objectToMove.transform.position += direction * speed * Time.deltaTime;

            // Check if the object is close enough to the waypoint
            if (Vector3.Distance(objectToMove.transform.position, waypoints[speechCheck].position) <= arrivalThreshold)
            {
                // Optionally, set the object's position exactly to the waypoint to prevent overshooting
                objectToMove.transform.position = waypoints[speechCheck].position;

                // Activate the UI elements (images and TMP text)
                ActivateUIElements();

                // Start the typewriter effect if it hasn't started already
                if (!typingStarted && textLabel != null)
                {
                    typingStarted = true; // Set the flag to true
                    Debug.Log("Object has reached the waypoint!");
                    textLabel.text = "";
                    StartCoroutine(TypeWriterEffect(characterSpeech));
                }
            }
        }
    }

    private void ActivateUIElements()
    {
        if (character != null)
            character.SetActive(true); // Activate Image 1

        if (textbox != null)
            textbox.SetActive(true); // Activate Image 2

        if (textLabel != null)
        {
            textLabel.gameObject.SetActive(true); // Activate TMP text
        }
        if (speechCheck == 3)
        {
            //activate elements here for text input
            playerImage.SetActive(true);
            nameInput.gameObject.SetActive(true);
        }
        else
        {
            playerImage.SetActive(false);
            nameInput.gameObject.SetActive(false);
        }
    }

    private void DeactivateUIElements()
    {
        if (character != null)
            character.SetActive(false); // Activate Image 1

        if (textbox != null)
            textbox.SetActive(false); // Activate Image 2

        if (textLabel != null)
        {
            textLabel.gameObject.SetActive(false); // Activate TMP text
        }
    }

    // Coroutine for the typewriter effect
    private IEnumerator TypeWriterEffect(string text)
    {
        // Loop through each character in the string
        foreach (char letter in text)
        {
            // Append the letter to the existing text
            textLabel.text += letter;

            // Wait before adding the next letter
            yield return new WaitForSeconds(typingSpeed);
        }
        speechPause = true;
    }

    //get text for name
    private void getName()
    {
        playerNameSet = nameInput.text;
        setName(playerNameSet);
    }

    //set name
    private void setName(string nameInput)
    {
      // player.setName(nameInput);
    }
}





