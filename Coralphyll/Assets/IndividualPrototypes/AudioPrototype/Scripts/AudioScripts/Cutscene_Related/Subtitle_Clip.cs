using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class Subtitle_Clip : PlayableAsset
{
    public string subtitleText;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    { 
        var playable = ScriptPlayable<Subtitles_Script>.Create(graph);

        Subtitles_Script subtitles_Script = playable.GetBehaviour();
        subtitles_Script.subtitleText = subtitleText;
        return playable;
    }
}
