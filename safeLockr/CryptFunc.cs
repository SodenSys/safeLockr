using System.Text;

namespace safeLockr
{
	public static class CryptFunc
	{
		public static string Encrypt(string plainText)
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
		public static string Decrypt(string inputToDecrypt)
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
		public static char GetRandomSpecialCharacter()
		{
			string specialCharacters = "!@$%^*()-_+[]{}|;:'\",.<>/";
			Random random = new();
			int randomIndex = random.Next(0, specialCharacters.Length);
			return specialCharacters[randomIndex];
		}
	}
}