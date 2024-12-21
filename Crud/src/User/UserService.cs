﻿using Crud.Data;
using Crud.src.User.dto;
using Microsoft.EntityFrameworkCore;

namespace Crud.src.User
{
    public class UserService
    {
        private readonly CrudDbContext _context;

        public UserService(CrudDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserEntity>> GetUsers()
        {
            List<UserEntity> result = await _context.Users.ToListAsync();
            return result;
        }

        public async Task<UserEntity?> GetUser(Guid id)
        {
            UserEntity? result = await _context.Users.FindAsync(id);
            return result;
        }

        public async Task PostUser(CreateUserDto user)
        {
            UserEntity userEntity = new UserEntity();

            userEntity.Name = user.Name;
            userEntity.Email = user.Email;
            userEntity.Password = user.Password;
            //userEntity.BirthDate = user.BirthDate;
            userEntity.PersonType = user.PersonType;
            userEntity.CityId = user.CityId;

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task PutUser(Guid id, CreateUserDto user)
        {
            UserEntity? userEntity = await _context.Users.FindAsync(id);

            if(userEntity == null) throw new Exception("User not found");

            userEntity.Name = user.Name;
            userEntity.Email = user.Email;
            userEntity.Password = user.Password;
            userEntity.BirthDate = user.BirthDate;
            userEntity.PersonType = user.PersonType;
            userEntity.CityId = user.CityId;

            _context.Users.Update(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(Guid id)
        {
            UserEntity? user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
