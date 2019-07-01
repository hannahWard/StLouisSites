using StLouisSites.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.ViewModels.Category
{
    public class CategoryCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Persist(RepositoryFactory repositoryFactory)
        {
            Models.Category category = new Models.Category
            {
                Id = this.Id,
                Name = this.Name,
            };
            repositoryFactory.GetCategoryRepository().Save(category);
        }
    }
}
