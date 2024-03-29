﻿using MediatR;

// ReSharper disable MemberCanBePrivate.Global

namespace MyBlog.Api.Application.Commands
{
    /// <summary>
    /// 创建用户
    /// </summary>
    public class CreateUserCommand : IRequest<long>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nickname"></param>
        /// <param name="email"></param>
        /// <param name="tel"></param>
        /// <param name="isAdmin"></param>
        /// <param name="password"></param>
        public CreateUserCommand(string name, string nickname, string email, string tel, bool isAdmin, string password)
        {
            Name = name;
            Nickname = nickname;
            Email = email;
            Tel = tel;
            IsAdmin = isAdmin;
            Password = password;
        }

        /// <summary>
        /// 用户名
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
        /// 手机号
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
    }
}