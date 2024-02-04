namespace safeLockr;

public class Program
{
	public static void Main()
	{
		Encrypt();
		Thread.Sleep(2000);
		Decrypt();
	}
	public static string Encrypt()
	{
		Write("\nPlease enter a string to encrypt: ");
		string plainText = ReadLine()!;
		string encryptedText = "";
		
		foreach (char X in plainText)
		{
			if (char.IsLetter(X))
			{
				char baseChar = char.IsUpper(X) ? 'A' : 'a';
				char encryptedChar = (char)(((X - baseChar + 6) % 26) + baseChar);
				encryptedText += encryptedChar;
			}
			else
			{
				encryptedText += X;
			}
		}
		
		Write("Encrypting");
		
		for (int i = 0; i < 5; i++)
		{
			Write(".");
			Thread.Sleep(50);
		}
		
		for (int i = 0; i < 15; i++)
		{
			string specialCharacters = "!@#$%^&*()-=_+[]{}|;:'\",.<>/?";
			Random random = new Random();
			int randomIndex = random.Next(0, specialCharacters.Length);
			char randomSpecialChar = specialCharacters[randomIndex];
			Write(randomSpecialChar);
			Thread.Sleep(50);
		}
		
		WriteLine("\n\nEncrypted result: " + encryptedText);
		return encryptedText;
	}
	public static void Decrypt()
	{
		Write("\nPlease enter a string to decrypt: ");
		string inputToDecrypt = ReadLine()!;
		
		string decryptedText = "";
		foreach (char X in inputToDecrypt)
		{
			if (char.IsLetter(X))
			{
				char baseChar = char.IsUpper(X) ? 'A' : 'a';
				char decryptedChar = (char)(((X - baseChar - 6 + 26) % 26) + baseChar);
				decryptedText += decryptedChar;
			}
			else
			{
				decryptedText += X;
			}
		}

		Write("Decrypting");

		for (int i = 0; i < 5; i++)
		{
			Write(".");
			Thread.Sleep(50);
		}
		
		for (int i = 0; i < 15; i++)
		{
			string specialCharacters = "!@#$%^&*()-=_+[]{}|;:'\",.<>/?";
			Random random = new Random();
			int randomIndex = random.Next(0, specialCharacters.Length);
			char randomSpecialChar = specialCharacters[randomIndex];
			Write(randomSpecialChar);
			Thread.Sleep(50);
		}
		
		WriteLine("\n\nDecrypted result: " + decryptedText);
	}
}