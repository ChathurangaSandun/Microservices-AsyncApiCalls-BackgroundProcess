using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WithHangFire.Services
{
    public interface IEmailService
    {
        Task SendMail();
    }
}
