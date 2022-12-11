using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_Kurs_API.Entities;
using AutoMapper;
using Users_Kurs_API.Models;
using System.Xml.Linq;

namespace Users_Kurs_API.Controller
{
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserController(UserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        #region user

        //Pobieranie WSZYTSKICH uzytkownikow

        [HttpGet("user")]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            var users = _dbContext
                .Users
                .Include(r => r.Address)
                .ToList();

            var usersDto = _mapper.Map<List<UserDto>>(users);
            return Ok(usersDto);
        }

        //Pobieranie JEDNEGO uzytkownika 
        [HttpGet("user/{id}")]
        public ActionResult<UserDto> GetById([FromRoute] int id)
        {
            var user = _dbContext
                .Users
                .Include(r => r.Address)
                .FirstOrDefault(x => x.Id == id);

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        //Usuwanie użytkowników
        [HttpDelete("user/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return Ok();
        }

        //Dodawanie uzytkownikow
        [HttpPost("user")]
        public ActionResult Add([FromBody] CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return Created($"/api/user/{user.Id}", null);
        }

        //Pobieranie użytkownika po imieniu
        //[HttpGet($"user/{name}")]
        //public ActionResult GetUserByName([FromRoute]string name)
        //{
        //    var user = _dbContext.Users.FirstOrDefault(x => x.Name == name);
        //    return Ok(user);
        //}

        #endregion

        #region address

        //Pobieranie WSZYSTKICH adresów

        [HttpGet("address")]
        public ActionResult<IEnumerable<Address>> GetAllAddress()
        {
            var addresses = _dbContext
                .Address
                .ToList();

            //var countId = addresses.Count();

            return Ok(addresses);

        }
        //Pobieranie JEDNEGO adresu

        [HttpGet("address/{id}")]
        public ActionResult<Address> GetAddress([FromRoute]int id)
        {
            var address = _dbContext
                .Address
                .FirstOrDefault(x => x.Id == id);
            
            return Ok(address);
        }
        //Usuwanie adresu

        [HttpDelete("address/{id}")]
        public ActionResult DeleteAddress([FromRoute]int id)
        {
            var deletedAddress = _dbContext.Address.FirstOrDefault(x => x.Id == id);
            _dbContext.Remove(deletedAddress);
            _dbContext.SaveChanges();

            return NoContent();
        }
       

        //Dodawanie adresu
        #endregion


    }


}

