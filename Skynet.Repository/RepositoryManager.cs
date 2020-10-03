using Skynet.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Skynet.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private SkynetContext _context;
        private IAirlineRepository _airlineRepository;
        private ICountryRepository _countryRepository;
        private IFlightRepository _flightRepository;
        private IUserRepository _userRepository;

        public RepositoryManager(SkynetContext context)
        {
            _context = context;
        }


        public IAirlineRepository Airline
        {
            get
            {
                if(_airlineRepository == null)
                    _airlineRepository = new AirlineRepository(_context);
                return _airlineRepository;
            }
        }

        public ICountryRepository Country
        {
            get
            {
                if(_countryRepository == null)
                    _countryRepository = new CountryRepository(_context);
                return _countryRepository;
            }
        }

        public IFlightRepository Flight
        {
            get
            {
                if(_flightRepository == null)
                    _flightRepository = new FlightRepository(_context);
                return _flightRepository;
            }
        }

        public IUserRepository User
        {
            get
            {
                if(_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }


        public Task SaveAsync() => _context.SaveChangesAsync();
    }

    public interface IRepositoryManager
    {
        IAirlineRepository Airline { get; }
        ICountryRepository Country {get;}
        IFlightRepository Flight {get;}
        IUserRepository User {get;}

        Task SaveAsync();
    }
}
