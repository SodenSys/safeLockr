using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/encrypt", async (HttpContext context) =>
{
	string plainText = context.Request.Query["plainText"];
	await context.Response.WriteAsync("Encrypting.....");
	await Task.Delay(500);
	await DisplayRandomCharacters(context);
	string encryptedText = Encrypt(plainText);
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
	string decryptedText = Decrypt(encryptedText);
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

static string Encrypt(string plainText)
{
    StringBuilder encryptedTextBuilder = new();

    foreach (char X in plainText)
    {
        if (char.IsLetter(X))
        {
            char baseChar = char.IsUpper(X) ? 'A' : 'a';
            char encryptedChar = (char)(((X - baseChar + 6) % 26) + baseChar);
            encryptedTextBuilder.Append(encryptedChar);
        }
        else
        {
            encryptedTextBuilder.Append(X);
        }

        encryptedTextBuilder.Append(GetRandomSpecialCharacter());
    }

    return encryptedTextBuilder.ToString();
}

static string Decrypt(string inputToDecrypt)
{
    if (inputToDecrypt == null)
    {
        return "";
    }

    StringBuilder decryptedTextBuilder = new();

    for (int i = 0; i < inputToDecrypt.Length; i++)
    {
        if (i % 2 == 0 && char.IsLetter(inputToDecrypt[i]))
        {
            char baseChar = char.IsUpper(inputToDecrypt[i]) ? 'A' : 'a';
            char decryptedChar = (char)(((inputToDecrypt[i] - baseChar - 6 + 26) % 26) + baseChar);
            decryptedTextBuilder.Append(decryptedChar);
        }
        else if (i % 2 == 0)
        {
            decryptedTextBuilder.Append(inputToDecrypt[i]);
        }
    }

    return decryptedTextBuilder.ToString();
}

static char GetRandomSpecialCharacter()
{
    string specialCharacters = "!@$%^*()-_+[]{}|;:'\",.<>/";
    Random random = new();
    int randomIndex = random.Next(0, specialCharacters.Length);
    return specialCharacters[randomIndex];
}