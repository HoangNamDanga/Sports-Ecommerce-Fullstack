using System.Runtime.Serialization;

namespace WebSport24hNews.HoangNam.Core.Infrastructure
{
    // cung cấp một cách thống nhất để xử lý các lỗi cụ thể trong ứng dụng
    [Serializable]
    public class BaseException : Exception
    {
        public BaseException()
        {
        }


        //message : Một chuỗi chứa thông tin mô tả lỗi.
        public BaseException(string message)
             : base(message)
        {
        }


        //throw new BaseException("Lỗi xảy ra tại file '{0}', dòng {1}.", fileName, lineNumber);
        public BaseException(string messageFormat, params object[] args)
             : base(string.Format(messageFormat, args))
        {
        }

        //Mục đích : Constructor này được sử dụng trong quá trình serialization và deserialization của đối tượng exception.
        //Tham số:
        //info : Một đối tượng SerializationInfo chứa dữ liệu cần thiết để serialize hoặc deserialize đối tượng.
        // context : Một đối tượng StreamingContext chứa thông tin về nguồn hoặc đích của luồng tuần tự hóa.
        protected BaseException(SerializationInfo info, StreamingContext context)
             : base(info, context)
        {
        }


        //throw new BaseException("Không thể đọc file.", ex);
        public BaseException(string message, Exception innerException)
             : base(message, innerException)
        {
        }
    }
}
