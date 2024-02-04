using static safeLockr.Program;

namespace safeLockr.Tests
{
	public class CryptTests
	{
		[Fact]
		public void EncryptTest()
		{
			// given
			string input = "aaa123";
			string expectedEncResult = "ggg123";

			using (StringReader sr = new StringReader(input))
			{
				SetIn(sr);

				// when
				string actualEncResult = Encrypt();

				// then
				Assert.Equal(expectedEncResult, actualEncResult);
			}
		}
		
        [Fact]
        public void DecryptTest()
        {
            // given
            string encryptedInput = "ggg123";
            string expectedDecResult = "aaa123";

            using (StringReader sr = new StringReader(encryptedInput))
            using (StringWriter sw = new StringWriter())
            {
                SetIn(sr);
                SetOut(sw);

                // when
                Decrypt();

                // then
                string consoleOutput = sw.ToString().Trim();
                Assert.Contains(expectedDecResult, consoleOutput);
            }
        }
	}
}