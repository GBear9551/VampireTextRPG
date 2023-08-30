using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Include the TextMeshPro namespace
using System;


// [ExecuteAlways]
public class DrinkBloodButton : MonoBehaviour
{
    // [Header(" Title ")]

    // [Tooltip(" Parameter additional information")]

    // Parameters for the drink blood function
    // time it takes to shift
    [SerializeField] float timeTakenForColorShift = 1f;

    // audioclip
    [SerializeField] AudioClip audioClip = null;
    // color to transition to
    [SerializeField] Color color = Color.red;
    [SerializeField] Color originalColor ;


    // animation state( it could be the case that all textmesh classes are wrapped with our text class and can exist in an isAnimating state, to handle multiple
    // animation applications. 






    // Cache
    // Text to perform drink blood action on i.e. a text mesh pro object
    [SerializeField] TextMeshProUGUI textToChange = null;
    [SerializeField] TextMeshProUGUI mainTextArea = null;
    [SerializeField] MainText mainText = null;
    [SerializeField] Button button = null; 
    [SerializeField] string buttonName = null;
    TextMeshProUGUI buttonNamePlace = null;

    // Button can change the color of other text, TODO: make the functionality general
    bool drinkWasClicked = false;
    float timeSinceButtonWasClicked = 0f;
    float originalFontSize = 12f;
    [Tooltip("This SCALES the originial font size, so doubling, tripling, quadrupling... etc the size.")] 
      [SerializeField] float finalFontSize = 1f;

    // Variables for MoveUpText

    [SerializeField] float amountToMoveUp = 0f;
    
    [SerializeField] float timeToMoveUp = 1f; // Duration in seconds
    private Vector2 originalAnchoredPosition;
    private Vector2 finalAnchoredPosition;
    private float timeSinceStartedMovingUp = 0f;
    private bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        // Add a listener to the button's click event
        button.onClick.AddListener(OnButtonClick);

        // Find the TextMeshProUGUI component on a child object
        buttonNamePlace = button.GetComponentInChildren<TextMeshProUGUI>();


        // Store the original anchored position
        originalAnchoredPosition = textToChange.rectTransform.anchoredPosition;

        // Set the final anchored position
        finalAnchoredPosition = originalAnchoredPosition + new Vector2(0, amountToMoveUp);



        // Change the text of the TextMeshProUGUI component
        if (buttonNamePlace != null)
        {
            buttonNamePlace.text = buttonName;
        }

        if( textToChange != null)
        {
            // Store the original color for later use
            originalColor = textToChange.color;
            originalFontSize = textToChange.fontSize;
            finalFontSize = originalFontSize * finalFontSize;
        }


    }

    void OnButtonClick()
    {

        drinkWasClicked = true;

        textToChange.text = "Drinking villager...";
        buttonNamePlace.text = "End the drink."; //"Continue thirsting."

        if(drinkWasClicked )
        {

            StartCoroutine(ButtonClicked());


            //textToChange.text = "The shallow shell of the human lays depeleted.";
        }
    }

    IEnumerator ButtonClicked()
    {

        StartCoroutine(changeTextSize());
        yield return StartCoroutine(mainText.transitionAway());

        mainTextArea.text = chooseRandomVillagerDeathText();
        mainTextArea.pageToDisplay = 1;
        yield return StartCoroutine(mainText.transitionIn());


        Debug.Log(mainTextArea.text);

    }

    IEnumerator changeTextSize()
    {
        // Declare and initialize variables
        float timeElapsed = 0;
        float loopDuration = 1;
        float targetFontSize = originalFontSize + 10;

        while( timeElapsed < loopDuration)
        {
            timeElapsed += Time.deltaTime;

            float fractionComplete = timeElapsed / loopDuration; // Revise for infinite looping and finite looping.

            textToChange.fontSize = Mathf.Lerp(originalFontSize, targetFontSize, fractionComplete);

            yield return  null;
        }




    }


    // Update is called once per frame
    void Update()
    {
        // Perform drink
        // During the drink performance the textToChange will undergo a time of transition from starting color to red color


        if (!drinkWasClicked)
            sendTextUp();

    }

    void sendTextUp()
    {
        // Update the time
        timeSinceStartedMovingUp += Time.deltaTime;

        // Calculate the fraction of the total time that has elapsed
        float fractionComplete = timeSinceStartedMovingUp / timeToMoveUp;

        // Interpolate between the original anchored position and the final anchored position
        textToChange.rectTransform.anchoredPosition = Vector2.Lerp(originalAnchoredPosition, finalAnchoredPosition, fractionComplete);

        // Stop moving if the transition is complete
        if (fractionComplete >= 1f)
        {
            isMoving = false;
        }


    }


  


    void performDrink()
    {
        // Declare and initialize variables


        // Call color change coroutine
        // yield return StartCoroutine(vtext.colorAndSizeChange());

        // Update the time, since the perform drink is in the update function.
        isMoving = false;


        //



        timeSinceButtonWasClicked += Time.deltaTime;

        // Interpolating is a lot about getting the percent of something until its completion, get that percent of completion.
        float fractionComplete = timeSinceButtonWasClicked / timeTakenForColorShift;

        // Apply the color shift
        // Lerp the color from the starting color to the target color
        textToChange.color = Color.Lerp(originalColor, color, fractionComplete);


        // Lerp between the font size
        textToChange.fontSize = Mathf.Lerp(originalFontSize, finalFontSize, fractionComplete);


        // Clean up, this includes deallocation and resetting state variables.
        // Reset the variables if the transition is complete
        if (fractionComplete >= 1f)
        {
            timeSinceButtonWasClicked = 0f; // Keep this if we want the drink to repeat

        }


    }


    string chooseRandomVillagerDeathText()
    {

        string[] descriptions = new string[7];
        int randomIndex = UnityEngine.Random.Range(0, 7);

        descriptions[0] = "In the dark alley, a vampire descended upon an unsuspecting traveler. The vampire's fangs pierced the skin, and with a sinister grin, it drained all the blood, leaving the lifeless body to be found at dawn.";
        descriptions[1] = "A scholar who was researching vampires made a fatal mistake of staying overnight in the vampire's castle. The vampire found him, feasted on his blood until there was none left, and vanished into the shadows.";
        descriptions[2] = "A young woman, enchanted by the charm of a vampire, met her gruesome end as he sucked every drop of blood from her. Her pale, lifeless body was discovered the next day by a horrified friend.";
        descriptions[3] = "An old hunter, who had tracked vampires all his life, met his match one fateful night. Despite his experience, he was overpowered, and the vampire relished in sucking his blood slowly, savoring the victory.";
        descriptions[4] = "A couple lost in the woods stumbled upon a hungry vampire. The creature took its time with them, feasting on one and then the other, leaving their drained bodies as a grim testament to its ruthlessness.";
        descriptions[5] = "A vampire, awakened from its long slumber, found a thief in its lair. As punishment, it sucked the blood from the terrified thief in a matter of seconds, leaving nothing but a shriveled corpse.";
        descriptions[6] = "A child, lured by a vampire's hypnotic gaze, followed it into the night. The vampire drank the child's blood with a cruel pleasure, and the small, lifeless body was found the next morning, a grim reminder of the terror that lurks in the night.";

        return descriptions[randomIndex];



    }

}
