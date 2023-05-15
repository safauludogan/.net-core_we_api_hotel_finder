using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HotelsController : ControllerBase
	{
		private IHotelService _hotelService;
		public HotelsController(IHotelService hotelService)
		{
			_hotelService = hotelService;
		}
		/// <summary>
		/// Get All Hotels
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var hotels = await _hotelService.GetAllHotels();
			return Ok(hotels);//200 + hotel
		}

		[HttpGet]
		[Route("[action]/{id}")]//api/hotels/gethotelsbyid/2
		public async Task<IActionResult> GetHotelById(int id)
		{
			var hotel = await _hotelService.GetHotelsById(id);
			if (hotel != null)
			{
				return Ok(hotel);
			}
			return NotFound();//404
		}

		[HttpGet]
		[Route("[action]/{name}")]//api/hotels/gethotelsbyname/safa
		public async Task<IActionResult> GetHotelByName(string name)
		{
			var hotel = await _hotelService.GetHotelsByName(name);
			if (hotel !=null)
			{
				return Ok(hotel);
			}
			return NotFound();
		}

		[HttpGet]
		[Route("[action]")]//GetHotelByNameAndId? id = 2 & name = alara
		public async Task<IActionResult> GetHotelByNameAndId(int id,string name)
		{
			return Ok();
		}

		[HttpPost]
		[Route("CreateHotel")]
		public async Task<IActionResult> CreateHotel([FromBody]Hotel hotel)
		{		
			var createdHotel =await _hotelService.CreateHotel(hotel);
			return CreatedAtAction("Post",new { id=createdHotel.Id},createdHotel);	
		}

		[HttpPut]
		[Route("[action]")]
		public async Task<IActionResult> UpdateHotel([FromBody] Hotel hotel)
		{
			if (await _hotelService.GetHotelsById(hotel.Id) != null)
			{
				return Ok(await _hotelService.UpdateHotel(hotel));
			}		
			return NotFound();
		}

		[HttpDelete]
		[Route("[action]/{id}")]
		public async Task<IActionResult> DeleteHotel(int id)
		{
			if (_hotelService.GetHotelsById(id) != null)
			{
				await _hotelService.DeleteHotel(id);
				return Ok();
			}
			return NotFound();
		}

	}
}
