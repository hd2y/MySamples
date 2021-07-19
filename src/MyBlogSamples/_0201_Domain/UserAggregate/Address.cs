using System.Collections.Generic;
using MyBlog.Domain.Abstractions;

// ReSharper disable MemberCanBePrivate.Global

namespace MyBlog.Domain.UserAggregate
{
    /// <summary>
    /// 地址
    /// </summary>
    public class Address : ValueObject
    {
        /// <summary>
        /// 将无参数构造函数设为私有
        /// </summary>
        protected Address()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <param name="street"></param>
        /// <param name="zipCode"></param>
        public Address(string country, string city, string street, string zipCode)
        {
            Country = country;
            City = city;
            Street = street;
            ZipCode = zipCode;
        }

        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; private set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; private set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string ZipCode { get; private set; }

        /// <summary>
        /// 获取原子值
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Country;
            yield return City;
            yield return Street;
            yield return ZipCode;
        }
    }
}