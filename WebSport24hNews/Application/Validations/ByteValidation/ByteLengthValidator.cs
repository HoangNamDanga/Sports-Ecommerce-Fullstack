using System.Text;

namespace WebSport24hNews.Application.Validations.ByteValidation
{
    public class ByteLengthValidator
    {
        public static bool BeValidLength(string input, int maxBytes)
        {
            if (string.IsNullOrEmpty(input)) return true;


            // Chuyển chuỗi thành mảng byte
            byte[] byteArray = Encoding.UTF8.GetBytes(input);

            return byteArray.Length <= maxBytes;
        }
    }
}
