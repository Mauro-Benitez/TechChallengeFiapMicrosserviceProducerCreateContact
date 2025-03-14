﻿using TechChallengeFiap.Messages;

namespace TCFiapProducerCreateContact.Application.Services
{
    public interface IRabbitMqClient
    {
        Task PublicMessageCreate(CreateContactMessage contact);

        Task PublicMessageUpdate(UpdateContactMessage contact);

        Task PublicMessageDelete(RemoveContactMessage id);

    }
}
