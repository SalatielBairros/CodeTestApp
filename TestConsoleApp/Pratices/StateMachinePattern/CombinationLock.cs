namespace CodeTestApp.Pratices.StateMachinePattern
{
  public class CombinationLock
  {
    public string Status;
    private readonly int[] _combination;
    private int informedCountIndex = 0;

    public CombinationLock(int[] combination)
    {
      _combination = combination;
      Lock();
    }

    public void Lock()
    {
      Status = "LOCKED";
      informedCountIndex = 0;
    }

    public void EnterDigit(int digit)
    {
      if (informedCountIndex == 0) Status = string.Empty;
      if (_combination[informedCountIndex] != digit)
      {
        Status = "ERROR";
      }
      else if ((informedCountIndex + 1) == _combination.Length)
      {
        Status = "OPEN";
      }
      else
      {
        Status += digit;
        informedCountIndex++;
      }
    }
  }
}
