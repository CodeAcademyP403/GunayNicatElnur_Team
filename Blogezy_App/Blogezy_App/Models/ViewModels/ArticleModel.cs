using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogezy_App.Models.ViewModels
{
    public partial class ArticleModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Tags { get; set; }

        [DataType(DataType.Text)]
        public string UserApp { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string MetaKeywords { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string MetaDescription { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Detail { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
        
        public string PhotoPath { get; set; }

        public DateTime AddedDate { get; set; }
        public DateTime EditDate { get; set; }
    }

    public partial class ArticleModel
    {
        public static implicit operator Article(ArticleModel articleModel)
        {
            return new Article()
            {
                AddedDate = DateTime.Now,
                Description = articleModel.Description,
                Detail = articleModel.Detail,
                Id = articleModel.Id,
                MetaDescription = articleModel.MetaDescription,
                MetaKeywords = articleModel.MetaKeywords,
                Name = articleModel.Name,
                PhotoPath = articleModel.File.FileName,
                Tags = articleModel.Tags
                //,AuthorId = articleModel.Author
            };
        }
    }
}
