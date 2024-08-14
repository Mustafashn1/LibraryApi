using APINEW.DATA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace APINEW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly NewApiApplicationContext _db;

        public BookController(NewApiApplicationContext context)
        {
            _db = context;
        }

        // CRUD işlemleri burada tanımla

        [HttpGet]
        public List<ToursEntity> GetAllTours() 
        { 
            return _db.Tours.ToList();
        }


        [HttpGet("{id} Gore Kitap Getir")]
        public async Task<IActionResult> GetToursDetails(int id)
        {
            if (id == 0)
            { 
                return BadRequest(); 
            }

            var book = await _db.Tours.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost("Kitap Ekle")]
        public ActionResult<ToursEntity> AddBook([FromBody] ToursEntity ToursDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            _db.Tours.Add(ToursDetails);
            _db.SaveChanges();
            return Ok(ToursDetails);
        }

        [HttpPost("Kitap Guncelle")]
        public ActionResult<ToursEntity> UpdateBook(Int32 id,
            [FromBody] ToursEntity ToursDetails)
        {
            if (ToursDetails == null)
            {
                return BadRequest(ToursDetails);
            }

            var toursDetails=_db.Tours.FirstOrDefault(x=>x.kitapid == id);
            if(toursDetails == null)
            {
                return NotFound();
            }

            toursDetails.kitapAd= ToursDetails.kitapAd;
            toursDetails.yazar= ToursDetails.yazar;
            toursDetails.tur= ToursDetails.tur;
            toursDetails.sayfa= ToursDetails.sayfa;

            _db.SaveChanges();
            return Ok(ToursDetails);
        }

        [HttpPut("Kitap Silme")]
        public ActionResult DeleteBook(int id)
        {
            var tourDetails = _db.Tours.FirstOrDefault(x => x.kitapid == id);
            if (tourDetails == null)
            {
                return NotFound();
            }

            _db.Tours.Remove(tourDetails);
            _db.SaveChanges();

            return NoContent();
        }


    }
}
