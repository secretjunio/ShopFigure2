using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMohinh.Models;

namespace ShopMohinh.Service
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
