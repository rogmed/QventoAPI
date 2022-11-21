namespace QventoAPI.Swagger
{
    public static class SwaggerBasicAuthMiddlewareExtension
    {
        public static IApplicationBuilder UseSwaggerAuthorized(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SwaggerBasicAuthMiddleware>();
        }
    }
}
