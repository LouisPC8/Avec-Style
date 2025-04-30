using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AvecStyle_Serveur.Data;
using AvecStyle_Serveur.Models;
using System.Text.RegularExpressions;
using AvecStyle_Serveur.Models.Enums;

namespace AvecStyle_Serveur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly AvecStyle_ServeurContext _context;

        public ArticlesController(AvecStyle_ServeurContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Outfit>>> GetOutfits(UserSetting us)
        {
            List<Article> filteredArticles = await _context.Article.Where(a => a.Gender == us.Gender && a.Style == us.Style).ToListAsync(); //La Shape n'est pas prise en compte

            var tops = filteredArticles.Where(a => a.Category == Category.Top).ToList();
            var bottoms = filteredArticles.Where(a => a.Category == Category.Bottom).ToList();
            var shoes = filteredArticles.Where(a => a.Category == Category.Shoes).ToList();
            var accessories = filteredArticles.Where(a => a.Category == Category.Accessory).ToList();

            var random = new Random();
            var outfits = new List<Outfit>();

            for (int i = 0; i < 5; i++)
            {
                var outfit = new Outfit
                {
                    Top = new ArticleDTO(tops[random.Next(tops.Count)]),
                    Bottom = new ArticleDTO(bottoms[random.Next(bottoms.Count)]),
                    Shoes = new ArticleDTO(shoes[random.Next(shoes.Count)]),
                    Accessory = new ArticleDTO(accessories[random.Next(accessories.Count)])
                };
                outfits.Add(outfit);
            }
            return Ok(outfits);
        }

        [HttpPost]
        public async Task<IActionResult> ReceiveRecommendations([FromBody] RecommendationRequest request)
        {
            if (request == null || request.Recommendations == null || !request.Recommendations.Any())
            {
                return BadRequest("Invalid recommendation data.");
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "recommendations.txt");

            try
            {
                // Open a StreamWriter to write the recommendations to the file
                using (var writer = new StreamWriter(filePath, append: true))
                {
                    foreach (var recommendation in request.Recommendations)
                    {
                        // Write each recommendation to the file
                        await writer.WriteLineAsync($"ArticleId: {recommendation.Id}");
                        await writer.WriteLineAsync($"ShopURL: {recommendation.ShopURL}");
                        await writer.WriteLineAsync($"ImageURL: {recommendation.ImageURL}");
                        await writer.WriteLineAsync(new string('-', 50)); // Separator
                    }
                }

                return Ok("Recommendations received and written to file successfully.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during file writing
                return StatusCode(500, $"An error occurred while writing to the file: {ex.Message}");
            }
        }

        // DTO for the incoming recommendation request
        public class RecommendationRequest
        {
            public int ArticleId { get; set; }
            public List<RecommendationDTO> Recommendations { get; set; }
        }

        // DTO for individual recommendations
        public class RecommendationDTO
        {
            public int Id { get; set; }
            public string ShopURL { get; set; }
            public string ImageURL { get; set; }
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Image>> GetPicture(int id)
        //{
        //    Image? i = await _context.Image.FindAsync(id);
        //    byte[] bytes;
        //    if (i == null){
        //        bytes = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/placeholder.png");
        //        return File(bytes, "image/png");
        //    }

        //    // Récupération du fichier sur le disque
        //    bytes = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/" + i.FileName);
        //    return File(bytes, i.MimeType);
        //}
    }
}
