using System;

public class A
{
    public void M1(bool a, bool b)
    {
        try
        {
            if (a) // +1
            {
                
                for (int i = 0; i < 10; i++) // +2 (N=1)
                {
                    
                    while (b) // +3 (N=2)
                    {
                    } 
                }
            }
        }
        catch (Exception e) // +1
        {
            if (b) // +2 (N=1)
            {
            }
        }
    }
 
    public void M2()
    {
        if (true) // +1
        {
            try { throw new Exception("ErrorType1"); }
            catch (IndexOutOfRangeException ex) // +2 (N=1)
            {
            }
        }
    }
    
    public void M3()
    {
        if (true) // +1
        {
            try { throw new Exception("ErrorType1"); }
            catch (Exception ex) when (ex.Message == "ErrorType2") // +2+1 (N=1)
            {
            }
        }
    }
    
    public void M4()
    {
        if (true) // +1
        {
            try { throw new Exception("ErrorType1"); }
            catch (Exception ex) // +2 (N=1)
            {
                if (ex.Message == "ErrorType3") // +3 (N=2)
                {
                }
            }
        }
    }
}
