using Microsoft.AspNetCore.Mvc;

namespace ShoesShop.Web.Client.Areas.Admin.Controllers;

[Area("Admin")]
public class BaseAdminController : Controller
{
    [NonAction]
    protected ActionResult BadRequestResponse(string message)
    {
        /*
         * BadRequestObjectResult()
         * Dùng để tạo một HTTP response với mã trạng thái 400 Bad Request.
         * Thường được sử dụng khi có lỗi hoặc dữ liệu không hợp lệ trong yêu cầu từ client. Trả về thông điệp lỗi để thông báo cho client về sự cố xảy ra.
         */
        return new BadRequestObjectResult(message);
    }

    [NonAction]
    protected ActionResult NotFondResponse(string message)
    {
        /*
         * NotFoundObjectResult()
         * Dùng để tạo một HTTP response với mã trạng thái 404 Not Found.
         * Thường được sử dụng khi nguồn tài nguyên mà client yêu cầu không tồn tại hoặc không được tìm thấy. Trả về thông điệp lỗi để thông báo rằng tài nguyên không tồn tại.
         */
        return new NotFoundObjectResult(message);
    }

    [NonAction]
    protected ActionResult SuccessResponse(string message)
    {
        /*
         * ObjectResult()
         * Dùng để tạo một HTTP response với mã trạng thái mà bạn tự định nghĩa hoặc một mã trạng thái mặc định, ví dụ như 200 OK.
         * Thường được sử dụng khi bạn muốn trả về dữ liệu tùy chỉnh trong response. message trong ví dụ có thể là bất kỳ đối tượng nào, chẳng hạn dữ liệu JSON hoặc XML, để client có thể xử lý.
         */
        return new ObjectResult(message);
    }
}