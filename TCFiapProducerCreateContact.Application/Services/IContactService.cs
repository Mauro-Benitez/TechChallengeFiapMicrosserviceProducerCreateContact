using TCFiapProducerCreateContact.Application.Inputs;

namespace TCFiapProducerCreateContact.Application.Services
{
    public interface IContactService
    {
        Task CreateContactAsync(CreateContactInputModel contactInput);

        Task UpdateContactAsync(UpdateContactInputModel contactInput);

        Task DeleteContactAsync(Guid id);

    }
}
