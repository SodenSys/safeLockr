using safeLockr;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/encrypt", async (HttpContext context) =>
{
    string plainText = context.Request.Query["plainText"];
    await context.Response.WriteAsync("Encrypting.....");
    await Task.Delay(500);
    await DisplayRandomCharacters(context);
    string encryptedText = CryptFunc.Encrypt(plainText);
    await context.Response.WriteAsync("\n\nEncrypted result: " + encryptedText);
    await context.Response.WriteAsync("\n\nEndpoint for encryption: /encrypt?plainText=<yourInputHere>");
    await context.Response.WriteAsync("\nEndpoint for decryption: /decrypt?encryptedText=<yourInputHere>");
});

app.MapGet("/decrypt", async (HttpContext context) =>
{
    string encryptedText = context.Request.Query["encryptedText"];
    await context.Response.WriteAsync("Decrypting.....");
    await Task.Delay(500);
    await DisplayRandomCharacters(context);
    string decryptedText = CryptFunc.Decrypt(encryptedText);
    await context.Response.WriteAsync("\n\nDecrypted result: " + decryptedText);
    await context.Response.WriteAsync("\n\nEndpoint for encryption: /encrypt?plainText=<yourInputHere>");
    await context.Response.WriteAsync("\nEndpoint for decryption: /decrypt?encryptedText=<yourInputHere>");
});

app.Run();


static async Task DisplayRandomCharacters(HttpContext context)
{
	string specialCharacters = "!@$%^*()_[]{}|;:'\",.<>/";
	Random random = new();
	for (int i = 0; i < 15; i++)
	{
		int randomIndex = random.Next(0, specialCharacters.Length);
		char randomSpecialChar = specialCharacters[randomIndex];
		await context.Response.WriteAsync(randomSpecialChar.ToString());
		await Task.Delay(50);
	}
}