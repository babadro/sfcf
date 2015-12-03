using System.Collections.Generic;
using sfcf.Domain.Entities;

namespace sfcf.WebUI.ViewModels
{
    public class VotingListData
    {
        public PagedList.IPagedList<Voting> Votings { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int? CurrentCategoryId { get; set; }
    }
}