using System;
using MyBlog.Domain.Abstractions;
using MyBlog.Domain.Events;
// ReSharper disable ClassNeverInstantiated.Global

// ReSharper disable MemberCanBePrivate.Global

namespace MyBlog.Domain.UserAggregate
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User : Entity<long>, IAggregateRoot
    {
        /// <summary>
        /// 将无参数构造函数设为私有
        /// </summary>
        protected User()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nickname"></param>
        /// <param name="email"></param>
        /// <param name="tel"></param>
        /// <param name="isAdmin"></param>
        /// <param name="password"></param>
        /// <param name="address"></param>
        /// <param name="deleted"></param>
        /// <param name="createTime"></param>
        public User(string name, string nickname, string email, string tel, bool isAdmin, string password,
            Address address = default, bool deleted = default, DateTime createTime = default)
        {
            Name = name;
            Nickname = nickname;
            Email = email;
            Tel = tel;
            IsAdmin = isAdmin;
            Password = password;
            Address = address;
            Deleted = deleted;
            CreateTime = createTime == default ? DateTime.Now : createTime;
            
            AddDomainEvent(new UserCreatedDomainEvent(this));
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// 更新用户邮箱
        /// </summary>
        /// <param name="email"></param>
        public void ChangeEmail(string email)
        {
            Email = email;
            AddDomainEvent(new UserEmailChangedDomainEvent(this));
        }
    }
}