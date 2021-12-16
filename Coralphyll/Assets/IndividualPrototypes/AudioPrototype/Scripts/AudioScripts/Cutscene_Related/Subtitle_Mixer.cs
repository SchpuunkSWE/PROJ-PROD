using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;
public class Subtitle_Mixer : AkEventPlayableBehavior
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        string currentText = "";
        float currentAlpha = 0f;

        if (!text) { return; }

        int inputCount = playable.GetInputCount();
        for(int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);

            if(inputWeight > 0f)
            {
                ScriptPlayable<Subtitles_Script> inputPlayable = (ScriptPlayable<Subtitles_Script>)playable.GetInput(i);

                Subtitles_Script input = inputPlayable.GetBehaviour();
                currentText = input.subtitleText;
                currentAlpha = inputWeight;
            }
        }

        text.text = currentText;
        text.color = new Color(1, 1, 1, currentAlpha);
    }
}
