using System.Collections.Generic;
using MediatR;
// ReSharper disable MemberCanBePrivate.Global

namespace MyBlog.Api.Application.Queries
{
    public class UserQuery : IRequest<IDictionary<string, object>>
    {
        public int UserId { get; set; }
    }
}