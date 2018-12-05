using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globamantics.Services
{
    public class ProposalMemoryService : IProposalService
    {
        public List<ProposalModel> proposals = new List<ProposalModel>();

        public ProposalMemoryService()
        {
            proposals.Add(new ProposalModel
            {
                Id = 1,
                ConferenceId = 1,
                Speaker = "Roland Guijt",
                Title = "Understanding .NET Core Security",
                Approved = false
            });
            proposals.Add(new ProposalModel
            {
                Id = 2,
                ConferenceId = 1,
                Speaker = "Roland Guijt",
                Title = "Understanding .NET Core 2.x",
                Approved = false
            });
            proposals.Add(new ProposalModel
            {
                Id = 3,
                ConferenceId = 2,
                Speaker = "Karam Malkon",
                Title = "Understanding React",
                Approved = false
            });
        }

        public Task Add(ProposalModel model)
        {
            model.Id = proposals.Max(p => p.Id) + 1;
            proposals.Add(model);
            return Task.CompletedTask;
        }

        public Task<ProposalModel> Approve(int proposalId)
        {
            return Task.Run(() =>
            {
                var proposal = proposals.FirstOrDefault(p => p.Id == proposalId);
                proposal.Approved = true;
                return proposal;
            });
        }

        public Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return Task.Run(() => proposals.Where(p => p.ConferenceId == conferenceId).AsEnumerable());
        }
    }
}
