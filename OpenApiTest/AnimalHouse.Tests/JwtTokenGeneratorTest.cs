using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NUnit.Framework;

namespace AnimalHouse.Tests
{
    [TestFixture]
    public class JwtTokenGeneratorTest
    {
        [Test]
        public void GenerateJwt()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("af5b8f5e-ffd3-4bc2-84df-e027a0432974"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
 
            var token = new JwtSecurityToken(
                issuer: "Serhii Prostakov",
                audience: "Serhii Prostakov",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials,
                claims: new Claim[] { new("scope", "api animals.read animals.all") }
            );
 
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            Console.WriteLine(tokenString);
        }
    }
}