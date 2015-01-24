﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class sequenceManager : MonoBehaviour {



    public List<sequence> sequences = new List<sequence>();

    public bool playerOne = false,  playerTwo = false, playerThree = false, playerFour = false;
    bool playerOneOnce = false, playerTwoOnce = false, playerThreeOnce = false, playerFourOnce = false;

    Station station;
    int lengths, completed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (playerOne == true && playerOneOnce == false) // Checking if player one has completed their sequence
        {
            completed++;
            playerOneOnce = true;
        }
        if (playerTwo == true && playerTwoOnce == false) // Checking if player two has completed their sequence
        {
            completed++;
            playerTwoOnce = true;
        }
        if (playerThree == true && playerThreeOnce == false) // Checking if player three has completed their sequence
        {
            completed++;
            playerThreeOnce = true;
        }
        if (playerFour == true && playerFourOnce == false) // Checking if player four has completed their sequence
        {
            completed++;
            playerFourOnce = true;
        }

        if (PlayerPrefs.GetInt("Player Count") == completed) // If amount of players that have completed equals the amount of players triggers stations being fixed
        {
            station.FixStation(1); // Fixes station

            // Resetting all the bools and int used to calculate total completed
            playerOne = false;
            playerTwo = false;
            playerThree = false;
            playerFour = false;

            playerOneOnce = false;
            playerTwoOnce = false;
            playerThreeOnce = false;
            playerFourOnce = false;

            completed = 0;
            
            station = null; // Resets station so that a broken station can overwrite
        }
	
	}

    public void sequnceStation(int length, Station stationH) // Station sequence so that station and length can be passed without needing each character to have a copy of these when they call for a new sequence
    {
        Debug.Log("Found You");

        station = stationH; // Adds passed station to locally held station

        lengths = length; // Adds passed length to the locally held int

        sequence(); // Starts sequence
    }

    public void sequence() // Randomly picks the sequence of events
    {
        // Resetting all the bools and int used to calculate total completed
        playerOne = false;
        playerTwo = false;
        playerThree = false;
        playerFour = false;

        playerOneOnce = false;
        playerTwoOnce = false;
        playerThreeOnce = false;
        playerFourOnce = false;

        completed = 0;

        int[] sequenceI = new int[lengths]; // Creates sequence array of length of passed int

        for (int i = 0; i < sequenceI.Length; i++)
        {
            sequenceI[i] = UnityEngine.Random.Range(0, 6); // Creates a random int between 0 and 5
            // 0 = A, 1 = B, 2 = X, 3 = Y, 4 = Left Shoulder, 5 = Right Shoulder
        }

        Debug.Log(string.Join("+", Array.ConvertAll<int, String>(sequenceI, Convert.ToString))); // Debug output of sequence

        foreach (sequence hold in sequences) // Passes sequence to each character
        {
            hold.sequenceI = sequenceI;
            hold.length = lengths;
        }

        //sequenceOutput(length, sequenceI); // Calls the output method to output to screen and wait for users input
    }
}
