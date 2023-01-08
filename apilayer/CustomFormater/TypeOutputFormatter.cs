using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using ModelsLayer;

public class TypeOutputFormatter : TextOutputFormatter
{
    public TypeOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/dtotoken"));

        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    protected override bool CanWriteType(Type? type)
        => typeof(DTOToken).IsAssignableFrom(type)
            || typeof(IEnumerable<DTOToken>).IsAssignableFrom(type);
    

    public override async Task WriteResponseBodyAsync(
        OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var httpContext = context.HttpContext;
        var serviceProvider = httpContext.RequestServices;

        var logger = serviceProvider.GetRequiredService<ILogger<TypeOutputFormatter>>();
        var buffer = new StringBuilder();

        if (context.Object is DTOToken token)
        {
            FormatToken(buffer, token, logger);
        }
        else
        {
            FormatToken(buffer, (DTOToken)context.Object!, logger);
        }

        await httpContext.Response.WriteAsync(buffer.ToString(), selectedEncoding);
    }

    private static void FormatToken(StringBuilder buffer, DTOToken token, ILogger logger)
    {   
        buffer.AppendLine($"Token :{token.Token};");

        logger.LogInformation("Writing Token " , token.Token);
    }
}