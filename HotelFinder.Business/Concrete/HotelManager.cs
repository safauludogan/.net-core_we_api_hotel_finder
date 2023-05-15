using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;

namespace HotelFinder.Business.Concrete
{
	public class HotelManager : IHotelService
	{
		private IHotelRepository _hotelRepository;

		public HotelManager(IHotelRepository hotelRepository) {
			_hotelRepository = hotelRepository;
		}

		public async Task<Hotel> CreateHotel(Hotel hotel)
		{
			return await _hotelRepository.CreateHotel(hotel);	
		}

		public async Task<Hotel> DeleteHotel(int id)
		{
			 return await _hotelRepository.DeleteHotel(id);	
		}

		public async Task<List<Hotel>> GetAllHotels()
		{
			return await _hotelRepository.GetAllHotels();
		}

		public async Task<Hotel> GetHotelsById(int id)
		{
			if (id > 0)
			{
				return await _hotelRepository.GetHotelById(id);
			}
			throw new Exception("id cannot be less than 1");
			
		}

		public async Task<Hotel> GetHotelsByName(string name)
		{
			return await _hotelRepository.GetHotelByName(name);
		}

		public async Task<Hotel> UpdateHotel(Hotel hotel)
		{
			return await _hotelRepository.UpdateHotel(hotel);	
		}
	}
}
