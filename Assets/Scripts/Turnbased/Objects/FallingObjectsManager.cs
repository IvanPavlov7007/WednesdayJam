using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectsManager : TurnListenerObject
{
    public GameObject prefab;
    public List<Transform> tracks;
    public float frequency;
    public int maxTurnFrequency;

    private void Awake()
    {
        tracks = new List<Transform>(GetComponentsInChildren<Transform>());
        tracks.Remove(transform);
    }

    private void Start()
    {
        TimeFlowManager.Instance.onPlayerMakeTurn += onTurn;
    }

    public override void onTurn(TurnOption turn)
    {
        int count = Mathf.Min( Mathf.RoundToInt(Random.Range(0, frequency)), tracks.Count);
        int[] allocatedTracks = new int[tracks.Count];
        for (int i = 0; i < tracks.Count; i++)
        {
            allocatedTracks[i] = -1;
        }
        for(int i = 0; i < count; i++)
        {
            int pos = Random.Range(0, tracks.Count - 1);
            while(allocatedTracks[pos] > 0)
            {
                if (pos < count)
                    pos++;
                else
                    pos = 0;
            }
            allocatedTracks[pos] = 1;

            Instantiate(prefab, tracks[pos].position, Quaternion.identity);
        }
    }
}
