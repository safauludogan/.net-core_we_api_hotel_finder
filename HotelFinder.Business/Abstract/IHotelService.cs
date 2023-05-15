using HotelFinder.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Abstract
{
	public interface IHotelService
	{
		Task<List<Hotel>> GetAllHotels();
		Task<Hotel> GetHotelsById(int id);
		Task<Hotel> GetHotelsByName(string name);
		Task<Hotel> CreateHotel(Hotel hotel);
		Task<Hotel> UpdateHotel(Hotel hotel);
		Task<Hotel> DeleteHotel(int id);	
	}
}
