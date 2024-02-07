namespace safeLockr.Tests
{
    public class CryptTests
    {
        [Fact]
        public void EncryptDecryptTest()
        {
            // given
            string originalInput = "aaa123";

            // when
            string encryptedOutput = CryptFunc.Encrypt(originalInput);
            string decryptedOutput = CryptFunc.Decrypt(encryptedOutput);

            // then
            Assert.Equal(originalInput, decryptedOutput);
        }
    }
}
