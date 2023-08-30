using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Runtime.CompilerServices;
using System.CodeDom.Compiler;

public class MainText : MonoBehaviour
{


    // Parameters

    // Fade Parameters
    [SerializeField] float fadeInDuration = 5f;
    [SerializeField] float fadeOutDuration = 5f;

    // Cache
    TextMeshProUGUI mainTextSection = null;


    // State
    bool isAnimating = false; // master control boolean can be broken up for layered animations later.
    float originalAlpha = 0f;

    // Fade Transitions
    float targetFadeInAlpha = 1f;
    float targetFadeOutAlpha = 0f;
    float fadeInStartTime = 0f;
    float fadeOutStartTime = 0f;


    bool initialized = false;
    
    // Start is called before the first frame update
    void Start()
    {
        mainTextSection = GetComponent<TextMeshProUGUI>();
        originalAlpha = mainTextSection.color.a;
        displayStoryLine();
        StartCoroutine(TransitionToNextPage()); // Done becuase .textInfo.pageCount does not initialize correctly on Start() .
    }


   
    // Update is called once per frame
    void Update()
    {
        // Declare and initialize variables
        // if player hp is not 0 

        // StoryLine

        // Events 
        // Combat
        // Interesting happenings
        // Randomized events: 

        // Player Input

        // Update Story Line Parameters: Characters, Stats, BloodThirst, Curses, Gifts, Items, 

        // If player hp == 0, defeat story summary

        // Repeat

        /*if (animation.peek().complete)
            currentAnimation = animation.pop();
        else
            currentAnimation.update();*/

        


        

    }

    void displayStoryLine()
    {

        // Declare and initialize variables
        int getNumberOfCharactersInStorySection = 0;

        string blockOfStory = " In the heart of the village, where the cobblestone paths wound through quaint cottages, a peculiar atmosphere clung to the air like a mist. The first rays of dawn painted the sky with hues of orange and pink, casting a warm glow upon the sleepy streets. Each structure stood as a testament to time's passage, their timeworn facades carrying whispers of generations long past.\r\n\r\nAmidst this tranquil setting, a figure emerged, a girl named Dracula. She seemed to blend seamlessly with the surroundings, her presence both enigmatic and ordinary. Her raven-black hair cascaded down her back, and her attire, simple and rustic, reflected the essence of village life. As she walked, the scent of freshly baked bread wafted from nearby bakeries, mingling with the earthy fragrance of dew-kissed flowers.\r\n\r\n";

        mainTextSection.text = blockOfStory;
    }

    int getCurrentPage()
    {
        return mainTextSection.pageToDisplay;
    }

    public IEnumerator TransitionToNextPage()
    {

        yield return StartCoroutine(transitionAway());

        goToNextPage();

        yield return StartCoroutine(transitionIn());

    }

    void goToNextPage()
    {
        // StartCoRoutine, after the transitionAway() then transitionIn

        if ( mainTextSection.pageToDisplay < mainTextSection.textInfo.pageCount)
        {

            mainTextSection.pageToDisplay++;
            
        }
        else
            mainTextSection.pageToDisplay = 1;  // Loop back to the first page
    }

    void goToPreviousPage()
    {
        if (mainTextSection.pageToDisplay > 1)
            mainTextSection.pageToDisplay--;
        else
            mainTextSection.pageToDisplay = 1; 

    }

    public IEnumerator transitionAway()
    {
        // Declare and initialize variables
        float fractionComplete = 0f;
        float currentAlpha = mainTextSection.color.a;


        // Originial opacity stored



        // While the opacity is not zero we can transition away, if it is zero, then transition away is being used incorrectly
        while(mainTextSection.color.a > targetFadeOutAlpha)
        {


            // Add time to fade start time, because the fade i.e. the transition away has been called. 
            fadeOutStartTime += Time.deltaTime;


            // Calculate the fraction complete
            fractionComplete = fadeOutStartTime / fadeOutDuration;

            // Get current color(all colors have alpha values-channels).
            Color endingColor = mainTextSection.color;

            // The text is present with full opacity, now it is time to transition the opacity with a lerp from 1 to zero.
            endingColor.a = Mathf.Lerp(currentAlpha, targetFadeOutAlpha, fractionComplete);

            // Set main text section's color to the ending color.
            mainTextSection.color = endingColor;

            yield return null;



        }

        fadeOutStartTime = 0;
        Debug.Log("Transition Away ended");
        


    }

    public IEnumerator transitionIn()
    {
        // Declare and initialize variables

        float fractionComplete = 0f;
        
        float currentAlpha = mainTextSection.color.a;


        while (mainTextSection.color.a < targetFadeInAlpha)
        {

            // Add time to the fade in
            fadeInStartTime += Time.deltaTime;

            // Calculate the fraction complete
            fractionComplete = fadeInStartTime / fadeInDuration;

            // Get the current color in order to store the alpha channel
            Color endingColor = mainTextSection.color;

            endingColor.a = Mathf.Lerp(currentAlpha, targetFadeInAlpha, fractionComplete);

            // Set the main text section's color
            mainTextSection.color = endingColor;




            yield return null;
        }

        fadeInStartTime = 0;
        Debug.Log("Transition In ended");
    }

}
