using System;

namespace CodeTestApp.Pratices
{
  public class Participant
  {
    private readonly Mediator _mediator;
    public Participant(Mediator mediator)
    {
      mediator.Alert += Mediator_Alert;
      _mediator = mediator;
    }

    public int Value { get; private set; } = 0;

    private void Mediator_Alert(object sender, int e)
    {
      if (sender != this)
        Value += e;
    }

    public void Say(int n)
    {
      _mediator.EmmitValue(this, n);
    }
  }

  public class Mediator
  {
    public void EmmitValue(Participant participant, int value)
    {
      Alert?.Invoke(participant, value);
    }

    public event EventHandler<int> Alert;
  }
}
