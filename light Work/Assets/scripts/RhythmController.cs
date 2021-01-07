using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RhythmController : MonoBehaviour
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public double songBpm;

    //The number of seconds for each song beat
    public double secPerBeat;

    //Current song position, in seconds
    public double songPosition;

    //Current song position, in beats
    public double songPositionInBeats;

    //How many seconds have passed since the song started
    public double dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    //The offset to the first beat of the song in seconds
    public double firstBeatOffset;

    public List<double> beats;

    public int i;

    public GameObject myPrefab;

    public System.Random rnd = new System.Random();

    void Start()
    {
            //Load the AudioSource attached to the Conductor GameObject
    musicSource = GetComponent<AudioSource>();

    //Calculate the number of seconds in each beat
    secPerBeat = 60f / songBpm;

    //Record the time when the music starts
    dspSongTime = (double)AudioSettings.dspTime;

    beats = new List<double> { 3.0, 5.0, 6.5, 11.0, 13.5, 14, 14.5, 15.5 };
    i = 0;
    //Start the music
    musicSource.Play();
      
    }

    // Update is called once per frame
    void Update()
    {
    //determine how many seconds since the song started
    songPosition = (double)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

    //determine how many beats since the song started
    songPositionInBeats = (songPosition / secPerBeat);
    
    if (songPositionInBeats >= beats[i] - 2)
        {
            i++;
            Debug.Log(songPositionInBeats);
            Instantiate(myPrefab, spawnLocation(), Quaternion.identity);
        }
    }
    public Vector3 spawnLocation()
    {
        int spawnPos = rnd.Next(1, 7);
        switch (spawnPos)
        {
            case 1:
                return new Vector3((float)-2.629758, 0, 0);
                break;
            case 2:
                return new Vector3((float)2.629758, 0, 0);
                break;
            case 3:             
                return new Vector3((float)1.275, (float)2.3, 0);
                break;
            case 4:
                return  new Vector3((float)-1.275, (float)2.3, 0);
                break;
            case 5:
                return new Vector3((float)1.275, (float)-2.3, 0);
                break;
            case 6:
                return new Vector3((float)-1.275, (float)-2.3, 0);
                break;
            default:
                return new Vector3((float)-1.275, (float)-2.3, 0);
                break;
        }
    }
}