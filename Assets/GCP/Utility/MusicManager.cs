using System.Collections.Generic;
using UnityEngine;

namespace GCP.Utility
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> songList;

        private AudioSource musicPlayer;
        private List<AudioClip> unplayedSongs;
        private List<AudioClip> playedSongs;

        private int currentSongIndex = -1;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }


        private void Start()
        {
            musicPlayer = GetComponent<AudioSource>();
            musicPlayer.loop = false;
        
            unplayedSongs = new List<AudioClip>(songList);
            playedSongs = new List<AudioClip>();

            PlayNextSong();
        }

        public void PlayNextSong()
        {
            if (currentSongIndex != -1)
            {
                playedSongs.Add(unplayedSongs[currentSongIndex]);
                unplayedSongs.RemoveAt(currentSongIndex);
            }

            currentSongIndex = Random.Range(0, unplayedSongs.Count - 1);
            musicPlayer.clip = unplayedSongs[currentSongIndex];
            musicPlayer.Play();
            Invoke(nameof(PlayNextSong), unplayedSongs[currentSongIndex].length + 0.5f);
        }
    }
}