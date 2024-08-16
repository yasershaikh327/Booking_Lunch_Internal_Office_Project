
public class ModelStateInvalidException : Exception
{
    public ModelStateInvalidException()
    {
    }

    public ModelStateInvalidException(string message) : base(message)
    {
    }
}


public class PageNotFoundException : Exception
{
    public PageNotFoundException()
    {
    }

    public PageNotFoundException(string message) : base(message)
    {
    }
}

public class KeyNotFoundException : Exception
{
    public KeyNotFoundException()
    {
        
    }

    public KeyNotFoundException(string message) : base(message)
    {
    }
}

public class InternalServerErrorException : Exception
{
    public InternalServerErrorException()
    {
    }    
    public InternalServerErrorException(string message) : base(message)
    {
    }
}


public class MethodNotAllowedException : Exception
{
    public MethodNotAllowedException()
    {
    }

    public MethodNotAllowedException(string message) : base(message)
    {
    }
}