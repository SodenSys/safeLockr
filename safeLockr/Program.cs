using safeLockr;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (HttpContext context) =>
{
	context.Response.ContentType = "text/html";
	await context.Response.WriteAsync("<body style='background-color: black; color: white;'>");
	await context.Response.WriteAsync("<p style='font-size: 20px;'>Endpoint for encryption: <a href='http://safelockrapi-env.eba-d2idsiid.eu-north-1.elasticbeanstalk.com/encrypt?plainText=' style='color: cyan;'>http://safelockrapi-env.eba-d2idsiid.eu-north-1.elasticbeanstalk.com/encrypt?plainText=</a></p>");
	await context.Response.WriteAsync("<p style='font-size: 20px;'>Endpoint for decryption: <a href='http://safelockrapi-env.eba-d2idsiid.eu-north-1.elasticbeanstalk.com/decrypt?encryptedText=' style='color: cyan;'>http://safelockrapi-env.eba-d2idsiid.eu-north-1.elasticbeanstalk.com/decrypt?encryptedText=</a></p>");
	await context.Response.WriteAsync("</body>");
});

app.MapGet("/encrypt", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html";
    var plainTextValue = context.Request.Query["plainText"].FirstOrDefault();

    if (!string.IsNullOrWhiteSpace(plainTextValue))
    {
        string encryptedText = CryptFunc.Encrypt(plainTextValue);
        await context.Response.WriteAsync("<body style='background-color: black; color: white;'>");
        await context.Response.WriteAsync($"<p style='font-size: 30px;'>Encrypted result: {encryptedText}</p>");
        await context.Response.WriteAsync("</body>");
    }
    else
    {
        await context.Response.WriteAsync("<body style='background-color: black; color: white;'>");
        await context.Response.WriteAsync("<p style='font-size: 30px;'>Please enter a string to encrypt.</p>");
        await context.Response.WriteAsync("</body>");
    }
});


app.MapGet("/decrypt", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html";
    var encryptedTextValue = context.Request.Query["encryptedText"].FirstOrDefault();

    if (!string.IsNullOrWhiteSpace(encryptedTextValue))
    {
        string decryptedText = CryptFunc.Decrypt(encryptedTextValue);
        await context.Response.WriteAsync("<body style='background-color: black; color: white;'>");
        await context.Response.WriteAsync($"<p style='font-size: 30px;'>Decrypted result: {decryptedText}</p>");
        await context.Response.WriteAsync("</body>");
    }
    else
    {
        await context.Response.WriteAsync("<body style='background-color: black; color: white;'>");
        await context.Response.WriteAsync("<p style='font-size: 30px;'>Please enter a string to decrypt.</p>");
        await context.Response.WriteAsync("</body>");
    }
});

app.Run();