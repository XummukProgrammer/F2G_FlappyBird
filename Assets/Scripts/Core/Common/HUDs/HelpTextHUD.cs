using System.Collections.Generic;
using UnityEngine;

public class HelpTextHUDOutput
{
    public string Text { get; private set; }
    public float Delay { get; private set; }

    public void Init(string text, float delay)
    {
        Text = text; 
        Delay = delay;
    }
}

public class HelpTextHUD : HUD
{
    private List<HelpTextHUDOutput> _outputs = new();
    HelpTextHUDOutput _currentOutput;
    private float _time = 0;

    public void AddOutput(string text, float delay)
    {
        var output = new HelpTextHUDOutput();
        output.Init(text, delay);
        _outputs.Add(output);

        if (_currentOutput == null)
        {
            SetCurrentOutput(output);
        }
    }

    private void ChangeCurrentOutput()
    {
        if (_outputs.Count > 0)
        {
            _outputs.RemoveAt(0);

            if (_outputs.Count > 0)
            {
                SetCurrentOutput(_outputs[0]);
            }
            else
            {
                _currentOutput = null;
                SetText("");
            }
        }
    }

    private void SetCurrentOutput(HelpTextHUDOutput output)
    {
        _currentOutput = output;
        SetText(_currentOutput.Text);
    }

    private void SetText(string text)
    {
        var behaviour = GetBehaviour<HelpTextHUDBehaviour>();
        if (behaviour)
        {
            behaviour.SetText(text);
        }
    }

    protected override void OnShow()
    {
        base.OnShow();

        SetText("");
    }

    public override void OnUpdate()
    {
        if (_currentOutput != null)
        {
            _time += Time.deltaTime;

            if (_time > _currentOutput.Delay)
            {
                _time = 0;
                ChangeCurrentOutput();
            }
        }
    }
}
