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

    beats = new List<double> {1, 3, 4.5, 9, 11, 13, 19, 20.5, 25, 26, 27, 32, 32.5, 33, 41.5, 42.5, 43.5, 45, 47, 48.5, 50, 51,
            53, 56, 58, 60, 62, 64, 66, 68, 70, 72, 73.5, 76, 79, 80, 82, 84, 86, 88, 90, 92, 93, 94,
            96, 98, 100, 101, 102, 102.5, 103, 104, 106, 108, 109.5, 114, 116, 118, 121, 122.5, 124,
            126, 128, 130, 133, 135, 137, 138, 140, 142, 144, 146, 148, 149.5, 151, 153, 155, 157, 160,
            162, 163, 166, 168, 170, 172, 174, 175, 176.5, 177, 178, 180, 182, 184, 185.5, 186, 188, 190,
            192, 194, 196, 197.5, 200, 202, 204.5, 206, 208, 210, 211.5, 212, 214, 216, 218, 220, 223.5, 224, 225,
            225.5, 226, 228, 228.5, 229, 230, 231, 231.5, 232, 232.5, 234, 236, 238, 240, 241, 242, 243, 244, 244.5,
            246, 248, 250, 252, 254, 256, 258, 260, 261, 262, 264, 266, 266.5, 267, 268, 270, 272, 273, 274, 276, 279,
            280, 281, 282, 283, 284, 286, 288, 290, 292, 293, 293.5, 294, 296, 298, 300, 301, 301.5, 302, 304, 305, 306,
            308, 309, 310, 312, 312.5, 313, 314, 316, 317, 318, 320, 321, 321.5, 322, 323, 324, 325, 326, 328, 330, 331, 332,
            334, 335, 335.5, 336, 337, 337.5, 338, 340, 341, 341.5, 342, 344, 345, 345.5, 346, 347, 348, 349, 350, 352, 352.5,
            353, 353.5, 354, 356, 358, 360, 362, 364, 366, 368, 370, 372, 374, 376, 378, 380, 382, 384, 386, 390, 391, 392, 393,
            394, 396, 398, 400, 402, 403, 404, 404.5, 406, 408, 410, 411, 412, 413, 416, 418, 419, 420, 424, 426, 427, 428,
            429, 429.5, 430, 431, 432, 433, 434, 435, 436, 437, 438, 438.25};
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
            Instantiate(myPrefab, SpawnLocation(), Quaternion.identity);
        }
    }
    public Vector3 SpawnLocation()
    {
        int spawnPos = rnd.Next(1, 7);
        switch (spawnPos)
        {
            case 1:
                return new Vector3((float)-2.629758, 0, 0);
            case 2:
                return new Vector3((float)2.629758, 0, 0);
            case 3:             
                return new Vector3((float)1.275, (float)2.3, 0);
            case 4:
                return  new Vector3((float)-1.275, (float)2.3, 0);
            case 5:
                return new Vector3((float)1.275, (float)-2.3, 0);
            case 6:
                return new Vector3((float)-1.275, (float)-2.3, 0);
            default:
                return new Vector3((float)-1.275, (float)-2.3, 0);
        }
    }
}