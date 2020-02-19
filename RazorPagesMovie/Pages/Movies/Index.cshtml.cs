using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(RazorPagesMovieContext _context, ILogger<IndexModel> _logger)
        {
            this._context = _context;
            this._logger = _logger;
        }

        public IList<Movie> Movie { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            
            var movies = from m in _context.Movie select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }
            
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            Movie = await movies.ToListAsync();
        }
    }
}