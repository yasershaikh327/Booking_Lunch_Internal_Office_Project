using Microsoft.AspNetCore.Mvc.Filters;

public class MyCustomExceptionFilter : ExceptionFilterAttribute, IExceptionFilter
{
    public override void OnException(ExceptionContext context)
    {
        if(context.Exception.GetType().Equals(typeof(KeyNotFoundException)))
            throw new ModelStateInvalidException();
        if (context.Exception.GetType().Equals(typeof(KeyNotFoundException)))
            throw new PageNotFoundException();
        if (context.Exception.GetType().Equals(typeof(KeyNotFoundException)))
            throw new MethodNotAllowedException();
        if (context.Exception.GetType().Equals(typeof(KeyNotFoundException)))
            throw new InternalServerErrorException();
    }
}