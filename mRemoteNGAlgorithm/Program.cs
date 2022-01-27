using System;

namespace mRemoteNGAlgorithm
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AskPath();
        }
        
        private static void AskPasswordToUser(ref string password)
        {
            Console.WriteLine("Enter master password (default : 123456)");

            var tempMasterPassword = Console.ReadLine();

            if (!string.IsNullOrEmpty(tempMasterPassword))
            {
                password = tempMasterPassword;
            }
        }

        private static void AskPasswordInDBToUser(ref string passwordInDB)
        {
            Console.WriteLine("Enter password in db (default : bkldAyHKzNnNLV0hVhi7kKrcKIGxWu2qUf4dw1gL5HI=)");

            var tempPasswordInDB = Console.ReadLine();

            if (!string.IsNullOrEmpty(tempPasswordInDB))
            {
                passwordInDB = tempPasswordInDB;
            }
        }

        private static void AskPlainPasswordToUser(ref string plainPassword)
        {
            Console.WriteLine("Enter plain password (default : testpassword)");

            var tempPlainPassword = Console.ReadLine();

            if (!string.IsNullOrEmpty(tempPlainPassword))
            {
                plainPassword = tempPlainPassword;
            }
        }

        private static void AskPath()
        {
            Console.WriteLine("Choose path ( default 0 = Decrypt , 1 = Encrypt");

            if (Console.ReadLine() == "1")
            {
                PathEncrypt();
            }
            else
            {
                PathDecrypt();
            }
            
            Console.WriteLine("Enter 1 for continue or 0 for exit");

            if (Console.ReadLine() == "1")
            {
                AskPath();
            }
        }

        private static void PathDecrypt()
        {
            string masterPassword = "123456";
            AskPasswordToUser(ref masterPassword);

            string passwordInDataBase = "bkldAyHKzNnNLV0hVhi7kKrcKIGxWu2qUf4dw1gL5HI=";
            AskPasswordInDBToUser(ref passwordInDataBase);

            MRemoteCrypter mRemoteCrypter = new MRemoteCrypter();

            Console.WriteLine("Encrypted Password is = " + mRemoteCrypter.decrypt(masterPassword, passwordInDataBase));
        }

        private static void PathEncrypt()
        {
            string masterPassword = "123456";
            AskPasswordToUser(ref masterPassword);

            string plainPassword = "testpassword";
            AskPlainPasswordToUser(ref plainPassword);

            MRemoteCrypter mRemoteCrypter = new MRemoteCrypter();

            Console.WriteLine("Encrypted Password is = " + mRemoteCrypter.encrypt(masterPassword, plainPassword));
        }
    }
}