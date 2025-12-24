using EasyCaching.Core;

namespace WebSport24hNews.HoangNam.Service.Caching
{
    public interface IHybridCachingManager
    {
        //Cung cấp khả năng sử dụng cache theo kiểu hybrid (kết hợp cả in-memory và redis).
        IHybridCachingProvider HybridCachingProvider { get; }

        bool IsConnectedRedis { get; } // Kiểm tra xem hiện tại có kết nối được với Redis không (để fallback nếu cần)

        IEasyCachingProvider Inmemory { get; }  // Truy cập trực tiếp cache in-memory hoặc Redis riêng biệt nếu cần.

        IRedisCachingProvider Redis { get; }




        // Các phương thức thao tác cache:
        Task<IEnumerable<string>> GetAllKeysMemoryCache(string prefix); // 🔑 Lấy tất cả các key:
        Task<IEnumerable<string>> GetAllKeysRedis(string prefix); // → Dùng để lấy danh sách tất cả các keys đang được lưu trong cache theo prefix, tiện cho thống kê hoặc xóa hàng loạt.


        Task<T> GetDataInMemory<T>(string prefix); //  Lấy dữ liệu trực tiếp:
        Task<T> GetDataRedis<T>(string prefix); // → Truy xuất dữ liệu cache trực tiếp từ in-memory hoặc redis.





        //Những hàm "Get or Set" thông minh:
        //Nếu có thì lấy từ cache, nếu không thì gọi Func<T> để lấy data và lưu vào cache:
        //Check cache có chưa.
        //Nếu có → trả về.
        // Nếu không → gọi userService.GetAllAsync(), lưu vào cache, rồi trả về.
        T GetDb<T>(string key, Func<T> acquirer, int? cacheTime = null);
        // Dùng khi bạn đang trong context đồng bộ (không dùng async/await).
        T GetDb<T>(string key); // Dùng khi bạn chỉ muốn đọc cache, không muốn xử lý nếu không có.


        //📌 Đây là method phổ biến nhất khi làm việc với cache trong môi trường thực tế.
        Task<T> GetDbAsync<T>(string key, Func<Task<T>> acquirer, int? cacheTime = null);
        //Nếu không có dữ liệu trong cache → chạy acquirer() rồi lưu cache

        Task<T> GetDbAsync<T>(string key); // Không lưu gì vào cache
        // Dùng khi bạn chỉ muốn đọc nhẹ nhàng trong các API hoặc xử lý logic mà không muốn sinh dữ liệu mới.


        Task<T> GetDbInMemoryAsync<T>(string key, Func<Task<T>> acquirer, int? cacheTime = null); // Y như GetDbAsync, nhưng chỉ dùng cache in-memory,Không động tới Redis
        // Dùng khi bạn không muốn cache phân tán, ví dụ trong app console, desktop, hoặc trong test/local dev.



        Task<T> GetDbRedisAsync<T>(string key, Func<Task<T>> acquirer, int? cacheTime = null); // Y như GetDbAsync, nhưng chỉ làm việc với Redis, Không lưu hay đọc từ in-memory
        // Dùng cho các hệ thống cần cache chia sẻ giữa nhiều server (distributed)

    }
}
