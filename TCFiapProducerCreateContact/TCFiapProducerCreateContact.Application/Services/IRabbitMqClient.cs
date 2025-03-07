using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCFiapProducerCreateContact.Core.Entities;

namespace TCFiapProducerCreateContact.Application.Services
{
    public interface IRabbitMqClient
    {
        Task PublicMessageCreate(Contact contact);

        Task PublicMessageUpdate(Contact contact);

    }
}
